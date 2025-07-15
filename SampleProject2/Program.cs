using Microsoft.EntityFrameworkCore;
using SampleProject2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyRequestDbContext>(options =>
    options.UseInMemoryDatabase("MyRequests"));

//builder.Services.AddDbContext<MyRequestDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));

builder.Services.Configure<RouteOptions>(options =>
    {
        options.ConstraintMap.Add("NationalCode", typeof(NationalCodeConstraint));
    });

var app = builder.Build();

app.UseRouting();

app.UseMiddleware<MyRequestMiddleware>();

app.MapGet("/api/person/{Ncode:NationalCode}",async context=>
{
    await context.Response.WriteAsync("Ncode is valid");
});


app.Run();
