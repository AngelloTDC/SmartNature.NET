using Microsoft.EntityFrameworkCore;
using SmartNature.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SmartNatureDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\v11.0;Database=SmartNatureDB;Trusted_Connection=True;"));

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SmartNatureDbContext>();


    context.Database.Migrate();

    if (!context.Sensores.Any())
    {
        var sensor = new Sensor
        {
            Nome = "Sensor Central",
            Localizacao = "Parque Ibirapuera",
            Leituras = new List<Leitura>
        {
            new Leitura { DataHora = DateTime.Now, Temperatura = 35.4, Umidade = 40, Fumaca = 5 },
            new Leitura { DataHora = DateTime.Now.AddMinutes(-10), Temperatura = 34.7, Umidade = 42, Fumaca = 7 }
        }
        };

        context.Sensores.Add(sensor);
        context.SaveChanges();
    }

}

app.Run();
