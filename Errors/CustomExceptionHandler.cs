using Microsoft.AspNetCore.Diagnostics;

namespace BoardcampApiCS.Errors;

public static class CustomExceptionHandlerExtension
{
  public static void UseCustomExceptionHandler(this WebApplication app)
  {
    app.UseExceptionHandler(appError =>
    {
      appError.Run(async context =>
      {
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<IExceptionHandlerFeature>();

        if (exception is not null)
        {
          if (exception.Error is ConflictError)
          {
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            await context.Response.WriteAsync(new ErrorDetailsViewModel()
            {
              Message = exception.Error.Message,
              StatusCode = context.Response.StatusCode
            }.ToString());
            return;
          }

          if (exception.Error is NotFoundError)
          {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(new ErrorDetailsViewModel()
            {
              Message = exception.Error.Message,
              StatusCode = context.Response.StatusCode
            }.ToString());
            return;
          }

          if (exception.Error is BadRequestError)
          {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(new ErrorDetailsViewModel()
            {
              Message = exception.Error.Message,
              StatusCode = context.Response.StatusCode
            }.ToString());
            return;
          }

          context.Response.StatusCode = 500;
          await context.Response.WriteAsync("Server Internal Error");
        }
      });
    });
  }
}