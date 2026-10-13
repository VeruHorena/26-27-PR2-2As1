namespace RazeniMin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pole = { 5, 1, 3, 4, 2 };
            int min;
            int pozice;
            int pomocna;
            for (int i = 0; i < pole.Length; i++) {
                min = pole[i];
                pozice = i;
                for (int j = i+1; j < pole.Length; j++) {
                    if (pole[j] < min)
                    {
                        min = pole[j];
                        pozice = j;
                    }
                }
                pomocna = pole[i];
                pole[i] = pole[pozice];
                pole[pozice] = pomocna;
               //tuples (pole[i], pole[pozice]) = (pole[pozice], pole[i]);           
            }
            foreach (var cislo in pole)
            {
                Console.WriteLine(cislo);
            }
        }
    }
}
