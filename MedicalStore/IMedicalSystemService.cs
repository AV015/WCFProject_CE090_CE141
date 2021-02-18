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
    interface IMedicalSystemService
    {
        [OperationContract]
        DataSet viewMedicineData();

        [OperationContract]
        string addMedicineData(Medicine m);
    }

    [DataContract]
    public class Medicine
    {
        int mid;
        string mname;
        int stock;
        int price;

        [DataMember]
        public int Id
        {
            get { return mid; }
            set { mid = value; }
        }
        [DataMember]
        public string MedicineName
        {
            get { return mname; }
            set { mname = value; }
        }
        [DataMember]
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        [DataMember]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
   
    }
}
