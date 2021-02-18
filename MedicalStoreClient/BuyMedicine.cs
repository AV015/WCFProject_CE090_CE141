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
    public partial class BuyMedicine : Form
    {
        ServiceReference4.BuyMedicineServiceClient proxy = new ServiceReference4.BuyMedicineServiceClient();
        public BuyMedicine()
        {
            
            InitializeComponent();
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            

            SqlCommand cmd1 = new SqlCommand("Select MedicineName from Medicine", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd1.ExecuteNonQuery();

            comboBox1.DisplayMember = "MedicineName";
            comboBox1.ValueMember = "MedicineName";
            comboBox1.DataSource = ds.Tables[0];

            con.Close();
      

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg;
            int price = 0, total = 0, qty = 0, updated_qty = 0, total_qty = 0;
            DateTime dt = DateTime.Now;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand("Select * from Medicine where MedicineName=@mname", con);
            cmd.Parameters.AddWithValue("@mname", comboBox1.SelectedValue.ToString());

            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                price = Convert.ToInt32(rdr.GetValue(3));
                total_qty = Convert.ToInt32(rdr.GetValue(2));
            }
            qty = Convert.ToInt32(textBox1.Text);
            total = qty * price;
            updated_qty = total_qty - qty;
            label4.Visible = true;
            label4.Text = "(Max : " + total_qty + " )";
            label3.Visible = true;
            label3.Text = "Amount To Be Paid : Rs." + total.ToString();
            ServiceReference4.Buy b = new ServiceReference4.Buy();
            b.UserId = Credential.uid;
            b.MedicineName = comboBox1.SelectedValue.ToString();
            b.Quantity = Convert.ToInt32(textBox1.Text);
            b.Amount = total;
            b.Date = dt;

            msg = proxy.addPurchaseData(b);
            label5.Visible = true;
            label5.Text = msg;
            con.Close();

            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("update Medicine set Stock=@stock where MedicineName=@mname", con1);
            cmd1.Parameters.AddWithValue("@stock", updated_qty);
            cmd1.Parameters.AddWithValue("@mname", comboBox1.SelectedValue.ToString());
            cmd1.ExecuteNonQuery();
            con1.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int total_qty = 0;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand("Select * from Medicine where MedicineName=@mname", con);
            cmd.Parameters.AddWithValue("@mname", comboBox1.SelectedValue.ToString());

            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                total_qty = Convert.ToInt32(rdr.GetValue(2));
            }
            
            label4.Visible = true;
            label4.Text = "(Max : " + total_qty + " )";
        }
    }
}
