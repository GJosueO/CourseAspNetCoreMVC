using BlogCoreSolution.AccesoDatos.Data;
using BlogCoreSolution.AccesoDatos.Data.Repository;
using BlogCoreSolution.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new InvalidOperationException("Connection string 'ConexionSQL' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
// AQUI AGREGAMOS INYECCION DEL CONTENEDOR DE TRABAJAO  AL CONTENEDOR IoC(INVERSION OF CONTENT) de inyeccion de dependencias.
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>(); // PERMITE INYECTAR EL CONTENEDOR DE TRABAJO EN LOS CONTROLADORES
// EL CONTENEDOR IoC PERMITE:
// CREA OBJETOS POR NOSOTROS
// RESUELVE DEPENDENCIAS AUTOMATICAMENTE
// GESTIONA EL CICLO DE VIDA DE LOS OBJETOS
// EL ADDSCOPED NOS DICE: 
// CUANTO  TIEMPO VIVE EL OBJETO 
// SIGNIFICA QUE CREA UNA INSTANCIA POR PETICION HTTP }
// SE REUTILIZA DURANTE TODA LA PETICION / SE DESTRUYE AL FINAL DE LA PETICION
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}") //Agregamos el area de cliente para que sea la pagina de inicio y usuarios sin ningun rol definido puedan acceder a esta area
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
