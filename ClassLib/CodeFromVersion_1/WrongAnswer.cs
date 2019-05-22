namespace IrregularVocabularyTest
{
    public class WrongAnswer
    {
        public WrongAnswer()
        {
            EnteredSimplePast     = string.Empty;
            EnteredPastParticiple = string.Empty;
            EnteredTranslation    = string.Empty;
        }

        public string Infinitiv             { get; set; }
        public string EnteredSimplePast     { get; set; }
        public string EnteredPastParticiple { get; set; }
        public string EnteredTranslation    { get; set; }
        public int    Key                   { get; set; }
    }
}