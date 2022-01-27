using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WinTimer
{
    internal class Alarme
    {
        public Alarme(string nome, int intervalo)
        {
            Timer=new System.Timers.Timer() {
                AutoReset = true,
                Enabled = false,
                Interval = intervalo*1000,
            };
            //= new System.Timers.Timer() { AutoReset = true, Enabled = false };
            Nome = nome;
            Timer.Elapsed += TocaAlarme;
        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Alarme.wav");
        


        private DateTime? proximaExecucao;
        public string Nome { get; set; } = string.Empty;
        public System.Timers.Timer Timer { get; set; } 
        public bool Ativo
        {
            get
            {
                return Timer.Enabled;
            }
            set 
            { 
                if (value)
                {
                    Timer.Enabled = true;
                    Timer.Start();
                    this.proximaExecucao = DateTime.Now.AddMilliseconds(Timer.Interval);
                } else
                {
                    Timer.Enabled = false;
                    Timer.Stop();
                    proximaExecucao = null;

                }
            }

        }
        public int Intervalo => Timer == null ? 0 : (int)Timer.Interval / 1000;

        public DateTime? ProximaExecucao => proximaExecucao;

        private void TocaAlarme(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Tocou o alarme {Nome}");
            player.Play();
        }

    }
}
