using System;
using System.Collections.Generic;
using System.Text;

namespace KouzelniciADraci
{
    internal class Kouzelnik:Postava
    {
        private int mana;
       

        public int Mana { get => mana; set => mana = value; }

        public Kouzelnik(string jmeno, int zivoty):base(jmeno,zivoty)
        {
            mana = Generator.Next(5, 21);
            Console.WriteLine($"Spustil se konstruktor Kouzelnik.cs. \n Vytvořen objekt Kouzelnika s manou {mana} ");
        }
        public void SesliKouzlo()
        {
            if (mana >= 10)
            {
                mana = mana - 10;
                Console.WriteLine($"{Jmeno} sesílá ohnivou kouli!");
                Console.WriteLine($"Zbývá mu {mana} many.");
            }
            else
            {
                Console.WriteLine($"{Jmeno} nemá dostatek many.");
            }
        }
    }
}
