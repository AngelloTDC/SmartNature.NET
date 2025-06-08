public class Leitura
{
    public int Id { get; set; }
    public double Temperatura { get; set; }
    public double Umidade { get; set; }
    public double Fumaca { get; set; }
    public DateTime DataHora { get; set; }

    public int SensorId { get; set; }
    public Sensor Sensor { get; set; }
}
