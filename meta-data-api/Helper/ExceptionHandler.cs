using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace meta_data_api.Helper;

public static class ExceptionHandler
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, NLog.Logger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.Error($"Error Occurred in MetaDataAPI ({Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} environment): {contextFeature.Error}");
                }
            });
        });
    }
}
