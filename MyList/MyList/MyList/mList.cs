using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
  public  class mList
    {
       private int[] list = new int[50];
       private int i = 0;

        public int this[int index]
        {
            get
             {
                return list[index];
             }

            set
             {
                list[index] = value;
             }
        }

        public void Add (int value)
        {        
            if (list.Length==i)
            {
                Array.Resize(ref list,list.Length+1);
            }
            list[i] = value;
            i++;
        }


        public void Remove (int value)
        {
            int[] newList = new int[50];
            int j = 0;
            for (int i=0; i<list.Length;i++)
            {
                if (list[i] == value)
                    list[i] = 0;
            }

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != 0)
                {
                    newList[j] = list[i];
                    j++;
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = newList[i];
            }
        }


       public void Sort ()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[i])
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

        }

        public void Clear ()
       {
           for (int i = 0; i < list.Length; i++)
           {
               list[i] = 0;
           }
       }


        public int Count ()
        {
            int k = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != 0)
                {
                     k = k+1;
                }
            }
            return k;
        }

        public void Reverse()
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] > list[i])
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

        }

    }
}
