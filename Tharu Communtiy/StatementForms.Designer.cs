namespace Tharu_Communtiy
{
    partial class StatementForms
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.loaninfotblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tharu_CommunityDataSet3 = new Tharu_Communtiy.Tharu_CommunityDataSet3();
            this.installmenttblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.loaninfo_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet3TableAdapters.loaninfo_tblTableAdapter();
            this.installment_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet3TableAdapters.installment_tblTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.monthlyDepotblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tharu_CommunityDataSet1 = new Tharu_Communtiy.Tharu_CommunityDataSet1();
            this.monthlyDepo_tblTableAdapter = new Tharu_Communtiy.Tharu_CommunityDataSet1TableAdapters.monthlyDepo_tblTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.loaninfotblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.installmenttblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepotblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // loaninfotblBindingSource
            // 
            this.loaninfotblBindingSource.DataMember = "loaninfo_tbl";
            this.loaninfotblBindingSource.DataSource = this.tharu_CommunityDataSet3;
            // 
            // tharu_CommunityDataSet3
            // 
            this.tharu_CommunityDataSet3.DataSetName = "Tharu_CommunityDataSet3";
            this.tharu_CommunityDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // installmenttblBindingSource
            // 
            this.installmenttblBindingSource.DataMember = "installment_tbl";
            this.installmenttblBindingSource.DataSource = this.tharu_CommunityDataSet3;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.loaninfotblBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.installmenttblBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.monthlyDepotblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Tharu_Communtiy.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 50);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1274, 556);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date From:-";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(526, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date From:-";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(75, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(600, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(354, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loaninfo_tblTableAdapter
            // 
            this.loaninfo_tblTableAdapter.ClearBeforeFill = true;
            // 
            // installment_tblTableAdapter
            // 
            this.installment_tblTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(959, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // monthlyDepo_tblTableAdapter
            // 
            this.monthlyDepo_tblTableAdapter.ClearBeforeFill = true;
            // 
            // StatementForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 607);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "StatementForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatementForms";
            this.Load += new System.EventHandler(this.StatementForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loaninfotblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.installmenttblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepotblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tharu_CommunityDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Tharu_CommunityDataSet3 tharu_CommunityDataSet3;
        private System.Windows.Forms.BindingSource loaninfotblBindingSource;
        private Tharu_CommunityDataSet3TableAdapters.loaninfo_tblTableAdapter loaninfo_tblTableAdapter;
        private System.Windows.Forms.BindingSource installmenttblBindingSource;
        private Tharu_CommunityDataSet3TableAdapters.installment_tblTableAdapter installment_tblTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Tharu_CommunityDataSet1 tharu_CommunityDataSet1;
        private System.Windows.Forms.BindingSource monthlyDepotblBindingSource;
        private Tharu_CommunityDataSet1TableAdapters.monthlyDepo_tblTableAdapter monthlyDepo_tblTableAdapter;
    }
}