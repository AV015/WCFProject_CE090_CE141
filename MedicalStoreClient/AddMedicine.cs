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
    public partial class AddMedicine : Form
    {
        ServiceReference2.MedicalSystemServiceClient proxy = new ServiceReference2.MedicalSystemServiceClient();
        public AddMedicine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Medicine m = new ServiceReference2.Medicine();
            m.MedicineName = textBox1.Text;
            m.Stock = Convert.ToInt32(textBox2.Text);
            m.Price = Convert.ToInt32(textBox3.Text);

            string msg = proxy.addMedicineData(m);
            label5.Visible = true;
            label5.Text = msg;
        }
    }
}
