using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace veri
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TVDatabase;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string server = "server_adresi";
            string database = "veritabani_adi";
            string uid = "kullanici_adı";
            string password = "sifre";

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // Diğer olaylar ve metotlar buraya eklenecek.


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Kanal Adı
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //program adı/ reklam adı
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // yayın saati
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //yönetmen adı
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // oyuncu
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Program mı
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Reklam mı
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (OpenConnection())
                {
                    string kanalAdi = textBox1.Text;
                    string programAdi = KanalAdı.Text;
                    string yayinSaati = textBox3.Text;
                    string yonetmenAdi = textBox4.Text;
                    string oyuncuAdi = textBox5.Text;
                    bool programMi = checkBox1.Checked;
                    bool reklamMi = checkBox2.Checked;

                    string query = "INSERT INTO TabloAdi (KanalAdi, ProgramAdi, YayinSaati, YonetmenAdi, OyuncuAdi, ProgramMi, ReklamMi) " +
                                   $"VALUES ('{kanalAdi}', '{programAdi}', '{yayinSaati}', '{yonetmenAdi}', '{oyuncuAdi}', {programMi}, {reklamMi})";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    CloseConnection();
                    MessageBox.Show("Veriler başarıyla kaydedildi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
