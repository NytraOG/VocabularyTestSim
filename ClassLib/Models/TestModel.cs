using System;
using System.Collections.Generic;

namespace ClassLib.Models
{
    public class TestModel
    {
        public TestModel(List<VokabelModel> zuTestendeVokabeln)
        {
            ZuTestendeVokabeln = zuTestendeVokabeln;
            Antworten          = new List<AntwortenModel>();
        }

        public  List<VokabelModel>   ZuTestendeVokabeln { get; set; }
        public  List<AntwortenModel> Antworten          { get; set; }
        private DateTime             StartZeitpunkt     { get; set; }
        private DateTime             EndZeitpunkt       { get; set; }
        public  double               Testdauer          => (EndZeitpunkt - StartZeitpunkt).TotalMinutes;

        public void TestStarten()
        {
            StartZeitpunkt = DateTime.Now;
        }

        public double TestBeenden()
        {
            EndZeitpunkt = DateTime.Now;

            return Testdauer;
        }
    }
}