using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SputnikMVc.Context;
using SputnikMVc.Helpers;
using SputnikMVc.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var buil = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfigurationRoot configuration = buil.Build();


builder.Services.AddDbContext<MySQLContext>( options =>
{
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
});
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<YoutubeService>();
builder.Services.AddScoped<YoutubeMusicaHelper>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
