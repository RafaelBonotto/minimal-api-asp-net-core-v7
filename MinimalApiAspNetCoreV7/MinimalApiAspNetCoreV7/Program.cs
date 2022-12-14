using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("filtro", (string param) =>
{
    return $"{param}";
})
.AddEndpointFilter(async (context, next) =>
{
    if (context.HttpContext.Request.QueryString.Value.Contains("null"))
        return Results.BadRequest();

    return await next(context);
});



app.UseHttpsRedirection();

app.Run();