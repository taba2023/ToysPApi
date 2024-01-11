using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToysP.Models;

namespace ToysP.Filters.ActionFilters
{
    public class Toy_ValidateUpdateToyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var toy = context.ActionArguments["toy"] as Toy;

            if (id.HasValue && toy != null && id != toy.ToyId)
            {
                context.ModelState.AddModelError("ToyId", "ToyId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }

        }
    }
}
