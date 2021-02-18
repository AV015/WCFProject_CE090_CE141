using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStore
{
    class BuyMedicineService : IBuyMedicineService
    {
        public string addPurchaseData(Buy b)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Purchase(UserId,MedicineName,Quantity,Amount,Date) values(@uid,@mname,@qty,@amount,@dt)", con);
            cmd.Parameters.AddWithValue("@uid", b.UserId);
            cmd.Parameters.AddWithValue("@mname", b.MedicineName);
            cmd.Parameters.AddWithValue("@qty", b.Quantity);
            cmd.Parameters.AddWithValue("@amount", b.Amount);
            cmd.Parameters.AddWithValue("@dt", b.Date);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "Transaction Done Successfully";
            }
            else
            {
                Message = " Error Occured While Transaction Done";
            }
            con.Close();
            return Message;
        }
    }
}
