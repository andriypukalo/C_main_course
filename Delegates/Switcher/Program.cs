using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    public delegate void MyDelegate(string value);


    class Program
    {
        public static bool checkStringForNum(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsDigit(value[i]))
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            AlfaNumericCollector alpha = new AlfaNumericCollector();
            StringCollector str = new StringCollector();
            MyDelegate Fuction_delegate;

            while (true)
            {

                Console.WriteLine("Enter string or y for exit: ");

                string value = Console.ReadLine();

                if (value == "y")
                {
                    break;
                }

                ///--------------------------------------
                ///
                
                //підписка делегата на метод відповідного класу
                if (checkStringForNum(value))
                {
                    Fuction_delegate = new MyDelegate (alpha.Add);
                }
                else
                {
                    Fuction_delegate = new MyDelegate(str.Add);
                }

                Fuction_delegate(value);
            }
            alpha.Show();
            str.Show();
        }
    }
}
