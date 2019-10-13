using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SoftwareHutPreview.Application.Infrastructure.Exceptions;

namespace SoftwareHutPreview.Application.Infrastructure
{
    public class ExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = GetErrorCode(context.Exception.GetType());
            string errorMessage = context.Exception.Message;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int) statusCode;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new
            {
                message = errorMessage,
                errorCode = statusCode
            });

            response.ContentLength = result.Length;
            response.WriteAsync(result);
        }

        private HttpStatusCode GetErrorCode(Type getType)
        {
            if (getType == typeof(NotImplementedException))
            {
                return HttpStatusCode.NotImplemented;
            }
            if (getType == typeof(NotFoundException))
            {
                return HttpStatusCode.NotFound;
            }
            if (getType == typeof(InvalidOperationException))
            {
                return HttpStatusCode.NotFound;
            }
            return HttpStatusCode.InternalServerError;
        }
    }
}
