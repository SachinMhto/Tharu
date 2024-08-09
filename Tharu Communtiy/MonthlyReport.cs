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
    public partial class MonthlyReport : Form
    {
        public MonthlyReport()
        {
            InitializeComponent();
        }

        private void MonthlyReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.monthlyDepo_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet.monthlyDepo_tbl, dateTimePicker1.Value);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) {
                MessageBox.Show("Error "+ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                this.monthlyDepo_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet.monthlyDepo_tbl, dateTimePicker1.Value);

                this.reportViewer1.RefreshReport();
            } catch (Exception ex) {
                MessageBox.Show("Error " + ex.Message);
            }
            this.monthlyDepo_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet.monthlyDepo_tbl,dateTimePicker1.Value);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                dateTimePicker1.Value = DateTime.Now;
                this.monthlyDepo_tblTableAdapter.FillByDate(this.tharu_CommunityDataSet.monthlyDepo_tbl, dateTimePicker1.Value);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
           
        }
    }
}
