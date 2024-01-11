using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToysP.Models.Repositories;

namespace ToysP.Filters.ActionFilters
{
    public class Toy_ValidateToyIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var toyId = context.ActionArguments["id"] as int?;
            if (toyId.HasValue)
            {
                if (toyId.Value <= 0)
                {
                    context.ModelState.AddModelError("ToyId", "ToyId is Invalid.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ToyRepository.ToyExists(toyId.Value))
                {
                    context.ModelState.AddModelError("ToyId", "ToyId doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
