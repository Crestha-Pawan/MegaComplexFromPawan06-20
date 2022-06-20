using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Common
{
   public static class CommaSeperatedDigit
    {
        public static string getCommaSeperatedValue(string value)
        {
           
            decimal? amount = value.Split(".")[0].ToDecimal();
            string first = amount.ToString();
            char[] digits = first.ToCharArray();
            digits = newArray(digits);
            first = new string(digits);
            return string.Format("{0}.{1}",first, value.Split(".")[1]);
        }
        public static string getCommaSeperatedValue_addentry(string value)
        {
            
            decimal? amount = value.ToDecimal();
            string first = amount.ToString();
            char[] digits = first.ToCharArray();
            digits = newArray(digits);
            first = new string(digits);
            return string.Format("{0}", first);
        }
        private static char[] newArray(char[] digits)
        {
            List<char> termsList = new List<char>();
            int n = digits.Length;
            for (int i = n; i > 0; i--)
            {
                if (i > 2)
                {
                    if (i % 2 != 0)
                    {
                        if (i != n)
                        {
                            termsList.Add(',');
                        }
                    }
                }
                termsList.Add(digits[n - i]);
            }
            return termsList.ToArray();
        }
    }
}
