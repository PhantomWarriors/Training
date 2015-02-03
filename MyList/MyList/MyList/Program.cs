using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            //mList listt = new mList();
           
            //listt.Add(11);
            //listt.Add(12);
            //listt.Add(13);
            //listt.Reverse();
            //listt.AddToStart(11111);

            //Console.WriteLine(listt[0]);

            newMList list = new newMList();

            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Add(4);//идет на следующий

            //list[0] = 15;

            var lst = list;
          list.Reverse();
           // list.Clear();
           // list.Insert(4,10);
           // list.DelFirst();
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);
            Console.WriteLine(list[3]);
            Console.WriteLine(list[4]);
            Console.WriteLine("Количество: "+list.Count());
        }
    }
}
