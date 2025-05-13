using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Timer;

internal class Ntp
{
    private string NtpServer = "time.windows.com"; // Default NTP server
    public Ntp(string? ntpServer)
    {
        if (int.TryParse(ntpServer, out int opcao))
        {
            switch (opcao)
            {
                case 1:
                    NtpServer = "a.ntp.br"; // Default NTP server
                    break;
                case 2:
                    NtpServer = "d.st1.ntp.br"; // Default NTP server
                    break;
                case 3:
                    NtpServer = "pool.ntp.org"; // Default NTP server
                    break;
                case 4:
                    NtpServer = "200.20.186.94"; // Default NTP server
                    break;
                case 5:
                    NtpServer = "time.windows.com"; // Default NTP server
                    break;
                case 6:
                    NtpServer = "time.google.com"; // Default NTP server
                    break;
                case 7:
                    NtpServer = "time.aws.com"; // Default NTP server
                    break;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(ntpServer))
                NtpServer = ntpServer;

        }
    }

    public Ntp()
    {
    }

    public DateTime Agora()
    {
        const int NtpDataLength = 48;
        byte[] ntpData = new byte[NtpDataLength];

        // Setting the Leap Indicator, Version Number, and Mode fields
        ntpData[0] = 0x1B;

        // Connect to the NTP server
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            var addresses = Dns.GetHostAddresses(NtpServer);
            socket.Connect(addresses, 123 );
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
