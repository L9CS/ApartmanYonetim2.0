using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace shellby
{
    public partial class Form1 : Form
    {
        private Point lastPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=dbLogin.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            string ad = bunifuTextBox1.Text;
            string parola = bunifuTextBox2.Text;
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Login where kullanici='" + ad + "' AND sifre='" + parola + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Risky maybe you get ban");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//here how to move loader 
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)//here how to move loader 
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)//here how to move loader 
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)//here how to move loader 
        {
            lastPoint = new Point(e.X, e.Y);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuIconButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://eclipse.lol/");
        }

        private void bunifuIconButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/Riot_Eclipse");
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
