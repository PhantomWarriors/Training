using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Woman : Person
    {
        int beauty;
        string eyeColor;
        string smile;
        string line;

        public int Beauty { get; set; }
        public string EyeColor { get; set; }
        public string Smile { get; set; }
        public Woman(int id, string name, int bt, string color, string sm)
        {
            this.Id = id;
            this.Name = name;
            this.Beauty = bt;
            this.EyeColor = color;
            this.Smile = sm;
        }
        public Woman()
        {
            this.Id = 0;
            this.Name = null;
            this.Beauty = 0;
            this.EyeColor = null;
            this.Smile = null;
        }
        public override string WriteCSV(Person per)
        {
            return line = Convert.ToString((per.GetType() + "," + per.Id + "," + per.Name + "," + ((Woman)per).Beauty + "," + ((Woman)per).EyeColor + "," + ((Woman)per).Smile));
        }
    }
}
