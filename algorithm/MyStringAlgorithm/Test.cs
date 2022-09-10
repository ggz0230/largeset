using System;
using System.Collections.Generic;
using System.Text;

namespace MyStringAlgorithm
{
    public class Test
    {

        public int MyAtoi(string s)
        {
            int index = 0, total = 0, sign = 1;
            if (s.Length == 0) return 0;
            while (s[index] == ' ' && index < s.Length - 1) index++;
            switch (s[index])
            {
                case '+': index++; break;
                case '-': index++; sign = -1; break;
            }
            while (index < s.Length)
            {
                int digt = s[index] - '0';
                if (digt < 0 || digt > 9) break;
                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digt)
                {
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }
                total = total * 10 + digt;
                index++;
            }
            return total * sign;
        }

    }
}
