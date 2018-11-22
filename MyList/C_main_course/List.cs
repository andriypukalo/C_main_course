using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_main_course
{

    public class List<T>
    {
        private class Node
        {
            public T Item { get; set; }
            public Node Prev { get; set; }
            public Node(T item)
            {
                Item = item;
            }
        }

        public List()
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