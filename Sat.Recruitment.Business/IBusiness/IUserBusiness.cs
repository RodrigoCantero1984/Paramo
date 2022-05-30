using Sat.Recruitment.IBusiness.IDto;
using System.Threading.Tasks;

namespace Sat.Recruitment.IBusiness
{
    public interface IUserBusiness
    {
        Task<IUserDTO> CreateAsync(IUserDTO user);

        decimal CalculateAmount(IUserDTO userDTO);
    }
}
