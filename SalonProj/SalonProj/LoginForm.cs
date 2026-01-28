using Guna.UI2.WinForms;
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
    public partial class LoginForm : Form
    {
        MainForm mainform;
        public LoginForm()
        {
            InitializeComponent();
            
            mainform = new MainForm(this);
            loadAccounts();
        } 

        private void loadAccounts()
        {
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();
            string query = "select * from salondatabase.accountdatabase";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] obj = { reader["AccountNumber"], reader["username"], reader["hashedPassword"], reader["name"], reader["accountType"] };
                mainform.guna2DataGridView4.Rows.Add(obj);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private const int shadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = shadow;
                return cp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainform = new MainForm(this);
            mainform.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            StaffLoginForm st = new StaffLoginForm(mainform);
            st.Show();
        }



        /*  private void button1_Click(object sender, EventArgs e)
          {
              string email = maskedTextBox1.Text;
              string password = maskedTextBox2.Text;
              bool correctEmail = false, correctPass = false;

              foreach (DataGridViewRow rows in mainform.dataGridView1.Rows)
              {
                  if (rows.Cells[0].Value.ToString() == email)
                  {
                      correctEmail = true;
                      if (rows.Cells[1].Value.ToString() == password)
                      {
                          correctPass = true;
                      }
                  }
              }

              if (correctEmail)
              {
                  if (correctPass)
                  {
                      mainform.Show();
                      this.Hide();
                  } else
                  {
                      MessageBox.Show("Incorrect Credentials!");
                  }
              } else
              {
                  MessageBox.Show("No account found!");
              }

          } */
    }
}
