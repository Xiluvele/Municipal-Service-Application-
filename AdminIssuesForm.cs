using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class AdminIssuesForm : Form
    {
        public AdminIssuesForm()
        {
            InitializeComponent();

            // Load all reported issues when the form opens
            StyleDataGridView();
            LoadIssues();
        }

        private void LoadIssues()
        {
            // Get all citizen-reported issues
            // Newest reported issue appears first
            var issues = IssueManager.Issues
                .OrderByDescending(issue => issue.ReportDate)
                .ToList();

            // Clear the current data before binding
            dgvIssues.DataSource = null;

            // Display the issues in the DataGridView
            dgvIssues.DataSource = issues;

            // Display the total number of reported issues
            lblIssueCount.Text =
                $"Total reported issues: {issues.Count}";


            // =====================================================
            // FRIENDLY COLUMN HEADINGS
            // =====================================================

            if (dgvIssues.Columns["Location"] != null)
            {
                dgvIssues.Columns["Location"].HeaderText =
                    "Location";
            }

            if (dgvIssues.Columns["Category"] != null)
            {
                dgvIssues.Columns["Category"].HeaderText =
                    "Category";
            }

            if (dgvIssues.Columns["Description"] != null)
            {
                dgvIssues.Columns["Description"].HeaderText =
                    "Description";
            }

            if (dgvIssues.Columns["MediaPath"] != null)
            {
                dgvIssues.Columns["MediaPath"].HeaderText =
                    "Attachment";
            }

            if (dgvIssues.Columns["ReportDate"] != null)
            {
                dgvIssues.Columns["ReportDate"].HeaderText =
                    "Date Reported";

                dgvIssues.Columns["ReportDate"]
                    .DefaultCellStyle.Format =
                    "dd MMM yyyy HH:mm";
            }

            if (dgvIssues.Columns["Status"] != null)
            {
                dgvIssues.Columns["Status"].HeaderText =
                    "Status";
            }
        }


        // =====================================================
        // BACK BUTTON
        // =====================================================
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // =====================================================
        // DATAGRIDVIEW
        // =====================================================
        private void dgvIssues_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // No action is required when a cell is clicked.
            // This method is kept because the DataGridView
            // may already be connected to this event.
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StyleDataGridView()
        {
            // Main table background
            dgvIssues.BackgroundColor = Color.White;

            // Normal row text
            dgvIssues.DefaultCellStyle.BackColor = Color.White;
            dgvIssues.DefaultCellStyle.ForeColor = Color.Black;

            // Selected row
            dgvIssues.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(31, 78, 121);

            dgvIssues.DefaultCellStyle.SelectionForeColor =
                Color.White;

            // Column headers
            dgvIssues.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(31, 78, 121);

            dgvIssues.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvIssues.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvIssues.EnableHeadersVisualStyles = false;

            // Grid appearance
            dgvIssues.GridColor = Color.LightGray;
            dgvIssues.RowHeadersVisible = false;

            // Give rows more space
            dgvIssues.RowTemplate.Height = 30;
        }
    }
}