using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;

namespace RealEstateAgency.API.Infrastructure
{
    public class ValidateModelStateFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,actionContext.ModelState);
            }
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.ActionContext.ModelState.IsValid)
            {
                actionExecutedContext.ActionContext.Response = actionExecutedContext.ActionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.ActionContext.ModelState);
            }
        }

    }
}