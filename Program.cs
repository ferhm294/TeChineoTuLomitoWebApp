using MVC_TeChineoTuLomito.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MVC_TeChineoTuLomito.Servicios.Cliente.IServicioCliente, MVC_TeChineoTuLomito.Servicios.Cliente.ServicioCliente>();
builder.Services.AddScoped<MVC_TeChineoTuLomito.Servicios.Empleado.IServicioEmpleado, MVC_TeChineoTuLomito.Servicios.Empleado.ServicioEmpleado>();
builder.Services.AddScoped<MVC_TeChineoTuLomito.Servicios.Mascota.IServicioMascota, MVC_TeChineoTuLomito.Servicios.Mascota.ServicioMascota>();
builder.Services.AddScoped<MVC_TeChineoTuLomito.Servicios.ProcedimientoAplicado.IServicioProcedimientoAplicado, MVC_TeChineoTuLomito.Servicios.ProcedimientoAplicado.ServicioProcedimientoAplicado>();
builder.Services.AddScoped<MVC_TeChineoTuLomito.Servicios.Procedimiento.IServicioProcedimiento, MVC_TeChineoTuLomito.Servicios.Procedimiento.ServicioProcedimiento>();
builder.Services.AddScoped<MVC_TeChineoTuLomito.Servicios.ReporteVacunacion.IServicioReporteVacunacion, MVC_TeChineoTuLomito.Servicios.ReporteVacunacion.ServicioReporteVacunacion>();


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
