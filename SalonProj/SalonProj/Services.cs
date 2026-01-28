using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonProj
{
    public partial class Services : UserControl
    {
        public Services()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        public void setServiceData (string service, string price, string employee)
        {
            label5.Text = service; 
            label6.Text = price; 
            label7.Text = employee;
        }
    }
}
