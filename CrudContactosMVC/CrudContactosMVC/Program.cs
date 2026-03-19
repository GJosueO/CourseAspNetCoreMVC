using CrudContactosMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Leer cadena de conexion 1er paso creacion de conexion.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar DbContext para inyeccion de dependencias 2do paso configuracion de inyeccion de dependencias
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer( 
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
); // scoped actua de esa manera y esta disponible para toda la aplicacion, lo cual es recomendable solo utilizar una sola.

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"))); //UTILIZADO EN TODA LA APP
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
