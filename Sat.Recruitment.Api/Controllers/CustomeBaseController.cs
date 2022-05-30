using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace Sat.Recruitment.Api.Controllers
{
    public class CustomeBaseController : ControllerBase
    {
        public ObjectResult ApiResponse(HttpStatusCode httpStatusCode, object content = null)
        {
            return StatusCode((int)httpStatusCode, content);
        }
    }
}
