using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Inyección de dependencias
builder.Services.AddTransient<ReservasCanchasUdlaContext>();
builder.Services.AddTransient<IAuthService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Carga de las variables de entorno desde archivo .env
DotNetEnv.Env.Load();

// Contexto de la base de datos
builder.Services.AddDbContext<ReservasCanchasUdlaContext>(options
    => options.UseSqlServer(DotNetEnv.Env.GetString("CADENA_CONEXION")));

// Agregar el servicio Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        // Consideraciones que debe tener Identity

        // Requisitos de contraseña

        options.Password.RequiredUniqueChars = 1;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 8;

        // Requisitos SingIn
        // ??? options.SignIn.RequireConfirmedEmail = true;

    }
    )
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ReservasCanchasUdlaContext>()
    .AddDefaultTokenProviders();

// Configuración de la autenticación y tokens
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("ISSUER"),
        ValidAudience = Environment.GetEnvironmentVariable("AUDIENCE"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("KEY")))
};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Se agrega autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Definición de roles
// Verifica que los roles existan, de lo contrario, los crea
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Seed un admin role
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string adminEmail = "admin@admin.com";
    string password = "1q2w3e4R@";

    if(await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var user = new Usuario
        {
            Email = adminEmail,
            UserName = adminEmail
        };

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
    
}

app.Run();
