var builder = WebApplication.CreateBuilder(args);

if (!File.Exists("bookmarksettings.json"))
{
    throw new SettingFileNullReferenceException();
}

builder.Configuration.AddJsonFile("bookmarksettings.json");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ResidentBookmarkContext>();

builder.Services.AddSingleton<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddSingleton<ISettingService, SettingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else if (app.Environment.IsStaging())
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Error/Staging/Error");
}
else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Error/Production/Error");
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();