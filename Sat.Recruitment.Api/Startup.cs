using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business;
using Sat.Recruitment.DAO;
using Sat.Recruitment.IBusiness;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.Inteface;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Api.Services;

namespace Sat.Recruitment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddDbContext<Context>(options =>   options.UseInMemoryDatabase("test"));

            services.Inject();
            //var serviceProvider = services.BuildServiceProvider();

            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IUserBusiness, UserBusiness>();
            //services.AddTransient<UserController>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
