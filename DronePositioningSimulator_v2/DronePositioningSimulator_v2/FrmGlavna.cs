using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DronePositioningSimulator_v2
{
    public partial class FrmGlavna : Form
    {
        FrmIzlaz frmIzlaz;
        bool pokrenuto;

        public FrmGlavna()
        {
            InitializeComponent();
        }

        private void FrmGlavna_Load(object sender, EventArgs e)
        {
            frmIzlaz = new FrmIzlaz();
            ocistiPolja();
            osvjeziDgv();
            frmIzlaz.Show();
            pokrenuto = false;
        }

        private void btnBoja_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            btnBoja.BackColor = colorDialog1.Color;
            txtBoja.Text = colorDialog1.Color.ToString();
        }

        private void btnDodajDron_Click(object sender, EventArgs e)
        {
            if (provjeriIspravnost())
            {
                Dron noviDron = new Dron();
                noviDron.PostaviVrijednosti(int.Parse(txtX.Text), int.Parse(txtY.Text), btnBoja.BackColor, txtNaziv.Text, int.Parse(txtSmjer.Text), int.Parse(txtBrzina.Text));
                Dron.ListaDronova.Add(noviDron);
                ocistiPolja();
                osvjeziDgv();
            }
            else
            {
                MessageBox.Show("Pogrešno uneseni podaci", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Dron.ListaDronova.Count > 0)
            {
                omoguciGumbe(true);
                frmIzlaz.Refresh();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            int index = dgvDronovi.CurrentRow.Index;
            Dron.ListaDronova.RemoveAt(index);
            osvjeziDgv();
            if (Dron.ListaDronova.Count > 0)
            {
                omoguciGumbe(true);
            }
            else
            {
                omoguciGumbe(false);
            }
            frmIzlaz.Refresh();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!pokrenuto)
            {
                btnStartStop.Text = "Pauziraj";
                frmIzlaz.DrawingTimer.Start();
                pokrenuto = true;
            }
            else
            {
                btnStartStop.Text = "Nastavi";
                frmIzlaz.DrawingTimer.Stop();
                pokrenuto = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Dron d in Dron.ListaDronova)
            {
                d.ResetrirajTrenutno();
            }
            btnStartStop.Text = "Start";
            btnKvadrat.Enabled = true;
            frmIzlaz.Refresh();
        }

        private void osvjeziDgv()
        {
            dgvDronovi.DataSource = Dron.ListaDronova.Select(l => new { NazivDron = l.NazivDron, X = l.X, Y = l.Y, Smjer = l.Smjer, Brzina = l.Brzina, Boja = l.Boja  }).ToList();
        }

        private void ocistiPolja()
        {
            this.txtNaziv.Text = "";
            this.txtX.Text = "";
            this.txtY.Text = "";
            this.txtBrzina.Text = "0";
            this.txtSmjer.Text = "0";
        }

        private bool provjeriIspravnost()
        {
            float pozX, pozY, s, v;
            if (float.TryParse(txtX.Text, out pozX) &&
            float.TryParse(txtY.Text, out pozY) &&
            float.TryParse(txtSmjer.Text, out s) &&
            float.TryParse(txtBrzina.Text, out v))
            {
                if (s >= 0 && s <= 360 && v >= 0 && v <= 15)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private void omoguciGumbe(bool y)
        {
            this.btnObrisi.Enabled = y;
            this.btnStartStop.Enabled = y;
            this.btnKvadrat.Enabled = y;
        }

        private void btnKvadrat_Click(object sender, EventArgs e)
        {
            
            frmIzlaz.DrawingTimer.Stop();
            Dron vodja = Dron.OrganizirajJato();
            frmIzlaz.MovingTimer.Start();
            btnKvadrat.Enabled = false;
            //frmIzlaz.DrawingTimer.Start();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();  
        }

        private void ofd_FileOk(object sender, CancelEventArgs e)
        {
            string[] zapisi = File.ReadAllLines(ofd.FileName);
            foreach (string red in zapisi)
            {
                string[] redSplitted = red.Split(';');
                Dron d = new Dron();
                string naziv = redSplitted[0];
                int x = int.Parse(redSplitted[1]);
                int y = int.Parse(redSplitted[2]);
                int s = int.Parse(redSplitted[3]);
                int b = int.Parse(redSplitted[4]);
                Color c = Color.FromName(redSplitted[5]);
                d.PostaviVrijednosti(x, y, c, naziv, s, b);
                Dron.ListaDronova.Add(d);
            }
            osvjeziDgv();
            if (Dron.ListaDronova.Count > 0)
            {
                omoguciGumbe(true);
                frmIzlaz.Refresh();
            }
        }
    }
}
