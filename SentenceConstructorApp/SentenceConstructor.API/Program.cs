using Microsoft.EntityFrameworkCore;
using SentenceConstructor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<SentenceConstructorContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SentenceConnectionString"),
               builder => builder.EnableRetryOnFailure()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();
