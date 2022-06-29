using Application.Extensions;
using Application.HangfireMail;
using Infrastructure.Persistence.Extensions;
using GiveOfferAPI.Infrastructure.ActionFilters;
using GiveOfferAPI.Infrastructure.Extensions;
using GiveOfferAPI.HangfireDb;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HangfireDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));
builder.Services.AddHangfire(c => c.UseSqlServerStorage(builder.Configuration.GetConnectionString("myconn")));
GlobalConfiguration.Configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("myconn")).
    WithJobExpirationTimeout(TimeSpan.FromDays(7));

builder.Services
    .AddControllers(opt => opt.Filters.Add<ValidateModelStateFilter>())
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    .AddFluentValidation()
        .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

builder.Services.AddApplicationRegistration();
builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);

// Add Cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

Mail mail = new Mail();
app.UseHangfireDashboard("/myJobDashboard");
RecurringJob.AddOrUpdate("Send Mail : Runs Every 2 Second", () => mail.SendEmail(), builder.Configuration["CronTime"]);

app.UseHttpsRedirection();

app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();