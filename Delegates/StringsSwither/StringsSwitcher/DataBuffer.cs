using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switcher
{
    public class DataBuffer
    {
        // клас обгортка над колекціями списків стрічок із цифрами і без 
        // містить методи додавання значень у потрібну колекцію і виводу на екран
        private AlfaNumericCollector AlphaNumList; // клас стрічок з цифрами
        private StringCollector AlphaList; // клас просто стрічок

        private DataBuffer()
        {
            AlphaNumList = new AlfaNumericCollector();
            AlphaList = new StringCollector();
        }

        private static DataBuffer instance;

        // шаблон сінглтон 
        public static DataBuffer Instance // для звертання до єдиного екземпляру класу DataBuffer з довыльного мысця програми
        {
            get
            {
                if (instance == null)
                    instance = new DataBuffer();
                return instance;
            }
        }


        public void AddToAlphaList(string value)
        {
            AlphaList.Add(value);
        }

        public void AddToAlphaNumList(string value)
        {
            AlphaNumList.Add(value);
        }

        public void ShowAlphaList()
        {
            AlphaList.Show();
        }

        public void ShowAlphaNumList()
        {
            AlphaNumList.Show();
        }
    }
}
