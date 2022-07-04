using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using thegame.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddMvc();
builder.Services.AddScoped<IGameGenerator, GameGenerator>();
builder.Services.AddSingleton<IGameRepository, GamesRepository>();
builder.Services.AddScoped<IGameChanger, GameChanger>();
builder.Services.AddScoped<IAI, AI>();


var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Use((context, next) =>
{
    context.Request.Path = "/index.html";
    return next();
});
app.UseStaticFiles();

app.Run();