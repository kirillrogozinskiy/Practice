using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� ������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� ��������� HTTP-��������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ��������� ���������
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "MarkAsWatched",
        pattern: "Watch/MarkAsWatched/{id?}",
        defaults: new { controller = "Watch", action = "MarkAsWatched" });

    endpoints.MapControllerRoute(
        name: "ByStatus",
        pattern: "Watch/ByStatus/{status?}",
        defaults: new { controller = "Watch", action = "ByStatus" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Watch}/{action=Index}/{id?}");
});

app.Run();