using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace CleanArchitecture.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// RequestDelegate: A delegate type method which handles the request.  
        ///                  Represents any Task returning method, which has a single parameter of type HttpContext.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            const string SERVER_CAPTION = "Server Error";
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                // determine what StatusCode you wish to return
                switch (error)
                {
                    case Version1CustomException e:                        
                        response.StatusCode = (int)HttpStatusCode.BadRequest; // Version1 custom application error
                        break;
                    case KeyNotFoundException e:                        
                        response.StatusCode = (int)HttpStatusCode.NotFound; // I want to deal with KeyNotFoundException specifically - not found error
                        // perform some extra tasks before logging error!
                        break;
                    default: // all other exceptions                        
                        response.StatusCode = (int)HttpStatusCode.InternalServerError; // catch all other errors - unhandled error
                        break;
                }

                // using shared "MyLogEvents" events ID with client too
                _logger.LogError(MyLogEvents.TestItem, error, SERVER_CAPTION); // log exception & stack
                
                // return error (message) to caller
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
