using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DronePositioningSimulator_v2
{
    class Dron
    {
        //public int IdDron { set; get; }
        public string NazivDron { set; get; }
        public float X { set; get; }
        public float Y { set; get; }
        public Color Boja { set; get; }
        public float Smjer { set; get; }
        public float Brzina { set; get; }
        public float TrenX { set; get; }
        public float TrenY { set; get; }
        public float TrenSmjer { set; get; }    

        public static List<Dron> ListaDronova { set; get; } = new List<Dron>();
        
        //za vođu
        private Formacija form;
        public int Brojac = 0;
        private List<MyPoint> generiraneLokacije;

        //za članove jata
        private List<MyPoint> primljeneZauzeteLokacije;
        private MyPoint buducaLokacija;
        private float buduciSmjer;
        private float buducaBrzina;
        private bool poslano = false;



        public static Dron OrganizirajJato()
        {
            Random r = new Random();
            int indeks = r.Next(0, ListaDronova.Count);
            //Dron vodja = ListaDronova.ElementAt(indeks);
            Dron vodja = ListaDronova.ElementAt(0);
            vodja.pokreniOrganizaciju();
            return vodja;
        }


        #region Funkcionalnost Drona
        public void PostaviVrijednosti(int x, int y, Color b, string naz = "", int s = 0, int v = 0)
        {
            this.NazivDron = naz;
            this.X = x;
            this.Y = y;
            this.Boja = b;
            this.Smjer = s;
            this.TrenSmjer = s;
            this.Brzina = v;
            this.TrenX = x;
            this.TrenY = y;
            primljeneZauzeteLokacije = new List<MyPoint>();
        }

        public void PomakniDron()
        {
            MyPoint trenutnaTocka = new MyPoint(this.TrenX, this.TrenY);
            MyPoint novaTocka = Kretanje.NapraviPomak(trenutnaTocka, this.TrenSmjer, this.Brzina);
            this.TrenX = novaTocka.X;
            this.TrenY = novaTocka.Y;
        }

        public void ResetrirajTrenutno()
        {
            this.TrenSmjer = this.Smjer;
            this.TrenX = this.X;
            this.TrenY = this.Y;
            // za vođu
            form = null;
            Brojac = 0;
            // za članove
            if (primljeneZauzeteLokacije != null) primljeneZauzeteLokacije.Clear();
            if (generiraneLokacije != null) generiraneLokacije.Clear();
            poslano = false;
        }

        public void ProvjeriRub(int w, int h)
        {
            if (this.TrenX >= w || this.TrenX <= 1)
            {
                this.TrenSmjer = 360 - this.TrenSmjer;
            }
            if (this.TrenY >= h || this.TrenY <= 1)
            {
                if (this.TrenSmjer > 0 && this.TrenSmjer < 90)
                {
                    this.TrenSmjer = 180 - this.TrenSmjer;
                }
                else if (this.TrenSmjer > 90 && this.TrenSmjer < 180)
                {
                    this.TrenSmjer = 180 - this.TrenSmjer;
                }
                else if (this.TrenSmjer > 180 && this.TrenSmjer < 270)
                {
                    this.TrenSmjer = 360 - (this.TrenSmjer - 180);
                }
                else if (this.TrenSmjer > 270 && this.TrenSmjer < 360)
                {
                    this.TrenSmjer = (360 - this.TrenSmjer) + 180;
                }
                else if (this.TrenSmjer == 0 || this.TrenSmjer == 180)
                {
                    this.TrenSmjer += 180;
                }
                else if (this.TrenSmjer == 360)
                {
                    this.TrenSmjer = 0;
                }

            }
        }

        public void PrimiPodatke(List<MyPoint> lista, float smjer, float brzina)
        {
            generiraneLokacije = new List<MyPoint>(lista);
            buduciSmjer = smjer;
            buducaBrzina = brzina;
        }

        public void PrimiLokaciju(MyPoint lokacija)
        {
            primljeneZauzeteLokacije.Add(lokacija);
        }

        public void IzaberiNajblizuLokaciju()
        {
            double minUdaljenost = double.MaxValue;
            double udaljenost;
            MyPoint najblizaLokacija = new MyPoint();
            foreach (MyPoint p in generiraneLokacije)
            {
                MyPoint postojeca = primljeneZauzeteLokacije.Find(tocka => Math.Round(tocka.X, 1) == Math.Round(p.X, 1) && Math.Round(tocka.Y, 1) == Math.Round(p.Y, 1));
                if (postojeca == null)
                {
                    udaljenost = Math.Sqrt(Math.Pow((TrenX - p.X), 2) + Math.Pow((TrenY - p.Y), 2));
                    if (udaljenost < minUdaljenost)
                    {
                        minUdaljenost = udaljenost;
                        najblizaLokacija = p;
                    }
                }
            }
            buducaLokacija = new MyPoint(najblizaLokacija.X, najblizaLokacija.Y);
            PosaljiLokaciju();
        }

        public void PosaljiLokaciju()
        {
            foreach (Dron d in Dron.ListaDronova)
            {
                d.PrimiLokaciju(buducaLokacija);
            }
        }

        public void IdiPremaLokaciji()
        {
            if (!poslano) this.TrenSmjer = izracunajSmjerPremaLokaciji();
            if (Math.Round(TrenX, 0) != Math.Round(buducaLokacija.X, 0) && Math.Round(TrenY, 0) != Math.Round(buducaLokacija.Y, 0))
            {
                this.PomakniDron();
                double udaljenost = Math.Sqrt(Math.Pow((TrenX - buducaLokacija.X), 2) + Math.Pow((TrenY - buducaLokacija.Y), 2));
                if (udaljenost < Brzina) Brzina = 1;
            }
            else
            {
                if (!poslano)
                {
                    Dron vodja = ListaDronova.ElementAt(0);
                    vodja.PrimiObavijestODolasku();
                    poslano = true;
                    this.TrenSmjer = buduciSmjer;
                    this.Brzina = buducaBrzina;
                }

            }
        }

        private float izracunajSmjerPremaLokaciji()
        {
            float x = buducaLokacija.X;
            float y = buducaLokacija.Y;
            double udaljenost = Math.Sqrt(Math.Pow((TrenX - x), 2) + Math.Pow((TrenY - y), 2));
            double izracun = 0;
            double kut = 0;

            if (x > TrenX && y < TrenY) // prvi kvadrant
            {
                izracun = (x - TrenX) / udaljenost;
                double kutRad = Math.Asin(izracun);
                kut = (180.0 * kutRad) / Math.PI;
            }
            else if (x > TrenX && y == TrenY) // 90 
            {
                kut = 90;
            }
            else if (x > TrenX && y > TrenY) // drugi kvadrant
            {
                izracun = (y - TrenY) / udaljenost;
                double kutRad = Math.Asin(izracun);
                kut = (180.0 * kutRad) / Math.PI;
                kut += 90;
            }
            else if (x == TrenX && y > TrenY) // 180
            {
                kut = 180;
            }
            else if (x < TrenX && y > TrenY) // treci kvadrant
            {
                izracun = (TrenX - x) / udaljenost;
                double kutRad = Math.Asin(izracun);
                kut = (180.0 * kutRad) / Math.PI;
                kut += 180;
            }
            else if (x < TrenX && y == TrenY) // 270
            {
                kut = 270;
            }
            else if (x < TrenX && y < TrenY) // cetvrti kvadrant
            {
                izracun = (TrenY - y) / udaljenost;
                double kutRad = Math.Asin(izracun);
                kut = (180.0 * kutRad) / Math.PI;
                kut += 270;
            }
            else if (x == TrenX && y < TrenY) // 0
            {
                kut = 0;
            }

            return (float)kut;
        }

        #endregion


        #region Funkcionalnost Vodje Dronova
        private void pokreniOrganizaciju()
        {
            this.generirajLokacije();
            Brojac = 0;
            foreach (Dron d in ListaDronova)
            {
                if (d != this)
                {
                    d.PrimiPodatke(form.ListaPozicija, TrenSmjer, Brzina);
                    d.PrimiLokaciju(form.ListaPozicija.ElementAt(0));
                }
            }
            foreach (Dron d in ListaDronova)
            {
                if (d != this)
                {
                    d.IzaberiNajblizuLokaciju();
                }
            }
        }

        private void generirajLokacije()
        {
            form = new Formacija(ListaDronova.Count, TrenSmjer, 50, Brzina);
            form.IzracunajPozicije(this.TrenX, this.TrenY);

            /*  kontrola
            Console.WriteLine("Broj redova: " + form.BrojRedova);
            Console.WriteLine("Broj stupaca: " + form.BrojStupaca);
            foreach (MyPoint item in form.ListaPozicija)
            {
                Console.WriteLine(item.X + ", " + item.Y);
            } */

        }

        public void PrimiObavijestODolasku()
        {
            Brojac++;
        }

        #endregion



    }
}
