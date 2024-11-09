using Microsoft.OpenApi.Models;
using Services;
using Services.Interfaces;
using AutoMapper;
using EstructuraDatos.Repositories;
using EstructuraDatos.Repositories.Interfaces;
using EstructuraDatos.Services;
using Profile;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost",
      builder => builder.WithOrigins("http://localhost:5173")
          .AllowAnyMethod()
          .AllowAnyHeader()
  );

});

builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IBookService, BookService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Author API",
        Version = "v1",
        Description = "API para gestionar autores"
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost"); // Asegúrate de usar el nombre correcto aquí

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();