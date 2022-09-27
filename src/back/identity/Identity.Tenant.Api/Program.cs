using Common.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Text;
using MediatR;
using Identity.Persistence.Database.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Identity.Services.Queries;
using Common.Core.Multitenancy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Database
builder.Services.AddDbContext<AppDbContextTenant>(options =>
               //options.UseSqlServer(
               //    Configuration.GetConnectionString("DefaultConnection"),
               //    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog")
               //)
               options.UseNpgsql(builder.Configuration.GetConnectionString("CnnPg1")
               //opt => opt.MigrationsHistoryTable("__EFMigrationsHistory", "Transport")
               )
            );


// Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<AppDbContextTenant>()
    .AddDefaultTokenProviders();

// Identity configuration
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 1;
});

// Add Authentication
var secretKey = Encoding.ASCII.GetBytes(
    builder.Configuration.GetValue<string>("SecretKey")
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Query services
builder.Services.AddScoped<IUserQueryTenantService, UserQueryTenantService>();
//builder.Services.AddScoped<ITenantService, TenantService>();
// cqrs
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.Load("Identity.Services.EvenHandlers"));


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

app.UseAuthorization();

app.MapControllers();

app.Run();
