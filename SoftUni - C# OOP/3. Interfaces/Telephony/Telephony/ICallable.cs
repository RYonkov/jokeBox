using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        public string number { get; set; }
        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        
    }
}
