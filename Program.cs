namespace ConsoleApp_typedemo_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hvilket ord skal der søges efter: ");
            var soegeWord = Console.ReadLine();
            Console.Write("Hvilket tekst skal der søges i: ");
            string hoestakTekst = Console.ReadLine();

            int antalForekomster = 0;
            Console.WriteLine($"Ordet ‘{soegeWord}’ forekommer {WordCount(soegeWord, hoestakTekst)} gange.");
        }

        static int WordCount(string ord, string tekst)
        {
            int count = 0;
            int index = 0;

            while ((index = tekst.IndexOf(ord, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += ord.Length;
            }
            return count;
        }
    }
}
