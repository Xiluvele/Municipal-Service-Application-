using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class AnnouncementForm : Form
    {
        // =====================================================
        // ANNOUNCEMENT BEING EDITED
        // =====================================================
        // If this is null, the form is being used to ADD.
        //
        // If it contains an Announcement, the form is being
        // used to EDIT that announcement.
        // =====================================================
        private Announcement announcementToEdit;


        // =====================================================
        // ADD ANNOUNCEMENT CONSTRUCTOR
        // =====================================================
        // Used when the administrator clicks:
        // Add Announcement
        // =====================================================
        public AnnouncementForm()
        {
            InitializeComponent();

            announcementToEdit = null;

            SetupForm();

            lblHeading.Text = "Add Announcement";
            btnSave.Text = "Save Announcement";
        }


        // =====================================================
        // EDIT ANNOUNCEMENT CONSTRUCTOR
        // =====================================================
        // Used when the administrator selects an announcement
        // and clicks Edit Selected.
        // =====================================================
        public AnnouncementForm(Announcement announcement)
        {
            InitializeComponent();

            announcementToEdit = announcement;

            SetupForm();

            lblHeading.Text = "Edit Announcement";
            btnSave.Text = "Save Changes";

            LoadAnnouncementDetails();
        }


        // =====================================================
        // SETUP FORM
        // =====================================================
        // Populates the priority ComboBox and sets default
        // values for a new announcement.
        // =====================================================
        private void SetupForm()
        {
            // Clear existing items first so that priorities
            // are not added more than once.
            cmbPriority.Items.Clear();


            // These match the priority numbers used by our
            // AnnouncementPriorityQueue:
            //
            // Critical = 1
            // High     = 2
            // Normal   = 3
            cmbPriority.Items.Add("Critical");
            cmbPriority.Items.Add("High");
            cmbPriority.Items.Add("Normal");


            // Administrator must select one of our
            // predefined priorities.
            cmbPriority.DropDownStyle =
                ComboBoxStyle.DropDownList;


            // Normal is the default priority.
            cmbPriority.SelectedItem = "Normal";


            // Today's date is the default date.
            dtpAnnouncementDate.Value =
                DateTime.Today;
        }


        // =====================================================
        // LOAD ANNOUNCEMENT DETAILS
        // =====================================================
        // When editing, populate the controls with the
        // information from the selected announcement.
        // =====================================================
        private void LoadAnnouncementDetails()
        {
            if (announcementToEdit == null)
            {
                return;
            }


            txtTitle.Text =
                announcementToEdit.Title;

            txtMessage.Text =
                announcementToEdit.Message;


            // Make sure the date is valid for the
            // DateTimePicker before assigning it.
            if (announcementToEdit.Date >=
                dtpAnnouncementDate.MinDate &&
                announcementToEdit.Date <=
                dtpAnnouncementDate.MaxDate)
            {
                dtpAnnouncementDate.Value =
                    announcementToEdit.Date;
            }


            // Convert the stored numeric priority
            // into user-friendly text.
            switch (announcementToEdit.Priority)
            {
                case 1:
                    cmbPriority.SelectedItem =
                        "Critical";
                    break;

                case 2:
                    cmbPriority.SelectedItem =
                        "High";
                    break;

                case 3:
                    cmbPriority.SelectedItem =
                        "Normal";
                    break;

                default:
                    cmbPriority.SelectedItem =
                        "Normal";
                    break;
            }
        }


        // =====================================================
        // TITLE TEXT CHANGED
        // =====================================================
        // Keep this method because your Designer may already
        // have the TextChanged event connected to it.
        // =====================================================
        private void txtTitle_TextChanged(
            object sender,
            EventArgs e)
        {

        }


        // =====================================================
        // SAVE BUTTON
        // =====================================================
        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            // =================================================
            // VALIDATE TITLE
            // =================================================
            if (string.IsNullOrWhiteSpace(
                txtTitle.Text))
            {
                MessageBox.Show(
                    "Please enter the announcement title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();

                return;
            }


            // =================================================
            // VALIDATE MESSAGE
            // =================================================
            if (string.IsNullOrWhiteSpace(
                txtMessage.Text))
            {
                MessageBox.Show(
                    "Please enter the announcement message.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMessage.Focus();

                return;
            }


            // =================================================
            // VALIDATE PRIORITY
            // =================================================
            if (cmbPriority.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select an announcement priority.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPriority.Focus();

                return;
            }


            // =================================================
            // CONVERT PRIORITY TO NUMBER
            // =================================================
            int priority;


            switch (cmbPriority.SelectedItem.ToString())
            {
                case "Critical":
                    priority = 1;
                    break;

                case "High":
                    priority = 2;
                    break;

                default:
                    priority = 3;
                    break;
            }


            // =================================================
            // ADD NEW ANNOUNCEMENT
            // =================================================
            if (announcementToEdit == null)
            {
                // Generate the next unique ID.
                int newAnnouncementId =
                    EventManager.GetNextAnnouncementId();


                // Create the new announcement.
                Announcement newAnnouncement =
                    new Announcement(
                        newAnnouncementId,
                        txtTitle.Text.Trim(),
                        txtMessage.Text.Trim(),
                        priority,
                        dtpAnnouncementDate.Value.Date
                    );


                // Add to Priority Queue and save to
                // announcements.txt.
                EventManager.AddAnnouncement(
                    newAnnouncement);


                MessageBox.Show(
                    "Announcement added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


            // =================================================
            // EDIT EXISTING ANNOUNCEMENT
            // =================================================
            else
            {
                // Keep the existing AnnouncementId but use
                // the administrator's updated information.
                Announcement updatedAnnouncement =
                    new Announcement(
                        announcementToEdit.AnnouncementId,
                        txtTitle.Text.Trim(),
                        txtMessage.Text.Trim(),
                        priority,
                        dtpAnnouncementDate.Value.Date
                    );


                bool updated =
                    EventManager.UpdateAnnouncement(
                        updatedAnnouncement);


                if (!updated)
                {
                    MessageBox.Show(
                        "The announcement could not be updated.",
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                MessageBox.Show(
                    "Announcement updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


            // =================================================
            // CLOSE FORM SUCCESSFULLY
            // =================================================
            // ManageAnnouncementsForm checks for DialogResult.OK
            // and reloads the DataGridView.
            this.DialogResult =
                DialogResult.OK;

            this.Close();
        }


        // =====================================================
        // CANCEL BUTTON
        // =====================================================
        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            this.DialogResult =
                DialogResult.Cancel;

            this.Close();
        }
    }
}