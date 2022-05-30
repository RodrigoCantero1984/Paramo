using Sat.Recruitment.IBusiness;
using Sat.Recruitment.IBusiness.IDto;
using Sat.Recruitment.Business.Enum;
using Sat.Recruitment.Repository.Inteface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business

{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly Mapper _userMapper;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userMapper = new Mapper();
        }

        public async Task<IUserDTO> CreateAsync(IUserDTO userDTO)
        {
            userDTO.Email = userDTO.Email.NormalizeEmail();
            userDTO.Money = CalculateAmount(userDTO);

            var exist = _userRepository.Exist(x => (x.Email == userDTO.Email || x.Phone == userDTO.Phone)
                                       || (x.Name == userDTO.Name && x.Address == userDTO.Address));

            if (exist)
                throw new BadRequestException(new List<string> { "The user is duplicated" });

            var user = _userMapper.User(userDTO);

            user = await _userRepository.CreateAsync(user);

            return _userMapper.UserDTO(user);
        }

        public decimal CalculateAmount(IUserDTO userDTO)
        {
            switch (userDTO.UserType)
            {
                case UserType.Normal:

                    if (userDTO.Money > 100)
                        return (userDTO.Money * 0.20m) + userDTO.Money;
                    else if (userDTO.Money > 10 && userDTO.Money < 100)
                        return (userDTO.Money * 0.80m) + userDTO.Money;
                    break;
                case UserType.SuperUser:

                    if (userDTO.Money > 100)
                        return (userDTO.Money * 0.20m) + userDTO.Money;
                    break;
                case Enum.UserType.Premium:

                    if (userDTO.Money > 100)
                        return (userDTO.Money * 2) + userDTO.Money;
                    break;
                default:
                    return userDTO.Money;
            }
            return userDTO.Money;
        }
    }

}
