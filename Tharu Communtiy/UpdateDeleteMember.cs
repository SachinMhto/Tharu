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
    public partial class UpdateDeleteMember : Form
    {
        public UpdateDeleteMember()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
              retriveData();

                
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        void retriveData() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select * from memberDetails_tbl where passbookNo=@passbookNo";
                SqlCommand cmd = new SqlCommand(q, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@passbookNo",
                   Convert.ToInt32(textBox1.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // Read the data
                    while (reader.Read())
                    {
                        // Display the data in the text boxes
                        textBox2.Text = reader["memberName"].ToString();
                        textBox3.Text = reader["parentName"].ToString();
                        textBox4.Text = reader["mobileNo"].ToString();
                        textBox5.Text = reader["address"].ToString();
                        textBox6.Text = reader["email"].ToString();
                    }
                }
                else {
                    MessageBox.Show("No data found for the given passbook number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
