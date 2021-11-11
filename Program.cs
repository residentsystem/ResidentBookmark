var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.SetBasePath(Directory.GetCurrentDirectory());
    config.AddJsonFile("bookmarksettings.json", optional: true, reloadOnChange: true);
})
.UseContentRoot(Directory.GetCurrentDirectory());

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ResidentBookmarkContext>();

builder.Services.AddSingleton<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddSingleton<IBookmarkService, BookmarkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else if (app.Environment.IsStaging())
{
    app.UseExceptionHandler("/Error/Staging/Error");
}
else
{
    app.UseExceptionHandler("/Error/Production/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();