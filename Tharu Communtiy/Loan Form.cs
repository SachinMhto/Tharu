using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tharu_Communtiy
{
    public partial class Loan_Form : Form
    {
        public Loan_Form()
        {
            InitializeComponent();
            dateTimePicker1.Value= DateTime.Now;

        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private string memberName;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        void validation(KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e);
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
                   Convert.ToInt32(textBox3.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // Read the data
                    while (reader.Read())
                    {
                        // Display the data in the text boxes
                        textBox1.Text = textBox3.Text;
                        textBox2.Text = reader["memberName"].ToString();

                    }

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
        void reset() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            dateTimePicker2.Value = DateTime.Now;
            textBox9.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text) ||
           string.IsNullOrWhiteSpace(textBox6.Text) ||
           string.IsNullOrWhiteSpace(textBox7.Text) ||
           string.IsNullOrWhiteSpace(textBox8.Text) ||
           string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateTimePicker1.Value.Date==dateTimePicker2.Value.Date) {
                MessageBox.Show("Deadline Cannot be Equal to Loan provided date", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Proceed to check for previous loan
                getName();
                checkPre();
               
            }
        }
        void getName() {
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
        void checkPre() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select status from loaninfo_tbl where passbookNo=@pass";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string status = result.ToString();

                    if (status.Equals("pending", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("There is a pending loan. Operation cannot proceed.", "Pending Loan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else if (status.Equals("paid", StringComparison.OrdinalIgnoreCase)) {
                        insert();
                    }
                    
                }
                else
                {
                    insert();
                     }
    }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
        void insert() {
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "INSERT INTO loaninfo_tbl (passbookNo, loanIssueDate, loanDeadline, loanAmt, interestRate, serviceCharge, trustedPersons, status,loanAmt_interestAmt,remaining_Loan,description) " +
                           "VALUES (@passbookNo, @loanIssueDate, @loanDeadline, @loanAmt, @interestRate, @serviceCharge, @trustedPerson, @status,@loanAmt_interestAmt,@remain,@desc)";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@passbookNo", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@loanIssueDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@loanDeadline", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@loanAmt", Convert.ToDecimal(textBox5.Text));
                cmd.Parameters.AddWithValue("@interestRate", Convert.ToDecimal(textBox6.Text));
                cmd.Parameters.AddWithValue("@serviceCharge", Convert.ToDecimal(textBox7.Text));
                cmd.Parameters.AddWithValue("@trustedPerson", textBox9.Text);
                cmd.Parameters.AddWithValue("@status", "pending");
                cmd.Parameters.AddWithValue("@loanAmt_interestAmt", Convert.ToDecimal(textBox8.Text));
                cmd.Parameters.AddWithValue("@remain", Convert.ToDecimal(textBox8.Text));
                cmd.Parameters.AddWithValue("@desc", "Community provided Loan To "+ memberName);



                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Loan successfully provided.");
                    reset();
                }
                else
                {
                    MessageBox.Show("loan failed to provide");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox8.Clear();
                MessageBox.Show("Please enter a valid loan amount.");
                
            }
            else { 
            textBox8.Text = textBox5.Text;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        void update() {
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                int interestRate = int.Parse(textBox6.Text);
                decimal interestRateDecimal = interestRate / 100m;
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;
                int monthsDifference = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
                decimal totalInterest = int.Parse(textBox5.Text) * interestRateDecimal * monthsDifference;
                decimal finalAmt = totalInterest + int.Parse(textBox5.Text);
                textBox8.Text = finalAmt.ToString();
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            update();


            //if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
            //{
            //    // Parse values from textboxes
            //    if (decimal.TryParse(textBox5.Text, out decimal loanAmount) &&
            //        int.TryParse(textBox6.Text, out int interestRate))
            //    {
            //        // Convert interest rate to decimal
            //        decimal interestRateDecimal = interestRate / 100m;

            //        // Calculate the difference in months
            //        DateTime startDate = dateTimePicker1.Value;
            //        DateTime endDate = dateTimePicker2.Value;
            //        int monthsDifference = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;

            //        // Calculate total interest
            //        decimal totalInterest = loanAmount * interestRateDecimal * monthsDifference;

            //        // Calculate final amount
            //        decimal finalAmt = totalInterest + loanAmount;

            //        // Display the final amount in textBox8
            //        textBox8.Text = finalAmt.ToString("F2"); // Format to 2 decimal places
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please enter valid numeric values.");
            //    }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            update();
        }

        private void editLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
            button1.Visible = !button1.Visible;
            button3.Visible = !button3.Visible;
            button4.Visible = button3.Visible;
            button2.Visible = button1.Visible;
            button5.Visible = button3.Visible;
            if (button1.Visible == true)
            {
                label1.Text = "Loan Form";
                label1.BackColor = Color.White;
            }
            else {
                label1.Text = "Edit Loan Form";
                label1.BackColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                retriveData();
                fetch();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void fetch()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string q = "select * from loaninfo_tbl where passbookNo=@pass and status=@status";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@pass", int.Parse(textBox3.Text));
                        cmd.Parameters.AddWithValue("@status", "pending");

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox3.Text = reader["passbookNo"].ToString();

                                DateTime loanIssueDate;
                                if (DateTime.TryParse(reader["loanIssueDate"].ToString(), out loanIssueDate))
                                {
                                    dateTimePicker1.Value = loanIssueDate;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid loan issue date.");
                                }

                                DateTime loanDeadline;
                                if (DateTime.TryParse(reader["loanDeadline"].ToString(), out loanDeadline))
                                {
                                    dateTimePicker2.Value = loanDeadline;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid loan deadline date.");
                                }

                                textBox5.Text = reader["loanAmt"].ToString();
                                textBox6.Text = reader["interestRate"].ToString();
                                textBox7.Text = reader["serviceCharge"].ToString();
                                textBox9.Text = reader["trustedPersons"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the provided passbook number and status.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text) ||
          string.IsNullOrWhiteSpace(textBox6.Text) ||
          string.IsNullOrWhiteSpace(textBox7.Text) ||
          string.IsNullOrWhiteSpace(textBox8.Text) ||
          string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Deadline Cannot be Equal to Loan provided date", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                updateLoaninfo();
            }
          
        }
        void updateLoaninfo()
        {
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "UPDATE loaninfo_tbl " +
                      "SET loanDeadline = @ld, loanAmt = @la, interestRate = @ia, serviceCharge = @sc, trustedPersons = @tp " +
                      "WHERE passbookNo = @pass AND status = @status";
                SqlCommand cmd = new SqlCommand(q,conn);
                cmd.Parameters.AddWithValue("@ld", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@la", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@ia", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@sc", decimal.Parse(textBox7.Text));
                cmd.Parameters.AddWithValue("@tp", textBox9.Text);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@status", "pending");

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Loan information updated successfully.");
                    reset();
                }
                else
                {
                    MessageBox.Show("No record found with the given passbook number and status.");
                }
            
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deletedata();
        }
        void deletedata()
        {
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "delete from loaninfo_tbl where passbookNo=@pass and status=@status";
                SqlCommand cmd=new SqlCommand(q,conn);
                cmd.Parameters.AddWithValue("@pass",int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@status", "pending");
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Loan information deleted successfully.");
                    reset();
                }
                else
                {
                    MessageBox.Show("No record found with the given passbook number and status.");
                }

            } catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
