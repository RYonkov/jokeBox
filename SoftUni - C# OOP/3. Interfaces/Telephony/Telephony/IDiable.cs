using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IDiable
    {
        public string number { get; set; }
        public void Dialing(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
