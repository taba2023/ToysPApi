using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToysP.Models.Repositories;

namespace ToysP.Filters.ExceptionFilters
{
    public class Toy_HandleUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strToyId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strToyId, out int ToyId)) 
            {
                if (!ToyRepository.ToyExists(ToyId))
                {
                    context.ModelState.AddModelError("ToyId", "Toy doesn't exist anymore.");
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
