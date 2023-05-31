using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Alcohol
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
    }
    internal class Currency
    {
        public int ID { set; get; }
        public string table { get; set; }       // typ tabeli 
        public string currency { get; set; }    // nazwa waluty 
        public string code { get; set; }        // kod walutowy
        public List<Rate> rates { get; set; }   // lista kursów poszczególnych walut w tabeli 

    }

    public class Rate
    {
        public int rateID { get; set; }
        public float mid { get; set; } // kurs średni {tabela A i tabela B}
        public float bid { get; set; } // kurs kupna {tabela C}
        public float ask { get; set; } // kurs sprzedaży {tabela C}
        public string effectiveDate { get; set; }  // data publikacji 

    }
}
