using System;
using System.Collections.Generic;
using System.Text;

namespace KouzelniciADraci
{
    internal class Bojovnik:Postava
    {
        private int sila;
        

        public int Sila { get => sila; set => sila = value; }

        public Bojovnik (string jmeno, int zivoty):base(jmeno,zivoty)
        {
            sila = Generator.Next(1, 11);
            Console.WriteLine($"Byl spuštěn konstruktor Bojovnik.cs. \n Vytvořen objekt Bojovníka se sílou {sila} ");
        }
        public void SekniMecem()
        {
            Console.WriteLine($"Bojovník {Jmeno} seká mečem za {sila} bodů.");
        }
    }
}
