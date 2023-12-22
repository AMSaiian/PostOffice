using BusinessLogic.AutoMapper;
using Data.Context;
using Data.Initialisers;
using Data.Initialisers.Seed;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task InitialiseContextAsync(IInitialiser contextInitialiser)
{
    await contextInitialiser.InitialiseAsync();
}