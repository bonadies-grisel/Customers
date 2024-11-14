#region Usings
using Microsoft.AspNetCore.Http;
using knowledge.common.entities.Types.Enums;
using knowledge.common.interfaces.IServices;
#endregion

namespace knowledge.common.middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITracerService tracerService)
        {
            try 
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string nameSpace = ex.TargetSite?.DeclaringType?.Namespace ?? "UnknownNamespace";
                await tracerService.ExceptionAsync(ApplicationModule.Api, nameSpace, ex);
            }
        }
    }
}
