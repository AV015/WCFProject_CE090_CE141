using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStore
{
    [ServiceContract]
    interface IRegistrationService
    {

        [OperationContract]
        string InsertUserDetails(UserDetails userInfo);
        [OperationContract]
        DataSet SelectUserDetails();
    }
    
    [DataContract]
    public class UserDetails
    {
        int userid;
        string username;
        string password;
     
        [DataMember]
        public int Id
        {
            get { return userid; }
            set { userid = value; }
        }
        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}

