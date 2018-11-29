using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_main_course
{
    public class CustomList<T> : IEnumerable<T> // наслідуємо інтерфейс перечислення - перерахування щоб реалізувати енумератор і ітератор
    {

        // вертає всю колекцію щоб можна було по індексу знайти кожен елемент і застосувати ітератор
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetByIndex(i);
        }

        System.Collections.IEnumerator  System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // енумертор - доступ до кожного члена колекції
        }
        //-------------------------------------------------------------------
        private class Node 
        {
            public T Item { get; set; }
            public Node Prev { get; set; }
            public Node(T item)
            {
                Item = item;
            }

        }

        public CustomList()
        {
        }

        private Node Top
        {
            get;
            set;
        }

        public int Count
        {
            get;
            private set;
        }

        public void Add(T value)
        {
            Node node = new Node(value);
            node.Prev = Top;
            Top = node;
            Count++;
        }


        public T GetByIndex(int index) // вертає елемент по індексу 
        {

            if (Top == null)
                throw new Exception("List is empty");
            T res = default(T);

            Node ind = Top;

            for (int i = 0; i<  Count - index ; i++)
            {
                res = ind.Item;
                ind = ind.Prev;

            }
            return res;

        }
      

        public T Pop()
        {

            if (Top == null)
                throw new Exception("List is empty");
            
                T res = Top.Item;
                Top = Top.Prev;
                Count--;

            
            return res;
        }

        
    }
}