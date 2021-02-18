using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStore
{
    [ServiceContract]
    interface IPurchaseHistoryService
    {
        [OperationContract]
        DataSet viewPurchaseHistory(int id);
    }
}
