using SimpleRestAPI.Models;
using SimpleRestAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FilmRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/GetFilm/{id}", (int id, FilmRepository repository) =>
{
    return repository.GetFilm(id);
});

app.MapGet("/GetAllFilms", ( FilmRepository repository) =>
{
    return repository.GetAllFilms();
});

app.MapPost("/AddFilm", (Film film, FilmRepository repository) =>
{
    return repository.AddFilm(film);
});

app.MapPut("/UpdateFilm", (Film film, FilmRepository repository) =>
{
    return repository.UpdateFilm(film);
});

app.MapDelete("/DeleteFilm/{id}", (int id, FilmRepository repository) =>
{
    return repository.RemoveFilm(id);
});


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}