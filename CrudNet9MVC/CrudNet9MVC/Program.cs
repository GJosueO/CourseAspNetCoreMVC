//ESTE FUE CREADO Y ES APPLICATIONDB CONTENXT
using CrudNet9MVC.Data;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);
//CONFIGURACION DE DB contenedor de dependencias
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"))); //UTILIZADO EN TODA LA APP

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
