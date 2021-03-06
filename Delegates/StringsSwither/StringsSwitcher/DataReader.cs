﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{

    public delegate void MyStringChangedDelegate(string newValue);

    public class DataReader
    {
        // клас для читання значень стрічок з консолі
        // містить подію на зміну значення нової введеноїх стрічки
        // на цю подію можна підписатися і виконувати дії по розподілу
        private static string newString;
        public string NewString// строка шо вводиться
        {
            get
            {
                return newString;
            }
            set
            {
                newString = value;
                OnStringChanged(newString);// що відбувається при зміні данних в стрічці
            }
        }
        public static event MyStringChangedDelegate StringChanged;// подія на ввід строки

        public bool AddString()// додавання нової стрічки з консолі і перевірка чи продовжувати вводити дані чи ні 
        {
            string tempStr;
            Console.WriteLine("Enter string or y for exit: ");
            tempStr = Console.ReadLine();
            if (tempStr == "y")
                return false;
            else
            {
                NewString = tempStr;
                return true;
            }
        }

        public static void OnStringChanged(string newValue)// на цю подію можна підписатися і виконувати дії по розподілу
        {
            if (StringChanged != null)
                StringChanged(newValue);
        }


    }
}
