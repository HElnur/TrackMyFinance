using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TrackMyFinance.Application;
using TrackMyFinance.Infrastructure;

var MyAllowSpecificOrigins = "_myAllowSpecifikOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:Key"])),
        ValidateIssuer = true,  // Prodüksiyon ortamında true olmalı
        ValidateAudience = true,  // Prodüksiyon ortamında true olmalı
        ValidateLifetime = true,  // Token süresi geçerli mi diye kontrol eder
        ValidateIssuerSigningKey = true  // İmza doğrulaması yapılmalı
    };
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

    var environment = builder.Services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();




    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerDoc(description.GroupName, new OpenApiInfo
        {
            Title = $"Track My Finance API: ({environment.EnvironmentName})",
            Version = description.ApiVersion.ToString(),
            Description = "Huseynov Elnur => Track My Finance API",
            Contact = new OpenApiContact
            {
                Name = "Huseynov Elnur",
                Email = "elnurhsynz@gmail.com",
            },
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Description = "JWT Autentifikasiya token daxil edin.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                       {
              {
                new OpenApiSecurityScheme
                {
                  Reference = new OpenApiReference
                    {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                  },
                  new List<string>()
                }
                  });

    }
    c.CustomSchemaIds(a => a.FullName);


}
);

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

var app = builder.Build();

app.UseSwagger();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwaggerUI(c =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
    {
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        c.RoutePrefix = string.Empty;
    }
});

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();