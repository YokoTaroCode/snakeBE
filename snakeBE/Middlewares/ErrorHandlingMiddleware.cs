using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace A_snakeBE.Middlewares
{
    public class ErrorHandlingMiddleware : IExceptionHandler
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception e, CancellationToken ct)
        {
            _logger.LogError(e, "Eccezione catturata: {Message}", e.Message);

            var problemDetails = e switch
            {
                KeyNotFoundException => new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Risorsa non trovata",
                    Detail = e.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                },

                OperationCanceledException or TaskCanceledException => new ProblemDetails
                {
                    Status = 499, // Client Closed Request
                    Title = "Richiesta annullata",
                    Detail = "L'operazione è stata interrotta dall'utente o dalla chiusura della connessione.",
                    Type = "https://httpstatuses.com/499"
                },

                ArgumentException => new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Richiesta non valida",
                    Detail = e.Message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                },

                _ => new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Errore del Server",
                    Detail = "Si è verificato un errore imprevisto.",
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                }
            };

            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, ct);

            return true;
        }
    }
}