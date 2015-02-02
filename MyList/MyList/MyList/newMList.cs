using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class newMList
    {
        private int size=0;
        private Node first;
        private Node last;

        public Node First
        {
            get { return first; }
            set { first = value; }
        }
        public Node Last
        {
            get { return last; }
            set { last = value; }
        }
        public void Add(int val)
        {
            Node current = new Node(val);
            if (first==null)
            {
                first = current;
                last = current;
            }
            else
            {
                last.Next = current;
                last = current;
            }
        }

        public int this [int index]
        {
            get
            {
                return this.GetItem(index);
            }
        }

        public int GetItem (int pos)
        {
            int counter = 0;
            Node position = first;
            int result = 0;
            while (position!=null)
            {
                if (counter==pos)
                {
                    result = position.Data;
                    break;
                }
                counter++;
                position = position.Next;
            }
            return result;
        }

        public int Count()
        {
            int counter = 0;
            Node position = first;
            while (position!=null)
            {
                counter++;
                position = position.Next;
            }
            return counter;
        }


        public void Remove(int value)
        {

        }

    }
}
