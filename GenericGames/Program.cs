var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseWebRoot("wwwroot").UseStaticWebAssets();

var services = builder.Services;

// Add services to the container.
var GenericGamesConnection = builder.Configuration.GetConnectionString("GenericGamesConnection") ??
    throw new InvalidOperationException("Connection string 'GenericGamesConnection' not found.");
services.AddDbContext<GenericGamesContext>(options =>
            options.UseSqlite(GenericGamesConnection), ServiceLifetime.Transient);

services.AddDatabaseDeveloperPageExceptionFilter();
services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GenericGamesContext>();

services.AddRazorPages();
services.AddServerSideBlazor();

services
    .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

services
    .AddScoped<GenericGamesService, GenericGamesService>()
    .AddScoped<NotificationService, NotificationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
