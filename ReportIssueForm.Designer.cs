namespace MunicipalServicesApp
{
    partial class ReportIssueForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.progressReport = new System.Windows.Forms.ProgressBar();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtOtherCategory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(125, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(750, 56);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "REPORT AN ISSUE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.Location = new System.Drawing.Point(63, 81);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(875, 38);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Help us improve your community by reporting a municipal issue.";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(63, 138);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(58, 16);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(63, 169);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(406, 22);
            this.txtLocation.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(63, 225);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(63, 256);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(370, 24);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(63, 313);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 16);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description ";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(68, 344);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(365, 96);
            this.rtbDescription.TabIndex = 16;
            this.rtbDescription.Text = "";
            this.rtbDescription.TextChanged += new System.EventHandler(this.rtbDescription_TextChanged);
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Location = new System.Drawing.Point(63, 488);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(80, 16);
            this.lblAttachments.TabIndex = 8;
            this.lblAttachments.Text = "Attachments";
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Location = new System.Drawing.Point(63, 519);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(250, 44);
            this.btnAttachFile.TabIndex = 9;
            this.btnAttachFile.Text = "Attach Image / Document";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // lstAttachments
            // 
            this.lstAttachments.FormattingEnabled = true;
            this.lstAttachments.ItemHeight = 16;
            this.lstAttachments.Location = new System.Drawing.Point(338, 500);
            this.lstAttachments.Name = "lstAttachments";
            this.lstAttachments.Size = new System.Drawing.Size(334, 68);
            this.lstAttachments.TabIndex = 10;
            this.lstAttachments.SelectedIndexChanged += new System.EventHandler(this.lstAttachments_SelectedIndexChanged);
            // 
            // lblEngagement
            // 
            this.lblEngagement.Location = new System.Drawing.Point(63, 606);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new System.Drawing.Size(875, 38);
            this.lblEngagement.TabIndex = 11;
            this.lblEngagement.Text = "You\'re helping improve your community!";
            this.lblEngagement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressReport
            // 
            this.progressReport.Location = new System.Drawing.Point(43, 667);
            this.progressReport.Name = "progressReport";
            this.progressReport.Size = new System.Drawing.Size(815, 25);
            this.progressReport.TabIndex = 12;
            this.progressReport.Click += new System.EventHandler(this.progressReport_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Orange;
            this.btnSubmit.Location = new System.Drawing.Point(63, 706);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(188, 50);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit Report";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(275, 706);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 50);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear\n";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBack.Location = new System.Drawing.Point(425, 706);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 50);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtOtherCategory
            // 
            this.txtOtherCategory.Location = new System.Drawing.Point(477, 256);
            this.txtOtherCategory.Name = "txtOtherCategory";
            this.txtOtherCategory.Size = new System.Drawing.Size(100, 22);
            this.txtOtherCategory.TabIndex = 17;
            this.txtOtherCategory.Visible = false;
            // 
            // ReportIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 777);
            this.Controls.Add(this.txtOtherCategory);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.progressReport);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.lstAttachments);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.lblAttachments);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportIssueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report an Issue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Label lblEngagement;
        private System.Windows.Forms.ProgressBar progressReport;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtOtherCategory;
    }
}