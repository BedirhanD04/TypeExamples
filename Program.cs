using System;
using System.IO;

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

            // 1. RETTELSE: WordCount returnerer nu Result<int>!
            Result<int> result = WordCount(soegeWord, hoestakTekst);

            // 2. RETTELSE: Først tjekker vi, om der er fejl
            if (!result.IsSuccess)
            {
                Console.WriteLine($"[FEJL]: {result.ErrorMessage}");
            }
            else
            {
                int antalForekomster = result.Value;
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
                    }
                }
            }
            Console.WriteLine("\n--- Dynamic Test ---");
            Console.WriteLine(ProcessDynamic(50));          // outPut: 150
            Console.WriteLine(ProcessDynamic("C# Kursus"));   // outPut: Følgende tekst modtaget: C# Kursus
            Console.WriteLine(ProcessDynamic(true));        // OutPut: False

            Console.WriteLine("\nProgram afsluttet. Tryk på en tast for at afslutte...");
            Console.ReadKey();
        }

        
        static Result<int> WordCount(string ord, string tekst)
        {
            if (string.IsNullOrEmpty(ord) || string.IsNullOrEmpty(tekst))
            {
                return Result<int>.Failure("Ord eller tekst kan ikke være tomme.");
            }
            if (string.IsNullOrWhiteSpace(tekst))
            {
                return Result<int>.Failure("Teksten der skal søges i må ikke være tom!.");
            }

            int count = 0;
            int index = 0;
            while ((index = tekst.IndexOf(ord, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += ord.Length;
            }
            return Result<int>.Success(count);
        }

        static bool? checkCount(int count)
        {
            if (count == 0) return null;
            if (count < 10) return false;
            return true;
        }

        static dynamic ProcessDynamic(dynamic input)
        {
            if (input is int number)
            {
                return number + 100;
            }
            else if (input is string text)
            {
                return "Følgende tekst modtaget: " + text;
            }
            else
            {
                return false;
            }

            /*
            Selvom dynamic giver stor fleksibilitet ved at omgå typetjek under opsamlingen, 
            er der tre primære grunde til, at det ofte betragtes som usikkert eller farligt i praksis. 
            For det første er der ingen type-sikkerhed ved compile-time, hvilket betyder, 
            at C#-compileren ikke kan opdage fejl på forhånd, og hvis en metode eller egenskab ikke eksisterer, 
            vil programmet crashe med en kørselstidsfejl undervejs. For det andet er der ingen IntelliSense eller 
            automatisk kodefuldførelse i udviklingsmiljøet, fordi typen ikke er kendt på forhånd, hvilket gør det nemmere at lave fejl. 
            For det tredje giver det en ydeevneforringelse, 
            fordi .NET-motoren skal bruge ekstra ressourcer på at undersøge typer og finde metoder dynamisk, mens programmet kører.
            */

        }

    }
}