using Carter;
using Streets.Api;
using Streets.Application;
using Streets.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var CnnSrings = new CnnStrings();
builder.Configuration.GetSection("ConnectionStrings").Bind(CnnSrings);
builder.Services.AddDatabaseLayer(CnnSrings.DefaultConnection);
builder.Services.AddApplicationLayer();
//
builder.Services.AddCarter();

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

app.MapCarter();
app.UseHttpsRedirection();

app.Run();
