namespace ServisniPult;

internal class Porucha : Pozadavek
{
    public string Ucebna { get; }
    public string Zarizeni { get; }

    public Porucha(int id, string nazev, string ucebna, string zarizeni)
        : base(id, nazev)
    {
        Ucebna = ucebna;
        Zarizeni = zarizeni;
    }

    public override string ZiskejDetail()
    {
        return $"Porucha | Učebna: {Ucebna} | Zařízení: {Zarizeni}";
    }
    // TODO 2: Přidej IMaDopad a implementuj PopisDopadu().
}
