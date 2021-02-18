using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStore
{
    [ServiceContract]
    interface IBuyMedicineService
    {
        [OperationContract]
        string addPurchaseData(Buy b);
    }

    public class Buy
    {
        int userid;
        string mname;
        int qty;
        int amount;
        DateTime dt;

        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }
        public string MedicineName
        {
            get { return mname; }
            set { mname = value; }
        }
        public int Quantity
        {
            get { return qty; }
            set { qty = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public DateTime Date
        {
            get { return dt; }
            set { dt = value; }
        }
    }
}
