using ePizza.Models.Responses;
using System.Text.Json;

namespace ePizza.API.Middlewares
{
    public class CommonResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public CommonResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {                                                                       
                try
                {
                    await _next(context);

                    if (context.Response.ContentType != null && context.Response.ContentType.Contains("application/json"))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

                        var responseObj = new ApiResponseModel<object>(
                            
                            success: context.Response.StatusCode >=200 && context.Response.StatusCode <= 300,
                            data: JsonSerializer.Deserialize<object>(responseBody)!,
                            message : "Request Completed Successfully"
                            );

                        var jsonResponse = JsonSerializer.Serialize(responseObj);
                        context.Response.Body = originalBodyStream;
                        await context.Response.WriteAsync(jsonResponse);
                    }

                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 500;
                    var errorResponse = new
                    {
                        success = false,
                        data = (object)null,
                        message = ex.Message
                    };
                    var jsonResponse = JsonSerializer.Serialize(errorResponse);
                    context.Response.Body = originalBodyStream;
                    await context.Response.WriteAsync(jsonResponse);
                }
            }

        }

    }
}
