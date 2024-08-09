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
    public partial class InstallmentForm : Form
    {
        public InstallmentForm()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private string memberName;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid(e);
        }
        void valid(KeyPressEventArgs e) {
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

        private void button1_Click(object sender, EventArgs e)
        {
            retriveData();
           
        }
        void retriveData()
        {
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
                        textBox3.Text = reader["memberName"].ToString();

                    }
                    getData();

                }
                else
                {
                    MessageBox.Show("No data found for the given passbook number.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getData() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "Select * from loaninfo_tbl where passbookNo=@pass and status=@status";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@status", "pending");
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    textBox2.Text = row["passbookNo"].ToString();

                    DateTime loanDeadline;
                    if (DateTime.TryParse(row["loanDeadline"].ToString(), out loanDeadline))
                    {
                        dateTimePicker1.Value = loanDeadline;
                    }
                    textBox4.Text = row["id"].ToString();
                    textBox5.Text = row["loanAmt"].ToString();
                    textBox6.Text = row["interestRate"].ToString();
                    textBox7.Text = row["loanAmt_interestAmt"].ToString();
                    textBox8.Text = row["remaining_loan"].ToString();
                    textBox9.Text = row["trustedPersons"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the provided passbook number and status.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            valid(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allReset();
        }
        void allReset() { 
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            dateTimePicker1.Value=DateTime.Now;

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            //int payment;
            //int loanAmt;

            //// Check if textBox10 is empty and set its value to "0"
            //if (string.IsNullOrEmpty(textBox10.Text))
            //{
            //    textBox10.Text = "0";
            //}

            //// Try parsing textBox10 value
            //if (!int.TryParse(textBox10.Text, out payment))
            //{
               
            //    return;
            //}

            //// Check if textBox7 is empty or contains invalid data
            //if (!int.TryParse(textBox7.Text, out loanAmt))
            //{
            //    return;
            //}

            //// Calculate remaining amount
            //int remaining_amt = loanAmt - payment;
            //textBox8.Text = remaining_amt.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {         
                
                insertingPay();
                checking();
            
           
        }
        void getName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select memberName from memberDetails_tbl where passbookNo=@pass";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
                conn.Open();
                memberName = cmd.ExecuteScalar()?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        void insertingPay()
        {
            getName();
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "insert into installment_tbl(passbookNo,loanId,fine,payAmt,description) values(@pass,@lid,@fine,@payAmt,@desc)";
                SqlCommand cmd=new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass",int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@lid",int.Parse(textBox4.Text));
                int fine = 0;
                if (!string.IsNullOrEmpty(textBox11.Text))
                {
                    int.TryParse(textBox11.Text, out fine);
                }
                cmd.Parameters.AddWithValue("@fine", fine);
                cmd.Parameters.AddWithValue("@desc","intallment Pay By "+ memberName);
                cmd.Parameters.AddWithValue("@payAmt",int.Parse(textBox10.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                updateRemAmt();
                MessageBox.Show("Record inserted successfully.");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void updateRemAmt() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "update loaninfo_tbl set remaining_loan=@loan where passbookNo=@pass and status=@status";
                SqlCommand cmd = new SqlCommand(q, conn);
                int remAmt = int.Parse(textBox8.Text) - int.Parse(textBox10.Text);
                cmd.Parameters.AddWithValue("@loan", remAmt);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@status", "pending");
                conn.Open(); cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void checking()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string selectQuery = "select remaining_loan from loaninfo_tbl where passbookNo=@pass and id=@id";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@pass", int.Parse(textBox2.Text));
                    selectCmd.Parameters.AddWithValue("@id", int.Parse(textBox4.Text));


                    conn.Open();
                    object result = selectCmd.ExecuteScalar();
                    conn.Close();

                    if (result != null && int.Parse(result.ToString()) == 0)
                    {
                        string updateQuery = "update loaninfo_tbl set status=@status where passbookNo=@pass";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@status", "paid");
                        updateCmd.Parameters.AddWithValue("@pass", int.Parse(textBox2.Text));

                        conn.Open();
                        updateCmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Status updated to 'paid'.");
                    }
                    allReset();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
               
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void editInstallmentPayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPage EP=new EditPage();
            EP.ShowDialog();
        }
    }

}
