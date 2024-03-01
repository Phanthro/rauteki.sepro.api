using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Rauteki.Fire.Api.Misc;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        context.Result = new ObjectResult(exception.Message) { StatusCode = 500 };
        context.ExceptionHandled = true;
    }
}