using Microsoft.AspNetCore.Mvc.Filters;
using ToysP.Models.Repositories;
using ToysP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToysP.Filters.ActionFilters
{
    public class Toy_ValidateCreateToyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var toy = context.ActionArguments["toy"] as Toy;

            if (toy == null)
            {
                context.ModelState.AddModelError("Toy", "Toy object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingToy = ToyRepository.GetToyByProperties(toy.Name, toy.Gender, toy.Age);
                if (existingToy != null)
                {
                    context.ModelState.AddModelError("Toy", "Toy already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }


        }
    }

}
