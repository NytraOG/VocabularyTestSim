using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrregularVocabularyTest
{
    public class WrongAnswer
    {
        public string Infinitiv { get; set; }
        public string EnteredSimplePast { get; set; }
        public string EnteredPastParticiple { get; set; }
        public string EnteredTranslation { get; set; }
        public int Key { get; set; }

        public WrongAnswer()
        {
            EnteredSimplePast     = string.Empty;
            EnteredPastParticiple = string.Empty;
            EnteredTranslation    = string.Empty;
        }
    }
}
