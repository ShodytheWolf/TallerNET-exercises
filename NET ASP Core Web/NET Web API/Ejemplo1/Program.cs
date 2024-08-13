using Ejemplo1.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

//añadimos como Singleton el controlador de la tarea
//de esta forma no creamos un controlador nuevo por cada request a la API
builder.Services.AddSingleton<TareaController>();

//Esto también es necesario para registrar un controlador como Singleton
builder.Services.AddMvc().AddControllersAsServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
