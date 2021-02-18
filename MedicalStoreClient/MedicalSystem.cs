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
    public partial class MedicalSystem : Form
    {
       
        public MedicalSystem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewMedicine vm = new ViewMedicine();
            vm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMedicine am = new AddMedicine();
            am.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuyMedicine bm = new BuyMedicine();
            bm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateMedicine um = new UpdateMedicine();
            um.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewPurchase vp = new ViewPurchase();
            vp.Show();
        }
    }
}
