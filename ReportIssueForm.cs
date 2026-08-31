using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssueForm : Form
    {
        // Static list to store all issues across the application
        public static List<Issue> issuesList = new List<Issue>();
        private string selectedFilePath = "";
        public ReportIssueForm()
        {
            InitializeComponent();
            LoadCategories();
            InitializeEngagementFeatures();
        }


        private void LoadCategories()
        {
            // Populate the category ComboBox
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Road & Potholes Maintenance");
            cmbCategory.Items.Add("Water & Sanitation Issues");
            cmbCategory.Items.Add("Electricity");
            cmbCategory.Items.Add("Waste Management");
            cmbCategory.Items.Add("Public Safety");
            cmbCategory.Items.Add("Parks & Recreation");
            cmbCategory.Items.Add("Other");

            cmbCategory.SelectedIndex = -1;
        }

        private void InitializeEngagementFeatures()
        {
            // This label will change dynamically
            lblEngagement.Text = "💚 You're helping improve your community!";
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != -1)
            {
                string category = cmbCategory.SelectedItem.ToString();
                lblEngagement.Text = $"📋 Category: {category}. Please add a detailed description below.";
            }

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Supporting File";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|PDF Files|*.pdf|Document Files|*.doc;*.docx;*.txt|All Files|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    // Display the filename in the ListBox or Label
                    lstAttachments.Items.Clear();
                    lstAttachments.Items.Add("📎 " + Path.GetFileName(selectedFilePath));
                }
            }

        }

        private void lstAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Validate Input
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1 || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category for the issue.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a detailed description of the issue.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // 2. Create a new Issue object
            Issue newIssue = new Issue(
                txtLocation.Text.Trim(),
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text.Trim(),
                selectedFilePath
            );

            // 3. Add to the static list
            issuesList.Add(newIssue);

            // 4. User Engagement Feature: Encouraging Messages
            btnSubmit.Enabled = false;
            lblEngagement.Text = "📤 Submitting your report... Please wait.";

            // Use a timer to simulate processing
            Timer timer = new Timer();
            timer.Interval = 200;
            int step = 0;
            string[] messages = new string[]
            {
                "📤 Submitting your report...",
                "🔄 Processing your report... Thank you for your patience!",
                "💪 Your voice matters! Routing to the right department.",
                "🌟 Your report is making a difference in our community.",
                "🎉 Thank you for helping keep our city clean and safe!"
            };

            timer.Tick += (senderTimer, eTimer) =>
            {
                step++;
                if (step < messages.Length)
                {
                    lblEngagement.Text = messages[step];
                }
                else
                {
                    timer.Stop();
                    btnSubmit.Enabled = true;

                    MessageBox.Show(
                        "✅ Issue reported successfully!\n\n" +
                        "Thank you for helping improve our community.\n" +
                        "We will keep you updated on the progress of this issue.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ClearForm();
                    lblEngagement.Text = "💚 You're helping improve your community!";
                }
            };
            timer.Start();

        }

        private void ClearForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            selectedFilePath = "";
            lstAttachments.Items.Clear();
            btnSubmit.Enabled = true;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to clear the form? All entered data will be lost.",
               "Confirm Clear",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                ClearForm();
                lblEngagement.Text = "💡 Form cleared. Start a new report when you're ready.";
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLocation.Text) ||
                !string.IsNullOrWhiteSpace(rtbDescription.Text) ||
                cmbCategory.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved data. Are you sure you want to go back?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void progressReport_Click(object sender, EventArgs e)
        {

        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            int charCount = rtbDescription.Text.Length;
            if (charCount > 0 && charCount <= 10)
            {
                lblEngagement.Text = "✏️ Keep going! Provide as much detail as possible.";
            }
            else if (charCount > 10 && charCount <= 50)
            {
                lblEngagement.Text = "📝 Good progress! Include location, severity, and any helpful details.";
            }
            else if (charCount > 50)
            {
                lblEngagement.Text = "🌟 Excellent! Detailed reports help us respond faster.";
            }
        }
    }
}
