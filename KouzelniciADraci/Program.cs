namespace KouzelniciADraci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bojovnik b = new Bojovnik("Hehe", 4);
            b.PredstavSe();
            Kouzelnik k = new Kouzelnik("Cmaryfuk", 10);
            k.PredstavSe();
            b.SekniMecem();
            b.UtrpZraneni(2);
            k.SesliKouzlo();
            k.UtrpZraneni(4);
            b.PredstavSe();
            k.PredstavSe();
        }
    }
}
