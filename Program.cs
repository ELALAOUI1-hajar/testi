using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using testi.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
 
var builder = WebApplication.CreateBuilder(args);

// Configuration de la base de données
builder.Services.AddDbContext<CandidatContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration des fichiers statiques (wwwroot)
var env = builder.Environment;
var webRoot = env.WebRootPath;







var fileProvider = new PhysicalFileProvider(webRoot);
builder.Services.AddSingleton<IFileProvider>(fileProvider);


var cvUploadsPath = Path.Combine(webRoot, "CvUploads");
if (!Directory.Exists(cvUploadsPath))
{
    Directory.CreateDirectory(cvUploadsPath);
}

// Configuration des contrôleurs avec vues
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // Middleware pour le gestionnaire d'exceptions en mode non développement
    app.UseExceptionHandler("/Home/Error");
    // HSTS (Strict-Transport-Security) pour améliorer la sécurité
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirection automatique HTTP vers HTTPS
app.UseStaticFiles(); // Activation du middleware pour servir des fichiers statiques
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(cvUploadsPath),
    RequestPath = new PathString("/CvUploads")
});

app.UseRouting();

// Activation de l'authentification
app.UseAuthentication();
// Activation de l'autorisation
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
