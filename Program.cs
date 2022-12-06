using LeBonCoin_Toulouse.Repositories;
using LeBonCoin_Toulouse.Services;
using LeBonCoin_Toulouse.Services.Interfaces;
using LeBonCoin_Toulouse.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddScoped<UserAppRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<ArticleRepository>();
builder.Services.AddScoped<ImageRepository>();
builder.Services.AddScoped<ILogin, LoginJwtService>();

builder.Services.AddAuthentication(a =>
{    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters()
   {
       ValidateIssuerSigningKey = true,
       ValidateIssuer = true,
       ValidIssuer = "sogeti",
       ValidateLifetime = true,
       ValidateAudience = true,
       ValidAudience = "sogeti",
       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la clé de sécurité pour générer la JWT")),

   });
builder.Services.AddAuthorization((builder) =>
{
    builder.AddPolicy("admin", options => { options.RequireRole("admin"); }); builder.AddPolicy("user", options => { options.RequireRole("admin", "user"); });
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
