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
    public partial class ViewMedicine : Form
    {
        ServiceReference2.MedicalSystemServiceClient proxy = new ServiceReference2.MedicalSystemServiceClient();
        public ViewMedicine()
        {
            InitializeComponent();
            DataSet ds = null;
            ds = proxy.viewMedicineData();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


        }
    }
}
