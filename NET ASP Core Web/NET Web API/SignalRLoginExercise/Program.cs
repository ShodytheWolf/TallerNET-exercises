using SignalRLoginExercise.Hubs;
using SignalRLoginExercise.Models;
using SignalRLoginExercise.Repositories;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//configuramos la dependencia de SignalR instalada por NuGet
//además de pedirle que nos avise de los errores en el lado del cliente
//ESTO SOLO DEBERÍA HACERSE EN PRODUCCIÓN!!!
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//registramos el Hub que vamos a utilizar para loggear al usuario
app.MapHub<UserHub>("/login");


//registramos el endpoint al que llamaremos una vez queramos que se autentiquen
app.MapGet("/Authenticate/{userId}", (string userId, IHubContext<UserHub> context) =>
{
    Console.WriteLine("Alcanzé la autenticación con contexto de userID: " + userId);
    
    context.Clients.Client(userId).SendAsync("AuthenticationComplete", userId);


});

    //app.MapGet("/", () => "Hello World!");
app.Run();
