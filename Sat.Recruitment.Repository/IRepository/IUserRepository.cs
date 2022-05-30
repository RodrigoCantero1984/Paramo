using Sat.Recruitment.Domain.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository.Inteface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> CreateAsync(User user);

    }
}
