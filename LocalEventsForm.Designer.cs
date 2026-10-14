namespace MunicipalServicesApp
{
    partial class LocalEventsForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.pnlAnnouncements = new System.Windows.Forms.Panel();
            this.lblAnnouncementPriority = new System.Windows.Forms.Label();
            this.lblAnnouncement = new System.Windows.Forms.Label();
            this.lblAnnouncementsTitle = new System.Windows.Forms.Label();
            this.pnlRecommendations = new System.Windows.Forms.Panel();
            this.flpRecommendations = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRecommendedInfo = new System.Windows.Forms.Label();
            this.lblRecommendedTitle = new System.Windows.Forms.Label();
            this.pnlUpcomingEvents = new System.Windows.Forms.Panel();
            this.flpEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUpcomingInfo = new System.Windows.Forms.Label();
            this.lblUpcomingEvents = new System.Windows.Forms.Label();
            this.lblRecentSearches = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlAnnouncements.SuspendLayout();
            this.pnlRecommendations.SuspendLayout();
            this.pnlUpcomingEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1236, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnBack.Location = new System.Drawing.Point(1119, 21);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 38);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(37, 51);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(356, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Discover upcoming events and stay informed about your community";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(35, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(358, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Events and Announcements";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.btnClearFilters);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.dtpEventDate);
            this.pnlSearch.Controls.Add(this.cmbCategory);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Location = new System.Drawing.Point(28, 91);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1208, 125);
            this.pnlSearch.TabIndex = 1;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnClearFilters.Location = new System.Drawing.Point(1003, 52);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(120, 38);
            this.btnClearFilters.TabIndex = 5;
            this.btnClearFilters.Text = "Clear";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(834, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 38);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Location = new System.Drawing.Point(601, 60);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.ShowCheckBox = true;
            this.dtpEventDate.Size = new System.Drawing.Size(120, 21);
            this.dtpEventDate.TabIndex = 3;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(357, 60);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(220, 20);
            this.cmbCategory.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(38, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 21);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSearchTitle.Location = new System.Drawing.Point(20, 12);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(97, 21);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "Find Events";
            // 
            // pnlAnnouncements
            // 
            this.pnlAnnouncements.BackColor = System.Drawing.Color.White;
            this.pnlAnnouncements.Controls.Add(this.lblAnnouncementPriority);
            this.pnlAnnouncements.Controls.Add(this.lblAnnouncement);
            this.pnlAnnouncements.Controls.Add(this.lblAnnouncementsTitle);
            this.pnlAnnouncements.Location = new System.Drawing.Point(35, 222);
            this.pnlAnnouncements.Name = "pnlAnnouncements";
            this.pnlAnnouncements.Size = new System.Drawing.Size(1201, 259);
            this.pnlAnnouncements.TabIndex = 2;
            // 
            // lblAnnouncementPriority
            // 
            this.lblAnnouncementPriority.AutoSize = true;
            this.lblAnnouncementPriority.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementPriority.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnnouncementPriority.Location = new System.Drawing.Point(20, 80);
            this.lblAnnouncementPriority.Name = "lblAnnouncementPriority";
            this.lblAnnouncementPriority.Size = new System.Drawing.Size(0, 13);
            this.lblAnnouncementPriority.TabIndex = 2;
            // 
            // lblAnnouncement
            // 
            this.lblAnnouncement.AutoSize = true;
            this.lblAnnouncement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblAnnouncement.Location = new System.Drawing.Point(20, 52);
            this.lblAnnouncement.Name = "lblAnnouncement";
            this.lblAnnouncement.Size = new System.Drawing.Size(243, 13);
            this.lblAnnouncement.TabIndex = 1;
            this.lblAnnouncement.Text = "No important announcements at the moment.";
            // 
            // lblAnnouncementsTitle
            // 
            this.lblAnnouncementsTitle.AutoSize = true;
            this.lblAnnouncementsTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblAnnouncementsTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAnnouncementsTitle.Name = "lblAnnouncementsTitle";
            this.lblAnnouncementsTitle.Size = new System.Drawing.Size(148, 13);
            this.lblAnnouncementsTitle.TabIndex = 0;
            this.lblAnnouncementsTitle.Text = "Important Announcements";
            // 
            // pnlRecommendations
            // 
            this.pnlRecommendations.BackColor = System.Drawing.Color.White;
            this.pnlRecommendations.Controls.Add(this.flpRecommendations);
            this.pnlRecommendations.Controls.Add(this.lblRecommendedInfo);
            this.pnlRecommendations.Controls.Add(this.lblRecommendedTitle);
            this.pnlRecommendations.Location = new System.Drawing.Point(35, 487);
            this.pnlRecommendations.Name = "pnlRecommendations";
            this.pnlRecommendations.Size = new System.Drawing.Size(1201, 137);
            this.pnlRecommendations.TabIndex = 3;
            // 
            // flpRecommendations
            // 
            this.flpRecommendations.AutoScroll = true;
            this.flpRecommendations.Location = new System.Drawing.Point(20, 72);
            this.flpRecommendations.Name = "flpRecommendations";
            this.flpRecommendations.Size = new System.Drawing.Size(1138, 45);
            this.flpRecommendations.TabIndex = 2;
            this.flpRecommendations.WrapContents = false;
            // 
            // lblRecommendedInfo
            // 
            this.lblRecommendedInfo.AutoSize = true;
            this.lblRecommendedInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecommendedInfo.Location = new System.Drawing.Point(20, 45);
            this.lblRecommendedInfo.Name = "lblRecommendedInfo";
            this.lblRecommendedInfo.Size = new System.Drawing.Size(314, 13);
            this.lblRecommendedInfo.TabIndex = 1;
            this.lblRecommendedInfo.Text = "Search for events to receive personalised recommendations.";
            // 
            // lblRecommendedTitle
            // 
            this.lblRecommendedTitle.AutoSize = true;
            this.lblRecommendedTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblRecommendedTitle.Location = new System.Drawing.Point(20, 15);
            this.lblRecommendedTitle.Name = "lblRecommendedTitle";
            this.lblRecommendedTitle.Size = new System.Drawing.Size(173, 20);
            this.lblRecommendedTitle.TabIndex = 0;
            this.lblRecommendedTitle.Text = "Recommended for you ";
            // 
            // pnlUpcomingEvents
            // 
            this.pnlUpcomingEvents.BackColor = System.Drawing.Color.White;
            this.pnlUpcomingEvents.Controls.Add(this.flpEvents);
            this.pnlUpcomingEvents.Controls.Add(this.lblUpcomingInfo);
            this.pnlUpcomingEvents.Controls.Add(this.lblUpcomingEvents);
            this.pnlUpcomingEvents.Location = new System.Drawing.Point(35, 630);
            this.pnlUpcomingEvents.Name = "pnlUpcomingEvents";
            this.pnlUpcomingEvents.Size = new System.Drawing.Size(1201, 240);
            this.pnlUpcomingEvents.TabIndex = 4;
            // 
            // flpEvents
            // 
            this.flpEvents.AutoScroll = true;
            this.flpEvents.Location = new System.Drawing.Point(20, 52);
            this.flpEvents.Name = "flpEvents";
            this.flpEvents.Size = new System.Drawing.Size(1138, 150);
            this.flpEvents.TabIndex = 2;
            this.flpEvents.WrapContents = false;
            // 
            // lblUpcomingInfo
            // 
            this.lblUpcomingInfo.AutoSize = true;
            this.lblUpcomingInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblUpcomingInfo.Location = new System.Drawing.Point(22, 32);
            this.lblUpcomingInfo.Name = "lblUpcomingInfo";
            this.lblUpcomingInfo.Size = new System.Drawing.Size(234, 13);
            this.lblUpcomingInfo.TabIndex = 1;
            this.lblUpcomingInfo.Text = "Browse upcoming events in your community";
            // 
            // lblUpcomingEvents
            // 
            this.lblUpcomingEvents.AutoSize = true;
            this.lblUpcomingEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblUpcomingEvents.Location = new System.Drawing.Point(20, 15);
            this.lblUpcomingEvents.Name = "lblUpcomingEvents";
            this.lblUpcomingEvents.Size = new System.Drawing.Size(96, 13);
            this.lblUpcomingEvents.TabIndex = 0;
            this.lblUpcomingEvents.Text = "Upcoming Events";
            // 
            // lblRecentSearches
            // 
            this.lblRecentSearches.AutoSize = true;
            this.lblRecentSearches.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentSearches.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecentSearches.Location = new System.Drawing.Point(526, 891);
            this.lblRecentSearches.Name = "lblRecentSearches";
            this.lblRecentSearches.Size = new System.Drawing.Size(147, 19);
            this.lblRecentSearches.TabIndex = 5;
            this.lblRecentSearches.Text = "Recent Searches: None";
            this.lblRecentSearches.Click += new System.EventHandler(this.label1_Click);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1248, 749);
            this.Controls.Add(this.lblRecentSearches);
            this.Controls.Add(this.pnlUpcomingEvents);
            this.Controls.Add(this.pnlRecommendations);
            this.Controls.Add(this.pnlAnnouncements);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services - Local Events & Announcements";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlAnnouncements.ResumeLayout(false);
            this.pnlAnnouncements.PerformLayout();
            this.pnlRecommendations.ResumeLayout(false);
            this.pnlRecommendations.PerformLayout();
            this.pnlUpcomingEvents.ResumeLayout(false);
            this.pnlUpcomingEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlAnnouncements;
        private System.Windows.Forms.Label lblAnnouncementsTitle;
        private System.Windows.Forms.Label lblAnnouncementPriority;
        private System.Windows.Forms.Label lblAnnouncement;
        private System.Windows.Forms.Panel pnlRecommendations;
        private System.Windows.Forms.Label lblRecommendedTitle;
        private System.Windows.Forms.FlowLayoutPanel flpRecommendations;
        private System.Windows.Forms.Label lblRecommendedInfo;
        private System.Windows.Forms.Panel pnlUpcomingEvents;
        private System.Windows.Forms.FlowLayoutPanel flpEvents;
        private System.Windows.Forms.Label lblUpcomingInfo;
        private System.Windows.Forms.Label lblUpcomingEvents;
        private System.Windows.Forms.Label lblRecentSearches;
    }
}