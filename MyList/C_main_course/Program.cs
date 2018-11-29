using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_main_course
{
    class Program
    {

        static void Main(string[] args)
        {
            CustomList<String> MyList = new CustomList<string>();
            MyList.Add("Andriy");
            MyList.Add("Serhiy");
            MyList.Add("Ivan");
            MyList.Add("Pavlo");
            MyList.Add("Oleksandr");
            MyList.Add("Mary");

            Console.WriteLine("\nTest Find by index in MyList:\n");
            Console.WriteLine("Value of index(5) =  " + MyList.GetByIndex(5));

            Console.WriteLine("\nTest foreach for MyList:\n");
            foreach (string s in MyList)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();

        }
    }
}