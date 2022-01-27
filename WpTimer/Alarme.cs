using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpTimer
{
    internal record Alarme
    {
        public string Nome { get; set; } = string.Empty;
        public int Duracao { get; set; }
        public System.Timers.Timer Timer { get; set; }=new System.Timers.Timer();
    }
}
