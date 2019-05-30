using System;

namespace ClassLib.Models
{
    public class AntwortenModel
    {
        public AntwortenModel()
        {
            Oid = Guid.NewGuid().ToString();
        }

        public string Oid                   { get; }
        public string Infinitiv             { get; set; }
        public string SimplePastEingabe     { get; set; }
        public string PastParticipleEingabe { get; set; }
        public string ÜbersetzungEingabe    { get; set; }
        public string TestrunOid            { get; set; }
    }
}