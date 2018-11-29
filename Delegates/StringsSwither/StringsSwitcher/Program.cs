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
            DataReader MyDataReader = new DataReader();//класс для вводу даних
            Console.WriteLine("Enter 1 for Events.");
            Console.WriteLine("Enter 2 for Delegates.");
            Console.WriteLine("Enter 3 for Actions.");
            Console.WriteLine("Enter 4 for Func.");
            Console.WriteLine("Choose method:");
            int method = Convert.ToInt16(Console.ReadLine());

            if (method == 1) // через події Event
              DataReader.StringChanged += Data_StringChanged; // підписуемся на подію, коли вводиться нова стрічка даних

            while (true)
            {
                if (!MyDataReader.AddString()) // ввід стрічки з клавіатури , якщо "y" то метод AddString поверне false і цикл припиняється
                    break;

                if (method == 2) // через делегати
                {
                    MyDelegate FuctionDelegate; // делегат 

                    // в залежності від того чи є у стрічці цифри - делегат підписується на метод додавання в той чи інший масив - колекцію
                    if (Analizator.CheckStringForNum(MyDataReader.NewString))
                        FuctionDelegate = DataBuffer.Instance.AddToAlphaNumList;
                    else
                        FuctionDelegate = DataBuffer.Instance.AddToAlphaList;
                    // аналізуємо передаємо введене значення, воно аналізується на наявнеість цифр у стрічці і ставиться 
                    // у відповідність делегату - один з методів - записати саме у яку колекцію
                    FuctionDelegate(MyDataReader.NewString); //виконуємо
                }

                if (method == 3) // Action
                {
                    UseTrueAction(
                        MyDataReader.NewString, 
                        DataBuffer.Instance.AddToAlphaNumList, // перша акція -> в клас з номерами
                        DataBuffer.Instance.AddToAlphaList); // друга акція -> в клас без номерів
                }

                if (method == 4) // Func
                {
                    UseTrueFunc(MyDataReader.NewString, Analizator.CheckStringForNum); // передаємо сюди стрічку і друг им параметром функцію визначення чи 
                    // чи містить стрічка нумери
                }
            }

            // вивід розподілених по класам стрічок 
            DataBuffer.Instance.ShowAlphaNumList();
            DataBuffer.Instance.ShowAlphaList();

            Console.ReadKey();
        }



        public static void UseTrueFunc(string value, Func<string, bool> func)
        {
            if (func(value))
            {
                DataBuffer.Instance.AddToAlphaNumList(value); // перша акція -> в клас з номерами
            }
            else
            {
                DataBuffer.Instance.AddToAlphaList(value); // друга акція -> в клас без номерів
            }
        }

        public static void UseTrueAction(string value, Action<string> act1, Action<string> act2)
        {
            if (Analizator.CheckStringForNum(value))
            {
                act1(value);
            }
            else
            {
                act2(value);
            }
        }
        // виконується при введені нової стрічки , якщо є підписка через +=
        public static void Data_StringChanged(string newValue)
        {
            if (Analizator.CheckStringForNum(newValue))
            {
                DataBuffer.Instance.AddToAlphaNumList(newValue);
            }
            else
            {
                DataBuffer.Instance.AddToAlphaList(newValue);
            }
        }
    }
}
