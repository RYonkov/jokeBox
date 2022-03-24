using System;
using System.Linq;

namespace Exercising
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "Radoslav";
            word = string.Join("", word.Reverse());
            Console.WriteLine(word);

            char[] newPass = word.Where((symbol, index) => index%2!=0).ToArray();
            word = new string(newPass);
            Console.WriteLine(word);
            Console.WriteLine(String.Join("", newPass));
        }
    }
}
