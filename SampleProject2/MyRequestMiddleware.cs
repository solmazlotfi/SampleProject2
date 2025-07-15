namespace SampleProject2
{
    public class MyRequestMiddleware
    {
        private readonly RequestDelegate _next;
        public MyRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context, MyRequestDbContext db)
        {
            if (context.Request.ContentLength > 0 && context.Request.Body.CanRead)
            {

                using var reader = new StreamReader(context.Request.Body);

                var body = await reader.ReadToEndAsync();

                var req = new MyRequest
                {
                    Path = context.Request.Path,
                    Method = context.Request.Method,
                    Body = body,
                    ReqDate = DateTime.Now
                };

                db.MyRequests.Add(req);
                await db.SaveChangesAsync();
                await context.Response.WriteAsync("1 record added");
            }

            await _next(context);
        }
    }

}