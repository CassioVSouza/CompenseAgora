using CompenseAgora.Components;
using CompenseAgora.Data;
using CompenseAgora.Models;
using CompenseAgora.Repositories.Interfaces;
using CompenseAgora.Repositories.Main;
using CompenseAgora.Services.Interfaces;
using CompenseAgora.Services.Main;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSqlServer<DataEFContext>(builder.Configuration.GetConnectionString("Database"));
builder.Services.AddScoped<SessionState>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileRepositorie, ProfileRepositorie>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
