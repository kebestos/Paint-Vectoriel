using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Vectoriel
{
    public partial class Form1 : Form
    {
        Graphics g;
        int i;
        List<Shape> Object = new List<Shape>();
        Bitmap B = new Bitmap(741, 600);        
        public Form1()
        {
            InitializeComponent();
           
            pictureBox1.Image = B;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);       

        }

        public  void DrawAll()
        {
            g.Clear(Color.White);
            foreach(Shape objet in Object )
            {
                objet.Draw(g);
            }
            if (listBox1.SelectedIndex != -1)
            {
                Pen rose = new Pen(Color.Pink);
                Shape s = Object[listBox1.SelectedIndex];
                g.DrawRectangle(rose, s.x, s.y, s.width, s.height);
            }            
            pictureBox1.Invalidate();            
        }

        public void MajListe()
        {
            listBox1.Items.Clear();

            foreach (Shape objet in Object)
            {
                listBox1.Items.Add(objet.GetType().Name +" x:"+objet.x+" y:"+ objet.y + " width:" + objet.width + " height:" + objet.height);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();


            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = MyDialog.Color;
            }
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            
            int w =0;
            int h=0;
            String x1 = textBox1.Text;
            String y1 = textBox2.Text;
            String x2 = textBox3.Text;
            String y2 = textBox4.Text;
            if (x1 != ""  && x2 != "" )
            {
                int X1 = Int32.Parse(x1);
                int Y1 = Int32.Parse(y1);
                int X2 = Int32.Parse(x2);
                int Y2 = Int32.Parse(y2);
                w = Math.Abs(X2 - X1);
                h = Math.Abs(Y2 - Y1);
                X1 = X1 > X2 ? X2 : X1;
                Y1 = Y1 > Y2 ? Y2 : Y1;
                rectangle rectangle = new rectangle(X1, Y1, w, h, panel1.BackColor);
                Object.Add(rectangle);
                DrawAll();
                MajListe();
                int J = Object.Count() - 1;
                listBox1.SelectedIndex = J;
            }
                

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape u = Object[listBox1.SelectedIndex];
                Object.RemoveAt(listBox1.SelectedIndex);
                Object.Insert(Object.Count(), u);
                MajListe();
                DrawAll();
                listBox1.SelectedIndex = Object.Count() - 1;
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Object.Clear();
            MajListe();
            DrawAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                if ( index > 0)
                {
                    Shape u = Object[listBox1.SelectedIndex];
                    Object.RemoveAt(listBox1.SelectedIndex);
                    Object.Insert(index - 1, u);
                    MajListe();
                    DrawAll();
                    listBox1.SelectedIndex = index - 1;
                }
                
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int w = 0;
            int h = 0;
            String x1 = textBox1.Text;
            String y1 = textBox2.Text;
            String x2 = textBox3.Text;
            String y2 = textBox4.Text;
            if (x1 != "" && x2 != "")
            {
                int X1 = Int32.Parse(x1);
                int Y1 = Int32.Parse(y1);
                int X2 = Int32.Parse(x2);
                int Y2 = Int32.Parse(y2);
                w = Math.Abs(X2 - X1);
                h = Math.Abs(Y2 - Y1);
                X1 = X1 > X2 ? X2 : X1;
                Y1 = Y1 > Y2 ? Y2 : Y1;
                Elipse elipse = new Elipse(X1, Y1, w, h, panel1.BackColor);
                Object.Add(elipse);
                DrawAll();
                MajListe();
                int J = Object.Count() - 1;
                listBox1.SelectedIndex = J;

            }
                
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape O = Object[listBox1.SelectedIndex];
                if (Object[listBox1.SelectedIndex].GetType().Name == "rectangle")
                {
                    rectangle rectangle = new rectangle(O.x+100,O.y+100, O.width, O.height, O.couleur);
                    Object.Add(rectangle);
                }
                if (Object[listBox1.SelectedIndex].GetType().Name == "Elipse")
                {
                    Elipse elipse = new Elipse(O.x + 100, O.y + 100, O.width, O.height, O.couleur);
                    Object.Add(elipse);
                }
                 if (Object[listBox1.SelectedIndex].GetType().Name == "Image")
                 {
                     Image image = new Image(O.x + 100, O.y + 100, O.width, O.height, O.couleur,O.GetLocation());
                     Object.Add(image);
                 }
                 if (Object[listBox1.SelectedIndex].GetType().Name == "Texte")
                 {
                     Font drawFont = new Font("Arial", 16);
                     Texte texte = new Texte(O.x + 100, O.y + 100, O.width, O.height, O.couleur,drawFont,O.GetTexte());
                     Object.Add(texte);
                 }
                DrawAll();
                MajListe();
                int J = Object.Count() - 1;
                listBox1.SelectedIndex = J;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i++;
            var mouse = e as MouseEventArgs;
            if(mouse !=null && i % 2 != 0)
            {
                textBox1.Text = mouse.X.ToString();
                textBox2.Text = mouse.Y.ToString();
            }
            if (mouse != null && i % 2 == 0)
            {
                textBox3.Text = mouse.X.ToString();
                textBox4.Text = mouse.Y.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int w = 0;
            int h = 0;
            String x1 = textBox1.Text;
            String y1 = textBox2.Text;
            String x2 = textBox3.Text;
            String y2 = textBox4.Text;
            if (x1 != "" && x2 != "")
            {
                int X1 = Int32.Parse(x1);
                int Y1 = Int32.Parse(y1);
                int X2 = Int32.Parse(x2);
                int Y2 = Int32.Parse(y2);
                w = Math.Abs(X2 - X1);
                h = Math.Abs(Y2 - Y1);
                X1 = X1 > X2 ? X2 : X1;
                Y1 = Y1 > Y2 ? Y2 : Y1;

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.InitialDirectory = "c:\\";
                openFile.Filter = "Image Files(*.BMP;*.JPG;)|*.BMP;*.JPG;";
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Image image = new Image(X1, Y1, w, h, panel1.BackColor, openFile.FileName);
                    Object.Add(image);
                   
                }
                DrawAll();
                MajListe();
                int J = Object.Count()-1;
                listBox1.SelectedIndex = J;

            }
                
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawAll();            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int w = 0;
            int h = 0;
            String x1 = textBox1.Text;
            String y1 = textBox2.Text;
            String x2 = textBox3.Text;
            String y2 = textBox4.Text;
            if (x1 != "" && x2 != "")
            {
                int X1 = Int32.Parse(x1);
                int Y1 = Int32.Parse(y1);
                int X2 = Int32.Parse(x2);
                int Y2 = Int32.Parse(y2);
                w = Math.Abs(X2 - X1);
                h = Math.Abs(Y2 - Y1);
                X1 = X1 > X2 ? X2 : X1;
                Y1 = Y1 > Y2 ? Y2 : Y1;

                string drawString = textBox5.Text;
                Font drawFont = new Font("Arial", 16);
                Texte texte = new Texte(X1, Y1, w, h, panel1.BackColor, drawFont, drawString);
                Object.Add(texte);
                DrawAll();
                MajListe();
                int J = Object.Count() - 1;
                listBox1.SelectedIndex = J;
            }
                
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Object.RemoveAt(listBox1.SelectedIndex);
                MajListe();
                DrawAll();
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape O = Object[listBox1.SelectedIndex];
                O.x = O.x + 1;
                DrawAll();
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape O = Object[listBox1.SelectedIndex];
                O.x = O.x - 1;
                DrawAll();
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape O = Object[listBox1.SelectedIndex];
                O.y = O.y + 1;
                DrawAll();
            }
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape O = Object[listBox1.SelectedIndex];
                O.y = O.y - 1;
                DrawAll();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                if (index < Object.Count() - 1)
                {
                    Shape u = Object[listBox1.SelectedIndex];
                    Object.RemoveAt(listBox1.SelectedIndex);
                    Object.Insert(index + 1, u);
                    MajListe();
                    DrawAll();
                    listBox1.SelectedIndex = index + 1;
                }
                
            }
                
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Shape u = Object[listBox1.SelectedIndex];
                Object.RemoveAt(listBox1.SelectedIndex);
                Object.Insert(0, u);
                MajListe();
                DrawAll();
                listBox1.SelectedIndex = 0;

            }
                
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i++;
            var mouse = e as MouseEventArgs;
            if (mouse != null && i % 2 != 0)
            {
                textBox1.Text = mouse.X.ToString();
                textBox2.Text = mouse.Y.ToString();
            }           
                   

        }

        private void button16_Click(object sender, EventArgs e)
        {
            int a = 0;
            String x1 = textBox1.Text;
            String y1 = textBox2.Text;
            int X1 = Int32.Parse(x1);
            int Y1 = Int32.Parse(y1);
            if (x1 != "")
            {
                foreach (Shape objet in Object)
                {

                    if (objet.x < X1 && X1 < objet.x + objet.width && objet.y < Y1 && Y1 < objet.height + objet.y)
                    {

                        MajListe();
                        DrawAll();
                        listBox1.SelectedIndex = a;

                    }
                    a++;
                }
            }
            
                
            
        }
    }
}
