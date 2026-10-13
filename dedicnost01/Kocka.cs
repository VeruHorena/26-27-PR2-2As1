using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost01
{
    internal class Kocka : Savec
    {
        private string druh;
        public Kocka(string srst, int doba, string jmeno, int vek) : base(srst, doba,jmeno,vek)
        {
            Console.WriteLine("Spustil se konstruktor kocky.");
            this.druh = "perska";
        }

        public string Druh { get => druh; set => druh = value; }
    }
}
