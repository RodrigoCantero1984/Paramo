using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Business;
using Sat.Recruitment.Business.DTO;
using Sat.Recruitment.IBusiness;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : CustomeBaseController
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            try
            {
                var response = await _userBusiness.CreateAsync(userDTO);

                return ApiResponse(HttpStatusCode.OK, response);
            }
            catch (BadRequestException e)
            {
                return ApiResponse(HttpStatusCode.BadRequest, e.Errors);
            }
            catch (Exception)
            {
                return ApiResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}

