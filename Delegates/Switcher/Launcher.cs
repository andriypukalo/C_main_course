using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    class Launcher
    {

        AlfaNumericCollector alpha;
        StringCollector str;

        bool isBreak = false;

        public bool checkStringForNum(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsDigit(value[i]))
                {
                    return true;
                }

            }
            return false;
        }

        public Launcher()
        {
            alpha = new AlfaNumericCollector();
            str = new StringCollector();

            DataReader Data = new DataReader();//класс для вводу даних
            Data.StringChanged += Data_StringChanged;

            while (true)
            {
                Console.WriteLine("Enter string or y for exit: ");
                Data.NewString = Console.ReadLine();
                if (isBreak)
                    break;
            }
            alpha.Show();
            str.Show();
        }

        private void Data_StringChanged(object sender, EventArgs e)
        {
            string value = ((DataReader)sender).NewString;

            if (value == "y")
            {
                isBreak = true;
                return;
            }

            if (checkStringForNum(value))
            {
                alpha.Add(value);
            }
            else
            {
                str.Add(value);
            }
        }
    }
}