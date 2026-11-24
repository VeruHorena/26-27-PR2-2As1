namespace ServisniPult;

internal class PoruchaProjektoru : Porucha
{
    public string Priznak { get; }

    public PoruchaProjektoru(int id, string nazev, string ucebna, string priznak)
        : base(id, nazev, ucebna, "projektor")
    {
        Priznak = priznak;
    }
}
