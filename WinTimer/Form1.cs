

namespace WinTimer
{
    public partial class Form1 : Form
    {
        List<Alarme> alarmeList=new();
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
            alarmeList.Add(new Alarme("teste", 10));
            alarmeList.Add(new Alarme("5 Min.", 300));
            alarmeList.Add(new Alarme("15 Min.", 900));
            gAlarme.DataSource = alarmeList;
        }
    }
}