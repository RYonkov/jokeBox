using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthday
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
    }
}
