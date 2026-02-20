using DBEntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddAuthorization();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("DataSource=TodoList.db");
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// --User Endpoints--
app.MapRegisterEndpoints();
app.MapLoginEndpoints();
// --Todo Endpoints--
app.MapItemEndpoints();
// --Admin Endpoints--
app.MapAdminEndpoints();

app.Run();
