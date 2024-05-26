using desafio_backend.Communication.Response.Error;
using desafio_backend.Exception;
using desafio_backend.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace desafio_backend.API.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DesafioBackendException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    #region Private methods
    private void HandleProjectException(ExceptionContext context)
    {
        var exception = (DesafioBackendException)context.Exception;
        var errorResponse = new ResponseErrorJson(exception.GetErrors());

        context.HttpContext.Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessage.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }

    #endregion Private methods
}
