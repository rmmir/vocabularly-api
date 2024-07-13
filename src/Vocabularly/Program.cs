using MediatR;
using Microsoft.EntityFrameworkCore;
using Vocabularly.Domain;
using Vocabularly.Features.Words.CreateWord;
using Vocabularly.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    builder.Services.AddTransient(typeof(IPipelineBehavior<CreateWordCommand, Word>), typeof(CreateWordValidator));
    builder.Services.AddTransient<IRequestHandler<CreateWordCommand, Word>, CreateWordCommandHandler>();
}

var app = builder.Build();
{
    app.MapControllers();

    DbService.InitializeMigration(app);
}

app.Run();