using System;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bergle.Domain;
using Microsoft.AspNetCore.Http;

namespace Bergle.Controllers
{
    public class ExcecaoMiddleware
    {
        readonly RequestDelegate next;
        public ExcecaoMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ExcecaoDeDominio ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, ExcecaoDeDominio ex)
        {
            var code = HttpStatusCode.BadRequest;
            var mensagem = ex.Message;

            var result = JsonSerializer.Serialize(new {error = mensagem});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
    }    }
}