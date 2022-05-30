using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace Sat.Recruitment.Api.Controllers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = context.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
