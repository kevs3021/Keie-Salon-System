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
    public partial class DayFill : UserControl
    {
        public DayFill()
        {
            InitializeComponent();
        }

        private void DayFill_Load(object sender, EventArgs e)
        {

        }

        public void perDay(int day)
        {
            label1.Text = day + "";
        }
    }
}
