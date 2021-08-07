using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoDemoAulas.Classes
{
    public class Employee
    {
        public string ID { get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public int reportsTo { get; set; }

        public Employee()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        public Employee(string id)
        {
            this.ID = id;
        }
    }
}