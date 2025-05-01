

using System.Net.Sockets;
using System.Net;
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
        
        var clock = GetNetworkTime("pool.ntp.org");

        int difMinutos = 5 - (clock.Minute % 5);
        if (difMinutos == 0)
            difMinutos = 5;
        var alvo = clock.AddMinutes(difMinutos);
        var arredondado = new DateTime(alvo.Year, alvo.Month, alvo.Day, alvo.Hour, alvo.Minute, 0);
        var segundos = (arredondado - clock).TotalSeconds;
        btnAcao.Text = "Para";
        ProximaExecucao = DateTime.Now.AddSeconds(segundos);
        ct.Start();
    }

    private DateTime GetNetworkTime(string ntpServer)
    {
        const int NtpDataLength = 48;
        byte[] ntpData = new byte[NtpDataLength];

        // Setting the Leap Indicator, Version Number, and Mode fields
        ntpData[0] = 0x1B;

        // Connect to the NTP server
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            socket.Connect(new IPEndPoint(Dns.GetHostAddresses(ntpServer)[0], 123));
            socket.Send(ntpData);
            socket.Receive(ntpData);
        }

        // Extract the timestamp (starting at byte 40)
        ulong intPart = BitConverter.ToUInt32(ntpData, 40);
        ulong fracPart = BitConverter.ToUInt32(ntpData, 44);

        // Convert to big-endian
        intPart = SwapEndianness(intPart);
        fracPart = SwapEndianness(fracPart);

        // Calculate the time (NTP timestamp starts from 1900)
        var milliseconds = (intPart * 1000) + ((fracPart * 1000) / 0x100000000L);
        var networkDateTime = new DateTime(1900, 1, 1).AddMilliseconds((long)milliseconds);

        return networkDateTime.ToLocalTime();
    }



    private uint SwapEndianness(ulong x)
    {
        return (uint)(((x & 0x000000FF) << 24) +
                      ((x & 0x0000FF00) << 8) +
                      ((x & 0x00FF0000) >> 8) +
                      ((x & 0xFF000000) >> 24));
    }

}




