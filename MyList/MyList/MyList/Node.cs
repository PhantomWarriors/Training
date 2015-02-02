using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Node
    {
        private int data;
        private Node next;

        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node(int value)
        {
            data = value;
            next = null;
        }

    }
}
