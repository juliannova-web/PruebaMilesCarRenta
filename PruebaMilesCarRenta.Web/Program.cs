using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PruebaMilesCarRenta.Shared.Entities;
using PruebaMilesCarRenta.Web.Data;
using PruebaMilesCarRenta.Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var mySQLConfiguration = builder.Configuration.GetConnectionString("LocalConnection");

builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseMySql(mySQLConfiguration, ServerVersion.AutoDetect(mySQLConfiguration));
});

builder.Services.AddIdentity<User, IdentityRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequireDigit = false;
    cfg.Password.RequiredUniqueChars = 0;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
    cfg.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<IVehicleHelper, VehicleHelper>();
builder.Services.AddScoped<ICombosHelper, CombosHelper>();
builder.Services.AddScoped<IBookingHelper, BookingHelper>();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

SeedData(app);


void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeedDb? service = scope.ServiceProvider.GetService<SeedDb>();
        service.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
