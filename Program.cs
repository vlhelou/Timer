using System.Text;
using Timer;


ArgsParse argumentos = new ArgsParse(args);
int offset = 0;

if (!string.IsNullOrEmpty(argumentos.Valor("offset")))
{
    if (int.TryParse(argumentos.Valor("offset"), out int opcao))
    {
        offset = opcao;
    }
}

System.Timers.Timer ct = new()
{
    Interval = 500,
    Enabled = true
};

Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;

System.Media.SoundPlayer Minuto1 = new System.Media.SoundPlayer(@"Minuto1.wav");
System.Media.SoundPlayer Minuto2 = new System.Media.SoundPlayer(@"Minuto2.wav");
System.Media.SoundPlayer Minuto3 = new System.Media.SoundPlayer(@"Minuto3.wav");
System.Media.SoundPlayer Minuto4 = new System.Media.SoundPlayer(@"Minuto4.wav");

System.Media.SoundPlayer Vela5 = new System.Media.SoundPlayer(@"Vela5.wav");
System.Media.SoundPlayer Vela15 = new System.Media.SoundPlayer(@"Vela15.wav");


DateTimeOffset tempoReferencia = DateTimeOffset.Now;
DateTimeOffset proximaExecucao = DateTimeOffset.Now.AddSeconds(60);
//int gFaltam = 0;

if (string.IsNullOrEmpty(argumentos.Valor("agora")))
{
    string? ntpServer = argumentos.Valor("ntp");
    Ntp ntp = new Ntp(ntpServer);
    var clock = new DateTimeOffset(ntp.Agora());
    //Console.WriteLine("\u259B");

    var agora = clock.ToUnixTimeSeconds();
    long referencia = (agora - (agora % 60)) + 60;
    proximaExecucao = DateTimeOffset.FromUnixTimeSeconds(referencia + offset);
    referencia = (agora - (agora % (60*15))) ;
    tempoReferencia = DateTimeOffset.FromUnixTimeSeconds(referencia + offset);

}

//Console.WriteLine($"Referência: {referencia}, offset: {offset}, próxima: {ProximaExecucao}");

//ct.Start();
ct.Elapsed += (s, e) =>
{
    var segundos = (int)(proximaExecucao-DateTimeOffset.Now).TotalSeconds;
    int minutos = (int)Math.Floor((proximaExecucao - tempoReferencia).TotalMinutes);

    if (segundos <=0 )
    {
        if (minutos % 15 == 0)
        {
            Vela15.Play();
        }
        else if (minutos % 5 == 0)
        {
            Vela5.Play();
        }
        else if (minutos % 1 == 0)
        {
            switch (minutos % 5)
            {
                case 1:
                    Minuto1.Play();
                    break;
                case 2:
                    Minuto2.Play();
                    break;
                case 3:
                    Minuto3.Play();
                    break;
                case 4:
                    Minuto4.Play();
                    break;
            }
        }
        proximaExecucao = proximaExecucao.AddSeconds(60);
    }
    else
    {
        var restando =  segundos;
        Console.Title = "Faltando: " + restando.ToString();
    }

    //var faltamSegundos = (int)(ProximaExecucao - DateTime.Now).TotalSeconds;
    //var minuto = DateTime.Now.Minute;
    //Console.SetCursorPosition(0, 0);
    //if (faltamSegundos >= 0)
    //{
    //    if (faltamSegundos != gFaltam)
    //    {
    //        int unidade = faltamSegundos % 10;
    //        int dezena = (faltamSegundos / 10) % 10;
    //        gFaltam = faltamSegundos;


    //        if (faltamSegundos < 10)
    //            Console.ForegroundColor = ConsoleColor.Red;
    //        else
    //            Console.ForegroundColor = ConsoleColor.White;

    //        for (int i = 0; i < dezena; i++)
    //            Console.Write("\u25A5.");

    //        Console.Write(new string('.', unidade).PadRight(30));

    //        Console.SetCursorPosition(0, 1);
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        for (int i = 0; i < 5 - (minuto % 5); i++)
    //            Console.Write($"{i} ");
    //        //Console.Write("\u25A5.");
    //        Console.Write("                 ");


    //        Console.SetCursorPosition(0, 2);
    //        Console.ForegroundColor = ConsoleColor.Blue;
    //        for (int i = 0; i < 15 - (minuto % 15); i++)
    //            Console.Write($"{i} ");
    //        Console.Write("                 ");

    //        Console.SetCursorPosition(0, 3);
    //        Console.Title = $"faltam {faltamSegundos} ";

    //    }
    //}
    //else
    //{
    //    if (ProximaExecucao.Minute % 15 == 0)
    //    {
    //        Vela15.Play();
    //    }
    //    else if (ProximaExecucao.Minute % 5 == 0)
    //    {
    //        Vela5.Play();
    //    }
    //    else if (ProximaExecucao.Minute % 1 == 0)
    //    {
    //        switch(ProximaExecucao.Minute % 5)
    //        {
    //            case 1:
    //                Minuto1.Play();
    //                break;
    //            case 2:
    //                Minuto2.Play();
    //                break;
    //            case 3:
    //                Minuto3.Play();
    //                break;
    //            case 4:
    //                Minuto4.Play();
    //                break;
    //        }
    //    }
    //    ProximaExecucao = ProximaExecucao.AddSeconds(60);

    //}

};


Console.ReadKey();


