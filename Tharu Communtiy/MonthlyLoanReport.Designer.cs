namespace Tharu_Communtiy
{
    partial class MonthlyLoanReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tharu_CommunityDataSet1 = new Tharu_Communtiy.Tharu_CommunityDataSet1();
            this.monthlyDepotblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthlyDepo_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet1TableAdapters.monthlyDepo_tblTableAdapter();
            this.loaninfotblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loaninfo_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet1TableAdapters.loaninfo_tblTableAdapter();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepotblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaninfotblBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.loaninfotblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tharu_Communtiy.LoanReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 44);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(795, 394);
            this.reportViewer1.TabIndex = 0;
            // 
            // tharu_CommunityDataSet1
            // 
            this.tharu_CommunityDataSet1.DataSetName = "Tharu_CommunityDataSet1";
            this.tharu_CommunityDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // monthlyDepotblBindingSource
            // 
            this.monthlyDepotblBindingSource.DataMember = "monthlyDepo_tbl";
            this.monthlyDepotblBindingSource.DataSource = this.tharu_CommunityDataSet1;
            // 
            // monthlyDepo_tblTableAdapter
            // 
            this.monthlyDepo_tblTableAdapter.ClearBeforeFill = true;
            // 
            // loaninfotblBindingSource
            // 
            this.loaninfotblBindingSource.DataMember = "loaninfo_tbl";
            this.loaninfotblBindingSource.DataSource = this.tharu_CommunityDataSet1;
            // 
            // loaninfo_tblTableAdapter
            // 
            this.loaninfo_tblTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MonthlyLoanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "MonthlyLoanReport";
            this.Text = "MonthlyLoanReport";
            this.Load += new System.EventHandler(this.MonthlyLoanReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepotblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaninfotblBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Tharu_CommunityDataSet1 tharu_CommunityDataSet1;
        private System.Windows.Forms.BindingSource monthlyDepotblBindingSource;
        private Tharu_CommunityDataSet1TableAdapters.monthlyDepo_tblTableAdapter monthlyDepo_tblTableAdapter;
        private System.Windows.Forms.BindingSource loaninfotblBindingSource;
        private Tharu_CommunityDataSet1TableAdapters.loaninfo_tblTableAdapter loaninfo_tblTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
    }
}