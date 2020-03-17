using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ControlSystem.WebApi.Device.AWS.Infrastructure.Validation
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //if (actionContext.ActionArguments.Any(kv => kv.Value == null))
            //{
            //    throw new BadRequestException("Please provide payload");
            //}

            //if (!actionContext.ModelState.IsValid)
            //{
            //    throw new BadRequestException(string.Join(Environment.NewLine, actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(e => !string.IsNullOrWhiteSpace(e.ErrorMessage) ? e.ErrorMessage :
            //        e.Exception.Message)));
            //}
        }
    }
}
