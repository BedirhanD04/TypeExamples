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
                    Saver saverUser = new UserFolderSave();
                    saverUser.Save("typedemo_02.txt", soegeWord);

                    Saver saverProject = new ProjectFolderSave();
                    saverProject.Save("typedemo_project.txt", soegeWord);
                    Console.ReadKey();

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
