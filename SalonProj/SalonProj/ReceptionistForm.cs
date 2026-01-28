using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics.Eventing.Reader;
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;

namespace SalonProj
{
    public partial class ReceptionistForm : Form
    {


        // --------------------- DECLARATIONS ------------------------------ //

        string customerName = "", customerContact = "", customerEmail = "";
        QueueForm queueform = new QueueForm();
        StaffLoginForm stf;
        int currentServiceID = 0;
        string selectedCustomer = "";
        List<string> accountInfoList = new List<string>();
        bool foundCustomer = false;
        AutoCompleteStringCollection nc = new AutoCompleteStringCollection();
        List<string> staffList = new List<string>();


        // ----------------------------------------------------------------- //


        public ReceptionistForm(QueueForm queueform, StaffLoginForm stf)
        {
            InitializeComponent();
            loadDataGridViews();
            this.queueform = queueform;
            this.stf = stf;
            loadInventory();
            guna2TextBox11.AutoCompleteSource = AutoCompleteSource.CustomSource;
            guna2TextBox11.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            queueform.QueueChanged += ticketStaff;
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
            guna2ComboBox4.Items.AddRange(products.ToArray());

        }


        public void loadInventory()
        {
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string query2 = "select * from producttable";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                object[] obj = { reader["productName"], "$"+reader["productPrice"], reader["stocks"] };
                guna2DataGridView6.Rows.Add(obj);
            }


        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            customerName = guna2TextBox1.Text;
            customerContact = guna2TextBox2.Text;
            customerEmail = guna2TextBox3.Text;

            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();
            string query = "insert into customerinfo (name, contact, email) value (@name,@contact,@email)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", customerName);
            cmd.Parameters.AddWithValue("@contact", customerContact);
            cmd.Parameters.AddWithValue("@email", customerEmail);
            cmd.ExecuteNonQuery();

            guna2DataGridView1.Rows.Clear();

            loadDataGridViews();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox11.Text != string.Empty)
            {
                guna2Button4.Enabled = true;
                guna2ComboBox1.Enabled = true;
                guna2ComboBox2.Enabled = true;

                selectedCustomer = guna2TextBox1.Text;
            }

            guna2Button5.Enabled = false;
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.Items.Clear();
            guna2DataGridView3.Rows.Clear();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            guna2ComboBox2.Items.Clear();
            List<object> serviceList = new List<object>();
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string query = "select * from servicestable where category = @category";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@category", guna2ComboBox1.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                serviceList.Add(reader["serviceName"]+" - $" + reader["price"]);
            }

            reader.Close();
            guna2ComboBox2.Items.AddRange(serviceList.ToArray());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string selected = guna2ComboBox2.Text;
            string serviceName = selected.Split(new string[] {" - "}, StringSplitOptions.None)[0];

            string query = "select * from servicestable where serviceName = @serviceID";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@serviceID", serviceName);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] obj = { reader["serviceName"], reader["category"], "$"+reader["price"] };
                currentServiceID = Convert.ToInt32(reader["serviceID"]);
                guna2DataGridView3.Rows.Add(obj);
            }

            reader.Close();
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.Items.Clear();

            int total = 0;

            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                string priceString = row.Cells[2].Value.ToString();
                string numericString = priceString.Replace("$", "");

                total += Convert.ToInt32(int.Parse(numericString));
            }

            label9.Text = "Total Price: $" + total;

            guna2Button5.Enabled = true;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3.SelectedRows.Count > 0)
            {
                int index = guna2DataGridView3.SelectedRows[0].Index;
                guna2DataGridView3.Rows.RemoveAt(index);
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string currentID = generateTicket();
            int queueNum = 1;
            int serviceCount = 0;

            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                object[] objj = { currentID, row.Cells[0].Value, "Pending", row.Cells[2].Value };
                guna2DataGridView4.Rows.Add(objj);
                serviceCount++;
            }

            string[] parts = label13.Text.Split(':');
            string name = parts[1].Trim();  
            queueform.addQueue(currentID, serviceCount, name);
                guna2DataGridView3.Rows.Clear();
                guna2Button5.Enabled = false;
                guna2Button4.Enabled = false;
                label9.Text = "Total Price:";
            label13.Text = "Customer Name:";
            label14.Text = "Contact:";
            label15.Text = "Email:";
            label12.Text = "Customer ID:";
            guna2TextBox11.Text = string.Empty;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            stf.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            string input = guna2TextBox11.Text;

            string pattern = @"\((\w+)\)";

            Match match = Regex.Match(input, pattern);

            string IDNumber = "";
            string numeric = "";

            if (match.Success)
            {
                IDNumber = match.Groups[1].Value;
                numeric = Regex.Match(IDNumber, @"\d+").Value;
            }

            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string query2 = "select * from customerinfo where customerNumber = @numeric";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@numeric", numeric);
            MySqlDataReader reader = cmd2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    label13.Text = "Customer Name: " + reader["firstName"] + " " + reader["lastName"];
                    int numerice = int.Parse(reader["customerNumber"].ToString());
                    string format = string.Format("SLN{0:000}", numerice);
                    label12.Text = "Customer ID: " + format;
                    label14.Text = "Contact: " + reader["contact"];
                    label15.Text = "Email: " + reader["email"];
                    foundCustomer = true;
                }
            } else
            {
                foundCustomer = false;
                ErrorDialog.Show("No Customer Found!","Error");
            }
           
        }

        private void guna2DataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private int CalculateHeight(DataGridViewCell cell)
        {
            int width = cell.Size.Width;
            string text = cell.FormattedValue.ToString();
            using (Graphics g = cell.DataGridView.CreateGraphics())
            {
                SizeF s = g.MeasureString(text, cell.DataGridView.Font, width);
                return (int)Math.Ceiling(s.Height) + 2;
            }
        }

        private void guna2DataGridView3_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView3.Rows)
            {
                int preferredHeight = CalculateHeight(row.Cells[0]);
                row.Height = preferredHeight;
            }
        }

        private void ReceptionistForm_Shown(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string query2 = "select * from staffdatabase";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                bool found = false;
                int numeric = int.Parse(reader["staffID"].ToString());
                string format = string.Format("STF{0:000}", numeric);
                if (guna2DataGridView2.RowCount != 0)
                {
                    foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                    {

                        if (format.Equals(row.Cells[0].Value.ToString()))
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    object[] obj = { format, reader["staffName"], reader["staffType"], "Available", "N/A", "N/A"};
                    guna2DataGridView2.Rows.Add(obj);
                    staffList.Add("("+format+") "+reader["staffName"].ToString());
                }
            }
            queueform.guna2ComboBox3.Items.Clear();
            queueform.guna2ComboBox3.Items.AddRange(staffList.ToArray());
        }

        private void loadDataGridViews()
        {

            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();

            string query2 = "select * from customerinfo";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            MySqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                object[] obj = { reader["firstName"], reader["lastName"], reader["contact"], reader["email"] };
                guna2DataGridView1.Rows.Add(obj);
                int numeric = int.Parse(reader["customerNumber"].ToString());
                string format = string.Format("SLN{0:000}", numeric);
                nc.Add(reader["firstName"] + " " + reader["lastName"] + " ("+format+")");
            }
            guna2TextBox11.AutoCompleteCustomSource = nc;
        
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            object[] obj = { guna2ComboBox4.Text, 1+"x" };
            guna2DataGridView8.Rows.Add(obj);
            guna2ComboBox4.SelectedIndex = -1;
        }

        private void guna2DataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string input = guna2DataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString();
            string pattern = @"\d+"; // Match one or more digits

            Match match = Regex.Match(input, pattern);

            int numericPart = 0;
            if (match.Success)
            {
                numericPart = int.Parse(match.Value);
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
               

                if (numericPart > 0)
                {
                    guna2DataGridView8.Rows[e.RowIndex].Cells[1].Value = numericPart + 1 + "x";
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                

                if (numericPart > 1)
                {
                    guna2DataGridView8.Rows[e.RowIndex].Cells[1].Value = numericPart - 1+"x";
                }
                else
                {
                    guna2DataGridView8.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void guna2TextBox10_TextChanged_1(object sender, EventArgs e)
        {
            if (guna2TextBox10.Text.Length >= 6)
            {
                guna2TextBox10.Text = guna2TextBox10.Text.Substring(0, 6);

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (guna2TextBox10.Text.Equals(row.Cells[4].Value.ToString()))
                    {
                        label19.Text = "Customer Name: " + row.Cells[5].Value.ToString();
                        label16.Text = "Assisted by: " + row.Cells[1].Value.ToString();
                        break;
                    }
                }
            }
            


        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView4.Rows)
            {
                if (guna2TextBox10.Text.Equals(row.Cells[0].Value))
                {
                    CheckBox check = new CheckBox();
                    check.Text = row.Cells[1].Value.ToString() + " (" + row.Cells[3].Value.ToString() + ")";
                    flowLayoutPanel1.Controls.Add(check);
                }
            }
        }

        private string generateTicket()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                char randomLetter = (char)random.Next('A', 'Z' + 1);
                sb.Append(randomLetter);

                int randomNum = random.Next(0, 10);
                sb.Append(randomNum);
            }

            return sb.ToString();

        }

        private void ticketStaff(object sender, EventArgs e)
        {

            string input = queueform.guna2ComboBox3.Text;

            string pattern = @"\((\w+)\)";

            Match match = Regex.Match(input, pattern);

            string IDNumber = "";
            string numeric = "";

            if (match.Success)
            {
                IDNumber = match.Groups[1].Value;
                numeric = Regex.Match(IDNumber, @"\d+").Value;
                queueform.guna2ComboBox3.Items.Remove(queueform.guna2ComboBox3.SelectedItem);
            }

            int eh = int.Parse(numeric);
            string format = string.Format("STF{0:000}", eh);

            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                if (row.Cells[0].Value.ToString() ==  format)
                {
                    row.Cells[4].Value = queueform.currentQueueID;
                    string[] parts = queueform.currentCustomer.Split(':');
                    string name = parts[1].Trim();
                    row.Cells[5].Value = name;
                    row.Cells[3].Value = "Assisting";
                    break;
                }
            }
        }
    }
}
