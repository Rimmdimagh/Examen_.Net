using AM.Infrastructure;
using Examen.Interfaces;
using Examen.Services;
using Examen.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;

var builder = WebApplication.CreateBuilder(args);


// Injection de dépendance
builder.Services.AddDbContext<DbContext, ExamContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));

//*******************

//................

builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IcategorieService, CategorieService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
