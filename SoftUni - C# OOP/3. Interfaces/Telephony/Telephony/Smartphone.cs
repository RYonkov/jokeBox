using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string number { get; set ; }
        public string Site { get ; set ; }
    }
}
