using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tharu_Communtiy
{
    public partial class ChangePassword : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check();
        }
        private void button1_Click(object sender, EventArgs e)
        {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            
        }
        void change()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string query = "UPDATE admin_tbl SET Password = @password WHERE Username = @user";
                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password changed successfully.");
                }
                else
                {
                    MessageBox.Show("Username not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to change password. Error: " + ex.Message);
            }
            
        }
        void check()
        {
            // Check if any of the required text boxes are empty
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                // Check if the passwords match only if all fields are filled
                if (textBox3.Text.Equals(textBox4.Text))
                {
                    change();
                }
                else
                {
                    MessageBox.Show("Passwords do not match.");
                }
            }
        }

        }
}
