using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStore
{
    class MedicalSystemService : IMedicalSystemService
    {
        public string addMedicineData(Medicine m)
        {
            string mname, Message;
            int stock, price;

            mname = m.MedicineName;
            stock = m.Stock;
            price = m.Price;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Medicine(MedicineName,Stock,Price) values(@mname,@stock,@price)", con);
                cmd.Parameters.AddWithValue("@mname", mname);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@price", price);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Message = "Details Inserted Successfully";
                }
                else
                {
                    Message = " Details Aren't Inserted Successfully";
                }
                con.Close();
                return Message;        
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
        }

        public DataSet viewMedicineData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Medicine", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
    }
}
