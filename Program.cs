using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DialogueDeGestion.Controllers;
using Radzen;
using System;

var builder = WebApplication.CreateBuilder(args);

//var configuration = builder.Configuration;

// Obtenir le mot de passe depuis la variable d'environnement
string dbPassword = Environment.GetEnvironmentVariable("PASSWORDMYSQL") ?? "default_password";

Console.WriteLine("Mot de passe DB récupéré: " + dbPassword);

// Remplacer le placeholder dans la chaîne de connexion par le mot de passe réel
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection").Replace("{PASSWORD}", dbPassword);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions(o =>
{
    o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
});
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// Ajouter la connexion à la base de données
/*builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
                     new MySqlServerVersion(new Version(8, 0, 21))));*/

// Ajoutez la connexion à la base de données avec la chaîne de connexion ajustée
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, 
                     new MySqlServerVersion(new Version(8, 0, 21))));


builder.Services.AddScoped<DataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();