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
    public partial class StaffLoginForm : Form
    {
        string accountType = "";
        MainForm mainForm;
        QueueForm qf;
        ReceptionistForm receptionistForm;

        public StaffLoginForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            qf = new QueueForm();
            receptionistForm = new ReceptionistForm(qf, this);
        }
        

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string user = guna2TextBox1.Text;
            string pass = guna2TextBox2.Text;
            bool founduser = false, foundpass = false;

            foreach (DataGridViewRow row in mainForm.guna2DataGridView4.Rows)
            {
                if (user.Equals(row.Cells[1].Value))
                {
                    founduser = true;
                    if (pass.Equals(row.Cells[2].Value))
                    {
                        foundpass = true;
                        accountType = row.Cells[4].Value.ToString();
                        break;
                    }
                }
            }

           if (founduser)
           {
              if (foundpass)
                {
                    if (accountType.Equals("Receptionist"))
                    {
                        
                        qf.Show();
                        receptionistForm.Show();
                        this.Hide();
                        
                    } else
                    {
                        qf.Show();
                        StaffForm sff = new StaffForm(qf, this, receptionistForm);
                        sff.Show();
                        this.Hide();
                    }

                    guna2TextBox1.Text = string.Empty;
                    guna2TextBox2.Text = string.Empty;
                } else
                {
                    MessageBox.Show("Wrong pass");
                }
           } else
            {
                MessageBox.Show("Wrong user");
            }
        }
    }
}
