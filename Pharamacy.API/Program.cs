using Pharamcy.Application.extention;
using Pharamcy.Infrastructure.Extention;
using Pharamcy.Presentation.Middleware;
using Pharamcy.Presistance.Extention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure()
                .AddApplication()
                .AddPresistance();

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

var supportedCultures = new[] { "en-US", "ar-EG", "de-DE" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapControllers();

app.Run();
