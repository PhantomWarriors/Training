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
            List<int> test = new List<int>();

            test.Add(15);
            test.Remove(15);

            mList listt = new mList();
           
            listt.Add(11);
            listt.Add(12);
            listt.Add(13);
            listt.Reverse();
            test.Add(15);
        }
    }
}
