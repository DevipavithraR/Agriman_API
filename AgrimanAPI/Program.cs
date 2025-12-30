using Agriman.Application.Services;
using AgrimanAPI.Application.Ports;
using AgrimanAPI.Application.Services;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositories
builder.Services.AddScoped<ITransactionThingsRepository, TransactionThingsRepository>();
builder.Services.AddScoped<ITransactionWorkDetailRepository, TransactionWorkDetailRepository>();
builder.Services.AddScoped<IMasterWorkNames, MasterWorkNameRepository>();
builder.Services.AddScoped<IMasterPacking, MasterPackingRepository>();

// Services
builder.Services.AddScoped<TransactionThingsService>();
builder.Services.AddScoped<TransactionWorkDetailService>();
builder.Services.AddScoped<MasterWorkNameService>();
builder.Services.AddScoped<MasterPackingService>();

builder.Services.AddScoped<IPackingRepository, PackingRepository>();
builder.Services.AddScoped<IPackingService, PackingService>();

// Dependency Injection
builder.Services.AddScoped<IProfitLossRepository, ProfitLossRepository>();
builder.Services.AddScoped<ProfitLossService>();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactCorsPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// ✅ CORS MUST be here
app.UseCors("ReactCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

