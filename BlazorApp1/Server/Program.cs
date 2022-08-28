using Microsoft.AspNetCore.ResponseCompression;
using BlazorApp1.Server.Service.UserService;
using BlazorApp1.Shared;
using BlazorApp1.Server.Service.UploadService;
using BlazorApp1.Server.Service.FileDBService;
using BlazorApp1.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<IAWSConfiguration, AWSConfiguration>();
builder.Services.AddSingleton<FileDBService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
