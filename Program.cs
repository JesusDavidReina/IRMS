using IRMS.Context;
using IRMS.Repositorios;
using IRMS.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContextIRMS>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region repositorios
builder.Services.AddScoped<IClimaRepositorio, ClimaRepositorio>();
builder.Services.AddScoped<ICultivoRepositorio, CultivoRepositorio>();
builder.Services.AddScoped<IJugadorRepositorio, JugadorRepositorio>();
builder.Services.AddScoped<IGranjaRepositorio, GranjaRepositorio>();
builder.Services.AddScoped<IPartidaRepositorio, PartidaRepositorio>();
builder.Services.AddScoped<IDispositivoRepositorio, DispositivoRepositorio>();
builder.Services.AddScoped<ITipoDispositivoRepositorio, TipoDispositivoRepositorio>();
builder.Services.AddScoped<IAccionRepositorio, AccionRepositorio>();
#endregion

#region servicios
builder.Services.AddScoped<IClimaServicio, ClimaServicio>();
builder.Services.AddScoped<ICultivoServicio, CultivoServicio>();
builder.Services.AddScoped<IJugadorServicio, JugadorServicio>();
builder.Services.AddScoped<IGranjaServicio, GranjaServicio>();
builder.Services.AddScoped<IPartidaServicio, PartidaServicio>();
builder.Services.AddScoped<IDispositivoServicio, DispositivoServicio>();
builder.Services.AddScoped<ITipoDispositivoServicio, TipoDispositivoServicio>();
builder.Services.AddScoped<IAccionServicio, AccioServicio>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
