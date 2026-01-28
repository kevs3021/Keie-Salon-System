using MySql.Data.MySqlClient;
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
    public partial class StaffForm : Form
    {
        QueueForm qf;
        StaffLoginForm stf;
        ReceptionistForm rf;
        List<string> finishedServices = new List<string>(); 
        object currentCustomerQueueID = "";
        object customerName = "";
        public StaffForm(QueueForm qf, StaffLoginForm stf, ReceptionistForm rf)
        {
            InitializeComponent();
            this.qf = qf;
            this.stf = stf;
            this.rf = rf;
            loadProducts();
        }

        private void loadProducts()
        {
            List<string> products = new List<string>();
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string query2 = "select * from producttable";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                products.Add(reader["productName"].ToString());
            }
            guna2ComboBox3.Items.AddRange(products.ToArray());

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in rf.guna2DataGridView4.Rows)
            {
                if (currentCustomerQueueID.Equals(row.Cells[0].Value))
                {
                    CheckBox check = new CheckBox();
                    check.Text = row.Cells[1].Value.ToString();
                    flowLayoutPanel1.Controls.Add(check);
                }
            }
            label1.Text = "Current Queue ID: "+currentCustomerQueueID.ToString();
            label3.Text = "Customer Name: "+customerName.ToString();


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox) control;
                    finishedServices.Add(checkBox.Text);
                }
            }

            object[] obj = { currentCustomerQueueID, customerName };
            rf.guna2DataGridView5.Rows.Add(obj);

            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            foreach (DataGridViewRow rows in guna2DataGridView6.Rows)
            {
                double currentPrice = 0;
                string query2 = "select * from producttable where productName = @name";
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@name", rows.Cells[0].Value.ToString());

                MySqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    currentPrice = Convert.ToDouble(reader["stocks"]) - Convert.ToDouble(rows.Cells[1].Value);
                }

                reader.Close();

                string query3 = "update producttable set stocks = @stocks where productName = @name";
                MySqlCommand cmd3 = new MySqlCommand(query3, con);
                cmd3.Parameters.AddWithValue("@name", rows.Cells[0].Value.ToString());
                cmd3.Parameters.AddWithValue("@stocks", currentPrice);
                cmd3.ExecuteNonQuery();
            }

          

            rf.guna2DataGridView6.Rows.Clear();
            rf.loadInventory();


        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            stf.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            object[] obj = { guna2ComboBox3.Text, 1 };
            guna2DataGridView6.Rows.Add(obj);
            guna2ComboBox3.SelectedIndex = -1;
        }

        private void guna2DataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2) 
            {
                int currentQuantity = Convert.ToInt32(guna2DataGridView6.Rows[e.RowIndex].Cells[1].Value);

                if (currentQuantity > 0)
                {
                    guna2DataGridView6.Rows[e.RowIndex].Cells[1].Value = currentQuantity+1;
                }
            } else if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                int currentQuantity = Convert.ToInt32(guna2DataGridView6.Rows[e.RowIndex].Cells[1].Value);

                if (currentQuantity > 1)
                {
                    guna2DataGridView6.Rows[e.RowIndex].Cells[1].Value = currentQuantity - 1;
                } else
                {
                    guna2DataGridView6.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
