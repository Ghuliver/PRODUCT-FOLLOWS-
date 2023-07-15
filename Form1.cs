using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace ÜRÜN_TAKİP_OTOMASYONU
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand   komut;
        SqlDataAdapter dataAdapter;
        public Form1()
        {
            InitializeComponent();
        }
        void getir()
        {
            try
            {
                baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS01;Initial Catalog=sirket;Integrated Security=True");
                baglanti.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM ürüntb", baglanti);
                DataTable table = new DataTable();
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data: " + ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            getir();
        }

        

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO ürüntb VALUES(@ürünno, @ürünad,@ürün_model,@üretim_tarih,@çıkış_tarih,@çıkış_fiyat,@satılan_yer,@kalan_sayı,@gerekli_malzeme)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ürünno", textBox1.Text);
            komut.Parameters.AddWithValue("@ürünad", textBox2.Text);
            komut.Parameters.AddWithValue("@ürün_model", textBox3.Text);
            komut.Parameters.AddWithValue("@üretim_tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@çıkış_tarih", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@çıkış_fiyat", textBox6.Text);
            komut.Parameters.AddWithValue("@satılan_yer", textBox7.Text);
            komut.Parameters.AddWithValue("@kalan_sayı", textBox8.Text);
            komut.Parameters.AddWithValue("@gerekli_malzeme", textBox9.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM ürüntb WHERE ürünno= @ürünno";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ürünno", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE ürüntb SET ürünno=@ürünno, ürünad=@ürünad,ürün_model=@ürün_model,üretim_tarih=@üretim_tarih,çıkış_tarih=@çıkış_tarih,çıkış_fiyat=@çıkış_fiyat,satılan_yer=@satılan_yer,kalan_sayı=@kalan_sayı,gerekli_malzeme=@gerekli_malzeme WHERE ürünno=@ürünno";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ürünno", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@ürünad", textBox2.Text);
            komut.Parameters.AddWithValue("@ürün_model", textBox3.Text);
            komut.Parameters.AddWithValue("@üretim_tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@çıkış_tarih", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@çıkış_fiyat", textBox6.Text);
            komut.Parameters.AddWithValue("@satılan_yer", textBox7.Text);
            komut.Parameters.AddWithValue("@kalan_sayı", textBox8.Text);
            komut.Parameters.AddWithValue("@gerekli_malzeme", textBox9.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();

        }

    }
}
