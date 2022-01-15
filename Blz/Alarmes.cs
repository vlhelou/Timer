namespace Blz;
public class Alarmes
{
    public string Nome { get; set; } = string.Empty;
    public int Duracao { get; set; }
    public int ProximaExecucao { get; set; }
    public int Remanescente { get; set; }

    public bool Ativo { get; set; } = true;

}
