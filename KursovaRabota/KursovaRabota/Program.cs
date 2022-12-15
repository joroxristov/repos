using KursovaRabota.Repositories;
using KursovaRabota.Repositories.Abstractions;
using KursovaRabota.Repositories.Implementations;
using KursovaRabota.Services.Abstractions;
using KursovaRabota.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KursovaRabotaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Configure the HTTP request pipeline.
public class Startup
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
   // public void ConfigureServices(IServiceCollection services) 
  //  { 
   //     services.Add
   // }

}


