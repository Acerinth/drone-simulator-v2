using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronePositioningSimulator_v2
{
    public static class Kretanje
    {
        public static float KorigirajKut(float s)
        {
            float noviKut = s;
            if (s > 90 && s < 180)
            {
                noviKut = 180 - s;
            }
            if (s == 180)
            {
                noviKut = 0;
            }
            if (s > 180 && s < 270)
            {
                noviKut = s - 180;
            }
            if (s == 270)
            {
                noviKut = 90;
            }
            if (s > 270 && s < 360)
            {
                noviKut = 360 - s;
            }
            if (s == 360)
            {
                noviKut = 0;
            }
            return noviKut;
        }

        public static float IzracunajPomakX(float s, float v, bool tip=true)
        {
            float pomakX;
            float kut;
            double kutRadijani;
            if (tip)
            {
                kut = KorigirajKut(s);
                kutRadijani = Math.PI * kut / 180.0;
                pomakX = (float)Math.Sin(kutRadijani) * v;
                return pomakX;
            }
            kut = KorigirajKut(s);
            kutRadijani = Math.PI * kut / 180.0;
            pomakX = (float)Math.Cos(kutRadijani) * v;
            return pomakX;
        }

        public static float IzracunajPomakY(float s, float v, bool tip=true)
        {
            float pomakY;
            float kut;
            double kutRadijani;
            if (tip)
            {
                kut = KorigirajKut(s);
                kutRadijani = Math.PI * kut / 180.0;
                pomakY = (float)Math.Round((Math.Cos(kutRadijani) * v), 0);
                return pomakY;
            }
            kut = KorigirajKut(s);
            kutRadijani = Math.PI * kut / 180.0;
            pomakY = (float)Math.Round((Math.Sin(kutRadijani) * v), 0);
            return pomakY;
        }

        public static MyPoint NapraviPomak(MyPoint tocka, float smjer, float brzina, bool tip=true)
        {
            float x = tocka.X;
            float y = tocka.Y;
            if (smjer < 90 && smjer > 0)
            {
                x += IzracunajPomakX(smjer, brzina, tip);
                y -= IzracunajPomakY(smjer, brzina, tip);
            }
            else if (smjer == 90)
            {
                x += IzracunajPomakX(smjer, brzina, tip);
            }
            else if (smjer > 90 && smjer < 180)
            {
                x += IzracunajPomakX(smjer, brzina, tip);
                y += IzracunajPomakY(smjer, brzina, tip);
            }
            else if (smjer == 180)
            {
                y += IzracunajPomakY(smjer, brzina, tip);
            }
            else if (smjer > 180 && smjer < 270)
            {
                x -= IzracunajPomakX(smjer, brzina, tip);
                y += IzracunajPomakY(smjer, brzina, tip);
            }
            else if (smjer == 270)
            {
                x -= IzracunajPomakX(smjer, brzina, tip);
            }
            else if (smjer > 270 && smjer < 360)
            {
                x -= IzracunajPomakX(smjer, brzina, tip);
                y -= IzracunajPomakY(smjer, brzina, tip);
            }
            else if (smjer == 360 || smjer == 0)
            {
                y -= IzracunajPomakY(smjer, brzina, tip);
            }

            MyPoint novaTocka = new MyPoint(x, y);
            return novaTocka;
        }
    }
}
