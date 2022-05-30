using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business.DTO;
using Sat.Recruitment.Business.Enum;
using Sat.Recruitment.Api.Services;
using Xunit;


namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly UserController _userController;

        public UnitTest1()
        {
            var services = new ServiceCollection();

            services.Inject();

            var serviceProvider = services.BuildServiceProvider();

            _userController = serviceProvider.GetService<UserController>();

        }

        [Fact]
        public async Task Test1()
        {


            var response = await _userController.Create(new UserDTO
            {
                Name = "rodrigo cantero",
                Email = "jb.rodrigo@gmail.com",
                Address = "lourdes 1201",
                Phone = "+549 1167512563",
                UserType = UserType.SuperUser,
                Money = 124
            });

            var okResult = response as ObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult is ObjectResult);
            Assert.IsType<UserDTO>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Test2()
        {

            await _userController.Create(new UserDTO
            {
                Name = "rodrigo cantero",
                Email = "jb.rodrigo@gmail.com",
                Address = "lourdes 1201",
                Phone = "+549 1167512563",
                UserType = UserType.SuperUser,
                Money = 124
            });

            await _userController.Create(new UserDTO
            {
                Name = "Maria de los Angeles",
                Email = "puppomaria6@gmail.com",
                Address = "Turquia 110",
                Phone = "+549 1136310865",
                UserType = UserType.Normal,
                Money = 124
            });

            var response = await _userController.Create(new UserDTO
            {
                Name = "marcelino cantero",
                Email = "rodrigo_cantero@hotmail.com",
                Address = "lourdes 1201",
                Phone = "+549 1167512563",
                UserType = UserType.Normal,
                Money = 124
            });

            var result = response as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is ObjectResult);
            Assert.IsType<List<string>>(result.Value);

            var data = (List<string>)result.Value;
            
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The user is duplicated", data[0]);

        }

        [Fact]
        public async Task Test3()
        {

            var response = await _userController.Create(new UserDTO
            {
                Email = "rodrigo_cantero@hotmail.com",
                Address = "lourdes 1201",
                Phone = "+549 1167512563",
                UserType = UserType.Normal,
                Money = 124
            });

            var result = response as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is ObjectResult);
            Assert.IsType<List<string>>(result.Value);

            var data = (List<string>)result.Value;

            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The user is duplicated", data[0]);
        }

        [Fact]
        public async Task Test4()
        {

            var response = await _userController.Create(new UserDTO
            {
                Name = "marcelino cantero",
                Address = "lourdes 1201",
                Phone = "+549 1167512563",
                UserType = UserType.Normal,
                Money = 124
            });

            var result = response as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is ObjectResult);
            Assert.IsType<List<string>>(result.Value);

            var data = (List<string>)result.Value;

            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The user is duplicated", data[0]);
        }

        [Fact]
        public async Task Test5()
        {

            var response = await _userController.Create(new UserDTO
            {
                Name = "marcelino cantero",
                Email = "rodrigo_cantero@hotmail.com",
                Phone = "+549 1167512563",
                UserType = UserType.Normal,
                Money = 124
            });

            var result = response as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result is ObjectResult);
            Assert.IsType<List<string>>(result.Value);

            var data = (List<string>)result.Value;

            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("The user is duplicated", data[0]);
        }
    }
}
