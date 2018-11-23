using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    public class StringCollector
    {
        // клас що містить стрічки без цифр
        List<string> Content;
        public StringCollector()
        {
            Content = new List<string>();
        }

        public void Add(string value)
        {
            Content.Add(value);
        }
        public void Show()
        {
            Console.WriteLine("List without numbers:");
            foreach (string s in Content)
            {
                Console.WriteLine(s);
            }
        }
    }
}
