using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tharu_Communtiy
{
    public partial class StatementForms : Form
    {
        public StatementForms()
        {
            InitializeComponent();
        }

        private void StatementForms_Load(object sender, EventArgs e)
        {
            this.monthlyDepo_tblTableAdapter.Fill(this.tharu_CommunityDataSet1.monthlyDepo_tbl);
            this.installment_tblTableAdapter.Fill(this.tharu_CommunityDataSet3.installment_tbl);
            this.loaninfo_tblTableAdapter.Fill(this.tharu_CommunityDataSet3.loaninfo_tbl);

            this.reportViewer1.RefreshReport();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < dateTimePicker2.Value.Date)
            {
                running();
            }
            else
            {
                MessageBox.Show("Start date must be greater than the end date. Please select a valid date range.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void running() {

            try
            {
                int startYear = dateTimePicker1.Value.Year;
                int startMonth = dateTimePicker1.Value.Month;
                int endYear = dateTimePicker2.Value.Year;
                int endMonth = dateTimePicker2.Value.Month;

                this.loaninfo_tblTableAdapter.FillByHello(this.tharu_CommunityDataSet3.loaninfo_tbl, startYear, startMonth, endYear, endMonth);
                this.installment_tblTableAdapter.FillByDate1(this.tharu_CommunityDataSet3.installment_tbl, startYear, startMonth, endYear, endMonth);
                this.monthlyDepo_tblTableAdapter.FillByMonth(this.tharu_CommunityDataSet1.monthlyDepo_tbl, startYear, startMonth, endYear, endMonth);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value= DateTime.Now;
            dateTimePicker2.Value= DateTime.Now;
            this.installment_tblTableAdapter.Fill(this.tharu_CommunityDataSet3.installment_tbl);
            this.loaninfo_tblTableAdapter.Fill(this.tharu_CommunityDataSet3.loaninfo_tbl);

            this.reportViewer1.RefreshReport();
        }
    }
}
