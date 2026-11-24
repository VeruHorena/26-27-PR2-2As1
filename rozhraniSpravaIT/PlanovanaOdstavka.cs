namespace ServisniPult;

internal class PlanovanaOdstavka
{
    public string Sluzba { get; }
    public string Termin { get; }

    public PlanovanaOdstavka(string sluzba, string termin)
    {
        Sluzba = sluzba;
        Termin = termin;
    }
    // TODO 2: Přidej IMaDopad a implementuj PopisDopadu().
}
