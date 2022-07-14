using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowsable
    {
        public string Site { get; set; }
        public void Browsing (string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
