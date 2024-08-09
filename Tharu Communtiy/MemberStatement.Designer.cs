namespace Tharu_Communtiy
{
    partial class MemberStatement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.monthlyDepotblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tharu_CommunityDataSet1 = new Tharu_Communtiy.Tharu_CommunityDataSet1();
            this.loaninfotblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.installmenttblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaninfo_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet1TableAdapters.loaninfo_tblTableAdapter();
            this.monthlyDepo_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet1TableAdapters.monthlyDepo_tblTableAdapter();
            this.installment_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet1TableAdapters.installment_tblTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepotblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaninfotblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.installmenttblBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.monthlyDepotblBindingSource;
            reportDataSource5.Name = "DataSet2";
            reportDataSource5.Value = this.loaninfotblBindingSource;
            reportDataSource6.Name = "DataSet3";
            reportDataSource6.Value = this.installmenttblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tharu_Communtiy.memberStmt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-6, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1020, 495);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter passbook Number";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(317, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(382, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // monthlyDepotblBindingSource
            // 
            this.monthlyDepotblBindingSource.DataMember = "monthlyDepo_tbl";
            this.monthlyDepotblBindingSource.DataSource = this.tharu_CommunityDataSet1;
            // 
            // tharu_CommunityDataSet1
            // 
            this.tharu_CommunityDataSet1.DataSetName = "Tharu_CommunityDataSet1";
            this.tharu_CommunityDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loaninfotblBindingSource
            // 
            this.loaninfotblBindingSource.DataMember = "loaninfo_tbl";
            this.loaninfotblBindingSource.DataSource = this.tharu_CommunityDataSet1;
            // 
            // installmenttblBindingSource
            // 
            this.installmenttblBindingSource.DataMember = "installment_tbl";
            this.installmenttblBindingSource.DataSource = this.tharu_CommunityDataSet1;
            // 
            // loaninfo_tblTableAdapter
            // 
            this.loaninfo_tblTableAdapter.ClearBeforeFill = true;
            // 
            // monthlyDepo_tblTableAdapter
            // 
            this.monthlyDepo_tblTableAdapter.ClearBeforeFill = true;
            // 
            // installment_tblTableAdapter
            // 
            this.installment_tblTableAdapter.ClearBeforeFill = true;
            // 
            // MemberStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 545);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "MemberStatement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemberStatement";
            this.Load += new System.EventHandler(this.MemberStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepotblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaninfotblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.installmenttblBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Tharu_CommunityDataSet1 tharu_CommunityDataSet1;
        private System.Windows.Forms.BindingSource loaninfotblBindingSource;
        private Tharu_CommunityDataSet1TableAdapters.loaninfo_tblTableAdapter loaninfo_tblTableAdapter;
        private System.Windows.Forms.BindingSource monthlyDepotblBindingSource;
        private Tharu_CommunityDataSet1TableAdapters.monthlyDepo_tblTableAdapter monthlyDepo_tblTableAdapter;
        private System.Windows.Forms.BindingSource installmenttblBindingSource;
        private Tharu_CommunityDataSet1TableAdapters.installment_tblTableAdapter installment_tblTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}