using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
   public class newMList
    {
        private int size=0;
        private newMList first;
        private newMList last;
        private int data;
        private newMList next;
        private newMList previous;

        public newMList First
        {
            get { return first; }
            set { first = value; }
        }
        public newMList Last
        {
            get { return last; }
            set { last = value; }
        }
        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public newMList Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
        public newMList Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
        public newMList(int value)
        {
            data = value;
            next = null;
            previous = null;
        }
        public newMList(int value, newMList res)
        {
            data = value;
            next = res;
            previous = null;
        }
        public newMList()
        {
            data = 0;
            next = null;
            previous = null;
        } 
        public int this [int index]
        {
            get
            {
                //if (index > size)
                // throw new IndexOutOfRangeException();
                return this.GetValue(index);
            }
             set
            {
                SetValue(index, value);
            }
        }
        public int GetValue (int pos)
        {
            int counter = 0;
            newMList position = first;
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
        public void SetValue(int pos, int val)
        {
            int counter = 0;
            newMList position = first;
            while (position != null)
            {
                if (counter == pos)
                {
                    position.Data = val;
                    break;
                }
                counter++;
                position = position.Next;
            }
        }
        public void Add(int value)
        {
            newMList current = new newMList(value);
            if (first == null)
            {
                first = current;
                last = current;
            }
            else
            {
                last.Next = current;
                var temp = last;
                last = current;
                last.Previous = temp;
            }
            size++;
        }
        public int Count()
        {
            int counter = 0;
            newMList position = first;
            while (position!=null)
            {
                counter++;
                position = position.Next;
            }
            return counter;
        }
        public void Remove(int value)
        {
            var temp = first;
            newMList current = null;
            int k = 0;
            while(temp!=null)
            {
                if (temp.Data == value && temp.Data != last.Data && temp.Data != first.Data&& k==0)
                {
                    current.Next = temp.Next;
                    temp = temp.Next;
                    size = size - 1;
                    k++;
                }
                else if(temp.Data==value && temp.Data==last.Data&& k==0)
                {
                    last = temp.Previous;
                    last.Next = null;
                    size = size - 1;
                    k++;
                    break;
                }
                current = temp;
                temp = temp.Next;
                if (first.Data == value&& k==0 )
                {
                    k++;
                    current = temp;
                    first = current;
                    current.Previous = null;
                    temp = temp.Next;
                    size = size - 1;
                }
            }

         }
        public void Clear()
        {
            newMList temp = first;
            newMList current=null;

            while (temp!=null)
            {
                current = temp;
                temp = temp.Next;
                current = null;

            }
            last = null;
            first = null;
            size=0;
        }
        public void Delete(int position)
        {
            var temp = first;
            newMList current = null;
            int k = 0;
            int counter = 0;
            while (temp != null)
            {
                if (position == 0 && k==0)
                {
                    this.DelFirst();
                    k++;
                }
                else if (position == size-1)
                {
                    last = last.Previous;
                    last.Next = null;
                    size = size - 1;
                    k++;
                    break;
                }
                else if (position == counter)
                {
                    current.Next = temp.Next;
                    temp = temp.Next;
                    size = size - 1;
                }
                current = temp;
                temp = temp.Next;
                counter++;
            }
        }
        public void Insert (int position, int value)
        {
            var temp = first;
            newMList current = null;
            int counter = 0;
            int k=0;
            while (temp!=null)
            {
                if (position == 0 && k == 0)
                {
                    this.AddToStart(value);
                    k++;
                }
                else if (position==counter)
                {
                    current = new newMList(value);
                    current.Next = temp;
                    current.Previous = temp.Previous;
                    temp.Previous = current;
                    var tempPrevios = current.Previous;
                    tempPrevios.Next = current;
                    temp = current;
                    size++;
                }
                else if (counter == size-1  && position==size)
                {
                    current = new newMList(value);
                    current.Next = null;
                    current.Previous = temp;
                    temp.Next = current;
                    last = current;
                    size++;
                    break;
                }
                current = temp;
                temp = temp.Next;
                counter++;
            }
        }
        public void AddToStart(int value)
        {
            var temp = first;
            newMList current = null;
            current = new newMList(value);
            current.Next = temp;
            first = current;
            temp.Previous=first;
            temp = first;
            size++;
        }
        public void DelFirst()
        {
            first = first.Next;
            first.Previous = null;
            size = size - 1;
        }

        public void Sort()
        {
           for (int i = 0; i < size; i++)
           {
               for (int j = i + 1; j < size; j++)
               {
                   if (this[j] < this[i])
                   {
                       var temp = this[i];
                       this[i] = this[j];
                       this[j] = temp;
                    }
                }
           }
        }
        public void Reverse()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (this[j] > this[i])
                    {
                        var temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }



           
        }
       }


/*

 

Node[0]: Data=1; Next= Node[1], Previous=null
Node[1]: Data=2; Next= Node[2], Previous=Node[0]
Node[2]: Data=3; Next= Node[3], Previous=Node[1]
Node[3]: Data=4; Next= null,    Previous=Node[2]
*/

/*

1. first=last= current;
2. last.next=current; last.previous=last; last=current;
3. last.next=current; last=current;
*/