using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost01
{
    internal class Zvire
    {
        private string jmeno;
        private int vek;
        private string barva;

        public string Jmeno { get => jmeno; set => jmeno = value; }
        public int Vek { get => vek; set => vek = value; }
        public string Barva { get => barva; set => barva = value; }

        public Zvire(string jmeno, int vek)
        {
            Console.WriteLine("Spustil se konstruktor Zvirete");
            this.jmeno = jmeno;
            this.vek = vek;
        }
    }
}
