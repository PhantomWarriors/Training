using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.CRUD crud = new Person.CRUD();
           // Person.Person person = new Person.Person();
            List<Person.Person> people = new List<Person.Person>();

            people.Add(new Person.Man(7,"Vasya","Strong",15,7));
            people.Add(new Person.Woman(8,"Olga",10,"Blue","Bu"));
            //crud.OpenConnection();
            //crud.Create(people);
           // crud.Delete(0);
           // crud.Update(1, people[0]);
            people.Add(crud.Read(7));

            

        }
    }
}
