using Pharamcy.Application.extention;
using Pharamcy.Application.Interfaces;
using Pharamcy.Infrastructure.Extention;
using Pharamcy.Presentation.Middleware;
using Pharamcy.Presistance.Extention;
using Pharamcy.Presistance.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddApplication()
                .AddInfrastructure()
                .AddPresistance(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHanlderMiddleware>();

app.UseHttpsRedirection();

var supportedCultures = new[] { "en-US", "ar-EG" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapControllers();

DataSeeding.Initialize(app.Services.CreateScope().ServiceProvider);

app.Run();
