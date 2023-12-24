using System.Text;
using BusinessLogic;
using BusinessLogic.AutoMapper;
using BusinessLogic.Interfaces;
using Data.Context;
using Data.Initialisers;
using Data.Initialisers.Seed;
using Data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostOfficeContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("LocalInstance")));

builder.Services.AddValidators();
builder.Services.AddComparers();
builder.Services.AddServices();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o => o.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]))
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder => builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
    await using var context = scope.ServiceProvider.GetRequiredService<PostOfficeContext>();
    await InitialiseContextAsync(new ContextInitialiser(context, new DataSeed()));

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task InitialiseContextAsync(IInitialiser contextInitialiser)
{
    await contextInitialiser.InitialiseAsync();
}