

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


    System.Media.SoundPlayer player60 = new System.Media.SoundPlayer(@"Tick60.wav");
    System.Media.SoundPlayer player300 = new System.Media.SoundPlayer(@"Tick300.wav");
    


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
                            player300.Play();
                    }
                }
                else if (faltam % 60 == 0)
                {
                    if (!this.chMudo.Checked)
                    {
                        player60.Play();

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
        string conteudo = string.Empty;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.timeapi.io/api/Time/current/zone?timeZone=America/Sao_Paulo");
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            conteudo = reader.ReadToEnd();
        }
        var apiAgora = JsonSerializer.Deserialize<ApiTempo>(conteudo);
        if (apiAgora == null)
            return;

        int difMinutos = 5 - (apiAgora.minute % 5);
        if (difMinutos == 0)
            difMinutos = 5;
        var alvo = apiAgora.dateTime.AddMinutes(difMinutos);
        var arredondado = new DateTime(alvo.Year, alvo.Month, alvo.Day, alvo.Hour, alvo.Minute, 0);
        var segundos = (arredondado - apiAgora.dateTime).TotalSeconds;
        btnAcao.Text = "Para";
        ProximaExecucao = DateTime.Now.AddSeconds(segundos);
        ct.Start();
        //var client = new HttpClient();
        //using HttpResponseMessage response = await httpClient.GetAsync("todos/3");
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

file record ApiTempo
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
    public int hour { get; set; }
    public int minute { get; set; }
    public int seconds { get; set; }
    public int milliSeconds { get; set; }
    public DateTime dateTime { get; set; }
    public string? date { get; set; }
    public string? time { get; set; }
    public string? timeZone { get; set; }
    public string? dayOfWeek { get; set; }
    public bool dstActive { get; set; }
}
