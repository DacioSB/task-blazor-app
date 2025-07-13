using CompleteProject.Data;
using CompleteProject.Services;
using CompleteProject.ViewModels;
using CompleteProject; // Ensure this is the correct namespace for the App class
using Radzen;
using CompleteProject.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=/home/docitu/Documents/csharp/blazor_complete_project/CompleteProject/Data/todo.db"));
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<IBugRepository, BugRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IBugService, BugService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<BugListViewModel>();
builder.Services.AddScoped<FeatureListViewModel>();
builder.Services.AddScoped<AzurePhotoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();