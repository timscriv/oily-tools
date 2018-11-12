using Microsoft.AspNetCore.Mvc.Filters;
using OilyTools.Core.Exceptions;
using System.Linq;

namespace OilyTools.Api.Filters
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new ValidationException(context.ModelState.ToDictionary(m => m.Key, m => m.Value.Errors.Select(e => e.ErrorMessage)));
            }
        }
    }
}
