using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost01
{
    internal class Savec:Zvire
    {
        private string typSrsti;

        public string TypSrsti { get => typSrsti; set => typSrsti = value; }
        public int DobaKojeni { get => dobaKojeni; set => dobaKojeni = value; }

        private int dobaKojeni;

        public Savec(string srst, int doba, string jmeno, int vek):base(jmeno,vek)
        {
            Console.WriteLine("Spusten konstruktor savce.");
            this.typSrsti = srst;
            this.dobaKojeni= doba;
        }
        public void vydejZvuk(string text)
        {
            Console.WriteLine(text + " " + text);
        }
    }
}
