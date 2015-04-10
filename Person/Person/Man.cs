using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
   public class Man : Person
    {
        private string strength;
        private int age;
        private int stamina;
        string line;

        public string Strength {get; set;}

        public int Age { get; set; }
        public int Stamina { get; set; }

        public Man (int id, string name, string str, int age, int stam)
        {
            this.Id = id;
            this.Name = name;
            this.Strength = str;
            this.Age = age;
            this.Stamina = stam;
        }
        public Man()
        {
            this.Id = 0;
            this.Name = null;
            this.Strength = null;
            this.Age = 0;
            this.Stamina = 0;
        }
        public override string WriteCSV(Person per)
        {
            return line = Convert.ToString((per.GetType() + "," + per.Id + "," + per.Name + "," + ((Man)per).Strength + "," + ((Man)per).Age + "," + ((Man)per).Stamina));
        }
    }
}
