using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudyAbroadApi.Data;
using StudyAbroadApi.Endpoints;
using StudyAbroadApi.Repositories;
using StudyAbroadApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = builder.Configuration["Jwt:Issuer"],
            ValidAudience            = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey         = new SymmetricSecurityKey(
                                           Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddValidation();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddGameStoreDb();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapAuthEndpoints();
app.MapStudyAbroadEndpoints();
app.MigrateDb();
app.Run();