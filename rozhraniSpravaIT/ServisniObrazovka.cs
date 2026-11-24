using System;
using System.Collections.Generic;
using System.Text;

namespace ServisniPult;

internal sealed class ServisniObrazovka
{
    private static readonly string[] Nabidka = { "Fronta", "Dopady", "Přidat", "Odbavit", "Konec" };
    private readonly FrontaPozadavku fronta;
    private readonly PlanovanaOdstavka odstavka;
    private string zprava = "";

    public ServisniObrazovka(FrontaPozadavku fronta, PlanovanaOdstavka odstavka)
    {
        this.fronta = fronta;
        this.odstavka = odstavka;
    }

    public void Spust()
    {
        if (Console.IsInputRedirected || Console.IsOutputRedirected)
        {
            Console.WriteLine("Spusť aplikaci v interaktivním terminálu.");
            return;
        }

        Console.OutputEncoding = Encoding.UTF8;
        int poziceMenu = 0;
        int pozicePozadavku = 0;
        bool vObsahu = false;

        while (true)
        {
            IReadOnlyList<Pozadavek> pozadavky = fronta.ZiskejCekajici();
            pozicePozadavku = Math.Clamp(pozicePozadavku, 0, Math.Max(0, pozadavky.Count - 1));
            Vykresli(poziceMenu, pozicePozadavku, vObsahu, pozadavky);
            ConsoleKey klavesa = Console.ReadKey(intercept: true).Key;

            if (klavesa == ConsoleKey.Escape)
            {
                if (!vObsahu)
                    return;
                vObsahu = false;
                continue;
            }

            if (!vObsahu)
            {
                switch (klavesa)
                {
                    case ConsoleKey.LeftArrow:
                        poziceMenu = Math.Max(0, poziceMenu - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        poziceMenu = Math.Min(Nabidka.Length - 1, poziceMenu + 1);
                        break;
                    case ConsoleKey.Enter:
                        if (poziceMenu == Nabidka.Length - 1)
                            return;
                        if (poziceMenu == 2)
                            zprava = FormularPozadavku();
                        else if (poziceMenu == 3)
                            zprava = PotvrdOdbaveni(pozadavky);
                        else
                            vObsahu = true;
                        break;
                }
            }
            else if (poziceMenu == 0 && pozadavky.Count > 0)
            {
                if (klavesa == ConsoleKey.UpArrow)
                    pozicePozadavku = Math.Max(0, pozicePozadavku - 1);
                if (klavesa == ConsoleKey.DownArrow)
                    pozicePozadavku = Math.Min(pozadavky.Count - 1, pozicePozadavku + 1);
            }
        }
    }

    private void Vykresli(int menu, int vybrany, bool vObsahu, IReadOnlyList<Pozadavek> pozadavky)
    {
        Console.Clear();
        int sirka = Math.Max(8, Math.Min(79, Console.WindowWidth - 1));
        string oddelovac = new string('─', sirka);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Radek(" SERVISNÍ PULT ŠKOLNÍHO IT", sirka);
        Radek(oddelovac, sirka);
        Console.ResetColor();

        for (int i = 0; i < Nabidka.Length; i++)
        {
            if (i == menu)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
            }

            string polozka = i == menu ? $" [{Nabidka[i]}] " : $"  {Nabidka[i]}  ";
            if (sirka >= 55)
                Console.Write(polozka);
            else
                Radek(polozka, sirka);
            Console.ResetColor();
        }

        if (sirka >= 55)
            Console.WriteLine();
        Radek(oddelovac, sirka);
        if (menu == 0)
        {
            for (int i = 0; i < pozadavky.Count; i++)
            {
                string znacka = i == vybrany ? " › " : "   ";
                Radek($"{znacka}#{pozadavky[i].Id}  {pozadavky[i].Nazev}", sirka);
            }

            if (pozadavky.Count == 0)
                Radek(" Fronta je prázdná.", sirka);

            if (pozadavky.Count > 0)
            {
                Radek(oddelovac, sirka);
                Odstavec(pozadavky[vybrany].ZiskejDetail(), sirka);
            }
        }
        else if (menu == 1)
        {
            var zaznamy = new List<object>(pozadavky) { odstavka };
            List<string> radky = PrehledDopadu.Sestav(zaznamy);
            if (radky.Count == 0)
                Radek(" Přehled zatím neobsahuje žádné dopady.", sirka);

            foreach (string radek in radky)
                Odstavec("• " + radek, sirka);
        }
        else
        {
            string instrukce = menu switch
            {
                2 => "Enter otevře formulář nového požadavku.",
                3 => "Enter zobrazí první požadavek a nabídne jeho odbavení.",
                _ => "Enter ukončí aplikaci."
            };
            Odstavec(instrukce, sirka);
        }

        if (zprava.Length > 0)
        {
            Radek(oddelovac, sirka);
            Odstavec(zprava, sirka);
        }

        Radek(oddelovac, sirka);
        string napoveda = vObsahu
            ? menu == 0 ? " ↑↓ Výběr požadavku   Esc Zpět do menu" : " Esc Zpět do menu"
            : " ←→ Menu   Enter Otevřít   Esc Konec";
        Radek(napoveda, sirka);
    }

    private string FormularPozadavku()
    {
        int typ = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" SERVISNÍ PULT  /  NOVÝ POŽADAVEK");
            Console.WriteLine(typ == 0 ? " › Porucha" : "   Porucha");
            Console.WriteLine(typ == 1 ? " › Instalace" : "   Instalace");
            Console.WriteLine(" ↑↓ Vyber typ   Enter Pokračovat   Esc Zrušit");
            ConsoleKey klavesa = Console.ReadKey(intercept: true).Key;
            if (klavesa == ConsoleKey.Escape)
                return "Formulář zrušen.";
            if (klavesa == ConsoleKey.Enter)
                break;
            if (klavesa == ConsoleKey.UpArrow)
                typ = 0;
            if (klavesa == ConsoleKey.DownArrow)
                typ = 1;
        }

        Console.Clear();
        Console.WriteLine(typ == 0 ? " NOVÁ PORUCHA" : " NOVÁ INSTALACE");
        Console.WriteLine("Prázdný vstup zruší formulář.");
        string? nazev = NactiPole("Název");
        if (nazev is null)
            return "Formulář zrušen.";

        string? prvni = NactiPole(typ == 0 ? "Učebna" : "Počítač");
        if (prvni is null)
            return "Formulář zrušen.";

        string? druhy = NactiPole(typ == 0 ? "Zařízení" : "Program");
        if (druhy is null)
            return "Formulář zrušen.";

        return typ == 0
            ? fronta.PridejPoruchu(nazev, prvni, druhy)
            : fronta.PridejInstalaci(nazev, prvni, druhy);
    }

    private string PotvrdOdbaveni(IReadOnlyList<Pozadavek> pozadavky)
    {
        if (pozadavky.Count == 0)
            return fronta.OdbavPrvni();

        Console.Clear();
        Console.WriteLine(" SERVISNÍ PULT  /  ODBAVENÍ");
        Console.WriteLine($"První ve frontě: #{pozadavky[0].Id} {pozadavky[0].Nazev}");
        Console.WriteLine(" Enter Potvrdit   Esc Zrušit");

        while (true)
        {
            ConsoleKey klavesa = Console.ReadKey(intercept: true).Key;
            if (klavesa == ConsoleKey.Enter)
                return fronta.OdbavPrvni();
            if (klavesa == ConsoleKey.Escape)
                return "Odbavení zrušeno.";
        }
    }

    private static string? NactiPole(string popis)
    {
        Console.Write($"{popis}: ");
        string? text = Console.ReadLine()?.Trim();
        return string.IsNullOrEmpty(text) ? null : text;
    }

    private static void Radek(string text, int sirka)
    {
        Console.WriteLine(text.Length <= sirka ? text : text[..(sirka - 1)] + "…");
    }

    private static void Odstavec(string text, int sirka)
    {
        while (text.Length > sirka)
        {
            int konec = text.LastIndexOf(' ', sirka);
            if (konec <= 0)
                konec = sirka;
            Console.WriteLine(text[..konec]);
            text = text[konec..].TrimStart();
        }

        Console.WriteLine(text);
    }
}
