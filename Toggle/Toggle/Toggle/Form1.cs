using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toggle
{
    public partial class Form1 : Form
    {
            Random random = new Random();
            int r, value, attempt;
            string result;
            int sum;
            int amount, x,y;
            int[,] arr = new int[4, 4];


        public Form1()
        {
            InitializeComponent();

            for (int i =0; i<4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    r = random.Next(1, 50);
                    value = (int)Math.Pow(-1, r);
                    this.Controls.Add(new Toggle(i, j, value)); 
                }
            }
            foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            {
                toggles.Click += new System.EventHandler(this.Toggles_Click);
            }

        }
        private void Toggles_Click(object sender, EventArgs e)
        {
            Toggle b = (Toggle)sender;
            int x = b.IPosition;
            int y = b.JPosition;

            foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            {
                if (toggles.JPosition==y || toggles.IPosition==x)
                {
                    if (toggles.value < 0)
                    {
                        toggles.Width = 100;
                        toggles.Height = 50;
                        toggles.Location = new Point(toggles.Location.X - 25, toggles.Location.Y + 25);
                        toggles.value = 1;
                    }
                    else
                    {
                        toggles.Width = 50;
                        toggles.Height = 100;
                        toggles.Location = new Point(toggles.Location.X + 25, toggles.Location.Y - 25);
                        toggles.value = -1;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] array = new int[4, 4];
            int i = 0;

            foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            {
                int x = toggles.JPosition;
                int y = toggles.IPosition;
                array[x, y] = toggles.value;
                if (toggles.value==1)
                {
                    i++;
                }
            }
            SolvePuzzle(array, ref result, ref attempt,i);
            textBox1.Text = result;
            result = null;
            attempt = 0;
        }

        private void SolvePuzzle (int [,] array,ref string result, ref int attempt, int sum)
        {
            int[,] keyArray = new int[4, 4];
            if (sum >= 5)
            {
                array = Calculation(ref array, ref result, ref amount, ref x, ref y);
            }


             for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                keyArray[i, j] = array[i,j];
                                if (keyArray[i, j]==1)
                                        {
                                            result = result + j+","+i+"; ";
                                        }
                            }
                        }

            result = result + "Step";

            for (int i=0; i<4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    if (keyArray[i, j] == 1)
                    {

                        for (int ki = 0; ki < 4; ki++)
                        {
                            for (int kj = 0; kj < 4; kj++)
                            {
                                if (ki == i || kj == j)
                                {
                                    array[ki, kj] = array[ki, kj] * (-1);
                                }
                            }
                        }

                    }

                }
            }

            attempt++;
            if (attempt != 2)
            {
                SolvePuzzle(array,ref result, ref attempt,0);
            }

        }


        private int[,] Calculation (ref int [,] arr, ref string result, ref int amount, ref int x, ref int y)
        {
            int count=0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = arr[i, j];
                    if (arr[i, j] == 1)
                    {
                        count++;
                    }
                }
            }

            if (count>=5)
            {
                for (int i=0;i<4;i++)
                {
                    for (int j=0; j<4; j++)
                    {
                        if (arr[i,j]==1 || arr[i,j]==-1)
                        {
                            for (int ik=0; ik<4;ik++)
                            {
                                for (int jk=0; jk<4; jk++)
                                {
                                    if (ik==i||jk==j)
                                    {
                                        sum = sum + arr[ik, jk];
                                    }
                                }
                            }
                            if (sum>amount)
                            {
                                amount = sum;
                                x=i;
                                y=j;
                            }
                           sum = 0;
                        }
                    }

                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == x || j == y)
                        {
                            arr[i, j] = arr[i, j] * (-1);
                        }
                    }
                }
            }


         
          if (count >= 5 && amount !=0)
          {
              result = result + y + "," + x + "; ";
              amount = 0;
              x = 0;
              y = 0;
              Calculation(ref arr, ref result, ref amount, ref x, ref y);
          }
          return arr;
        }


    }
}
