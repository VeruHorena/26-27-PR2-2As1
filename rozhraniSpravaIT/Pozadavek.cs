namespace ServisniPult;

internal abstract class Pozadavek
{
    public int Id { get; }
    public string Nazev { get; }

    protected Pozadavek(int id, string nazev)
    {
        Id = id;
        Nazev = nazev;
    }

    public virtual string ZiskejDetail() => "Podrobnosti zatím nejsou uvedeny.";
}
