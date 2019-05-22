using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrregularVocabularyTest
{
    class Program
    {
        private static Dictionary<int,string> generatedVocables = new Dictionary<int, string>();
        private static string keyInput;

        static void Main(string[] args)
        {
            //Console.WriteLine(Constants.DisplayName);
            //Thread.Sleep(3000);

            do
            {
                var manager  = new TestManager();
                var provider = new VocableProvider();

                Console.Clear();
                MenüTextAnzeigen();
                keyInput = Console.ReadLine();

                switch (keyInput)
                {
                    case "g":
                        generatedVocables = provider.GetVocablesForTest();
                        Console.WriteLine("Test generated!");
                        break;
                    case "s":
                        if (!generatedVocables.Any()) 
                        {
                            Console.WriteLine("Generate Vocables before starting a Test!");
                            Thread.Sleep(1000);
                            break;
                        }
                        Console.WriteLine("Test started!");
                        Console.Clear();
                        manager.DoTheTest(provider, generatedVocables);
                        Thread.Sleep(1000);
                        break;
                    case "b":
                        break;
                    default:
                        Console.WriteLine("Unbekannte Eingabe");
                        break;
                }
            } while (keyInput != null && keyInput.ToLower() != "b");
        }

        private static void MenüTextAnzeigen()
        {
            Console.WriteLine("Um einen zufälligen Test zu erstellen 'g' eingeben und mit Enter bestätigen.\nUm einen Test durchzuführen 's' eingeben und mit Enter bestätigen.\nUm das Programm zu beenden 'b' drücken und mit Enter bestätigen");
        }
    }
}
