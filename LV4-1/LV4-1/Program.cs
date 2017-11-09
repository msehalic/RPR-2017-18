using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace V4
{
    class Program
    {
        TextBox textBox1;
        static void Main(string[] args)
        {
            Form form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(400, 500);
            form.MaximumSize = form.Size;
            form.MinimumSize = form.Size;
            form.MaximizeBox = false;
            //form.Icon = Properties.Resources.Banka;
            form.Text = "Digitron";
            form.BackColor = Color.White;
            form.ForeColor = Color.Black;
            form.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            form.Padding = new Padding(5, 5, 5, 5);
            string[] operatori = new string[15] { "1", "2", "3", "+", "4", "5", "6", "-", "7", "8", "9", "*", "0", "=", "/" };
            int brojac = 0;

            TextBox textBox1 = new TextBox();
            textBox1.Size = new Size(300, 300);
            textBox1.Location = new Point(50, 20);
            form.Controls.Add(textBox1);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Button button = new Button();
                    button.Location = new Point(35 + i * 80, 70 + j * 100);
                    button.Text = operatori[brojac];
                    button.Size = new Size(70, 70);
                    if (j == 3 && i == 1)
                    {
                        button.Size = new Size(140, 70); //operator =
                        i++;
                        brojac--;
                    }
                    brojac++;
                    if (i == 3 && j == 3) button.Text = "/"; //mrsko mi sredjivati pa ovako
                    form.Controls.Add(button);
                }
            }
            Application.Run(form);
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button1 = sender as Button;
            textBox1.Text += button1.Text;
            //if () //treba validirati
        }


    }
}

