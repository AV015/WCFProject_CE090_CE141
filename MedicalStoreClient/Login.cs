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
    public partial class Login : Form
    {
        //ServiceReference1.RegistrationServiceClient proxy = new ServiceReference1.RegistrationServiceClient();
        public static int uid;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname, password;
            uname = textBox1.Text;
            password = textBox2.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand("Select * from Registration where UserName=@uname AND Password=@password", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@password", password);
                //Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                rdr = cmd.ExecuteReader();
                label4.Visible = true;
                if (rdr.HasRows)
                {
                    rdr.Read();
                    uid = Convert.ToInt32(rdr.GetValue(0));
                    Credential.uid = uid;
                    label4.Text = "Login Successful";
                    con.Close();
                    MedicalSystem ms = new MedicalSystem();
                    ms.Show();
                }
                else
                {
                    label4.Text = "Login Failed";
                }
            
            }
            catch(Exception ex)
            {
                label4.Text = "Error : " + ex.ToString();
                con.Close();
            }
        }
    }
}
