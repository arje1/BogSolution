using BogAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BogAPI.Extensions
{
    public static class MiddlwareExtensions
    {

        public static void UseBogApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var Error = context.Features.Get<IExceptionHandlerFeature>();
                    var CurrentException = Error.Error;
                    var BogApiException = CurrentException as BogApiException;

                    ErrorModel ErrorModel = new ErrorModel();
                    if (BogApiException == null)
                    {
                        ErrorModel.Message = $"Internal Server Error";
                        ErrorModel.ErrorCode = StatusCodes.Status500InternalServerError;
                    }
                    else
                    {
                        ErrorModel = BogApiException.ErrorModel;
                    }

                    //TODO: log CurrentException in DB

                    context.Response.StatusCode = ErrorModel.ErrorCode;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(ErrorModel));
                });

            });

        }



    }
}
