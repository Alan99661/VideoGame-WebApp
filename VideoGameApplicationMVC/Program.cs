using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.CrudOperations;
using VideoGameApplication.Servises.MapConfig;
using VideoGameApplication.Servises.OtherOperations;
using Microsoft.AspNetCore.Identity;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Database.Configuring;
using VideoGameApplication.Servises.MicroServises;
using VideoGameApplication.Api.Contracts;
using VideoGameApplication.Api.Servises;
using VideoGameApplication.Servises.Contracts.SmallServices;
using VideoGameApplication.Servises.SmallServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<VideoGameDBContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<VideoGameDBContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<UserManager<User>>();
//builder.Services.AddScoped<RoleSeeder>();
builder.Services.AddAutoMapper(typeof(MapConfiguration));
builder.Services.AddScoped<IDeveloperCrudOperations, DeveloperCrudOperations>();
builder.Services.AddScoped<IGameCrudOperations, GameCrudOperations>();
builder.Services.AddScoped<IPlatformCrudOperations, PlatformCrudOperations>();
builder.Services.AddScoped<IReviewCrudOperations, ReviewCrudOperations>();
builder.Services.AddScoped<IScreenshotCrudOperations, ScreenshotCrudOperations>();
builder.Services.AddScoped<IGenreCrudOperations, GenreCrudOperations>();
builder.Services.AddScoped<IGetUpdateModels, GetUpdateModels>();
builder.Services.AddScoped<IGetSelectModels, GetSelectModels>();
builder.Services.AddScoped<IGetGameStats,GetGameStats>();
builder.Services.AddScoped<IReviewActions, ReviewActions>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IApiFetcher,ApiFetcher>();
builder.Services.AddScoped<IApiListChecker,ApiListChecker>();
builder.Services.AddScoped<ISearchEntities, SearchEntities>();
builder.Services.AddScoped<IGameSearchFilters, GameSearchFilters>();
builder.Services.AddScoped<IGameWithStatsCreator, GameWithStatsCreator>();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.LoginPath = "/Identity/Account/LogIn";
});


builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
	await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
	var user = new User() { UserName = "chadmin@gmail.com", Email = "chadmin@gmail.com"};
	var hashedPassword = userManager.PasswordHasher.HashPassword(user, "Password123+");
	user.PasswordHash = hashedPassword;
	await userManager.CreateAsync(user);
	await userManager.AddToRoleAsync(user, "Admin");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
