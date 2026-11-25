using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Teretana.Application.Uplate.Queries;
using Teretana.Data;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TeretanaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeretanaDb"))
           .EnableSensitiveDataLogging()); builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetUplateQuery).Assembly));

builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
var app = builder.Build();
if (args.Contains("--seed"))
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TeretanaDbContext>();
    await DbSeeder.SeedAsync(db);
    return;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
