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

namespace MedicalStoreClient
{
    
    public partial class UpdateMedicine : Form
    {
        int Id,Stock,Price;
        string MedicineName;

        ServiceReference2.MedicalSystemServiceClient proxy = new ServiceReference2.MedicalSystemServiceClient();
        public UpdateMedicine()
        {
            InitializeComponent();
            DataSet ds = null;
            ds = proxy.viewMedicineData();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void UpdateMedicine_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalStoreDBDataSet.Medicine' table. You can move, or remove it, as needed.
            this.medicineTableAdapter.Fill(this.medicalStoreDBDataSet.Medicine);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("update Medicine set MedicineName=@mname,Stock=@stock,Price=@price where Id=@id", con1);
            cmd1.Parameters.AddWithValue("@id", Id);
            cmd1.Parameters.AddWithValue("@stock", textBox2.Text);
            cmd1.Parameters.AddWithValue("@mname", textBox1.Text);
            cmd1.Parameters.AddWithValue("@price", textBox3.Text);
            cmd1.ExecuteNonQuery();
            con1.Close();
            DisplayData();
            clearData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("delete Medicine where Id=@id", con1);
            cmd1.Parameters.AddWithValue("@id", Id);
            cmd1.ExecuteNonQuery();
            con1.Close();
            DisplayData();
            clearData();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.dataGridView1.Rows[e.RowIndex].Selected = true;
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        public void clearData()
        {
            Id = 0;
            Stock = 0;
            Price = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void DisplayData()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd = new SqlCommand("Select * from Medicine", con1);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cmd.ExecuteNonQuery();
            con1.Close();
        }
    }
}
