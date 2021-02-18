using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStore
{
    class RegistrationService : IRegistrationService
    {
      
        public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf; Integrated Security = True; Connect Timeout = 30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Registration(UserName,Password) values(@UserName,@Password)", con);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
          
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message =  "Details Inserted Successfully";
            }
            else
            {
                Message =  " Details Aren't Inserted Successfully";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectUserDetails()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\source\repos\MedicalStore\MedicalStoreClient\MedicalStoreDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Registration", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
    }
}
