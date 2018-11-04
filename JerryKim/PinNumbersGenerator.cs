using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerryKim
{
    public class PinNumbersGenerator
    {
        List<string> pinNumbers = new List<string>();

        public PinNumbersGenerator(int countRequired, Random random)
        {
            PrintNumbers(countRequired, random);
        }

        public void PrintNumbers(int countRequired, Random random)
        {
            int countAddedNumber = 0;
            while( countAddedNumber < countRequired)
            {
                int unFiltered = GenerateRandomNumber(random);
                if (!hasRepeatedDigit(unFiltered)) 
                {
                    if (!hasIncrementalDigits(unFiltered))
                    {
                        string filtered = unFiltered.ToString("D4");
                        if (!this.pinNumbers.Contains(filtered))
                        {
                            this.pinNumbers.Add(filtered);
                            countAddedNumber++;
                        }
                    }
                }
            }
        }

        static int GenerateRandomNumber(Random random)
        {
            return random.Next(0, 9999);
        }

        public bool hasIncrementalDigits(int number)
        {
            int[] toArray = number.ToString("D4").ToCharArray().Select(Convert.ToInt32).ToArray();
            int isIncreament = 1;
            for (int i = toArray.Length - 1; i > 0; i--)
            {
                isIncreament = isIncreament * (toArray[i] - toArray[i - 1]);
            }
            return isIncreament > 0;
        }

        public bool hasRepeatedDigit(int number)
        {
            int[] toArray = number.ToString("D4").ToCharArray().Select(Convert.ToInt32).ToArray();
            for (int i = 0; i < toArray.Length; i++)
            {
                for (int j = i + 1; j < toArray.Length; j++)
                {
                    if (toArray[i] == toArray[j]) return true;
                }
            }
            return false;
        }

        public List<string> getPinNumbers()
        {
            return this.pinNumbers;
        }
    }
}
