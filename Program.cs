using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SgbProject.Data;
using SgbProject.Models;
using SgbProject.Repositories;
using SgbProject.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
}
);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ApplicationContext>();
builder.Services.AddScoped<IRepository<Bovino>, BovinosRepository>();
builder.Services.AddScoped<IRepository<Baixa>, BaixaRepository>();
builder.Services.AddScoped<IRepository<Usuario>, UsuariosRepository>();

builder.Services.AddScoped<IBaixasServices, BaixasService>();

builder.Services.AddScoped<IBovinosService, BovinosService>(bs =>
{
    var baixaRepository = bs.GetRequiredService<IRepository<Baixa>>();
    var bovinoRepository = bs.GetRequiredService<IRepository<Bovino>>();

    return new BovinosService(baixaRepository, bovinoRepository);
});
builder.Services.AddScoped<IUsuariosService, UsuariosService>(us =>
{
    var usuariosRepository = us.GetRequiredService<IRepository<Usuario>>();
    return new UsuariosService(usuariosRepository);
});



builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer("server=.\\SQLEXPRESS;database=SGB;trusted_connection=true;Integrated Security=True;"));
//notebook//options.UseSqlServer("server=DESKTOP-DQFMKA0\\SQLEXPRESS;database=SGB;trusted_connection=true;Integrated Security=True;"));
//options.UseSqlServer("" +
//"Data Source=.;" +
//"Initial Catalog=SGB;" +
//"Integrated Security=True;" +
////"User ID=sa;Password=1234;" +
//"Connect Timeout=15;" +
//"Encrypt=False;" +
//"TrustServerCertificate=False"
//));




builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});






builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Acesso protegido utilizando o accessToken obtido em \"api/Authenticate/login\""
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
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




app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
