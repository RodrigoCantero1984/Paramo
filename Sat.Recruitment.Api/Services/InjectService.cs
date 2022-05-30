using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business;
using Sat.Recruitment.DAO;
using Sat.Recruitment.IBusiness;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.Inteface;

namespace Sat.Recruitment.Api.Services
{
    public static class InjectService
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
               options.UseInMemoryDatabase("test"));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<UserController>();
        }
    }
}
