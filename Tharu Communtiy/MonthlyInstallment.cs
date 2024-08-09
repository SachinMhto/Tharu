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
    public partial class MonthlyInstallment : Form
    {
        public MonthlyInstallment()
        {
            InitializeComponent();
        }

        private void MonthlyInstallment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tharu_CommunityDataSet2.installment_tbl' table. You can move, or remove it, as needed.
            this.installment_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet2.installment_tbl,dateTimePicker1.Value);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tharu_CommunityDataSet2.installment_tbl' table. You can move, or remove it, as needed.
            this.installment_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet2.installment_tbl, dateTimePicker1.Value);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            // TODO: This line of code loads data into the 'tharu_CommunityDataSet2.installment_tbl' table. You can move, or remove it, as needed.
            this.installment_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet2.installment_tbl, dateTimePicker1.Value);

            this.reportViewer1.RefreshReport();
        }
    }
}
