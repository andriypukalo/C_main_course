using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    class Program
    {
        public delegate void MyDelegate(string value);

        static void Main(string[] args)
        {
            DataReader DataReader = new DataReader();//класс для вводу даних
            Console.WriteLine("Enter 1 for Events.");
            Console.WriteLine("Enter 2 for Delegates.");
            Console.WriteLine("Enter 3 for Actions.");
            Console.WriteLine("Choose method:");
            int method = Convert.ToInt16(Console.ReadLine());

            if (method == 1) // через події Event
              DataReader.StringChanged += Data_StringChanged; // підписуемся на подію, коли вводиться нова стрічка даних
            MyDelegate FuctionDelegate; // делегат 
            Action<string> Action; // Action

            while (true)
            {
                if (!DataReader.AddString()) // ввід стрічки з клавіатури , якщо "y" то метод AddString поверне false і цикл припиняється
                    break;

                if (method == 2) // через делегати
                {
                    // в залежності від того чи є у стрічці цифри - делегат підписується на метод додавання в той чи інший масив - колекцію
                    if (Analizator.CheckStringForNum(DataReader.NewString))
                        FuctionDelegate = DataBuffer.Instance.AddToAlphaNumList;
                    else
                        FuctionDelegate = DataBuffer.Instance.AddToAlphaList;
                    // аналізуємо передаємо введене значення, воно аналізується на наявнеість цифр у стрічці і ставиться 
                    // у відповідність делегату - один з методів - записати саме у яку колекцію
                    FuctionDelegate(DataReader.NewString); //виконуємо
                }

                if (method == 3)
                {
                    if (Analizator.CheckStringForNum(DataReader.NewString))
                        Action = DataBuffer.Instance.AddToAlphaNumList;
                    else
                        Action = DataBuffer.Instance.AddToAlphaList;
                    Action(DataReader.NewString);
                }
            }

            // вивід розподілених по класам стрічок 
            DataBuffer.Instance.ShowAlphaNumList();
            DataBuffer.Instance.ShowAlphaList();

            Console.ReadKey();
        }

        // виконується при введені нової стрічки , якщо є підписка через +=
        public static void Data_StringChanged(object sender, EventArgs e)
        {
            string value = ((DataReader)sender).NewString;

            if (Analizator.CheckStringForNum(value))
            {
                DataBuffer.Instance.AddToAlphaNumList(value);
            }
            else
            {
                DataBuffer.Instance.AddToAlphaList(value);
            }
        }
    }
}
