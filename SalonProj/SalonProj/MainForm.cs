using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Web.WebSockets;

namespace SalonProj
{
    public partial class MainForm : Form
    {

        LoginForm loginForm;
        StaffLoginForm staffLoginForm;
        
        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            loadForm();
            this.loginForm = loginForm;
            loadCalendar();
            loadServices();
            staffLoginForm = new StaffLoginForm(this);
        }

        // ------------------------------- DECLARATIONS ------------------------------------ //

        int guests = 0;
        int currentGuest = 1;
        string chosenService = "";
        string chosenEmployee = "";
        int month, year;

        // --------------------------------------------------------------------------------- //

        private void loadServices()
        {
            
            string connstring = "server=localhost;uid=root;pwd=kevs1024;database=salondatabase";
            MySqlConnection con = new MySqlConnection(connstring);
            con.Open();
            string query = "select * from servicestable";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] obj = { reader["serviceName"], reader["price"], reader["category"] };
                guna2DataGridView2.Rows.Add(obj);
            }
        }

       
        private void loadCalendar()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month).ToUpper();
            label17.Text = monthName + " / "+year;
            DateTime start = new DateTime(year, month,1);
            int days = DateTime.DaysInMonth(year, month);
            int daysWeek = Convert.ToInt32(start.DayOfWeek.ToString("d"));
            for (int i = 1;i<daysWeek; i++)
            {
                CalendarDay blankPage = new CalendarDay();
                flowLayoutPanel1.Controls.Add(blankPage);
            }
            for (int i =1;i<days;i++)
            {
                DayFill dayfill = new DayFill();
                dayfill.perDay(i);
                flowLayoutPanel1.Controls.Add(dayfill);
            }


        }
        private void loadForm()
        {
            object[] obj = { "kev", "kev123" };
           // dataGridView1.Rows.Add(obj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            guna2Panel1.Visible = false;
        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            guna2Panel1.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 1;


            

            if (guna2RadioButton1.Checked)
            {
                guests = 1;
            } else
            {
                if (guna2ComboBox1.SelectedIndex == 0)
                {
                    guests = 2;
                } else
                {
                    guests = 3;
                }
            }

            for (int i = guests; i > 0; i--)
            {
                ServiceInfoPanel guestPanel = new ServiceInfoPanel();
                guestPanel.Name = "guestPanel_"+i;
                guestPanel.Dock = DockStyle.Top;
                if (i != 1)
                {
                    guestPanel.label1.Text = "Guest " + (i-1) + " Services";
                }
                guna2Panel2.Controls.Add(guestPanel);
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                guna2ComboBox3.Visible = false;
            } else
            {
                guna2ComboBox3.Visible = true;
                if (guna2ComboBox2.SelectedIndex == 1)
                {
                    guna2ComboBox3.Items.Clear();
                    string[] items = { "Bangs trim - $30", "Mens haircut" };
                    guna2ComboBox3.Items.AddRange(items);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 3;
            chosenService = guna2ComboBox3.Text;
        }

        private void guna2RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            guna2Panel3.Visible = true;
            chosenEmployee = "Kevin";
        }

        private void guna2RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            guna2Panel3.Visible = false;
            chosenEmployee = "Female Employee";
        }

        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            guna2Panel3.Visible = false;
            chosenEmployee = "Male Employee";
        }

        private void guna2RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            guna2Panel3.Visible = false;
            chosenEmployee = "Any Employee";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            object[] info = { "Guest", chosenService, "$0", chosenEmployee };
            guna2DataGridView1.Rows.Add(info);
            UserControl findPanel = guna2Panel2.Controls.Find("guestPanel_"+currentGuest,false).First() as UserControl;
            if (findPanel != null)
            {
                Services addService = new Services();
                addService.Dock = DockStyle.Top;
                addService.setServiceData(chosenService, "$0", chosenEmployee);
                findPanel.Controls.Add(addService);
                
            }

            DialogResult result;
            if (currentGuest == 1)
            {
                result = YesNoDialog.Show("Would you like to add service for you?","Add extra service");
            } else
            {
               result = YesNoDialog.Show("Would you like to add service for guest"+(guests-1)+"?","Add extra service");
            }
            
            if (result == DialogResult.Yes)
            {
                guna2TabControl1.SelectedIndex = 1; 
            } else
            {
                if (guests == currentGuest)
                {
                    guna2TabControl1.SelectedIndex = 4;
                } else
                {
                    guna2TabControl1.SelectedIndex = 1;
                    currentGuest++;
                    label4.Text = "Select Services for Guest" + (currentGuest-1);
                }
            }
            
        }

        private void label15_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            month--;
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month).ToUpper();
            label17.Text = monthName + " / " + year;

            DateTime now = DateTime.Now;
            DateTime start = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int daysWeek = Convert.ToInt32(start.DayOfWeek.ToString("d"));
            for (int i = 1; i < daysWeek; i++)
            {
                CalendarDay blankPage = new CalendarDay();
                flowLayoutPanel1.Controls.Add(blankPage);
            }
            for (int i = 1; i < days; i++)
            {
                DayFill dayfill = new DayFill();
                dayfill.perDay(i);
                flowLayoutPanel1.Controls.Add(dayfill);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            month++;
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month).ToUpper();
            label17.Text = monthName + " / " + year;

            DateTime now = DateTime.Now;
            DateTime start = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int daysWeek = Convert.ToInt32(start.DayOfWeek.ToString("d"));
            for (int i = 1; i < daysWeek; i++)
            {
                CalendarDay blankPage = new CalendarDay();
                flowLayoutPanel1.Controls.Add(blankPage);
            }
            for (int i = 1; i < days; i++)
            {
                DayFill dayfill = new DayFill();
                dayfill.perDay(i);
                flowLayoutPanel1.Controls.Add(dayfill);
            }
        }

        
    }


}
