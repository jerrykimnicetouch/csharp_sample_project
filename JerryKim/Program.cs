using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerryKim
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            PinNumbersGenerator png = new PinNumbersGenerator(1000, random);
            List<string> pinNumbers = png.getPinNumbers();
            Console.WriteLine(" List of PIN Numbers:" + "\r\n");
            foreach (string pinNumber in pinNumbers)
            {
                Console.WriteLine(" "+ pinNumber);
            }
            Console.WriteLine("\r\n" + " Total Count: " + pinNumbers.Count);
            Console.ReadLine();
        }

    }
}
