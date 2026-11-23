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

namespace ed2026jaroslav
{
    public partial class Form1 : Form
    {
        int index = 0;
        void prikazi()
        {
            DataTable podaci = new DataTable();
            string cs = "Data Source=DESKTOP-A6MV7AL\\SQLEXPRESS;Initial Catalog=ed2026b;Integrated Security=True";
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from ucenik", veza);
            adapter.Fill(podaci);
            if(index >= podaci.Rows.Count) index = podaci.Rows.Count - 1;
            textBox1.Text = podaci.Rows[index]["id"].ToString();
            textBox2.Text = podaci.Rows[index]["ime"].ToString();
            textBox3.Text = podaci.Rows[index]["prezime"].ToString();
            textBox4.Text = podaci.Rows[index]["jmbg"].ToString();
            textBox5.Text = podaci.Rows[index]["email"].ToString();
            textBox6.Text = podaci.Rows[index]["pass"].ToString();
            textBox7.Text = podaci.Rows[index]["adresa"].ToString();
            textBox8.Text = podaci.Rows[index]["uloga"].ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prikazi();
        }

        private void buttonfirst_Click(object sender, EventArgs e)
        {
            index = 0;
            prikazi();
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                prikazi();
            }
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            index++;
            prikazi();
        }

        private void buttonlast_Click(object sender, EventArgs e)
        {
            index = int.MaxValue;
            prikazi();
        }

        private void buttonobrisi_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=DESKTOP-A6MV7AL\\SQLEXPRESS;Initial Catalog=ed2026b;Integrated Security=True";
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter($"delete from ucenik where id={textBox1.Text}", veza);
            prikazi();
        }

        private void buttonpromeni_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=DESKTOP-A6MV7AL\\SQLEXPRESS;Initial Catalog=ed2026b;Integrated Security=True";
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter($"update ucenik set ime='{textBox2.Text}',prezime='{textBox3.Text}',jmbg='{textBox4.Text}',email='{textBox5.Text}',pass='{textBox6.Text}',adresa='{textBox7.Text}',uloga={textBox8.Text} where id={textBox1.Text}", veza);
            prikazi();
        }

        private void buttondodaj_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=DESKTOP-A6MV7AL\\SQLEXPRESS;Initial Catalog=ed2026b;Integrated Security=True";
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter($"insert into ucenik(ime,prezime,jmbg,email,pass,adresa,uloga) values('{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}',{textBox8.Text})", veza);
            prikazi();
        }
    }
}
