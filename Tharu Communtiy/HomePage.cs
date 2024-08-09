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
    public partial class HomePage : Form
    {
        public string Username { get; set; }

        public HomePage(string username)
        {
            InitializeComponent();
            Username = username;
            timer1.Interval = 60000; // Set interval to 1 minute (60000 milliseconds)
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            // Initialize the label with the current date and time
            UpdateDateTimeLabel();
            textBox1.Text= Username;
        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
        }
        private void UpdateDateTimeLabel()
        {
            // Set the label's text to the current date and time
            label12.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MembersCRUD mc = new MembersCRUD();
            mc.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void updateDeleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteMember udm=new UpdateDeleteMember();
            udm.ShowDialog();
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
                   Convert.ToInt32(textBox2.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                   
                    while (reader.Read())
                    {
                        textBox3.Text = textBox2.Text;
                        textBox4.Text = reader["memberName"].ToString();
                        textBox5.Text = reader["parentName"].ToString();
                        textBox7.Text = reader["mobileNo"].ToString();
                        textBox6.Text = reader["email"].ToString();
                    }
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = !tableLayoutPanel2.Visible;
            button5.Visible = !button5.Visible;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            int amt = 0;
            int fine = 0;
            if (!string.IsNullOrEmpty(textBox8.Text))
            {
                int.TryParse(textBox8.Text, out amt);
            }
            if (!string.IsNullOrEmpty(textBox9.Text))
            {
                int.TryParse(textBox9.Text, out fine);
            }
            int total = amt + fine;
            textBox10.Text = total.ToString();
        }
    

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int amt = 0;
            int fine = 0;

            // Try to parse textBox8 text as integer, default to 0 if parsing fails
            if (!string.IsNullOrEmpty(textBox8.Text))
            {
                int.TryParse(textBox8.Text, out amt);
            }

            // Try to parse textBox9 text as integer, default to 0 if parsing fails
            if (!string.IsNullOrEmpty(textBox9.Text))
            {
                int.TryParse(textBox9.Text, out fine);
            }

            // Calculate total amount
            int total = amt + fine;

            // Display total amount in textBox10
            textBox10.Text = total.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox10.Text) && textBox10.Text != "0")
            {
                insertData(); // Call the insertData() method
            }
            else
            {
                // Optional: You can show a message or handle the case where no insertion occurs
                MessageBox.Show("Please enter a valid value in the textbox.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void resetDisplay() {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            tableLayoutPanel2.Visible = false;
        }
        void insertData() {
            try
            {

                int passbookNo = int.Parse(textBox3.Text);
                string name = textBox4.Text;
                int totalDeposite = int.Parse(textBox10.Text);
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    DateTime currentDateOfDeposit = DateTime.Now;

                    // SQL query to check for existing record
                    string checkQuery = "SELECT COUNT(*) FROM monthlyDepo_tbl " +
                                        "WHERE passbookNo = @passbookNo AND CAST(DateOfDeposite AS DATE) = CAST(@DateOfDeposite AS DATE)";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@passbookNo", passbookNo);
                        checkCmd.Parameters.AddWithValue("@DateOfDeposite", currentDateOfDeposit);

                        int recordCount = (int)checkCmd.ExecuteScalar();

                        if (recordCount > 0)
                        {
                            // Record exists
                            MessageBox.Show("Monthly deposite already paid");
                        }
                        else
                        {
                            // SQL query to insert data
                            string insertQuery = "INSERT INTO monthlyDepo_tbl (passbookNo, Name, DateOfDeposite, TotaldepositeAmt) " +
                                                 "VALUES (@passbookNo, @Name, @DateOfDeposite, @TotaldepositeAmt)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                // Add parameters with values
                                insertCmd.Parameters.AddWithValue("@passbookNo", passbookNo);
                                insertCmd.Parameters.AddWithValue("@Name", name);
                                insertCmd.Parameters.AddWithValue("@DateOfDeposite", currentDateOfDeposit);
                                insertCmd.Parameters.AddWithValue("@TotaldepositeAmt", totalDeposite);

                                insertCmd.ExecuteNonQuery();
                                MessageBox.Show("Data inserted successfully!");
                                mpRefresh();
                                button2.Enabled = false;
                                tableLayoutPanel2.Visible = false;
                                button5.Visible = false;
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void monthlyPayEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyPayEdit mpe = new MonthlyPayEdit();
            mpe.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkMonthlyData()) {
                Loan_Form frm = new Loan_Form();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pay Monthly Bill First");
            }

        }
        bool checkMonthlyData()
        {
            bool recordExists = false;
            try {
                int passbookNo;
                if (!int.TryParse(textBox3.Text, out passbookNo))
                {
                    MessageBox.Show("Invalid Passbook No. Please enter a valid integer.");
                    return false;
                }
                SqlConnection conn = new SqlConnection(cs);
                string q = "SELECT COUNT(*) FROM monthlyDepo_tbl WHERE passbookNo = @pass AND CAST(DateOfDeposite AS DATE) = CAST(@depo AS DATE)";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@depo", DateTime.Today);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    recordExists = true;
                }
                else {
                    recordExists = false;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return recordExists;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkMonthlyData())
            {
                InstallmentForm instaForm = new InstallmentForm();
                instaForm.ShowDialog();
            }
            else {
                MessageBox.Show("Pay Monthly Bill First");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            resetDisplay();
            button5.Visible = false;
        }
        void mpRefresh() {
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void accountSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void monthlyDepositeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyReport rp = new MonthlyReport();
            rp.ShowDialog();
        }

        private void monthlyInstallmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyInstallment ip=new MonthlyInstallment();
                ip.ShowDialog();
        }

        private void statementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatementForms statement = new StatementForms();
            statement.ShowDialog();
        }

        private void memberStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberStatement ms=new MemberStatement();
            ms.ShowDialog();
        }

        private void loanProvidedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyLoanReport loan = new MonthlyLoanReport();
            loan.ShowDialog();
        }
    }
    
}
   


