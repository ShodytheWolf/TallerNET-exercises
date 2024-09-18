using BlazorLogin.Client.Pages;
using BlazorLogin.Components;
using BlazorLogin.Hubs;
using BlazorLogin.Models;
using BlazorLogin.Repositories;
using Microsoft.AspNetCore.SignalR;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

//Añadimos servicio de Razor junto con el tipo de página que vamos a usar
//web assembly en este caso
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

//añadimos los componentes de Radzen, vale aclarar que también hay que declararlo en
//App.razor
builder.Services.AddRadzenComponents();

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
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapHub<UserHub>("/loginhub");

//registramos el endpoint al que llamaremos una vez queramos que se autentiquen
app.MapGet("/Authenticate/{userId}", (string userId, IHubContext<UserHub> context) =>
{
    Console.WriteLine("Alcanzé la autenticación con contexto de userID: " + userId);

     context.Clients.Client(userId).SendAsync("AuthenticationComplete", userId);


});

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorLogin.Client._Imports).Assembly);

app.Run();
