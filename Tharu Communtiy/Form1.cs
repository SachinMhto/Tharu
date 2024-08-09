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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select * from admin_tbl where username=@username and password=@password";
                SqlCommand cmd=new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@username",textBox1.Text);
                cmd.Parameters.AddWithValue("@password",textBox2.Text);
                conn.Open();
                SqlDataReader dr=cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Tag = textBox1.Text; 

                    this.Close();
                }
                else {
                    MessageBox.Show("LOGIN FAILED...");
                }
                conn.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword cp=new ChangePassword();
            cp.ShowDialog();
        }
    }
}
