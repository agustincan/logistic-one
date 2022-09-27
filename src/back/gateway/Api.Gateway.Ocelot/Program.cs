using Microsoft.AspNetCore.Cors.Infrastructure;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddOcelot();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
    );
});

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

//app.UseAuthorization();

//app.MapControllers();
app.UseCors(opt => opt.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
               );
app.UseHttpsRedirection();
app.UseOcelot().Wait();
app.Run();
