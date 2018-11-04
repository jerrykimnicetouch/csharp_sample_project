using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JerryKim;
using System.Linq;
using System.Collections.Generic;

namespace JerryKimTest
{
    [TestClass]
    public class UnitTest
    {
       [TestMethod]
        public void Test_HasIncrementalDigitsMethod()
        {
            Random random = new Random();
            PinNumbersGenerator testPN = new PinNumbersGenerator(1000, random);
            var allHasIncrementalDigits = 1;

            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            if( (i<j && j<k) && k<l)
                            {
                                if (!testPN.hasIncrementalDigits(i * 1000 + j * 100 + k * 10 + l)) allHasIncrementalDigits = -1;
                            }
                        }
                    }
                }
            }
            Assert.AreEqual(1, allHasIncrementalDigits);
        }
        [TestMethod]
        public void Test_HasRepeatedDigitMethod()
        {
            Random random = new Random();
            PinNumbersGenerator testPN = new PinNumbersGenerator(1000, random);
            var allHasRepeatedDigit = 1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            if( i == j || i == k || i == l || j == k || j == l || k == l )
                            {
                                if (!testPN.hasRepeatedDigit(i * 1000 + j * 100 + k * 10 + l)) allHasRepeatedDigit = -1;
                            }
                         }
                    }
                }
            }
            Assert.AreEqual(1, allHasRepeatedDigit);
        }
        [TestMethod]
        public void Test_UniquenessInGetPinNumbersMethod()
        {
            Random random = new Random();
            PinNumbersGenerator testPN = new PinNumbersGenerator(1000, random);
            List<string> pinNumbers = testPN.getPinNumbers();

            var grouped = pinNumbers.GroupBy(c => c);
            var totalDuplicate = 1;
            foreach (var grp in grouped)
            {
                var countDuplicate = grp.Count();
                totalDuplicate = totalDuplicate * countDuplicate;
            }
            Assert.AreEqual(1, totalDuplicate);
        }

    }
}
