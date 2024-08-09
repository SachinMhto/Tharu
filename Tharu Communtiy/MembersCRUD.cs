using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Tharu_Communtiy
{
    public partial class MembersCRUD : Form
    {
        public MembersCRUD()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        string email = "abc@gmail.com";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        void reset() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
                try
                {
                   
                    int passbookNo = int.Parse(textBox1.Text); 
                    string name = textBox2.Text + " " + textBox3.Text + " " + textBox4.Text;
                    string parentName = textBox5.Text; 
                    long mobileNo = long.Parse(textBox6.Text);
                    string address = textBox7.Text; 
                  
                if (string.IsNullOrEmpty(email)) {
                  
                } else {
                   email = textBox8.Text;
                }

                   
                    string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

                   
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        
                        string query = "INSERT INTO memberDetails_tbl (passbookNo, memberName, parentName, mobileNo, address, email) VALUES (@passbookNo, @memberName, @parentName, @mobileNo, @address, @email)";

                       
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            
                            cmd.Parameters.AddWithValue("@passbookNo", passbookNo);
                            cmd.Parameters.AddWithValue("@memberName", name);
                            cmd.Parameters.AddWithValue("@parentName", parentName);
                            cmd.Parameters.AddWithValue("@mobileNo", mobileNo);
                            cmd.Parameters.AddWithValue("@address", address);
                            cmd.Parameters.AddWithValue("@email", email);

                           
                            conn.Open();

                           
                            int rowsAffected = cmd.ExecuteNonQuery();

                           
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Insert successful.");
                            reset();
                            }
                            else
                            {
                                MessageBox.Show("Insert failed.");
                            }
                        }
                    }
                }
                catch (SqlException sqlEx) when (sqlEx.Number == 2627) 
                {
                    MessageBox.Show("Duplicate passbook number. Please enter a unique passbook number.");
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
