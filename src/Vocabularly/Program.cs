using Vocabularly.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<WordsService>();
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();