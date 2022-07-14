using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] inputSites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ICallable smartphone = new Smartphone();
            IDiable stationaryPhone = new StationaryPhone();
            IBrowsable smartphone1 = new Smartphone();

            foreach (string element in input)
            {
                if (!isValid(element))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (element.Length == 7)
                {
                    stationaryPhone.Dialing(element);
                }
                else if (element.Length == 10)
                {
                    smartphone.Calling(element);
                }
            }

            for (int i = 0; i < inputSites.Length; i++)
            {
                if (hasDigit(inputSites[i]))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone1.Browsing(inputSites[i]);
                }
            }
        }

        static bool isValid(string phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!Char.IsDigit(phoneNumber[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static bool hasDigit(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (Char.IsDigit(site[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
