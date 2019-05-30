using System;

namespace ClassLib.Models
{
    public class TestModel
    {
        public TestModel()
        {
            Oid = Guid.NewGuid().ToString();
        }

        public  string   Oid                      { get; }
        private DateTime StartZeitpunkt           { get; set; }
        private DateTime EndZeitpunkt             { get; set; }
        public  string   Grade                    { get; set; }
        public  double   CorrectAnswerePercentage { get; set; }
        public  double   Runtime                  => (EndZeitpunkt - StartZeitpunkt).TotalMinutes;

        public void CalculateCorrectAnswerePercentage()
        {
        }

        public void CalculateGrade()
        {
        }

        public void TestStarten()
        {
            StartZeitpunkt = DateTime.Now;
        }

        public double TestBeenden()
        {
            EndZeitpunkt = DateTime.Now;

            return Runtime;
        }
    }
}