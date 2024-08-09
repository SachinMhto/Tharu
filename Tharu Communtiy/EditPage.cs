using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tharu_Communtiy
{
    public partial class EditPage : Form
    {
        public EditPage()
        {
            InitializeComponent();
        }
        
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private void button4_Click(object sender, EventArgs e)
        {
            getAllData();
        }
        void getAllData()
        {
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select id from loaninfo_tbl where passbookNo=@pass and status=@status";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@status", "pending");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder sb = new StringBuilder();

                while (reader.Read())
                {
                    sb.AppendLine(reader["id"].ToString());
                }

                if (sb.Length > 0)
                {
                    textBox2.Text = sb.ToString();
                    textBox6.Text = textBox1.Text;
                    updateCode();
                }
                else
                {
                    textBox2.Text = "No data found.";
                }

                reader.Close();
            }

            catch (Exception ex) {
                MessageBox.Show("getAllDataError:" + ex.Message);
            }
        }
        void updateCode() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select * from installment_tbl where passbookNo=@pass and loanId=@loan";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@loan", int.Parse(textBox2.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                conn.Open();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("updateCodeError: " + ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateSave();
        }
        void cleanData() {

            textBox3.Clear();
            textBox4.Clear();

        }
        void updateSave() {
            try {
                SqlConnection conn = new SqlConnection(cs);
                string q = "UPDATE installment_tbl SET payAmt=@payAmt, fine=@fine WHERE id=@id";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@payAmt", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@fine", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));
                MessageBox.Show(textBox5.Text);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    updateCode();
                    finalUpdateInDb();
                    cleanData();
                    MessageBox.Show("Update successful.");

                }
                else
                {
                    MessageBox.Show("No records updated.");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        int remDataFun()
        {
            int totalPayAmout = 0;
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string q = "select payAmt from installment_tbl where loanId=@loan and passbookNo=@pass";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@loan", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox6.Text));
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        totalPayAmout += Convert.ToInt32(reader["payAmt"]);
                    }
                    catch (InvalidCastException)
                    {
                        MessageBox.Show($"Error casting payAmt to int. Actual value: {reader[0].ToString()}");
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error from remDataFun: " + ex.Message);
            }
            return totalPayAmout;
        }

        int fetchingDataFromloanInfo()
        {
            int totalAmt = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string q = "SELECT loanAmt_interestAmt FROM loaninfo_tbl WHERE id=@loan AND passbookNo=@pass";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@loan", int.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@pass", int.Parse(textBox6.Text));

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            decimal loanAmt_interestAmt = Convert.ToDecimal(reader["loanAmt_interestAmt"]);
                            totalAmt = (int)loanAmt_interestAmt;
                        }
                        catch (InvalidCastException)
                        {
                            MessageBox.Show($"Error casting loanAmt_interestAmt to decimal. Actual value: {reader[0].ToString()}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found for the given loanId and passbookNo.");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return totalAmt;
        }

        void finalUpdateInDb()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "UPDATE loaninfo_tbl SET remaining_loan=@amt WHERE id=@id AND passbookNo=@pass";
                SqlCommand cmd = new SqlCommand(q, conn);
                int remAmt = fetchingDataFromloanInfo() - remDataFun();
                cmd.Parameters.AddWithValue("@amt", remAmt);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@pass", int.Parse(textBox6.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error from finalAmtDb: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            deleteData();
        }
        void deleteData() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "Delete from installment_tbl where id=@id";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));
                MessageBox.Show(textBox5.Text);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    updateCode();
                    finalUpdateInDb();
                    cleanData();
                    MessageBox.Show("Delete successfuly.");

                }
                else
                {
                    MessageBox.Show("No records Deleted.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
