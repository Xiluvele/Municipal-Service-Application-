namespace MunicipalServicesApp
{
    partial class AdminDashboardForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPortal = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlReportedIssues = new System.Windows.Forms.Panel();
            this.lnkViewIssues = new System.Windows.Forms.LinkLabel();
            this.lblIssuesDescription = new System.Windows.Forms.Label();
            this.lblAdminIssuesCount = new System.Windows.Forms.Label();
            this.lblIssuesTitle = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.pnlAdminEvents = new System.Windows.Forms.Panel();
            this.lnkManageEvents = new System.Windows.Forms.LinkLabel();
            this.lblAdminEventsDescription = new System.Windows.Forms.Label();
            this.lblAdminEventsCount = new System.Windows.Forms.Label();
            this.lblAdminEventsTitle = new System.Windows.Forms.Label();
            this.pnlAdminAnnouncements = new System.Windows.Forms.Panel();
            this.lnkManageAnnouncements = new System.Windows.Forms.LinkLabel();
            this.lblAdminAnnouncementsDescription = new System.Windows.Forms.Label();
            this.lblAdminAnnouncementsCount = new System.Windows.Forms.Label();
            this.lblAdminAnnouncementsTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlReportedIssues.SuspendLayout();
            this.pnlAdminEvents.SuspendLayout();
            this.pnlAdminAnnouncements.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.pnlHeader.Controls.Add(this.button1);
            this.pnlHeader.Controls.Add(this.lblPortal);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1330, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.button1.Location = new System.Drawing.Point(1040, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPortal
            // 
            this.lblPortal.AutoSize = true;
            this.lblPortal.BackColor = System.Drawing.Color.Transparent;
            this.lblPortal.ForeColor = System.Drawing.Color.White;
            this.lblPortal.Location = new System.Drawing.Point(32, 48);
            this.lblPortal.Name = "lblPortal";
            this.lblPortal.Size = new System.Drawing.Size(138, 19);
            this.lblPortal.TabIndex = 1;
            this.lblPortal.Text = "Administration Portal";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MUNICIPAL SERVICES";
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(40, 120);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(273, 41);
            this.lblDashboardTitle.TabIndex = 1;
            this.lblDashboardTitle.Text = "Admin Dashboard";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.ForeColor = System.Drawing.Color.DimGray;
            this.lblWelcome.Location = new System.Drawing.Point(43, 165);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(218, 19);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome, Municipal Administrator";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.DimGray;
            this.lblDescription.Location = new System.Drawing.Point(43, 195);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(395, 19);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Manage citizen requests and municipal services from one place.";
            // 
            // pnlReportedIssues
            // 
            this.pnlReportedIssues.Controls.Add(this.lnkViewIssues);
            this.pnlReportedIssues.Controls.Add(this.lblIssuesDescription);
            this.pnlReportedIssues.Controls.Add(this.lblAdminIssuesCount);
            this.pnlReportedIssues.Controls.Add(this.lblIssuesTitle);
            this.pnlReportedIssues.Location = new System.Drawing.Point(50, 265);
            this.pnlReportedIssues.Name = "pnlReportedIssues";
            this.pnlReportedIssues.Size = new System.Drawing.Size(300, 180);
            this.pnlReportedIssues.TabIndex = 4;
            // 
            // lnkViewIssues
            // 
            this.lnkViewIssues.AutoSize = true;
            this.lnkViewIssues.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lnkViewIssues.Location = new System.Drawing.Point(20, 140);
            this.lnkViewIssues.Name = "lnkViewIssues";
            this.lnkViewIssues.Size = new System.Drawing.Size(114, 19);
            this.lnkViewIssues.TabIndex = 3;
            this.lnkViewIssues.TabStop = true;
            this.lnkViewIssues.Text = "View All Issues →";
            this.lnkViewIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1lnkViewIssues_LinkClicked);
            // 
            // lblIssuesDescription
            // 
            this.lblIssuesDescription.AutoSize = true;
            this.lblIssuesDescription.Location = new System.Drawing.Point(20, 105);
            this.lblIssuesDescription.Name = "lblIssuesDescription";
            this.lblIssuesDescription.Size = new System.Drawing.Size(156, 19);
            this.lblIssuesDescription.TabIndex = 2;
            this.lblIssuesDescription.Text = "Citizen issues submitted";
            // 
            // lblAdminIssuesCount
            // 
            this.lblAdminIssuesCount.AutoSize = true;
            this.lblAdminIssuesCount.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminIssuesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lblAdminIssuesCount.Location = new System.Drawing.Point(20, 65);
            this.lblAdminIssuesCount.Name = "lblAdminIssuesCount";
            this.lblAdminIssuesCount.Size = new System.Drawing.Size(33, 37);
            this.lblAdminIssuesCount.TabIndex = 1;
            this.lblAdminIssuesCount.Text = "0";
            // 
            // lblIssuesTitle
            // 
            this.lblIssuesTitle.AutoSize = true;
            this.lblIssuesTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblIssuesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblIssuesTitle.Name = "lblIssuesTitle";
            this.lblIssuesTitle.Size = new System.Drawing.Size(114, 19);
            this.lblIssuesTitle.TabIndex = 0;
            this.lblIssuesTitle.Text = "Reported Issues";
            // 
            // lblOverview
            // 
            this.lblOverview.AutoSize = true;
            this.lblOverview.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblOverview.Location = new System.Drawing.Point(50, 220);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(75, 20);
            this.lblOverview.TabIndex = 5;
            this.lblOverview.Text = "Overview";
            this.lblOverview.Click += new System.EventHandler(this.lblOverview_Click);
            // 
            // pnlAdminEvents
            // 
            this.pnlAdminEvents.Controls.Add(this.lnkManageEvents);
            this.pnlAdminEvents.Controls.Add(this.lblAdminEventsDescription);
            this.pnlAdminEvents.Controls.Add(this.lblAdminEventsCount);
            this.pnlAdminEvents.Controls.Add(this.lblAdminEventsTitle);
            this.pnlAdminEvents.Location = new System.Drawing.Point(380, 265);
            this.pnlAdminEvents.Name = "pnlAdminEvents";
            this.pnlAdminEvents.Size = new System.Drawing.Size(300, 180);
            this.pnlAdminEvents.TabIndex = 6;
            // 
            // lnkManageEvents
            // 
            this.lnkManageEvents.AutoSize = true;
            this.lnkManageEvents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lnkManageEvents.Location = new System.Drawing.Point(20, 140);
            this.lnkManageEvents.Name = "lnkManageEvents";
            this.lnkManageEvents.Size = new System.Drawing.Size(119, 19);
            this.lnkManageEvents.TabIndex = 3;
            this.lnkManageEvents.TabStop = true;
            this.lnkManageEvents.Text = "Manage Events →";
            this.lnkManageEvents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManageEvents_LinkClicked);
            // 
            // lblAdminEventsDescription
            // 
            this.lblAdminEventsDescription.AutoSize = true;
            this.lblAdminEventsDescription.Location = new System.Drawing.Point(20, 105);
            this.lblAdminEventsDescription.Name = "lblAdminEventsDescription";
            this.lblAdminEventsDescription.Size = new System.Drawing.Size(105, 19);
            this.lblAdminEventsDescription.TabIndex = 2;
            this.lblAdminEventsDescription.Text = "Events available";
            // 
            // lblAdminEventsCount
            // 
            this.lblAdminEventsCount.AutoSize = true;
            this.lblAdminEventsCount.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminEventsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lblAdminEventsCount.Location = new System.Drawing.Point(20, 65);
            this.lblAdminEventsCount.Name = "lblAdminEventsCount";
            this.lblAdminEventsCount.Size = new System.Drawing.Size(33, 37);
            this.lblAdminEventsCount.TabIndex = 1;
            this.lblAdminEventsCount.Text = "0";
            // 
            // lblAdminEventsTitle
            // 
            this.lblAdminEventsTitle.AutoSize = true;
            this.lblAdminEventsTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminEventsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblAdminEventsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAdminEventsTitle.Name = "lblAdminEventsTitle";
            this.lblAdminEventsTitle.Size = new System.Drawing.Size(124, 19);
            this.lblAdminEventsTitle.TabIndex = 0;
            this.lblAdminEventsTitle.Text = "Upcoming Events";
            // 
            // pnlAdminAnnouncements
            // 
            this.pnlAdminAnnouncements.Controls.Add(this.lnkManageAnnouncements);
            this.pnlAdminAnnouncements.Controls.Add(this.lblAdminAnnouncementsDescription);
            this.pnlAdminAnnouncements.Controls.Add(this.lblAdminAnnouncementsCount);
            this.pnlAdminAnnouncements.Controls.Add(this.lblAdminAnnouncementsTitle);
            this.pnlAdminAnnouncements.Location = new System.Drawing.Point(710, 265);
            this.pnlAdminAnnouncements.Name = "pnlAdminAnnouncements";
            this.pnlAdminAnnouncements.Size = new System.Drawing.Size(300, 180);
            this.pnlAdminAnnouncements.TabIndex = 7;
            // 
            // lnkManageAnnouncements
            // 
            this.lnkManageAnnouncements.AutoSize = true;
            this.lnkManageAnnouncements.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lnkManageAnnouncements.Location = new System.Drawing.Point(20, 140);
            this.lnkManageAnnouncements.Name = "lnkManageAnnouncements";
            this.lnkManageAnnouncements.Size = new System.Drawing.Size(124, 19);
            this.lnkManageAnnouncements.TabIndex = 3;
            this.lnkManageAnnouncements.TabStop = true;
            this.lnkManageAnnouncements.Text = "Manage Notices →";
            this.lnkManageAnnouncements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManageAnnouncements_LinkClicked);
            // 
            // lblAdminAnnouncementsDescription
            // 
            this.lblAdminAnnouncementsDescription.AutoSize = true;
            this.lblAdminAnnouncementsDescription.Location = new System.Drawing.Point(20, 105);
            this.lblAdminAnnouncementsDescription.Name = "lblAdminAnnouncementsDescription";
            this.lblAdminAnnouncementsDescription.Size = new System.Drawing.Size(118, 19);
            this.lblAdminAnnouncementsDescription.TabIndex = 2;
            this.lblAdminAnnouncementsDescription.Text = "Important notices";
            // 
            // lblAdminAnnouncementsCount
            // 
            this.lblAdminAnnouncementsCount.AutoSize = true;
            this.lblAdminAnnouncementsCount.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminAnnouncementsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lblAdminAnnouncementsCount.Location = new System.Drawing.Point(20, 65);
            this.lblAdminAnnouncementsCount.Name = "lblAdminAnnouncementsCount";
            this.lblAdminAnnouncementsCount.Size = new System.Drawing.Size(33, 37);
            this.lblAdminAnnouncementsCount.TabIndex = 1;
            this.lblAdminAnnouncementsCount.Text = "0";
            // 
            // lblAdminAnnouncementsTitle
            // 
            this.lblAdminAnnouncementsTitle.AutoSize = true;
            this.lblAdminAnnouncementsTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminAnnouncementsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblAdminAnnouncementsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAdminAnnouncementsTitle.Name = "lblAdminAnnouncementsTitle";
            this.lblAdminAnnouncementsTitle.Size = new System.Drawing.Size(115, 19);
            this.lblAdminAnnouncementsTitle.TabIndex = 0;
            this.lblAdminAnnouncementsTitle.Text = "Announcements";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 749);
            this.Controls.Add(this.pnlAdminAnnouncements);
            this.Controls.Add(this.pnlAdminEvents);
            this.Controls.Add(this.lblOverview);
            this.Controls.Add(this.pnlReportedIssues);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblDashboardTitle);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1200, 718);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services - Admin Dashboard";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlReportedIssues.ResumeLayout(false);
            this.pnlReportedIssues.PerformLayout();
            this.pnlAdminEvents.ResumeLayout(false);
            this.pnlAdminEvents.PerformLayout();
            this.pnlAdminAnnouncements.ResumeLayout(false);
            this.pnlAdminAnnouncements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPortal;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlReportedIssues;
        private System.Windows.Forms.Label lblIssuesTitle;
        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblAdminIssuesCount;
        private System.Windows.Forms.LinkLabel lnkViewIssues;
        private System.Windows.Forms.Label lblIssuesDescription;
        private System.Windows.Forms.Panel pnlAdminEvents;
        private System.Windows.Forms.LinkLabel lnkManageEvents;
        private System.Windows.Forms.Label lblAdminEventsDescription;
        private System.Windows.Forms.Label lblAdminEventsCount;
        private System.Windows.Forms.Label lblAdminEventsTitle;
        private System.Windows.Forms.Panel pnlAdminAnnouncements;
        private System.Windows.Forms.LinkLabel lnkManageAnnouncements;
        private System.Windows.Forms.Label lblAdminAnnouncementsDescription;
        private System.Windows.Forms.Label lblAdminAnnouncementsCount;
        private System.Windows.Forms.Label lblAdminAnnouncementsTitle;
    }
}