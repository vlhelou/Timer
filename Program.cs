

using System.Net.Sockets;
using System.Net;
using System.Text;


System.Timers.Timer ct = new()
{
    Interval = 500,
    Enabled = true
};

Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;

System.Media.SoundPlayer Vela1 = new System.Media.SoundPlayer(@"Vela1.wav");
System.Media.SoundPlayer Vela5 = new System.Media.SoundPlayer(@"Vela5.wav");
System.Media.SoundPlayer Vela15 = new System.Media.SoundPlayer(@"Vela15.wav");



//a.ntp.br
//200.20.186.94
var clock = new DateTimeOffset(GetNetworkTime("a.ntp.br"));
int gFaltam = 0;
//Console.WriteLine("\u259B");

int offset = (int)(clock - DateTimeOffset.Now).TotalSeconds;
var agora = clock.ToUnixTimeSeconds();
var referencia = (agora - (agora % 60)) + 60;
DateTimeOffset ProximaExecucao = DateTimeOffset.FromUnixTimeSeconds(referencia);
//Console.WriteLine($"Referência: {referencia}, offset: {offset}, próxima: {ProximaExecucao}");

//ct.Start();
ct.Elapsed += (s, e) =>
{
    var faltamSegundos = (int)(ProximaExecucao - DateTime.Now).TotalSeconds;
    var minuto = DateTime.Now.Minute;
    Console.SetCursorPosition(0, 0);
    if (faltamSegundos >= 0)
    {
        if (faltamSegundos != gFaltam)
        {
            int unidade = faltamSegundos % 10;
            int dezena = (faltamSegundos / 10) % 10;
            gFaltam = faltamSegundos;


            if (faltamSegundos < 10)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < dezena; i++)
                Console.Write("\u25A5.");

            Console.Write(new string('.', unidade).PadRight(30));
            
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i=0;i<5-(minuto % 5);i++)
                Console.Write($"{i} ");
            //Console.Write("\u25A5.");
            Console.Write("                 ");


            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 15-(minuto % 15); i++)
                Console.Write($"{i} ");
            Console.Write("                 ");

            Console.SetCursorPosition(0, 3);
            Console.Title=$"faltam {faltamSegundos} ";

        }
    }
    else
    {
        if (ProximaExecucao.Minute % 15 == 0)
        {
            Vela15.Play();
        }
        else if (ProximaExecucao.Minute % 5 == 0)
        {
            Vela5.Play();
        }
        else if (ProximaExecucao.Minute % 1 == 0)
        {
            Vela1.Play();
        }
        ProximaExecucao = ProximaExecucao.AddSeconds(60);

    }

    //Console.WriteLine($"UTC: {DateTime.UtcNow}, Local: {DateTime.Now}, Offset: {offset}");
};


Console.ReadKey();


static DateTime GetNetworkTime(string ntpServer)
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

static uint SwapEndianness(ulong x)
{
    return (uint)(((x & 0x000000FF) << 24) +
                  ((x & 0x0000FF00) << 8) +
                  ((x & 0x00FF0000) >> 8) +
                  ((x & 0xFF000000) >> 24));
}
