using Microsoft.EntityFrameworkCore;
using ProjetWebMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services MVC
builder.Services.AddControllersWithViews();

// Configurer Entity Framework avec MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

// Configurer le pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produits}/{action=Index}/{id?}");

app.Run();