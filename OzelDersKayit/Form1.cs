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

namespace OzelDersKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=EREN\\SQLEXPRESS;Integrated Security=True");

        private void Goster()
        {
            listView1.Items.Clear();
            bagla.Open();
            SqlCommand komut = new SqlCommand("Select * from Kurs.dbo.dersler", bagla);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["ders"].ToString());
                ekle.SubItems.Add(oku["alan"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());
                listView1.Items.Add(ekle);

            }
            bagla.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Goster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bagla.Open();
            //SqlCommand komut2 = new SqlCommand("insert into Kurs.dbo.dersler(id,adsoyad,ders,alan,tarih) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + checkBox1.Text.ToString() + "'," + checkBox2.Text.ToString() + "','" + checkBox3.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "')", bagla);
            SqlCommand komut2 = new SqlCommand("Insert Into Kurs.dbo.dersler(id,adsoyad,ders,alan,tarih) Values(@id,@adsoyad,@ders,@alan,@tarih)", bagla);
            komut2.Parameters.AddWithValue("@id", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@ders", comboBox1.Text);
            komut2.Parameters.AddWithValue("@alan", comboBox2.Text);
            komut2.Parameters.AddWithValue("@tarih", textBox3.Text);
            komut2.ExecuteNonQuery();
            bagla.Close();
            Goster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = " ";
            comboBox2.Text = " ";
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            bagla.Open();
            SqlCommand komut3 = new SqlCommand("Delete from Kurs.dbo.dersler where id=(" + id + ")", bagla);
            komut3.ExecuteNonQuery();
            bagla.Close();
            Goster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = " ";
            comboBox2.Text = " ";

        }

       private void button3_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bagla.Open();
            SqlCommand komut4 = new SqlCommand("Update Kurs.dbo.dersler set id='" + textBox1.Text.ToString() + "',adsoyad='" + textBox2.Text.ToString() + "',ders='" + comboBox1.Text.ToString() + "',alan='" + comboBox2.Text.ToString() + "',tarih='" + textBox3.Text.ToString() + "'where id=" + id + " ", bagla);
            komut4.ExecuteNonQuery();
            bagla.Close();
            Goster();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
