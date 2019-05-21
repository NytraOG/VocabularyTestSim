using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrregularVocabularyTest
{
    public class VocableProvider
    {
        private readonly string[] inifnitivArray;
        public string[] simplePastArray;
        public string[] pastParticibleArray;
        public string[] deutscheÜbersetzung;

        public VocableProvider()
        {
            inifnitivArray = new[]
                             {
                                 "be", "beat","become","begin","bend","bet","bid","bind","bite","bleed","blow","break","breed","bring","broadcast","build",
                                 "burn","burst","buy","cast","catch","choose","cling","come","cost","cut","deal","dig","dive","do","draw","dream","drink"
                             };
            simplePastArray = new[]
                              {
                                  "was","beat","became","began","bent","bet","bid","bound","bit","bled","blew","broke","bred","brought","broadcast","built",
                                  "burnt","burst","bought","cast","caught","chose","clung","came","cost","cut","dealt","dug","dove","did","drew","dreamt","drank"
                              };
            pastParticibleArray = new[]
                                  {
                                      "been","beaten","become","begun","bent","bet","bidden","bound","bitten","bled","blown","broken","bred","brought","broadcast","built",
                                      "burnt","burst","bought","cast","caught","chosen","clung","come","cost","cut","dealt","dug","dived","done","drawn","dreamt","drunk"
                                  };
            deutscheÜbersetzung = new[]
                                  {
                                      "sein","schlagen","werden","beginnen","biegen","wetten","jemanden bitten","binden","beißen","bluten","blasen","kaputtgehen","züchten",
                                      "bringen","übertragen","bauen","brennen","platzen","kaufen","werfen","fangen","wählen","festhalten","kommen","kosten","schneiden",
                                      "verhandeln","graben","tauchen","tun","zeichnen","träumen","trinken"
                                  };
        }

        public Dictionary<int,string> GetVocablesForTest()
        {
            var rng = new Random();

            var infinitive = new Dictionary<int,string>();
            
            for (int i = 0; i < 10; i++)
            {
                var number = rng.Next(0, 33);
                
                if (infinitive.ContainsValue(inifnitivArray[number]))
                {
                    i--;
                    continue;
                }

                infinitive.Add(number, inifnitivArray[number]);
            }

            return infinitive;
        }
    }
}
