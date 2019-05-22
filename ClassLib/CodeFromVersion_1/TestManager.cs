using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrregularVocabularyTest
{
    public class TestManager
    {
        public List<WrongAnswer> ListOfWrongAnswers { get; set; } = new List<WrongAnswer>();
        public double Points { get; set; }
        public double Grade { get; set; }
        public void DoTheTest(VocableProvider vocableprovider, Dictionary<int,string> generatedVocables)
        {
            StartSequence();

            foreach (var vocable in generatedVocables)
            {
                Console.Clear();
                Console.WriteLine("Please type down the missing forms of the irregular verb:\n" +
                                  $"\t{vocable.Value.ToUpper()}");

                var wrongAnswere = new WrongAnswer
                {
                    Key       = vocable.Key,
                    Infinitiv = vocable.Value
                };

                var entry = Console.ReadLine();

                var splitEntry = entry.Split(null);

                var simplePastEntry     = splitEntry[0].ToLower();
                var pastParticipleEntry = splitEntry[1].ToLower();
                var translation         = splitEntry[2].ToLower();

                if (simplePastEntry == vocableprovider.simplePastArray[vocable.Key])
                {
                    Points += 1;
                }
                else
                {
                    wrongAnswere.EnteredSimplePast = simplePastEntry;
                }

                if (pastParticipleEntry == vocableprovider.pastParticibleArray[vocable.Key])
                {
                    Points += 1;
                }
                else
                {
                    wrongAnswere.EnteredPastParticiple = pastParticipleEntry;
                }

                if (translation == vocableprovider.deutscheÜbersetzung[vocable.Key])
                {
                    Points += 1;
                }
                else
                {
                    wrongAnswere.EnteredTranslation = translation;
                }

                if (wrongAnswere.EnteredSimplePast != null || wrongAnswere.EnteredPastParticiple != null || wrongAnswere.EnteredTranslation != null)
                    ListOfWrongAnswers.Add(wrongAnswere);
            }
            Grade = CalculateGrade(Points);

            Console.WriteLine("Great! You finished the Test!" +
                              "Your grade is being calculated...");
            Thread.Sleep(2000);

            Console.Clear();
            Console.WriteLine($"Your grade: {Grade}\n");

            if (ListOfWrongAnswers.Count > 0)
            {
                Console.WriteLine("Your mistakes:\n\n");
                Console.WriteLine("INFINITIV\t| SIMPLE PAST\t| PARTICIPLE\t| TRANSLATION");
                Console.WriteLine("________________|_______________|_______________|_____________");

                foreach (var wrongAnswer in ListOfWrongAnswers)
                {
                    Console.WriteLine($"{wrongAnswer.Infinitiv}\t\t|\t{wrongAnswer.EnteredSimplePast}\t|\t{wrongAnswer.EnteredPastParticiple}\t|\t{wrongAnswer.EnteredTranslation}");
                }
            }
            Console.WriteLine("\n\nPress Enter to continue....");
                              
            Console.ReadKey();
        }

        private void StartSequence()
        {
            Console.WriteLine("In this test you will be given one infinitv at random.\n" +
                              "Then you need to type the SIMPLE PAST form, then the PAST PARTICIPLE and finally the german TRANSLATION.\n" +
                              "Type your answers in one line separated by white spaces and press Enter.\n" +
                              "\nExample Answer: 'taught taught unterrichten'\n");
            Console.WriteLine("\nPress Enter, if you are ready to begin...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Test starts in...");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine(Constants.countDown3);
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine(Constants.countDown2);
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine(Constants.countDown1);
            Thread.Sleep(1000);
        }

        private double CalculateGrade(double points)
        {
            if (points / 30 >= 0.95)
                return 1;
            if (points / 30 >= 0.9)
                return 1.3;
            if (points / 30 >= 0.85)
                return 1.7;
            if (points / 30 >= 0.8)
                return 2;
            if (points / 30 >= 0.75)
                return 2.3;
            if (points / 30 >= 0.7)
                return 2.7;
            if (points / 30 >= 0.65)
                return 3;
            if (points / 30 >= 0.6)
                return 3.3;
            if (points / 30 >= 0.55)
                return 3.7;
            if (points / 30 >= 0.5)
                return 4;

            return 5;
        }
    }
}
