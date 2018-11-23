using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    public class AlfaNumericCollector
    {
        // клас що містить стрічки з цифрами
        List<string> Content;
        public AlfaNumericCollector()
        {
            Content = new List<string>();
        }

        public void Add(string value)
        {
            Content.Add(value);
        }

        public void Show()
        {
            Console.WriteLine("List with numbers:");
            foreach (string s in Content)
            {
                Console.WriteLine(s);
            }
        }
    }
}