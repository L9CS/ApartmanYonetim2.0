using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shellby
{
    public partial class Form4 : Form
    {
        private Point lastPoint;
        public Form4()
        {
            InitializeComponent();
        }
        Random rdm = new Random();
        Random rdm1 = new Random();
        Random rdm2 = new Random();
        int toplam;
        int cikart;
        char c;
        private void Form4_Load(object sender, EventArgs e)
        {
            int sayi1 = rdm.Next(1, 20);
            for (int i = 0; i < 99999; i++)
            {

            }

            int sayi2 = rdm1.Next(1, 10);
            toplam = sayi1 + sayi2;
            cikart = sayi1 - sayi2;
            int islemim = rdm.Next(0, 2);
            if (islemim == 0)
            {
                c = '+';
            }
            else if (islemim == 1)
            {
                c = '-';
            }
            bunifuLabel2.Text = sayi1.ToString();
            bunifuLabel3.Text = c.ToString();
            bunifuLabel4.Text = sayi2.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (c == '+')
                {
                    if (int.Parse(bunifuTextBox1.Text) == toplam)
                    {
                        Form3 frm1 = new Form3();
                        frm1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Giriş !");
                    }
                }
                else if (c == '-')
                {
                    if (int.Parse(bunifuTextBox1.Text) == cikart)
                    {

                        Form3 frm1 = new Form3();
                        frm1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Giriş !");
                    }
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata " + hata.Message);
            }
        }
    }
}
