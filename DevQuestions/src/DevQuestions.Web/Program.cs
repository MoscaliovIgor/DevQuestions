var builder = WebApplication.CreateBuilder(args);

 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Course Web API"));
}

app.MapControllers();

app.Run();