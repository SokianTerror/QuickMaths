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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { //Mia eikoniki forma pou o xristis eisagei to pseudwnimo tou
            if(textBox1.Text != "" && textBox1.Text!= " ")
            {
                TestArea ta = new TestArea(textBox1.Text);
                ta.Show();
                this.Hide();
            }
            else //an o xristis balei keno eite space gia username emfanizei antistoixo minima alliws mpainei stin 2i forma 
            {
                MessageBox.Show("Please insert a username");
                textBox1.Text = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
