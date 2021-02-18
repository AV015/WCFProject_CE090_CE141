using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalStoreClient
{
    public partial class ViewPurchase : Form
    {
        ServiceReference3.PurchaseHistoryServiceClient proxy = new ServiceReference3.PurchaseHistoryServiceClient();
        public ViewPurchase()
        {
            InitializeComponent();
            DataSet ds = proxy.viewPurchaseHistory(Credential.uid);
            dataGridView1.DataSource = ds.Tables[0];
            
        }
    }
}
