namespace GestionDeTareasApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                var response = new
                {
                    Error = "Id not found",
                    stackTrace = ex.StackTrace
                };
                await context.Response.WriteAsJsonAsync(response);
            } 
        }
    }
}
