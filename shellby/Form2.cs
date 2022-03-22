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
using System.IO;


namespace shellby
{
    public partial class Form2 : Form
    {
        private Point lastPoint;
        public Form2()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=datam.accdb"); // databasenin yolunu bul ve bağlan
        public DataTable tablo = new DataTable(); // databaseyi kontol et 
        public OleDbDataAdapter adtr = new OleDbDataAdapter(); // bağlan
        public OleDbCommand kmt = new OleDbCommand();
        string DosyaYolu, DosyaAdi = "";
        int id;


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            bag.Open(); // bağlantıyı aç 
            cmd.Connection = bag; // bağlantıyı doğrula
            cmd.CommandText = "SELECT * FROM hareket"; // hareket fonktsiyonunu bul ve yazdır 
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["hareket"].ToString() + dr["tarih"].ToString() + dr["kullanici".ToString()]); // listboxa logları yazdırma fonkriyonu


            }
            bag.Close(); // bağlantıyı kapat

            timer1.Start(); // timer1 adlı fonksiyonu başlat 
            listele(); // listele adlı fonksiyonu başlat 

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X; // formu yönlendirme fonksiyonları 
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
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

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage1"); // butona basıldığında tabpage1 e yönlendir
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage2");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage3");
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }


        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "") errorProvider1.SetError(textBox1, "Boş geçilmez"); // eğer texboxun içi boşş ise yanına error işareti bırakır 
                else errorProvider1.SetError(textBox1, ""); // eğer texbox doğru ise error işareti bırakmadan devam eder
                if (textBox2.Text.Trim() == "") errorProvider1.SetError(textBox2, "Boş geçilmez");
                else errorProvider1.SetError(textBox2, "");
                if (textBox3.Text.Trim() == "") errorProvider1.SetError(textBox3, "Boş geçilmez");
                else errorProvider1.SetError(textBox3, "");
                if (textBox4.Text.Trim() == "") errorProvider1.SetError(textBox4, "Boş geçilmez");
                else errorProvider1.SetError(textBox4, "");
                if (textBox5.Text.Trim() == "") errorProvider1.SetError(textBox5, "Boş geçilmez");
                else errorProvider1.SetError(textBox5, "");
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")  // eğer textboxlar doğru ise 
                {
                    bag.Open(); // bağlantıyı başlat 
                    kmt.Connection = bag;
                    kmt.CommandText = "INSERT INTO stokbil(stokAdi,stokModeli,stokSeriNo,stokAdedi,stokTarih,kayitYapan,dosyaAdi) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + DosyaAdi + "') "; // seçilen verileri databaseye ekle
                    kmt.ExecuteNonQuery(); // database bağlantısını doğrula 
                    kmt.Dispose(); // doğrula2
                    bag.Close(); // bağlantıyı kapat 
                    for (int i = 0; i < this.Controls.Count; i++) // for i döngüsü ile datagriendviewe yazdır 
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                    }
                    listele();
                    if (DosyaAdi != "") File.WriteAllBytes(DosyaAdi, File.ReadAllBytes(DosyaAc.FileName)); 
                    MessageBox.Show("Kayıt İşlemi Tamamlandı ! ", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information); // loglara kodu gönder 
                }

            }
            catch //y yakala 
            {
                MessageBox.Show("Kayıtlı Seri No !");
                bag.Close(); // bağlantıyı kapat 
            }
            bag.Open(); // bağlantyı aç 
            kmt.Connection = bag; // bağlantıyı doğrula 
            kmt.CommandText = "INSERT INTO hareket(hareket,tarih,kullanici)  VALUES ('" + "Ekleme İşlemi Yapılmıştır..." + "','" + DateTime.Now.ToLongDateString() + "','" + textBox5.Text + "') "; // loglara yazdır

            kmt.ExecuteNonQuery();

            bag.Close(); // bağlantıyı kapat 
        }

        private void bunifuButton6_Click(object sender, EventArgs e) // silme butonu 
        {
            try // dene 
            {
                DialogResult cevap; // messagebox oluştur
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // messagebox
                if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "") // eğer yese basılırsa verileri sil
                {
                    bag.Open(); // bağlantıyı aç 
                    kmt.Connection = bag; // bağlantıyı doğrula 
                    kmt.CommandText = "DELETE from stokbil WHERE stokSeriNo='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' "; // verileri sil 
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close(); // bağlantıyı kapat 
                    listele(); // listele fonksiyonunu tekrar çalıştır 
                }
            }
            catch // yakala 
            {
                ;
            }

            bag.Open(); // bağlantı aç 
            kmt.Connection = bag;
            kmt.CommandText = "INSERT INTO hareket(hareket,tarih,kullanici) VALUES ('" + "Silme İşlemi Yapılmıştır..." + "','" + DateTime.Now.ToLongDateString() + "','" + textBox5.Text + "') "; // loglara yazdır 
            kmt.ExecuteNonQuery();

            bag.Close(); // kapat 
        }

        private void bunifuButton9_Click(object sender, EventArgs e) // düzenleme butonu 
        {
            bag.Open(); // başlat 
            kmt.Connection = bag;
            kmt.CommandText = "INSERT INTO hareket(hareket,tarih,kullanici) VALUES ('" + "Güncelleme İşlemi Yapılmıştır..." + "','" + DateTime.Now.ToLongDateString() + "','" + textBox5.Text + "') "; // loglara yazdırır 
            kmt.ExecuteNonQuery();


            bag.Close(); // bağlantıyı kapat 
        }

        private void btnResimEkle_Click(object sender, EventArgs e) // fotoğraf ekle 
        {
            if (DosyaAc.ShowDialog() == DialogResult.OK) // eğer oka basılırsa 
            {
                foreach (string i in DosyaAc.FileName.Split('\\')) // seçilen dosyayı oku 
                {
                    if (i.Contains(".jpg")) { DosyaAdi = i; } // eğer dosyanın yolu .jpg ile devam et 
                    else if (i.Contains(".png")) { DosyaAdi = i; } // eğer dosyanın yolu .png ise devam et 
                    else { DosyaYolu += i + "\\"; } // devam et 
                }
                pictureBox1.ImageLocation = DosyaAc.FileName; // databaseye ekle 
            }
            else // eğer 
            {
                MessageBox.Show("Dosya Girmediniz!"); // eğer fotoğraf seçilmediyse messageboxu gönder 
            }
        }

        private void btnResimSil_Click(object sender, EventArgs e) // resim silme metodu  
        {
            pictureBox1.ImageLocation = ""; // seçilen resimi databaseden kaldır 
            DosyaAdi = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // datagriendwivev
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); // texboxlardan okuduğu şeyleri dataviewe ekle 
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            try
            {
                kmt = new OleDbCommand("select * from stokbil where stokSeriNo='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", bag); // bağlantııoku 
                bag.Open(); // bağlantıyı yazdır 
                OleDbDataReader oku = kmt.ExecuteReader();
                oku.Read();
                if (oku.HasRows)
                {
                    pictureBox1.ImageLocation = oku[7].ToString(); // resimi al ve picture boxa ekle 
                    id = Convert.ToInt32(oku[0].ToString());
                }
                bag.Close(); // bağlantıyı kapat 
            }
            catch // yakala 
            {
                bag.Close(); // bağlantıyı kapat 
            }
        }

        public void listele() // listele fonksyionu datagriende yazdırır ve güncellemeye yarar 
        {
            tablo.Clear(); // tabloyu temizle 
            bag.Open(); // database bağlantısını sağla 
            OleDbDataAdapter adtr = new OleDbDataAdapter("select stokAdi,stokModeli,stokSeriNo,stokAdedi,stokTarih,kayitYapan From stokbil", bag); // database içinden verileri seç 
            adtr.Fill(tablo); // verileri tabloya ekle 
            dataGridView1.DataSource = tablo; // tablo 1 
            dataGridView2.DataSource = tablo; // tablo 2
            adtr.Dispose(); // ekle 
            bag.Close(); // kapat 
            try // dene 
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // herşeyi seç ve ekle 
                //datagridview1'deki tüm satırı seç              
                dataGridView1.Columns[0].HeaderText = "STOK ADI";
                //sütunlardaki textleri değiştirme
                dataGridView1.Columns[1].HeaderText = "STOK MODELİ";
                dataGridView1.Columns[2].HeaderText = "STOK SERİNO";
                dataGridView1.Columns[3].HeaderText = "STOK ADEDİ";
                dataGridView1.Columns[4].HeaderText = "STOK TARİH";
                dataGridView1.Columns[5].HeaderText = "KAYIT YAPAN";
                dataGridView1.Columns[0].Width = 120;
                //genişlik
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 120;
                // 2 
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç              
                dataGridView2.Columns[0].HeaderText = "STOK ADI";
                //sütunlardaki textleri değiştirme
                dataGridView2.Columns[1].HeaderText = "STOK MODELİ";
                dataGridView2.Columns[2].HeaderText = "STOK SERİNO";
                dataGridView2.Columns[3].HeaderText = "STOK ADEDİ";
                dataGridView2.Columns[4].HeaderText = "STOK TARİH";
                dataGridView2.Columns[5].HeaderText = "KAYIT YAPAN";
                dataGridView2.Columns[0].Width = 120;
                //genişlik
                dataGridView2.Columns[1].Width = 120;
                dataGridView2.Columns[2].Width = 120;
                dataGridView2.Columns[3].Width = 80;
                dataGridView2.Columns[4].Width = 100;
                dataGridView2.Columns[5].Width = 120;
            }
            catch
            {
                ;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStokModelAra_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From stokbil", bag); // modül aramA 
            if (radioButton1.Checked == true) // eğer radiobutton 1 seçildiyse 
            {
                if (textBox6.Text.Trim() == "") // eğer textbox1 boş ise 
                {
                    tablo.Clear(); // tabloyu temizle 
                    kmt.Connection = bag;
                    kmt.CommandText = "Select * from stokbil";
                    adtr.SelectCommand = kmt;
                    adtr.Fill(tablo); // otomattik olarak tabloyu doldur 
                }
                if (Convert.ToBoolean(bag.State) == false)
                {
                    bag.Open();
                }
                if (textBox6.Text.Trim() != "") 
                {
                    adtr.SelectCommand.CommandText = " Select * From stokbil" +
                         " where(stokAdi='" + textBox6.Text + "' )";
                    tablo.Clear();
                    adtr.Fill(tablo);
                    bag.Close();
                }


            }
            else if (radioButton2.Checked == true)
            {
                if (textBox6.Text.Trim() == "")
                {
                    tablo.Clear();
                    kmt.Connection = bag;
                    kmt.CommandText = "Select * from stokbil";
                    adtr.SelectCommand = kmt;
                    adtr.Fill(tablo);
                }
                if (Convert.ToBoolean(bag.State) == false)
                {
                    bag.Open();
                }
                if (textBox6.Text.Trim() != "")
                {
                    adtr.SelectCommand.CommandText = " Select * From stokbil" +
                         " where(stokModeli='" + textBox6.Text + "' )";
                    tablo.Clear();
                    adtr.Fill(tablo);
                    bag.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir arama türü seçiniz..."); // eğer birşey seçilmesse bağlantuyukapat;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // textbox 4 e birşey yazılamamasını sadece sayı seçilmesini sağlar 
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
