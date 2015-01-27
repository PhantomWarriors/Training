using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using MyList;

namespace MyListUniTest
{
    [TestFixture]
    public class UnitTest1
    {
        

        [Test]
        public void AddTest()
        {
            mList lst = new mList();
            lst.Add(5);
            int expected = 5;
            NUnit.Framework.Assert.AreEqual(expected, lst[0]);
        }

        [Test]
        public void CountTest()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(5);
            lst.Add(5);
            int expected = 3;
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }

        [Test]
        public void RemoveTest()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(5);
            int expected = 2;
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }

        [Test]
        public void SortTest()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(4);
            lst.Add(3);
            lst.Add(2);
            lst.Add(1);

            mList lst2 = new mList();
            lst2.Add(1);
            lst2.Add(2);
            lst2.Add(3);
            lst2.Add(4);
            lst2.Add(5);


            lst.Sort();
            //NUnit.Framework.CollectionAssert.AreEqual(lst, lst2);

            for (int i = 0; i < 5; i++)
            {
                NUnit.Framework.Assert.AreEqual(lst[i], lst2[i]);
            }
        }

         [Test]
        public void ClearTest()
        {
            mList lst = new mList();
            lst.Add(5);
            lst.Add(4);
            lst.Add(3);
            lst.Add(2);
            lst.Add(1);
            int expected = 0;
            lst.Clear();
            NUnit.Framework.Assert.AreEqual(expected, lst.Count());
        }


         public void ReverseTest()
         {
             mList lst = new mList();
             lst.Add(5);
             lst.Add(4);
             lst.Add(3);
             lst.Add(2);
             lst.Add(1);

             mList lst2 = new mList();
             lst2.Add(1);
             lst2.Add(2);
             lst2.Add(3);
             lst2.Add(4);
             lst2.Add(5);


             lst2.Reverse();
             //NUnit.Framework.CollectionAssert.AreEqual(lst, lst2);

             for (int i = 0; i < 5; i++)
             {
                 NUnit.Framework.Assert.AreEqual(lst[i], lst2[i]);
             }
         }






    }
}
