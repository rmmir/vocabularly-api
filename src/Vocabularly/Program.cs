using Microsoft.EntityFrameworkCore;

using Vocabularly.Persistence;
using Vocabularly.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<WordsService>();
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
}

var app = builder.Build();
{
    app.MapControllers();

    DbService.InitializeMigration(app);
}

app.Run();