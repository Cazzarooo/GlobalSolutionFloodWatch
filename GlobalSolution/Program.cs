using Microsoft.EntityFrameworkCore;
using GlobalSolution.Models;
using GlobalSolution.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM98660;Password=230505;");
});

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IAutenticacaoRepository, AutenticacaoRepository>();
builder.Services.AddTransient<IAplicativoRepository, AplicativoRepository>();
builder.Services.AddTransient<ISistemaAlertaRepository, SistemaAlertaRepository>();
builder.Services.AddTransient<ISensorRepository, SensorRepository>();
builder.Services.AddTransient<IHistoricoRepository, HistoricoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();