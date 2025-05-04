using FCG.Infrastructure;
using FCG.Infrastructure.Repository;
using FCG.Infrastructure.Repository.Helpers;
using FCG.Interfaces;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

builder.Services.AddControllers();

#region [Swagger]

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Fiap Cloud Games (FCG)", 
        Description = "Plataforma de venda de jogos digitais e gestão de servidores para partidas online. Grupo Tech Challenge 8NETT.",
        Contact = new OpenApiContact()
        {
            Name = "rm363924", Email = "wilson.carvalhais@gmail.com"
        },
        License = new OpenApiLicense() 
        { 
            Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") 
        },
        Version = "Fase 1" });
    
        var xmlFile = "FCG.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
});

#endregion

#region [JWT]

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});

#endregion

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings"));
}, ServiceLifetime.Scoped);

#region [DI]

builder.Services.AddTransient(typeof(BaseLogger<>));
builder.Services.AddScoped<CriptografiaHelper>();
builder.Services.AddScoped<TextoHelper>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
