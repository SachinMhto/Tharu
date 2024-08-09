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
    public partial class MonthlyLoanReport : Form
    {
        public MonthlyLoanReport()
        {
            InitializeComponent();
        }

        private void MonthlyLoanReport_Load(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.loaninfo_tblTableAdapter.FillByLoan(this.tharu_CommunityDataSet1.loaninfo_tbl, dateTimePicker1.Value);
            this.reportViewer1.RefreshReport();

        }
    }
}
