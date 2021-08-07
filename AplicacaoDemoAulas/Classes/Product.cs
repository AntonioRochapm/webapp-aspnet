using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoDemoAulas.Classes
{
    public class Supplier 
    { 
        public int ID { get; set; }
        public string Nome { get; set; }

    }
    public class Category
    {
        public int ID { get; set; }
        public string Designacao { get; set; }       
    }

    public class Product
    {
        public int ID { get; set; }
        public string Designacao { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public string QtByUnidade { get; set; }
        public decimal Preco { get; set; }
        public short QtdStock { get; set; }
        public short QtdOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Descontinuado { get; set; }

    }
}