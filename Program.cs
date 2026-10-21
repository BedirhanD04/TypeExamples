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

            int antalForekomster = WordCount(soegeWord, hoestakTekst);
            bool? countState = checkCount(antalForekomster);
            if (countState == null)
            {
                Console.WriteLine("Det søgte ord findes ikke i den angivne tekst.");
            }
            else
            {
                Console.WriteLine($"Ordet ‘{soegeWord}’ forekommer {antalForekomster} gange.");
                if ((bool)countState)
                {
                    // Source - https://stackoverflow.com/a/19329696
                    // Posted by xxbbcc, modified by community. See post 'Timeline' for change history
                    // Retrieved 2026-10-18, License - CC BY-SA 3.0

                    //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                    string fileName = Path.Combine(path, @"..\..\..\typedemo_02.txt");

                    System.IO.File.WriteAllText(fileName, hoestakTekst);

                }
            }
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
        static bool? checkCount(int count)
        {
            if (count == 0)
            {
                return null;
            }
            else if (count < 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
