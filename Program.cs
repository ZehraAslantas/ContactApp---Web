using ContactApp.Repositories;
using ContactApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*Burada(alt satýrda) DI çerçevesi için register kaydý yapcaz.
 ne zaman IContactRepository nesnesi enjekte edilirse o zaman InMemoryContactRepository(nesne) yi newle dedik
eðer veritabaný baðlayacak olsaydýk o zaman InMemoryContactRepository yerine
veritabaný reposunu yazardýk.yani kodlarý deðiþtirmicez*/

/*builder.Services.AddSingleton<IContactRepository,InMemoryContactRepository>();
bu yapý controller üzerinde kullanýlacak*/
//üstteki inmemory içindi bu veritabaný için eklendi alttaki

builder.Services
    .AddScoped<IContactRepository,EfContactRepository>(); 

builder.Services.AddDbContext<ContactDbContext>(options =>
{
    var connStr = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source = App_Data/contacts.db";
    options.UseSqlite(connStr);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contacts}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var dataDir = Path.Combine(app.Environment.ContentRootPath, "App_Data");
   
    Directory.CreateDirectory(dataDir); 
    var db = scope.ServiceProvider.GetRequiredService<ContactDbContext>(); 


    db.Database.Migrate(); 
    DbSeeder.Seed(db);
}
app.Run();
