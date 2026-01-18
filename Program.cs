var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

//add below code and observer output  
//starts
app.Use(async (context, next) =>
{
    Console.WriteLine("Incoming request: " + context.Request.Path);
    await next();
    Console.WriteLine("Outgoing response");
});
//end

app.UseAuthorization();

app.MapControllers();

app.Run();
