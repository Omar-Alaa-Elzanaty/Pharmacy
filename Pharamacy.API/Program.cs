using Microsoft.OpenApi.Models;
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


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                  new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
                }
            });
});

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
