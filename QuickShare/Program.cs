using Microsoft.EntityFrameworkCore;
using QuickShare;
using QuickShare.Data;
using QuickShare.Services;
using QuickShare.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(connectionString));
builder.Services.AddTransient<ISpaceService, SpaceService>();
builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<SlugService>();
builder.Services.AddTransient<TestApp>();


var app = builder.Build();
// app.UseHttpsRedirection();
// app.UseRouting();
// app.Run();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

var testApp = builder.Services.BuildServiceProvider().GetService<TestApp>();

await testApp!.Start3();