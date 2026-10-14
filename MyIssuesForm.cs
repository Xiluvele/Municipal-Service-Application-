using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MyIssuesForm : Form
    {
        public MyIssuesForm()
        {
            InitializeComponent();
            LoadIssues();
        }
        private void LoadIssues()
        {
            // Get the issues submitted through ReportIssueForm
            var issues = IssueManager.Issues
            .OrderByDescending(issue => issue.ReportDate)
            .ToList();

            // Display issues in the table
            dgvIssues.DataSource = issues;

            // Display total number of issues
            lblIssueCount.Text = $"Total issues: {issues.Count}";

            // Make column headings more user-friendly
            if (dgvIssues.Columns["Location"] != null)
                dgvIssues.Columns["Location"].HeaderText = "Location";

            if (dgvIssues.Columns["Category"] != null)
                dgvIssues.Columns["Category"].HeaderText = "Category";

            if (dgvIssues.Columns["Description"] != null)
                dgvIssues.Columns["Description"].HeaderText = "Description";

            if (dgvIssues.Columns["MediaPath"] != null)
                dgvIssues.Columns["MediaPath"].HeaderText = "Attachment";

            if (dgvIssues.Columns["ReportDate"] != null)
            {
                dgvIssues.Columns["ReportDate"].HeaderText = "Reported Date";
                dgvIssues.Columns["ReportDate"].DefaultCellStyle.Format =
                    "dd MMM yyyy HH:mm";
            }

            if (dgvIssues.Columns["Status"] != null)
                dgvIssues.Columns["Status"].HeaderText = "Status";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
