using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    public static class Analizator
    {
        // статичний клас що містить метод перевірки чи є у стрічці - цифри
        public static bool CheckStringForNum(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsDigit(value[i]))
                    return true;
            }
            return false;
        }
    }
}
