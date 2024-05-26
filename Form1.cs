using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int n;
        private int nrPuncte;
        const int radius = 5;
        private Puncte[] puncte;
        Graphics graphics;


        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (nrPuncte<n)
            {
                puncte[nrPuncte].X = e.X;
                puncte[nrPuncte].Y= e.Y;
                graphics.FillEllipse(Brushes.Red, puncte[nrPuncte].X - radius, puncte[nrPuncte].Y - radius, 2 * radius, 2 * radius);
                nrPuncte++;
            }
        }

        private void ReadNr()
        {
            try
            {
                using (StreamReader sr = new StreamReader("config.txt"))
                {
                    string line = sr.ReadLine();
                    n = int.Parse(line);
                }
            }

            catch (Exception e)
            {
               
                n = 5; 
            }
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
            ReadNr();
            puncte = new Puncte[n];
        }

    }
}
