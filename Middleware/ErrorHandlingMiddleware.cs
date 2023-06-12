using MyMoviesAPI.Exceptions;
using MyMoviesAPI.Models;

namespace MyMoviesAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private ServiceResponse<string> ServiceResponse(Exception ex, string message)
        {
            var response = new ServiceResponse<string>();
            response.Data = ex.Message;
            response.Success = false;
            response.Message = message;

            return response;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;

                var response = ServiceResponse(notFound, "Nie znaleziono filmu.");

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var response = ServiceResponse(ex, "Internal Server Error");

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
