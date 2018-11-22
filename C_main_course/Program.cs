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
            List<String> MyList = new List<string>();
            MyList.Add("Andriy");
            MyList.Add("Serhiy");
            MyList.Add("Ivan");



            while (MyList.Count > 0)
            {
                Console.WriteLine(MyList.Pop());
            }


        }
    }
}