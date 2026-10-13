using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost01
{
    internal class Pes : Savec
    {
        private int cisloCipu;
        public Pes(string srst, int doba, int cisloCipu, string jmeno, int vek) : base(srst, doba, jmeno, vek)
        {
            Console.WriteLine("Spustil se konstruktor psa.");
            this.cisloCipu = cisloCipu;
        }

        public int CisloCipu { get => cisloCipu; set => cisloCipu = value; }
    }
}
