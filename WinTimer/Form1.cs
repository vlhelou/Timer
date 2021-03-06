

using System.Timers;

namespace WinTimer
{
    public partial class Form1 : Form
    {
        System.Timers.Timer ct = new() { Interval = 500 };
        DateTime ProximaExecucao = new DateTime();

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
    }
}