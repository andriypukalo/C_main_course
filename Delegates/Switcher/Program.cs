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
        static void Main(string[] args)
        {
            Launcher Start = new Launcher();
            Console.ReadKey();
        }       
    }
}