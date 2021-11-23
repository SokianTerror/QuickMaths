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
    public partial class TestArea : Form
    {
        public Label[] labels1 = new Label[20]; //arxikopoiw tous pinakes tipou label kai textbox
        public Label[] labels2 = new Label[20];
        public Label[] labels3 = new Label[20];
        public Label[] labels4 = new Label[20];
        public Label[] labels5 = new Label[20];
        public TextBox[] TextBox1 = new TextBox[20];
        public int[] ap = new int[20]; //pinakas me tis apantiseis
        long ex;
        int metr = 0, m = 0;
        Random r = new Random();
        int counter;
        public TestArea(string u)
        {
            InitializeComponent();
            label4.Text = "Welcome " + u + "!";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Play Again")
            {
                metr = 0;
                for(int j = 0; j < 20; j++)
                {
                    labels1[j].Hide();
                    labels2[j].Hide();
                    labels3[j].Hide();
                    labels4[j].Hide();
                    if (j < m)
                    {
                        labels5[j].Hide();
                    }
                    TextBox1[j].Hide();
                }
            }
            button1.Hide();
            button4.Show();
            timer1.Enabled = true;
            panel1.Visible = true;
            label1.Visible = true;
            panel1.Location = new Point(button2.Location.X - 150, this.Height - 150);
            counter = 120;
            int[] pinar = new int[40]; //aritmoi praksewn3 
            int i;
            string[] mpar = new string[20]; //pinakas pou thetei ta tuxaia simvola
            string[] pr = { "+", "-", "*", "/" };// simvola praksewn
            for (i = 0; i < 40; i++)
            {
                pinar[i] = r.Next(100);
                if (i < 20)
                {
                    int p = r.Next(0, 4);
                    mpar[i] = pr[r.Next(0, 4)];
                }
            }
            for (i = 0; i < 20; i++)
            { 
                labels1[i] = new Label();
                if (i < 10)  //elegxei an exoun mpei oi prwtes 10 prakseis
                { //an oxi tis eisagei
                    labels1[i].Location = new Point(80, 70 + i * 50);
                }
                else
                { //an nai, gia na xwresoun oles oi prakseis paei tis ypoloipes prakseis deksia
                    labels1[i].Location = new Point(this.Width/2 - 100 , 70 + (i-10) * 50);
                }

                //parakatw dinei morfi stis prakseis
                    labels1[i].Text = pinar[i].ToString(); //to labels1[i] einai o prwtos arithmos tis praksis 
                    labels1[i].Name = "labels1" + i.ToString();
                    labels1[i].AutoSize = true;
                    labels1[i].BackColor = Color.Transparent;
                    labels2[i] = new Label(); //to labels2[i] einai o simvolo tis praksei pou eisagetai tixaia
                    labels2[i].Text = mpar[i];
                    labels2[i].Location = new Point(labels1[i].Location.X + 40, labels1[i].Location.Y);
                    labels2[i].Name = "labels2" + i.ToString();
                    labels2[i].AutoSize = true;
                    this.Controls.Add(labels2[i]);
                    labels3[i] = new Label(); //o deuteros arithmos tis praksis
                    labels3[i].Text = pinar[i + 20].ToString();
                    labels3[i].Location = new Point(labels1[i].Location.X + 60, labels1[i].Location.Y);
                    labels3[i].Name = "labels3" + i.ToString();
                    labels3[i].AutoSize = true;
                    //this.Controls.Add(labels3[i]);
                    labels4[i] = new Label(); //to =
                    labels4[i].Text = "=";
                    labels4[i].Location = new Point(labels1[i].Location.X + 90, labels1[i].Location.Y);
                    labels4[i].Name = "labels4" + i.ToString();
                    labels4[i].AutoSize = true;
                    this.Controls.Add(labels4[i]);
                    TextBox1[i] = new TextBox(); //to textbox pou tha dwsei apantisei o xristis
                    TextBox1[i].Text = 0.ToString();
                    TextBox1[i].Location = new Point(labels1[i].Location.X + 105, labels1[i].Location.Y);
                    TextBox1[i].Name = "TextBox1" + i.ToString();
                    TextBox1[i].AutoSize = true;
                    this.Controls.Add(TextBox1[i]);
                    int new1 = pinar[i], new2 = pinar[i + 20]; //new1 kai new2 oi arithmoi twn labels1[i] kai labels3[i] opou tha ginoun oi prakseis gia na vrw tin swsti apantisi
                    bool ok = false; //ok = ola kala
                    if (labels2[i].Text == "/") //an to simvolo einai /
                    {
                        if (new2 == 0) new2 = r.Next(1, 100); //an o paranomastis einai miden tote to parinei kainourio arithmo megalitero tou 1
                        while (ok == false)
                        {
                            double p = (double.Parse(labels1[i].Text) / double.Parse(labels3[i].Text)); //i praksi
                            if ((p % 1) == 0) //an i praksi einai akeraia tote
                            {
                                ok = true; //to ok ginetai alithisi
                                this.Controls.Add(labels1[i]); //eisagontai oi dio arithmoi stin forma
                                this.Controls.Add(labels3[i]);
                                pinar[i] = new1; //kai to pinar[i] kai pinar[i+20] pairnoun tis times new1 kai new2
                                pinar[i + 20] = new2;
                            }
                            else
                            { //an den einai akeraia
                                new1 = r.Next(100); //allazoun oi arithmoi
                                new2 = r.Next(1, 100);
                                labels1[i].Text = new1.ToString();
                                labels3[i].Text = new2.ToString();
                            }
                        }
                    }
                    else
                    {
                        this.Controls.Add(labels1[i]);
                        this.Controls.Add(labels3[i]);
                    }
                    d t = new d();
                    ap[i]= t.Dd(labels2[i].Text, pinar[i], pinar[i + 20]); //kalei tin Dd gia na kanei tin praksi tis grammis
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TestArea_Load(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Width/2, 30);
            button2.Location = new Point(this.Width - 65, 30);
            button4.Location = new Point(this.Width / 2, this.Height - 100);
        }

        private void button4_Click_1(object sender, EventArgs e)
        { //koumpi finish
            button1.Text = "Play Again"; // allazei onomasia sto start button kai to emfanizei wste o xristis na paiksei ksana
            button1.Show();
            timer1.Stop(); //stamataei timer
            button4.Hide(); //krivei to koumpi
            metr = 0;
            m = 0;
            label2.Visible = true;
            label2.Location = new Point(this.Width-300, this.Height/2);
            label2.Name = "label2";
            label2.AutoSize = true;
            for (int i = 0; i <20; i++)
            { //gia kathe ena apo ta 20 textboxes
                TextBox1[i].ReadOnly = true; //to kanei read only na min mporeis na simeiwseis panw
                int number;
                string value = TextBox1[i].Text; //to value einai i timi pou exei dwsei o xristis
                bool ea = int.TryParse(value, out number); //testarei an exei dwsei o xristis arithmo
                if (ea == true) //an nai tote
                {
                    El el = new El(); 
                    metr += el.Ep(number, ap[i]); //stelnw apantisi xristi kai swsti apantisei, ama einai idies o metritis auksanetai kata 1
                    if (int.Parse(TextBox1[i].Text) != ap[i]) //an i apantisi einai diaforetiki
                    {
                        labels5[m] = new Label(); //arxikopoiei tin label pou tha dwsei tin swsti apantisi 
                        labels5[m].Text ="= " + ap[i].ToString(); //to text tou label pairnei tin swsti apantisi
                        labels5[m].ForeColor = Color.Blue; //tin kanei mple
                        labels5[m].Location = new Point(TextBox1[i].Location.X + 100, TextBox1[i].Location.Y); //tin topothetei
                        labels5[m].Name = "labels5" + i.ToString();
                        labels5[m].Show(); 
                        labels5[m].Visible = true;
                        this.Controls.Add(labels5[m]); //tin eisagei stin forma
                        m++; //kai auksanei ton metriti kata 1 gia tin epomeni lathos apantisi tou xristi
                    }
                }
                else
                {
                    labels5[m] = new Label(); //arxikopoiei tin label pou tha dwsei tin swsti apantisi 
                    labels5[m].Text = "= " + ap[i].ToString(); //to text tou label pairnei tin swsti apantisi
                    labels5[m].ForeColor = Color.Blue; //tin kanei mple
                    labels5[m].Location = new Point(TextBox1[i].Location.X + 100, TextBox1[i].Location.Y); //tin topothetei
                    labels5[m].Name = "labels5" + i.ToString();
                    labels5[m].Show();
                    labels5[m].Visible = true;
                    this.Controls.Add(labels5[m]); //tin eisagei stin forma
                    m++; //kai auksanei ton metriti kata 1 gia tin epomeni lathos apantisi tou xristi
                }
            }
            label2.Text = "Your score is: " + metr.ToString()+"/20"; // emfanizei to plithos swstwn apantisewn se ena label
            if (ex > 0) //an o xristis exei perasei ton xrono
            {
                label3.Location = new Point(label2.Location.X-170, label2.Location.Y +100); 
                label3.Show();
                label3.Text=("You pass the time by: " + ex + " seconds"); //emfanizei to label pou leei kata poso kseperase ton xrono pou dwthike ston xristi
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--; //xronos pou apomenei
            label1.Text = counter.ToString()+"s"; //grafei ton xrono pou apomenei
            if (counter > 60) panel1.BackColor = Color.Green;
            else if (counter <= 60 && counter > 0) panel1.BackColor = Color.Orange;
            else if (counter <= 0)
            {
                panel1.BackColor = Color.Red;
                ex = -counter; //an perasei ta diathesima deuterolepta tote o ex tha parei tin thetiki timi tou counter gia na emfanisei ta deuterolepta pou ekane extra
            }
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator cal = new Calculator();
            cal.Show();
        }

        private void hint1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have 120 seconds to answer all 20 questions. Try to answer them in time, else you are not smart enough for QuickMaths!");
        }

        private void hint2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remember!! You have a calculator in the menu, waiting for you to use it. So if things comes difficult for you, just try it out!!");

        }
    }
}

