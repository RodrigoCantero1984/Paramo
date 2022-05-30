using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.DAO;
using Sat.Recruitment.Repository.Inteface;

namespace Sat.Recruitment.DAO
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
