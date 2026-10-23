using System;
using System.Collections.Generic;
using System.Text;

namespace KouzelniciADraci
{
    internal class Postava
    {
        private string jmeno;
        private int zivoty;
        private Random generator = new Random();
        public string Jmeno { get => jmeno; set => jmeno = value; }
        public int Zivoty { get => zivoty; set => zivoty = value; }
        public Random Generator { get => generator; set => generator = value; }

        public Postava(string jmeno, int zivoty)
        {
            this.jmeno = jmeno;
            this.zivoty = zivoty;
            Console.WriteLine("Spustil se konstruktor Postava.cs");
        }

        public void PredstavSe()
        {
            Console.WriteLine($"Jsem {Jmeno} a mám {zivoty} životů.");
        }

        public void UtrpZraneni(int poskozeni)
        {
            if (zivoty > poskozeni)
            {
                zivoty = zivoty - poskozeni;
            }
            else
            {
                zivoty = 0;
            }
            Console.WriteLine($"{jmeno} má aktuálně {zivoty} životů.");
        }
    }
}
