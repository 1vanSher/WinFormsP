using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;
using System.Data.SqlClient;
namespace WinFormsP2
{
    public partial class Form2 : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public Form2()
        {
            InitializeComponent();
            bind_data();
        }
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=123456;Database=fishingshop;");
        private void bind_data()
        {
            string sql = "select * FROM client ORDER BY id ASC";
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO client(id, fcs, card) VALUES ({text}, '{textBox2.Text}', '{textBox3.Text}');";
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            bind_data();
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
    }
}