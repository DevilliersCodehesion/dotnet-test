using System;
using System.Linq;
using dotnet_grad.Models;
using dotnet_grad.Controllers;
using dotnet_grad.Repository;
using dotnet_grad.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MediatR;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddFluentValidation(conf =>
// {
//   conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
//   conf.AutomaticValidationEnabled = false;
// });

builder.Services.AddControllers().AddFluentValidation(options =>
                {
                  // Validate child properties and root collection elements
                  options.ImplicitlyValidateChildProperties = true;
                  options.ImplicitlyValidateRootCollectionElements = true;

                  // Automatic registration of validators in assembly
                  options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestContext>();
builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddTransient<IToken, TokenRepository>();
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddAuthorization(options =>
  options.AddPolicy("admin", policy => policy.RequireRole("admin"))
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
  options.RequireHttpsMetadata = false;
  options.SaveToken = true;
  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = builder.Configuration["Jwt:Audience"],
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
  };
});

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Diff Swag", Version = "v1" });
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
  {
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JWT Authorization header using the Bearer scheme."
  });
  c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

