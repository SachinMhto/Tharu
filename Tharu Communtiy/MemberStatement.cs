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
    public partial class MemberStatement : Form
    {
        public MemberStatement()
        {
            InitializeComponent();
        }

        private void MemberStatement_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                work();
            }
            else
            {
                MessageBox.Show("Please enter a value in the textbox.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void work() {
            this.installment_tblTableAdapter.FillByPass(this.tharu_CommunityDataSet1.installment_tbl, int.Parse(textBox1.Text));

            this.monthlyDepo_tblTableAdapter.FillByPass(this.tharu_CommunityDataSet1.monthlyDepo_tbl, int.Parse(textBox1.Text));

            this.loaninfo_tblTableAdapter.FillByPass(this.tharu_CommunityDataSet1.loaninfo_tbl, int.Parse(textBox1.Text));

            this.reportViewer1.RefreshReport();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
