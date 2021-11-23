using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMaths
{
    public partial class Calculator : Form
    { //otan patietai ena koumpi praksis ola ta ypoloipa krivontai gia na min yparksei error
        public char symv=' '; //Exw to space stin arxi gia simbolo
        public bool pat=false; //bool metavliti gia na dw an exei patithei simvolo
        public Calculator()
        {
            InitializeComponent();
            label1.Text = "";  //to sigkekrimeno label mou dixnei to apotelesma opote stin arxi tha einai keno
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 2; //prosthetei ton antistoixo arithmo sto richtextbox
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 9;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pat = true;
            symv = '/';
            richTextBox1.Text += '/'; //vazw sto richtextbox opoy exw tis prakseis to simbolo / pou patithike
            button17.Hide(); //krivw ta koumpia praksewn gia na min yparksei error
            button14.Hide();
            button16.Hide();
            button15.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pat = true;
            symv = '-';
            richTextBox1.Text += '-';
            button17.Hide();
            button14.Hide();
            button16.Hide();
            button15.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pat = true;
            symv = '*';
            richTextBox1.Text += '*';
            button17.Hide();
            button14.Hide();
            button16.Hide();
            button15.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            float tel = 0; //to apotelesma twn praksewn
            if (symv == '+') //an to simbolo einai to +
            {
                string[] tmp = richTextBox1.Text.Split('+'); //xwrizw to richtextbox se dio kelia me gnwmona to simvolo +
                if (tmp[1] != "" && tmp[0] != "") //an kai ta dio den einai kena
                {
                    tel = long.Parse(tmp[0]) + long.Parse(tmp[1]); //o arithmos mou prostithetai
                }
                else if(tmp[0]== "" && tmp[1] == "") //an kai ta dio einai kena petaei analogo minima
                {
                    MessageBox.Show("Please write number");
                }
                else 
                {
                    if (tmp[0] != "") //an mono to deutero einai keno, grafw mono to prwto stoixeio
                    {
                        tel = long.Parse(tmp[0]);
                    }
                    else if (tmp[1] != "")
                    {
                        tel = long.Parse(tmp[1]); //an mono to prwto einai keno, grafw mono to deutero stoixeio
                    }
                }
            }
            else if (symv == '-')
            {
                string[] tmp = richTextBox1.Text.Split('-');
                if (tmp[1] != "" && tmp[0] != "")
                {
                    tel = long.Parse(tmp[0]) - long.Parse(tmp[1]);
                }
                else if (tmp[0] == "" && tmp[1] == "")
                {
                    MessageBox.Show("Please write number");
                }
                else
                {
                    if (tmp[0] != "")
                    {
                        tel = long.Parse(tmp[0]);
                    }
                    else if (tmp[1] != "")
                    {
                        tel = -long.Parse(tmp[1]);
                    }
                }
            }
            else if (symv == '*')
            {
                string[] tmp = richTextBox1.Text.Split('*');
                if (tmp[1] != "" && tmp[0] != "")
                {
                    tel = long.Parse(tmp[0]) * long.Parse(tmp[1]);
                }
                else if (tmp[0] == "" && tmp[1] == "")
                {
                    MessageBox.Show("Please write number");
                }
                else
                {
                    if (tmp[0] != "")
                    {
                        tel = long.Parse(tmp[0]);
                    }
                    else if (tmp[1] != "")
                    {
                        tel = long.Parse(tmp[1]);
                    }
                }
            }
            else if (symv == '/')
            {
                string[] tmp = richTextBox1.Text.Split('/');
                if (tmp[1] != "" && tmp[0] != "")
                {
                    if (long.Parse(tmp[1]) != 0) //an o paranomastis den einai miden tote kanei tin praksi
                    {
                        tel = (float)long.Parse(tmp[0]) / long.Parse(tmp[1]);
                    }
                    else 
                    {
                        MessageBox.Show("Denominator must not be zero!!"); //an einai miden petaei analogo minima
                    }
                }
                else if (tmp[1] == "" && tmp[0] == "")
                {
                    MessageBox.Show("Please write a number!");
                }
                else
                {
                    if (tmp[0] != "")
                    {
                        tel = long.Parse(tmp[0]);
                    }
                    else if (tmp[1] != "")
                    {
                        tel = long.Parse(tmp[1]);
                    }
                }

            }
            else if (symv == ' ' && richTextBox1.Text!="")
            {
                tel = long.Parse(richTextBox1.Text); //an den exei mpei simvolo tote emfanizei tin arithmo opws exei
            }
            label1.Text = tel.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text = ""; //einai to delete button opote mou ta midenizei ola kai emfanizei ta koumpia praksewn
            symv = ' ';
            richTextBox1.Text = "";
            button17.Show();
            button14.Show();
            button16.Show();
            button15.Show();
        }
        
        private void button12_Click(object sender, EventArgs e)
        { //einai to backspace button
            bool ys = false; //ys = yparxei symvolo (sto rtextbox)
            char[] ar = richTextBox1.Text.ToCharArray(); //spaw to rtextbox se enan char pinaka
            richTextBox1.Text = "";
            ar = ar.Take(ar.Count() - 1).ToArray(); //svinw tin teleytai thesi tou pinaka char
            for(int i = 0; i < ar.Count(); i++) //gia ta ipoloipa kelia 
            {
                richTextBox1.Text += ar[i]; //prosthetw sto rtextbox to kathe keli tou char (ola ektos apo auto pou svistike)
                if (ar[i] == symv) //ama vrei simvolo tote kanei true tin ys
                {
                    ys = true;
                }
            }
            if (ys == false) //ama i ys einai false diladi den vrike simbolo, kanei show ola ta koumpia me tis prakseis 
            {
                symv = ' ';
                button17.Show();
                button14.Show();
                button16.Show();
                button15.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pat = true; //to koumpi + 
            symv = '+';
            richTextBox1.Text += '+';
            button17.Hide();
            button14.Hide();
            button16.Hide();
            button15.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += 1;
        }
    }
}