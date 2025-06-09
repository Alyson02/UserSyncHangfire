using Hangfire;
using Microsoft.EntityFrameworkCore;
using UserSyncApp.Application.Services;
using UserSyncApp.Application.UseCases;
using UserSyncApp.Domain.Interfaces;
using UserSyncApp.Infrastructure.Peritence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddHttpClient();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserSyncService, UserSyncService>();
builder.Services.AddScoped<UserSyncJob>();

builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<UserSyncJob>(
    "sync-mock-usuarios",
    job => job.RunAsync(),
    Cron.Minutely);

app.Run();