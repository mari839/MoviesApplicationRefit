using MoviesApplicationRefit.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var authToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwZTAyYjhiYmZhZDlmMTkwOWQ1MGU4OTI1YzQ3ZTI3MiIsIm5iZiI6MTcyMTYzODE0Mi40MTc5NzEsInN1YiI6IjY2OWUxNmYzYmRhNjZiMDYwZGE4OGZlYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.amnJzF6tWfFl6I_TiSdpiF-EF58_XSDBrJRQPIqxgBI"; //static token
var refitSettings = new RefitSettings()
{
    AuthorizationHeaderValueGetter = (rq, ct) => Task.FromResult(authToken),
};

builder.Services
    .AddRefitClient<ITmdbApi>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"));

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
