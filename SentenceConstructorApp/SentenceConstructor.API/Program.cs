using Microsoft.EntityFrameworkCore;
using SentenceConstructor.Core.Interfaces;
using SentenceConstructor.Core.Services;
using SentenceConstructor.Infrastructure.Data;
using SentenceConstructor.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<SentenceConstructorContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SentenceConnectionString"),
               builder => builder.EnableRetryOnFailure()));

builder.Services.AddScoped(typeof(IWordRepository), typeof(WordRepository));
builder.Services.AddScoped(typeof(ISentenceRepository), typeof(SentenceRepository));
builder.Services.AddScoped(typeof(IWordService), typeof(WordService));
builder.Services.AddScoped(typeof(ISentenceService), typeof(SentenceService));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var MyAllowSpecificOrigins = "*";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200",
                                                  "*")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SentenceConstructorContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await SentenceConstructorSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}
app.Run();
