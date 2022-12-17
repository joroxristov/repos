using KursovaRabota.Repositories;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Repositories.Implementations;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<KursovaRabotaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<KursovaRabotaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<ICarSupplierRepository, CarSupplierRepository>();
builder.Services.AddScoped<ICarsService, CarsService>();
builder.Services.AddScoped<ICar_CarSupplierRepository,Car_CarSupplierRepository>();
builder.Services.AddScoped<ICarSupplierService, CarSupplierService>();
builder.Services.AddScoped<IBrandsRepository, BrandsRepository>();
builder.Services.AddScoped<IBrandsService, BrandsService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<KursovaRabotaDbContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cars}/{action=AllCars}/{id?}");

app.Run();
/*public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, KursovaRabotaDbContext context)
    {

        if (env.IsDevelopment())
        {
            context.Database.Migrate();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


    }
*/
// public void ConfigureServices(IServiceCollection services) 
//  { 
//     services.Add
// }

//

