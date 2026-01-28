
using Guna.UI2.WinForms;
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
    public partial class QueueForm : Form
    {   

        public event EventHandler QueueChanged;
        public string currentCustomer { get; set; }
        public string currentQueueID { get; set; }

        public QueueForm()
        {
            InitializeComponent();
 
        }

        private void pushButton(object sender, EventArgs e)
        {
            if (guna2ComboBox3.Text != string.Empty)
            {
                Guna2Button b = sender as Guna2Button;
                QueuePanel con = b.Parent as QueuePanel;

                currentQueueID = con.label13.Text;
                currentCustomer = con.label1.Text;

                int index = flowLayoutPanel1.Controls.IndexOf(con);

                if (index < flowLayoutPanel1.Controls.Count - 1)
                {
                    Guna2Button nxt = (flowLayoutPanel1.Controls[index + 1].Controls["guna2Button9"] as Guna2Button);
                    nxt.Visible = true;
                }
                QueueChanged?.Invoke(this, EventArgs.Empty);
                flowLayoutPanel1.Controls.Remove(con);
            } else
            {
                guna2MessageDialog1.Show("Select Staff first!", "Invalid Ticket");
            }
           
        }

        public void addQueue(string ID, int Services, string name)
        {
            QueuePanel queuePanel = new QueuePanel();
            queuePanel.label13.Text = ID;
            queuePanel.label2.Text = "Services: " + Services;
            queuePanel.label1.Text = "Name: " + name;
            queuePanel.Name = "queue" + ID;
            queuePanel.guna2Button9.Visible = flowLayoutPanel1.Controls.Count == 0;
            queuePanel.guna2Button9.Click += pushButton;
            flowLayoutPanel1.Controls.Add(queuePanel);
        }
    }
}
