using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ManageAnnouncementsForm : Form
    {
        // =====================================================
        // CONSTRUCTOR
        // =====================================================
        public ManageAnnouncementsForm()
        {
            InitializeComponent();

            // Apply styling to the announcements table.
            StyleDataGridView();

            // Display announcements when the form opens.
            LoadAnnouncements();
        }


        // =====================================================
        // LOAD ANNOUNCEMENTS
        // =====================================================
        // Gets all announcements from EventManager.
        //
        // The announcements are stored in the
        // AnnouncementPriorityQueue.
        //
        // Priority order:
        // 1 = Critical
        // 2 = High
        // 3 = Normal
        // =====================================================
        private void LoadAnnouncements()
        {
            var announcements =
                EventManager
                    .GetAllAnnouncements()
                    .ToList();


            // Clear the previous DataSource.
            dgvAnnouncements.DataSource = null;


            // Display announcements.
            dgvAnnouncements.DataSource =
                announcements;


            // Update total count.
            lblAnnouncementCount.Text =
                $"Total announcements: {announcements.Count}";


            // =================================================
            // COLUMN HEADINGS
            // =================================================

            if (dgvAnnouncements.Columns["AnnouncementId"] != null)
            {
                dgvAnnouncements.Columns["AnnouncementId"]
                    .HeaderText = "ID";
            }


            if (dgvAnnouncements.Columns["Title"] != null)
            {
                dgvAnnouncements.Columns["Title"]
                    .HeaderText = "Title";
            }


            if (dgvAnnouncements.Columns["Message"] != null)
            {
                dgvAnnouncements.Columns["Message"]
                    .HeaderText = "Message";
            }


            if (dgvAnnouncements.Columns["Priority"] != null)
            {
                dgvAnnouncements.Columns["Priority"]
                    .HeaderText = "Priority";
            }


            if (dgvAnnouncements.Columns["Date"] != null)
            {
                dgvAnnouncements.Columns["Date"]
                    .HeaderText = "Date";

                dgvAnnouncements.Columns["Date"]
                    .DefaultCellStyle.Format =
                    "dd MMM yyyy";
            }


            // Clear automatic selection after refreshing.
            dgvAnnouncements.ClearSelection();
        }


        // =====================================================
        // STYLE DATAGRIDVIEW
        // =====================================================
        private void StyleDataGridView()
        {
            dgvAnnouncements.BackgroundColor =
                Color.White;

            dgvAnnouncements.DefaultCellStyle.BackColor =
                Color.White;

            dgvAnnouncements.DefaultCellStyle.ForeColor =
                Color.Black;


            // Selected row colours.
            dgvAnnouncements.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(31, 78, 121);

            dgvAnnouncements.DefaultCellStyle.SelectionForeColor =
                Color.White;


            // Header colours.
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(31, 78, 121);

            dgvAnnouncements.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvAnnouncements.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);


            dgvAnnouncements.EnableHeadersVisualStyles =
                false;


            // Grid appearance.
            dgvAnnouncements.GridColor =
                Color.LightGray;

            dgvAnnouncements.RowHeadersVisible =
                false;

            dgvAnnouncements.RowTemplate.Height =
                30;


            // Fill available width.
            dgvAnnouncements.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // Select entire row.
            dgvAnnouncements.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;


            // Only one announcement at a time.
            dgvAnnouncements.MultiSelect =
                false;


            // Do not allow editing directly inside the table.
            dgvAnnouncements.ReadOnly =
                true;


            dgvAnnouncements.AllowUserToAddRows =
                false;

            dgvAnnouncements.AllowUserToDeleteRows =
                false;
        }


        // =====================================================
        // BACK BUTTON
        // =====================================================
        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }


        // =====================================================
        // DATAGRIDVIEW CELL CLICK
        // =====================================================
        // Keep this method because your Designer may already
        // have the CellContentClick event connected to it.
        //
        // FullRowSelect handles the row selection.
        // =====================================================
        private void dgvAnnouncements_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }


        // =====================================================
        // ADD ANNOUNCEMENT
        // =====================================================
        private void btnAddAnnouncement_Click(
            object sender,
            EventArgs e)
        {
            // Open AnnouncementForm without passing an
            // announcement. This puts the form in ADD mode.
            using (AnnouncementForm announcementForm =
                   new AnnouncementForm())
            {
                DialogResult result =
                    announcementForm.ShowDialog();


                // If the announcement was successfully saved,
                // reload the table.
                if (result == DialogResult.OK)
                {
                    LoadAnnouncements();
                }
            }
        }


        // =====================================================
        // EDIT ANNOUNCEMENT
        // =====================================================
        private void btnEditAnnouncement_Click(
            object sender,
            EventArgs e)
        {
            // Make sure the administrator selected a row.
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an announcement to edit.",
                    "No Announcement Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Get the Announcement object from the
            // selected DataGridView row.
            Announcement selectedAnnouncement =
                dgvAnnouncements.SelectedRows[0]
                    .DataBoundItem as Announcement;


            if (selectedAnnouncement == null)
            {
                MessageBox.Show(
                    "The selected announcement could not be found.",
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // Pass the selected announcement into the form.
            //
            // This causes AnnouncementForm to open in
            // EDIT mode.
            using (AnnouncementForm announcementForm =
                   new AnnouncementForm(
                       selectedAnnouncement))
            {
                DialogResult result =
                    announcementForm.ShowDialog();


                // Refresh after a successful update.
                if (result == DialogResult.OK)
                {
                    LoadAnnouncements();
                }
            }
        }


        // =====================================================
        // DELETE ANNOUNCEMENT
        // =====================================================
        private void btnDeleteAnnouncement_Click(
            object sender,
            EventArgs e)
        {
            // Make sure an announcement was selected.
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an announcement to delete.",
                    "No Announcement Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Get the selected announcement.
            Announcement selectedAnnouncement =
                dgvAnnouncements.SelectedRows[0]
                    .DataBoundItem as Announcement;


            if (selectedAnnouncement == null)
            {
                MessageBox.Show(
                    "The selected announcement could not be found.",
                    "Selection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // Ask the administrator for confirmation.
            DialogResult confirmation =
                MessageBox.Show(
                    "Are you sure you want to delete \"" +
                    selectedAnnouncement.Title +
                    "\"?",
                    "Delete Announcement",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            // Stop if the administrator chooses No.
            if (confirmation != DialogResult.Yes)
            {
                return;
            }


            // Delete the announcement from EventManager.
            //
            // EventManager will:
            // 1. Remove it from the Priority Queue.
            // 2. Rebuild the Priority Queue.
            // 3. Save announcements.txt.
            bool deleted =
                EventManager.DeleteAnnouncement(
                    selectedAnnouncement.AnnouncementId);


            if (deleted)
            {
                MessageBox.Show(
                    "Announcement deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // Refresh the DataGridView.
                LoadAnnouncements();
            }
            else
            {
                MessageBox.Show(
                    "The announcement could not be deleted.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}