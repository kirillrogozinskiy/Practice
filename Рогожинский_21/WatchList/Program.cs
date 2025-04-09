using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WatchList.Services;

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ���������
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IWatchlistService, WatchlistService>();

var app = builder.Build();

// ��������� ��������� HTTP-��������
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
    pattern: "{controller=Watchlist}/{action=Index}/{id?}");

app.Run();