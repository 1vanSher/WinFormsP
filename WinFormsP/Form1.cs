using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using System.Windows.Forms;

namespace WinFormsP
{
    public partial class Form1 : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            bind_data();
        }
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=123456;Database=fishingshop;");
        private void bind_data()
        {
            string sql = $"select * FROM {tab.SelectedTab.Text} ORDER BY id ASC";
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();
            textBox2.Text = selectedrow.Cells[1].Value.ToString();
            textBox3.Text = selectedrow.Cells[2].Value.ToString();
        }

        private void tab_Selected(object sender, TabControlEventArgs e)
        {
            e.TabPage.Controls.Add(dataGridView1);
            bind_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO client(id, fcs, card) VALUES ({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}');";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE client SET fcs='{textBox2.Text}', card='{textBox3.Text}' WHERE id={textBox1.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM client WHERE id={textBox1.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO product(id, name, typeofgoods, saleprice, quantity) VALUES ({textBox4.Text}, '{textBox5.Text}', {textBox6.Text}, {textBox7.Text}, {textBox8.Text});";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE product SET name='{textBox5.Text}', typeofgoods={textBox6.Text}, saleprice={textBox7.Text}, quantity={textBox8.Text} WHERE id={textBox4.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM product WHERE id={textBox4.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO sale(id, title, quantity, client, date, totalamount, staff) VALUES ({textBox9.Text}, '{textBox10.Text}', {textBox11.Text}, {textBox12.Text}, {textBox13.Text}, {textBox14.Text}, {textBox15.Text});";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE sale SET title={textBox10.Text}, quantity={textBox11.Text}, client={textBox12.Text}, date='{textBox13.Text}', totalamount={textBox14.Text}, staff={textBox15.Text} WHERE id={textBox9.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM sale WHERE id={textBox9.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO storage(id, product, shipment, quantity, purshaseprice) VALUES ({textBox16.Text}, {textBox17.Text}, {textBox18.Text}, {textBox19.Text}, {textBox20.Text});";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE storage SET product={textBox17.Text}, shipment={textBox18.Text}, quantity={textBox19.Text}, purshaseprice='{textBox20.Text}' WHERE id={textBox16.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM storage WHERE id={textBox16.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO shipment(id, suppliers, date) VALUES ({textBox29.Text}, {textBox28.Text}, '{textBox27.Text}');";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE shipment SET suppliers={textBox27.Text}, date='{textBox28.Text}' WHERE id={textBox29.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM shipment WHERE id={textBox29.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO suppliers(id, fcs, adress, telephone) VALUES ({textBox36.Text}, '{textBox35.Text}', '{textBox34.Text}', '{textBox33.Text}');";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE suppliers SET fcs='{textBox35.Text}', adress='{textBox34.Text}', telephone='{textBox33.Text}' WHERE id={textBox36.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM suppliers WHERE id={textBox36.Text};";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
        }
    }
}