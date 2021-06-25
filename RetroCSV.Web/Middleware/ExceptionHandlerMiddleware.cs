using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RetroCSV.Core.Exceptions;
using RetroCSV.Core.Responses;

namespace RetroCSV_Clean_Architecture.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDictionary<Type, Func<HttpContext,Exception,Task>> _exceptionHandlers;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _exceptionHandlers = new Dictionary<Type, Func<HttpContext,Exception,Task>>
            {   //register known exceptions with their method handlers
                { typeof(ValidationException), HandleValidationException },
                { typeof(DuplicateColumnException), HandleDuplicateColumnException },
                { typeof(NotFoundException), HandleNotFoundException}
            };
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var type = exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
               return _exceptionHandlers[type].Invoke(context,exception);
            }
           
            return HandleUnknownException(context, exception);
        }
        private Task HandleValidationException(HttpContext context, Exception exception)
        {
            var error=exception as ValidationException;
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var response = new BaseResponse<IDictionary<string,string[]>>
            {
                Success = false,
                Message = "An Validation exception has occurred",
                Errors =  new List<IDictionary<string, string[]>>{error.Errors}
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private Task HandleUnknownException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new BaseResponse<string>
            {
                Success = false,
                Message = "An unknown exception has occurred",
                Errors = new List<string>{exception.Message+". "+exception.InnerException?.Message}
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response)); 
        }

        private Task HandleDuplicateColumnException(HttpContext context,Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var response = new BaseResponse<string>
            {
                Success = false,
                Message = "An application exception has occurred",
                Errors = new List<string>{exception.Message}
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        
        private Task HandleNotFoundException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            var response = new BaseResponse<string>
            {
                Success = false,
                Message = "An application exception has occurred",
                Errors = new List<string>{exception.Message}
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
    
    
    
}
