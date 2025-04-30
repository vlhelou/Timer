

using GuerrillaNtp;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;
using System.Timers;

namespace WinTimer;

public partial class Form1 : Form
{
    System.Timers.Timer ct = new() { Interval = 1000 };
    DateTime ProximaExecucao = new DateTime();
    DateTime ultimaExecucao = DateTime.Now;


    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Alarme.wav");

    delegate void SetTextCallback(string texto);

    public Form1()
    {

        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        ct.Enabled = true;
        ct.Start();
        ct.Elapsed += MostraTempo;
        btnAutomatico_Click(null, null);

    }


    private void MostraTempo(Object source, ElapsedEventArgs e)
    {
        if (btnAcao.Text == "Para")
        {
            if (lbFalta.InvokeRequired)
            {
                var faltam = (int)(ProximaExecucao - DateTime.Now).TotalSeconds;
                if (faltam <= 0)
                {
                    if (int.TryParse(txtIntervalo.Text, out int intervalo))
                    {
                        ProximaExecucao = ProximaExecucao.AddSeconds(intervalo);
                        if (!this.chMudo.Checked)
                            player.Play();
                    }
                }
                else if (faltam % 60 == 0)
                {
                    if (!this.chMudo.Checked)
                    {
                        Console.Beep(3000, 300);

                    }
                }
                SetTextCallback d = new SetTextCallback(DefinirTexto);
                this.Invoke(d, new object[] { faltam.ToString() });
            }

        }

    }

    private void DefinirTexto(string texto)
    {
        this.lbFalta.Text = texto;
    }

    private void btnAcao_Click(object sender, EventArgs e)
    {
        if (btnAcao.Text == "Inicia")
        {
            btnAcao.Text = "Para";
            if (int.TryParse(txtIntervalo.Text, out int intervalo))
            {
                ProximaExecucao = DateTime.Now.AddSeconds(intervalo);
                ct.Start();
            }

        }
        else
        {
            btnAcao.Text = "Inicia";
            ct.Stop();
        }
    }


    private void btnAutomatico_Click(object sender, EventArgs e)
    {
        NtpClient client = new NtpClient("a.st1.ntp.br");
        NtpClock clock = client.Query();

        //HttpClient client = new HttpClient();
        //var request = client.GetAsync("http://worldtimeapi.org/api/timezone/Etc/UTC").Result;
        //if (request.StatusCode != HttpStatusCode.OK)
        //    return;

        //var conteudo = request.Content.ReadAsStringAsync().Result;
        //var apiAgora = JsonSerializer.Deserialize<ApiTempo>(conteudo);
        //if (apiAgora == null)
        //    return;

        int difMinutos = 5 - (clock.Now.Minute % 5);
        if (difMinutos == 0)
            difMinutos = 5;
        var alvo = clock.Now.AddMinutes(difMinutos);
        var arredondado = new DateTime(alvo.Year, alvo.Month, alvo.Day, alvo.Hour, alvo.Minute, 0);
        var segundos = (arredondado - clock.Now).TotalSeconds;
        btnAcao.Text = "Para";
        ProximaExecucao = DateTime.Now.AddSeconds(segundos);
        ct.Start();
    }

    //private void DetectaProxy()
    //{
    //    string conteudo = string.Empty;
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.timeapi.io/api/Time/current/zone?timeZone=America/Sao_Paulo");
    //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    //    using (Stream stream = response.GetResponseStream())
    //    using (StreamReader reader = new StreamReader(stream))
    //    {
    //        conteudo = reader.ReadToEnd();
    //    }

    //    Console.WriteLine(conteudo);
    //}
}


public class ApiTempo
{
    public string? utc_offset { get; set; }
    public string? timezone { get; set; }
    public int day_of_week { get; set; }
    public int day_of_year { get; set; }
    public DateTimeOffset datetime { get; set; }
    public DateTimeOffset utc_datetime { get; set; }
    public int unixtime { get; set; }
    public int raw_offset { get; set; }
    public int week_number { get; set; }
    public bool dst { get; set; }
    public string? abbreviation { get; set; }
    public int dst_offset { get; set; }
    public object? dst_from { get; set; }
    public object? dst_until { get; set; }
    public string? client_ip { get; set; }
}


