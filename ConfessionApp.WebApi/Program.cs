using ConfessionApp.Application.Interfaces;
using ConfessionApp.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);
var vercelUrl = builder.Configuration["VercelFrontendUrl"];
var corsPolicyName = "AllowVercelFrontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        policy =>
        {
            if (!string.IsNullOrEmpty(vercelUrl))
            {
                policy.WithOrigins(vercelUrl)
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
            else
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
        });
});

builder.Services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();