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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tharu_Communtiy
{
    public partial class MonthlyPayEdit : Form
    {
        public MonthlyPayEdit()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimePicker1.Value.Date;
            DateTime dateTo = dateTimePicker2.Value.Date;
            if (string.IsNullOrWhiteSpace(textBox1.Text)) {
                MessageBox.Show("Passbook Number Field Is Missing", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dateFrom > dateTo)
            {
                MessageBox.Show("Date From should be before Date To.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fetch();
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.ReadOnly=false;
        }
        void reset() {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        void fetch() {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string q = "select * from monthlyDepo_tbl where passbookNo=@pass AND DateOfDeposite BETWEEN @startDate AND @endDate";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@pass", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@endDate", dateTimePicker2.Value);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        string q = "UPDATE monthlyDepo_tbl SET TotaldepositeAmt=@amt WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {
                           
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox2.Text));
                            cmd.Parameters.AddWithValue("@amt", Convert.ToInt64(textBox4.Text));
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Update successful.");
                              
                                reset();
                                fetch();
                            }
                            else
                            {
                                MessageBox.Show("No record found with the specified ID.");
                            }
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record permanently?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

               
                if (result == DialogResult.Yes)
                {
                    try
                    {  using (SqlConnection conn = new SqlConnection(cs))
                        {
                            string q = "DELETE FROM monthlyDepo_tbl WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(q, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox2.Text));

                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                    reset();
                                    fetch();
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the specified ID.");
                                }
                                conn.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Deletion canceled.");
                }
            }
            else
            {
                MessageBox.Show("Please enter the ID to delete.");
            }
        }
    }
    
}
