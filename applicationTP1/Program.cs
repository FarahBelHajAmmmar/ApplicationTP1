var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();
//le routage par défaut
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
//Route personnalisée pour l'action ByRelease
app.MapControllerRoute(
	name: "MovieReleased",
	pattern: "{controller=Movie}/{action=ByRelease}/{annee}/{mois}"
    , defaults: new{ controller="Movie",action= "ByRelease" }) ;
//routage avec la méthode MapGet
//app.MapGet("Movie/Index", () => "Hello World!");
//routage avec endpoints
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "CustomMovieRoute",
		pattern: "Movie/{action=Index}",
		defaults: new { controller = "Movie", action = "Index" }
	);


});

app.Run();
