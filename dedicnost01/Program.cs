namespace dedicnost01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kocka Micka = new Kocka("vlnita", 4, "Micka", 5);
            Micka.vydejZvuk("mnau");
            Pes Alex = new Pes("rovna", 5, 123, "Alex", 8);
            Alex.vydejZvuk("haf");
            List<Savec> listZvirat = new List<Savec>();
            listZvirat.Add(Micka);
            listZvirat.Add(Alex);


            vypisList(listZvirat);
        }
        public static void vypisList(List<Savec> seznam)
        {
            foreach (Savec m in seznam)
            {
                Console.WriteLine(m.Jmeno);
            }
        }
    }
}
