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
    public partial class Form1 : Form
    {
        ServiceReference1.RegistrationServiceClient proxy = new ServiceReference1.RegistrationServiceClient();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.UserDetails obj_user = new ServiceReference1.UserDetails();
            obj_user.UserName = textBox1.Text;
            obj_user.Password = textBox2.Text;
            string msg = proxy.InsertUserDetails(obj_user);
            label4.Visible = true;
            label4.Text = msg;

            Login l = new Login();
            l.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            l.Show();
        }
    }
}
