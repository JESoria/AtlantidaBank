using AtlantidaBankAPI.Models.Configurations;
using Microsoft.AspNetCore.Diagnostics;
using NLog;

namespace AtlantidaBankAPI
{
    public static class ServiceExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            context.Response.ContentType = "aplication/json";
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex is not null)
                            {
                                var logger = LogManager.GetCurrentClassLogger();
                                logger.Error("Hubo un error al procesar la solicitud. Error: " + ex.Error.Message + " Detalle Error: " + ex.Error.InnerException);

                                await context.Response.WriteAsync(new Error()
                                {
                                    StatusCode = context.Response.StatusCode,
                                    Message = "Hubo un error al procesar la solicitud. Error: " + ex.Error.Message + " Detalle Error: " + ex.Error.InnerException
                                }.ToString());
                            }
                        }
                    );
                }
                );
        }
    }
}
