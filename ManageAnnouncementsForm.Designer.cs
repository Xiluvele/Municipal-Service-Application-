namespace MunicipalServicesApp
{
    partial class ManageAnnouncementsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblAnnouncementCount = new System.Windows.Forms.Label();
            this.dgvAnnouncements = new System.Windows.Forms.DataGridView();
            this.btnAddAnnouncement = new System.Windows.Forms.Button();
            this.btnEditAnnouncement = new System.Windows.Forms.Button();
            this.btnDeleteAnnouncement = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnouncements)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(1184, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(335, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Announcements";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(16, 46);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(266, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Add, edit and remove municipal announcements";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1031, 23);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(40, 104);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(278, 30);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "Municipal Announcements";
            // 
            // lblAnnouncementCount
            // 
            this.lblAnnouncementCount.AutoSize = true;
            this.lblAnnouncementCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnnouncementCount.Location = new System.Drawing.Point(45, 138);
            this.lblAnnouncementCount.Name = "lblAnnouncementCount";
            this.lblAnnouncementCount.Size = new System.Drawing.Size(134, 15);
            this.lblAnnouncementCount.TabIndex = 2;
            this.lblAnnouncementCount.Text = "Total announcements: 0";
            // 
            // dgvAnnouncements
            // 
            this.dgvAnnouncements.AllowUserToAddRows = false;
            this.dgvAnnouncements.AllowUserToDeleteRows = false;
            this.dgvAnnouncements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnnouncements.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnnouncements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnnouncements.Location = new System.Drawing.Point(71, 194);
            this.dgvAnnouncements.MultiSelect = false;
            this.dgvAnnouncements.Name = "dgvAnnouncements";
            this.dgvAnnouncements.ReadOnly = true;
            this.dgvAnnouncements.RowHeadersVisible = false;
            this.dgvAnnouncements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnnouncements.Size = new System.Drawing.Size(479, 150);
            this.dgvAnnouncements.TabIndex = 3;
            this.dgvAnnouncements.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnnouncements_CellContentClick);
            // 
            // btnAddAnnouncement
            // 
            this.btnAddAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnAddAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAnnouncement.ForeColor = System.Drawing.Color.White;
            this.btnAddAnnouncement.Location = new System.Drawing.Point(71, 393);
            this.btnAddAnnouncement.Name = "btnAddAnnouncement";
            this.btnAddAnnouncement.Size = new System.Drawing.Size(150, 40);
            this.btnAddAnnouncement.TabIndex = 4;
            this.btnAddAnnouncement.Text = "Add Announcement";
            this.btnAddAnnouncement.UseVisualStyleBackColor = false;
            this.btnAddAnnouncement.Click += new System.EventHandler(this.btnAddAnnouncement_Click);
            // 
            // btnEditAnnouncement
            // 
            this.btnEditAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAnnouncement.Location = new System.Drawing.Point(227, 393);
            this.btnEditAnnouncement.Name = "btnEditAnnouncement";
            this.btnEditAnnouncement.Size = new System.Drawing.Size(150, 40);
            this.btnEditAnnouncement.TabIndex = 5;
            this.btnEditAnnouncement.Text = "Edit Selected";
            this.btnEditAnnouncement.UseVisualStyleBackColor = true;
            this.btnEditAnnouncement.Click += new System.EventHandler(this.btnEditAnnouncement_Click);
            // 
            // btnDeleteAnnouncement
            // 
            this.btnDeleteAnnouncement.BackColor = System.Drawing.Color.Maroon;
            this.btnDeleteAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAnnouncement.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAnnouncement.Location = new System.Drawing.Point(383, 393);
            this.btnDeleteAnnouncement.Name = "btnDeleteAnnouncement";
            this.btnDeleteAnnouncement.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteAnnouncement.TabIndex = 6;
            this.btnDeleteAnnouncement.Text = "Delete Selected";
            this.btnDeleteAnnouncement.UseVisualStyleBackColor = false;
            this.btnDeleteAnnouncement.Click += new System.EventHandler(this.btnDeleteAnnouncement_Click);
            // 
            // ManageAnnouncementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btnDeleteAnnouncement);
            this.Controls.Add(this.btnEditAnnouncement);
            this.Controls.Add(this.btnAddAnnouncement);
            this.Controls.Add(this.dgvAnnouncements);
            this.Controls.Add(this.lblAnnouncementCount);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ManageAnnouncementsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services - Manage Announcements";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnouncements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblAnnouncementCount;
        private System.Windows.Forms.DataGridView dgvAnnouncements;
        private System.Windows.Forms.Button btnAddAnnouncement;
        private System.Windows.Forms.Button btnEditAnnouncement;
        private System.Windows.Forms.Button btnDeleteAnnouncement;
    }
}