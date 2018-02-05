using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DronePositioningSimulator_v2;
using System.Collections.Generic;
using System.Drawing;

namespace JedinicnoTestiranje
{
    [TestClass]
    public class FormacijaTest
    {
        [TestMethod]
        public void JelCijeliBrojTest()
        {
            int n1 = 9;
            double korijen1 = Math.Sqrt(n1);

            bool rez1 = Formacija.JelCijeliBroj(korijen1);
            Assert.IsTrue(rez1, "Pogreška! Rezultat bi trebao biti cijeli broj.");

            int n2 = 7;
            double korijen2 = Math.Sqrt(n2);
            bool rez2 = Formacija.JelCijeliBroj(korijen2);
            Assert.IsFalse(rez2, "Pogreška! Rezultat ne bi trebao biti cijeli broj.");

            int brojCvorova1 = 6;
            int brojStupaca1 = 3;
            bool rez3 = Formacija.JelCijeliBroj(brojCvorova1 / brojStupaca1);
            Assert.IsTrue(rez3, "Pogreška! Rezultat bi trebao biti cijeli broj.");

            int brojCvorova2 = 7;
            int brojStupaca2 = 3;
            bool rez4 = Formacija.JelCijeliBroj(brojCvorova2 / brojStupaca2);
            Assert.IsTrue(rez3, "Pogreška! Rezultat bi trebao biti cijeli broj.");

        }

        [TestMethod]
        public void IzracunajBrojRedovaTest()
        {
            Formacija f1 = new Formacija(16, 60, 50, 4);
            Assert.AreEqual(4, f1.BrojRedova, "Broj redova nije u redu (16)!");

            Formacija f2 = new Formacija(5, 60, 50, 4);
            Assert.AreEqual(2, f2.BrojRedova, "Broj redova nije u redu (5)!");

            Formacija f3 = new Formacija(7, 60, 50, 4);
            Assert.AreEqual(3, f3.BrojRedova, "Broj redova nije u redu (7)!");

            Formacija f4 = new Formacija(14, 60, 50, 4);
            Assert.AreEqual(4, f4.BrojRedova, "Broj redova nije u redu (14)!");
        }

        [TestMethod]
        public void IzracunajBrojStupacaTest()
        {
            Formacija f1 = new Formacija(16, 60, 50, 4);
            Assert.AreEqual(4, f1.BrojStupaca, "Broj stupaca nije u redu (16)!");

            Formacija f2 = new Formacija(5, 60, 50, 4);
            Assert.AreEqual(3, f2.BrojStupaca, "Broj stupaca nije u redu (5)!");

            Formacija f3 = new Formacija(7, 60, 50, 4);
            Assert.AreEqual(3, f3.BrojStupaca, "Broj stupaca nije u redu (7)!");

            Formacija f4 = new Formacija(14, 60, 50, 4);
            Assert.AreEqual(4, f4.BrojStupaca, "Broj redova nije u redu (14)!");
        }

        [TestMethod]
        public void IzracunajSmjerPoretkaTest()
        {
            Formacija f1 = new Formacija(16, 60, 50, 4);
            Assert.AreEqual(150, f1.SmjerPoretka, "Smjer Poretka nije u redu (16)!");

            Formacija f2 = new Formacija(5, 90, 50, 4);
            Assert.AreEqual(180, f2.SmjerPoretka, "Smjer Poretka nije u redu (5)!");

            Formacija f3 = new Formacija(7, 270, 50, 4);
            Assert.AreEqual(0, f3.SmjerPoretka, "Smjer Poretka nije u redu (7)!");

            Formacija f4 = new Formacija(14, 330, 50, 4);
            Assert.AreEqual(60, f4.SmjerPoretka, "Smjer Poretka nije u redu (14)!");
        }

        [TestMethod]
        public void IzracunajPozicijeTest()
        {
            Formacija f1 = new Formacija(9, 60, 50, 4);
            List<MyPoint> lista = new List<MyPoint>();
            lista.Add(new MyPoint(100, 30));
            lista.Add(new MyPoint(143, 55));
            lista.Add(new MyPoint(186, 80));

            lista.Add(new MyPoint(75, 73));
            lista.Add(new MyPoint(118, 98));
            lista.Add(new MyPoint(161, 123));

            lista.Add(new MyPoint(50, 117));
            lista.Add(new MyPoint(93, 142));
            lista.Add(new MyPoint(136, 167));

            f1.IzracunajPozicije(100, 30);

            List<MyPoint> generirane = f1.ListaPozicija;
            
            Assert.IsTrue(lista.Count == generirane.Count, "Nije jednak broj!");
            for (int i = 0; i < lista.Count; i++)
            {
                Assert.AreEqual(lista[i].X, Math.Truncate(generirane[i].X));
                Assert.AreEqual(lista[i].Y, Math.Truncate(generirane[i].Y));
            }
            
        }
    }
}
