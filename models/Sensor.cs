using System.Text.Json.Serialization;

public class Sensor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Localizacao { get; set; }

    [JsonIgnore]
    public ICollection<Leitura> Leituras { get; set; } = new List<Leitura>();
}
