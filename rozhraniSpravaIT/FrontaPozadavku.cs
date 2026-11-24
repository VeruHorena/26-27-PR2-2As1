using System.Collections.Generic;

namespace ServisniPult;

internal sealed class FrontaPozadavku
{
    private readonly Queue<Pozadavek> cekajici;
    private int dalsiId = 1;

    public FrontaPozadavku(IEnumerable<Pozadavek> pocatecniPozadavky)
    {
        cekajici = new Queue<Pozadavek>(pocatecniPozadavky);
        foreach (Pozadavek pozadavek in cekajici)
        {
            if (pozadavek.Id >= dalsiId)
                dalsiId = pozadavek.Id + 1;
        }
    }

    public IReadOnlyList<Pozadavek> ZiskejCekajici() => cekajici.ToArray();

    // Připravený kód zavolá tento bod po odeslání formuláře pro poruchu.
    public string PridejPoruchu(string nazev, string ucebna, string zarizeni)
    {
        // TODO A: Přiděl ID, vytvoř objekt Porucha a zařaď ho na konec fronty.
        // Vrať potvrzení s číslem požadavku.
        return "Přidání poruchy zatím čeká na doplnění kódu.";
    }

    // Připravený kód zavolá tento bod po odeslání formuláře pro instalaci.
    public string PridejInstalaci(string nazev, string pocitac, string program)
    {
        // TODO B: Přiděl ID, vytvoř objekt Instalace a zařaď ho na konec fronty.
        // Vrať potvrzení s číslem požadavku.
        return "Přidání instalace zatím čeká na doplnění kódu.";
    }

    // Připravený kód zavolá tento bod po potvrzení odbavení.
    public string OdbavPrvni()
    {
        // TODO C: Pokud je fronta prázdná, vrať zprávu.
        // Jinak odeber první požadavek a vrať zprávu s jeho číslem a názvem.
        return "Odbavení zatím čeká na doplnění kódu.";
    }

    private int VygenerujId() => dalsiId++;
}
