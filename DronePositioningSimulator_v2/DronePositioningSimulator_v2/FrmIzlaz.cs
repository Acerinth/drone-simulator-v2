using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DronePositioningSimulator_v2
{
    public partial class FrmIzlaz : Form
    {
        public Timer DrawingTimer { private set; get; }
        public Timer MovingTimer { private set; get; }

        public FrmIzlaz()
        {
            InitializeComponent();
        }

        private void FrmIzlaz_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(FrmIzlaz_Paint);
            DrawingTimer = new Timer();
            DrawingTimer.Tick += new EventHandler(DrawingTimer_Tick);
            DrawingTimer.Enabled = false;
            DrawingTimer.Interval = 50;

            MovingTimer = new Timer();
            MovingTimer.Tick += new EventHandler(MovingTimer_Tick);
            MovingTimer.Enabled = false;
            MovingTimer.Interval = 50;
        }

        private void FrmIzlaz_Paint(object sender, PaintEventArgs e)
        {
            foreach (Dron d in Dron.ListaDronova)
            {
                SolidBrush boja = new SolidBrush(d.Boja);
                Pen olovka = new Pen(d.Boja);
                e.Graphics.FillEllipse(boja, d.TrenX - 5, d.TrenY - 5, 10, 10);
            }
        }

        private void DrawingTimer_Tick(object sender, EventArgs e)
        {
            foreach (Dron d in Dron.ListaDronova)
            {
                d.ProvjeriRub(this.ClientSize.Width - 5, this.ClientSize.Height - 5);
                d.PomakniDron();
            }
            this.Refresh();
        }

        private void MovingTimer_Tick(object sender, EventArgs e)
        {
            Dron vodja = Dron.ListaDronova.ElementAt(0);
            foreach (Dron d in Dron.ListaDronova)
            {
                if (d != vodja)
                {
                    d.ProvjeriRub(this.ClientSize.Width - 5, this.ClientSize.Height - 5);
                    d.IdiPremaLokaciji();
                }
            }
            this.Refresh();
            if (vodja.Brojac == Dron.ListaDronova.Count - 1)
            {
                MovingTimer.Stop();
                DrawingTimer.Start();
            }
            
        }
    }
}
