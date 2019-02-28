using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using InPort.Aplication.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;

namespace InPort.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    ((ValidationException)context.Exception).Failures);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            if (!_hostingEnvironment.IsDevelopment())
            {
                context.Result = new JsonResult(new { error = new[] { context.Exception.Message } });
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    error = new[] { context.Exception.Message },
                    stackTrace = context.Exception.StackTrace
                });
            }            
        }
    }
}
