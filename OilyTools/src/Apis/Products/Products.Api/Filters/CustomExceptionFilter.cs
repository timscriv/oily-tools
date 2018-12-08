using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using OilyTools.Core.Exceptions;
using Products.Core.Exceptions;
using System.Net;

namespace Products.Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            string errorMessage = "Oops! Something went wrong on our side...";
            object errors = null;

            if (context.Exception is DomainException domainException)
            {
                errorMessage = domainException.BusinessMessage;
                code = HttpStatusCode.BadRequest;
            }

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            if (context.Exception is ValidationException validationException)
            {
                errors = validationException.Failures;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new { message = errorMessage, errors});
        }
    }
}
