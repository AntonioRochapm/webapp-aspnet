using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoDemoAulas.Classes
{
    public class Utilizador
    {
        public string ID { get; }
        public string UTILIZADOR { get; set; }
        public string PALAVRAPASSE { get; set; }
        public string NOME { get; set; }

        public Utilizador()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        public Utilizador(string id)
        {
            this.ID = id;
        }
    }
}