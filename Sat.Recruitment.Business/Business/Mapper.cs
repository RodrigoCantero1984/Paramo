using AutoMapper;
using Sat.Recruitment.Business.DTO;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.IBusiness.IDto;
using Sat.Recruitment.Business.Enum;

namespace Sat.Recruitment.Business
{
    public class Mapper
    {
        private readonly IMapper mapper;
        public Mapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>()
                   .AfterMap((src, dest) => dest.UserType = (int)src.UserType);

                cfg.CreateMap<User, UserDTO>()
                   .AfterMap((src, dest) => dest.UserType = (UserType)src.UserType);

            });

            mapper = config.CreateMapper();
        }

        public User User(IUserDTO userDTO)
        {
            return mapper.Map<User>(userDTO);
        }

        public UserDTO UserDTO(User user)
        {
            return mapper.Map<UserDTO>(user);
        }
    }
}
