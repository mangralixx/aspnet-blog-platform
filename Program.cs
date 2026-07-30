using Microsoft.EntityFrameworkCore;
using MyWebApplication.Db;
using WebApplication.Db;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Налаштування бази
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDbContext")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ініціалізація бази
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    try
    {
        // Створюємо базу та заповнюємо її
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Помилка: {ex.Message}");
    }
}

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
    pattern: "{controller=Blog}/{action=Index}/{id?}"); 

app.Run();