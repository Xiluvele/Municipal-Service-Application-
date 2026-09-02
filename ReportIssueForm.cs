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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            // This ensures the progress bar updates when you type
            this.txtLocation.TextChanged += new EventHandler(txtLocation_TextChanged);

            // Hide the "Other" category textbox initially
            if (txtOtherCategory != null)
            {
                txtOtherCategory.Visible = false;
                txtOtherCategory.TextChanged += new EventHandler(txtOtherCategory_TextChanged);
            }
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
            // Set initial engagement message
            lblEngagement.Text = "Please enter the location of the issue.";

            // Show progress bar and set initial value
            if (progressReport != null)
            {
                progressReport.Visible = true;
                progressReport.Value = 0;
                progressReport.Style = ProgressBarStyle.Continuous;
            }
        }



        // Location Text Changed 
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                // User entered location - update message
                lblEngagement.Text = "Location entered! Now choose the category.";
                UpdateProgress(25); // 25% complete
            }
            else
            {
                lblEngagement.Text = "Please enter the location of the issue.";
                UpdateProgress(0);
            }
        }

        // Category Selected 
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != -1)
            {
                string selectedCategory = cmbCategory.SelectedItem.ToString();

                // Check if "Other" is selected
                if (selectedCategory == "Other")
                {
                    // Show the "Other" category textbox
                    if (txtOtherCategory != null)
                    {
                        txtOtherCategory.Visible = true;
                        txtOtherCategory.Focus();
                        lblEngagement.Text = "Please specify your category in the textbox below.";
                    }

                    // Don't update progress yet - wait for user to enter custom category
                    UpdateProgress(25);
                }
                else
                {
                    // Hide the "Other" category textbox if it was visible
                    if (txtOtherCategory != null)
                    {
                        txtOtherCategory.Visible = false;
                        txtOtherCategory.Clear();
                    }

                    // Normal category selected
                    lblEngagement.Text = $"Category selected: {selectedCategory}. Keep going and provide a description below.";
                    UpdateProgress(50);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    lblEngagement.Text = "Location entered! Now choose the category.";
                    UpdateProgress(25);
                }
            }

        }

        // Other Category Text Changed
        private void txtOtherCategory_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOtherCategory.Text))
            {
                // User has entered a custom category
                lblEngagement.Text = $"Custom category: {txtOtherCategory.Text.Trim()}. Keep going and provide a description below.";
                UpdateProgress(50); // 50% complete
            }
            else
            {
                lblEngagement.Text = "Please specify your category in the textbox below.";
                UpdateProgress(25);
            }
        }

        // Get the selected category (handles "Other" special case)
        private string GetSelectedCategory()
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            if (selectedCategory == "Other")
            {
                // Return the custom category entered by the user
                return string.IsNullOrWhiteSpace(txtOtherCategory.Text)
                    ? "Other (Unspecified)"
                    : "Other: " + txtOtherCategory.Text.Trim();
            }

            return selectedCategory;
        }

        // Attachment added
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
                    // Display the filename in the ListBox
                    lstAttachments.Items.Clear();
                    lstAttachments.Items.Add(" " + Path.GetFileName(selectedFilePath));

                    // Update engagement message
                    lblEngagement.Text = "You have now attached a file! Click the 'Submit Report' button to finalize your report.";
                    UpdateProgress(90); // 90% complete
                }
            }

        }

        // Update Progress Bar
        private void UpdateProgress(int value)
        {
            if (progressReport != null)
            {
                progressReport.Value = Math.Min(value, 100);
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
                lblEngagement.Text = "Please enter the location of the issue.";
                return;
            }

            if (cmbCategory.SelectedIndex == -1 || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category for the issue.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                lblEngagement.Text = "Location entered! Now choose the category.";
                return;
            }

            // Check if "Other" was selected and validate the custom category
            if (cmbCategory.SelectedItem.ToString() == "Other")
            {   
                if (string.IsNullOrWhiteSpace(txtOtherCategory.Text))
                {
                    MessageBox.Show("Please specify your custom category in the textbox.", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOtherCategory.Focus();
                    lblEngagement.Text = "Please specify your category in the textbox below.";
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a detailed description of the issue.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                lblEngagement.Text = "Category selected! Keep going and provide a description.";
                return;
            }

            // 2. Get the final category (handles "Other" special case)
            string finalCategory = GetSelectedCategory();

            // 3. Create a new Issue object
            Issue newIssue = new Issue(
                txtLocation.Text.Trim(),
                finalCategory,
                rtbDescription.Text.Trim(),
                selectedFilePath
            );

            // 4. Add to the static list
            issuesList.Add(newIssue);

            // 5. User Engagement Feature: Submission Processing
            btnSubmit.Enabled = false;
            lblEngagement.Text = "Submitting your report... Please wait.";

            if (progressReport != null)
            {
                progressReport.Value = 100;
            }

            Timer timer = new Timer();
            timer.Interval = 300;
            int step = 0;
            string[] messages = new string[]
            {
                "Submitting your report...",
                "Processing your report... Thank you for your patience!",
                "Your voice matters! Routing to the right department.",
                "Your report is making a difference in our community.",
                "Thank you for helping keep our city clean and safe!"
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

                    string displayMessage = "Issue Reported Successfully!\n\n";
                    displayMessage += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    displayMessage += "REPORT DETAILS\n";
                    displayMessage += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n";

                    displayMessage += $"Location: {txtLocation.Text.Trim()}\n";
                    displayMessage += $"Category: {finalCategory}\n";
                    displayMessage += $"Description: {rtbDescription.Text.Trim()}\n";

                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        displayMessage += $"Attachment: {Path.GetFileName(selectedFilePath)}\n";
                    }
                    else
                    {
                        displayMessage += $"Attachment: No file attached\n";
                    }

                    displayMessage += $"\nReported: {DateTime.Now.ToString("dd MMMM yyyy HH:mm")}\n";
                    displayMessage += $"Reference: #{DateTime.Now.ToString("yyyyMMddHHmmss")}\n\n";

                    displayMessage += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    displayMessage += "Thank you for helping improve our community!\n";
                    displayMessage += "We will keep you updated on the progress of this issue.";

                    MessageBox.Show(
                        displayMessage,
                        "Report Submitted Successfully",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ClearForm();
                    lblEngagement.Text = "Please enter the location of the issue.";
                    UpdateProgress(0);
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
            UpdateProgress(0);
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
                lblEngagement.Text = " Form cleared. Start a new report when you're ready.";
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

        // Description Text Changed
        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            int charCount = rtbDescription.Text.Length;

            if (charCount > 0)
            {
                lblEngagement.Text = "Great! Now you can attach a file to your report using the 'Attach Image/Document' button.";
                UpdateProgress(75); // 75% complete
            }
            else if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                // Reset to step 1 if description is empty
                lblEngagement.Text = " Please enter the location of the issue.";
                UpdateProgress(0);
            }
            else if (cmbCategory.SelectedIndex == -1)
            {
                lblEngagement.Text = " Location entered! Now choose the category.";
                UpdateProgress(25);
            }
        }

        //translating the language
        public void UpdateTranslations()
        {
            // Update all labels
            UpdateControlText("lblTitle", "report_issue_title");
            UpdateControlText("lblSubtitle", "report_issue_subtitle");
            UpdateControlText("lblLocation", "lblLocation");
            UpdateControlText("lblCategory", "lblCategory");
            UpdateControlText("lblDescription", "lblDescription");
            UpdateControlText("lblAttachments", "lblAttachments");
            UpdateControlText("lblEngagement", "lblEngagement");

            // Update buttons
            UpdateControlText("btnAttach", "btnAttach");
            UpdateControlText("btnSubmit", "btnSubmit");
            UpdateControlText("btnClear", "btnClear");
            UpdateControlText("btnBack", "btnBack");
        }

        private void UpdateControlText(string controlName, string translationKey)
        {
            Control[] controls = this.Controls.Find(controlName, true);
            if (controls.Length > 0 && controls[0] != null)
            {
                string translatedText = LanguageManager.GetString(translationKey);
                if (!string.IsNullOrEmpty(translatedText) && translatedText != translationKey)
                {
                    controls[0].Text = translatedText;
                }
            }
        }
    }
}
