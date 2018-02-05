using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronePositioningSimulator_v2
{
    public class Formacija
    {
        public int BrojCvorova { set; get; }
        public int BrojRedova { set; get; }
        public int BrojStupaca { set; get; }
        public float SmjerKretanja { set; get; }
        public int Razmak { set; get; }
        public float Brzina { set; get; }

        public float SmjerPoretka { set; get; }

        public List<MyPoint> ListaPozicija { set; get; }

        public Formacija(int brojCvorova, float smjer, int razmak, float brzina)
        {
            ListaPozicija = new List<MyPoint>();
            BrojCvorova = brojCvorova;
            BrojStupaca = IzracunajBrojStupaca();
            BrojRedova = IzracunajBrojRedova();
            SmjerKretanja = smjer;
            Razmak = razmak;
            Brzina = brzina;
            SmjerPoretka = IzracunajSmjerPoretka();
        }

        public float IzracunajSmjerPoretka()
        {
            float s = SmjerKretanja + 90;
            if (s == 360) s = 0;
            else if (s > 360) s = s - 360;
            return s;
        }

        public void IzracunajPozicije(float x, float y)
        {
            MyPoint prva = new MyPoint(x, y);
            ListaPozicija.Add(prva);
            MyPoint trenutna = prva;
            for (int i = 0; i < BrojRedova; i++)
            {
                for (int j = 0; j < BrojStupaca-1; j++)
                {
                    MyPoint iduca = Kretanje.NapraviPomak(trenutna, SmjerPoretka, Razmak, false);
                    ListaPozicija.Add(iduca);
                    trenutna = iduca;
                }
                if (i < BrojRedova - 1)
                {
                    float s = SmjerPoretka + 90;
                    float b = (i + 1) * Razmak;
                    trenutna = Kretanje.NapraviPomak(prva, s, b, false);
                    ListaPozicija.Add(trenutna);
                }
            }
        }

        public int IzracunajBrojRedova()
        {
            double korijen = Math.Sqrt(BrojCvorova);
            if (JelCijeliBroj(korijen))
            {
                return (int)korijen;
            }
            double pom = BrojCvorova / (double)BrojStupaca;
            if (JelCijeliBroj(pom))
            {
                return (int)pom;
            }
            return (int)Math.Truncate(pom) + 1;
        }

        public int IzracunajBrojStupaca()
        {
            double korijen = Math.Sqrt(BrojCvorova);
            if (JelCijeliBroj(korijen))
            {
                return (int)korijen;
            }
            
            return (int)Math.Truncate(korijen) + 1;
        }

        public static bool JelCijeliBroj(double broj)
        {
            double brojZaDijelit = Math.Truncate(broj);
            if (broj % brojZaDijelit == 0)
                return true;
            else
                return false;
        }

    }
}
