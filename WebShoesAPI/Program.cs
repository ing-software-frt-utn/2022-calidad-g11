using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using System.Reflection;
using System.Text;
using WebControlShoes.Application.Contratos;
using WebControlShoes.Application.Servicios;
using WebControlShoes.Domain.Entities;
using WebControlShoes.Domain.Repository;
using WebControlShoes.Infastructure;
using WebControlShoes.Infastructure.Repositories;
using Zapatillas.Domain.Entities;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
//builder.Services.AddScoped<IAppContext, AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(
    options =>  options.UseLazyLoadingProxies().UseSqlServer(connectionString)

    
);


builder.Services.AddHttpClient();
string MiCors = "MiCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
                        builder =>
                        {
                            builder.WithOrigins("*");
                        }
        );
});



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.RE

#region  REPOSITORIES
builder.Services.AddScoped< IRepository<Colour>, MyRepository<Colour> >();
builder.Services.AddScoped< IRepository<Defecto>, MyRepository<Defecto> >();
builder.Services.AddScoped< IRepository<Modelo>, MyRepository<Modelo> >();
builder.Services.AddScoped< IRepository<OrdenProduccion>, MyRepository<OrdenProduccion> >();
builder.Services.AddScoped< IRepository<LineaProduccion>, MyRepository<LineaProduccion> >();
builder.Services.AddScoped< IRepository<Usuario>, MyRepository<Usuario> >();
builder.Services.AddScoped< IRepository<SupervisorLinea>, MyRepository<SupervisorLinea> >();
builder.Services.AddScoped< IRepository<JornadaLaboral>, MyRepository<JornadaLaboral> >();
#endregion

#region  SERVICIOS DE APLICACION

builder.Services.AddScoped< IColorService,ColorServices>();
builder.Services.AddScoped< IModelService,ModelServices>();
builder.Services.AddScoped< ILineaService,LineaServices>();
builder.Services.AddScoped<IOrdenProduccionService, OrdenProduccionService>();
builder.Services.AddScoped<IInspeccionarService, InspeccionarCalzadoService>();

#endregion


//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
});

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(MiCors);

app.MapControllers();

app.Run();
