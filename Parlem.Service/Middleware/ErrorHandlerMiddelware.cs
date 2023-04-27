using System.Net;
using System.Text.Json;

namespace Parlem.Service.Middleware
{
    public class ErrorHandlerMiddelware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new Aplication.Wrappers.Response<string>() { Succeeded = false, Message = error?.Message};

                switch (error)
                {
                    case Aplication.Exceptions.ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case Aplication.Exceptions.ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
                
            }
        }
    }
}
