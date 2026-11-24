using System.Collections.Generic;

namespace ServisniPult;

internal static class Program
{
    private static void Main()
    {
        var ukazkovaData = new List<Pozadavek>
        {
            new PoruchaProjektoru(1, "Nefunguje projektor", "B12", "Obraz bliká"),
            new Instalace(2, "Instalace Visual Studia", "PC-03", "Visual Studio"),
            new Porucha(3, "Nefunguje tiskárna", "A03", "tiskárna")
        };

        var odstavka = new PlanovanaOdstavka("Školní Wi-Fi", "Pá 15:00–16:00");

        var fronta = new FrontaPozadavku(ukazkovaData);
        new ServisniObrazovka(fronta, odstavka).Spust();
    }
}
