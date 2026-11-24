namespace ServisniPult;

internal class Instalace : Pozadavek
{
    public string Pocitac { get; }
    public string ProgramKInstalaci { get; }

    public Instalace(int id, string nazev, string pocitac, string programKInstalaci)
        : base(id, nazev)
    {
        Pocitac = pocitac;
        ProgramKInstalaci = programKInstalaci;
    }

    public override string ZiskejDetail()
    {
        return $"Instalace | Počítač: {Pocitac} | Program: {ProgramKInstalaci}";
    }
}
