int volba;

while (true)
{
    Console.WriteLine("Výtej v půjčovně kol");
    Console.WriteLine("1. Vypsat seznam kol");
    Console.WriteLine("2. Vypůjčit si kolo");
    Console.WriteLine("3. Vrátit kolo");
    Console.WriteLine("4. Ukončit");

    if(!int.TryParse(Console.ReadLine() ,out volba))
    {
        Console.WriteLine("Zadej znovu");
        continue;
    }

    switch (volba)
    {
        case 1:


            break;

        case 2:
            break;

        case 3:
            break;

        case 4:
            break;
    }
}