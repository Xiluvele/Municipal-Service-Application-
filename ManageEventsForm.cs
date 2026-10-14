using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ManageEventsForm : Form
    {
        public ManageEventsForm()
        {
            InitializeComponent();

            StyleDataGridView();
            LoadEvents();
        }


        // =====================================================
        // LOAD EVENTS
        // =====================================================
        // Loads all municipal events from EventManager and
        // displays them in the administrator's DataGridView.
        //
        // This method is also called after Add, Edit and Delete
        // so that the table always displays the latest data.
        // =====================================================
        private void LoadEvents()
        {
            // Admin can view all events, not only upcoming events.
            var events = EventManager.GetAllEvents()
                .OrderBy(e => e.EventDate)
                .ToList();


            // Refresh the DataGridView.
            dgvEvents.DataSource = null;
            dgvEvents.DataSource = events;


            // Update the total number of events.
            lblEventCount.Text =
                $"Total events: {events.Count}";


            // =================================================
            // FRIENDLY COLUMN HEADINGS
            // =================================================

            if (dgvEvents.Columns["EventId"] != null)
            {
                dgvEvents.Columns["EventId"].HeaderText =
                    "Event ID";
            }

            if (dgvEvents.Columns["Title"] != null)
            {
                dgvEvents.Columns["Title"].HeaderText =
                    "Title";
            }

            if (dgvEvents.Columns["Description"] != null)
            {
                dgvEvents.Columns["Description"].HeaderText =
                    "Description";
            }

            if (dgvEvents.Columns["Category"] != null)
            {
                dgvEvents.Columns["Category"].HeaderText =
                    "Category";
            }

            if (dgvEvents.Columns["EventDate"] != null)
            {
                dgvEvents.Columns["EventDate"].HeaderText =
                    "Event Date";

                dgvEvents.Columns["EventDate"]
                    .DefaultCellStyle.Format =
                    "dd MMM yyyy";
            }

            if (dgvEvents.Columns["Location"] != null)
            {
                dgvEvents.Columns["Location"].HeaderText =
                    "Location";
            }
        }


        // =====================================================
        // STYLE DATAGRIDVIEW
        // =====================================================
        private void StyleDataGridView()
        {
            dgvEvents.BackgroundColor = Color.White;

            // Normal rows
            dgvEvents.DefaultCellStyle.BackColor =
                Color.White;

            dgvEvents.DefaultCellStyle.ForeColor =
                Color.Black;


            // Selected row
            dgvEvents.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(31, 78, 121);

            dgvEvents.DefaultCellStyle.SelectionForeColor =
                Color.White;


            // Column headers
            dgvEvents.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(31, 78, 121);

            dgvEvents.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvEvents.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            dgvEvents.EnableHeadersVisualStyles = false;


            // General appearance
            dgvEvents.GridColor = Color.LightGray;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.RowTemplate.Height = 30;


            // Only allow one full row to be selected.
            // This makes Edit and Delete easier and safer.
            dgvEvents.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEvents.MultiSelect = false;

            // Admin edits events using EventForm instead
            // of editing cells directly in the table.
            dgvEvents.ReadOnly = true;

            // Prevent adding/deleting directly through
            // the DataGridView.
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
        }


        // =====================================================
        // BACK BUTTON
        // =====================================================
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // =====================================================
        // ADD EVENT
        // =====================================================
        // Opens EventForm without supplying an existing event.
        //
        // EventForm therefore knows that it is being used
        // to create a new municipal event.
        // =====================================================
        private void btnAddEvent_Click(
            object sender,
            EventArgs e)
        {
            using (EventForm eventForm = new EventForm())
            {
                // Show the Add Event form.
                DialogResult result =
                    eventForm.ShowDialog();


                // EventForm returns OK only when the event
                // was successfully saved.
                if (result == DialogResult.OK)
                {
                    // Reload the table immediately so that
                    // the administrator sees the new event.
                    LoadEvents();
                }
            }
        }


        // =====================================================
        // EDIT SELECTED EVENT
        // =====================================================
        // Gets the LocalEvent belonging to the selected row
        // and sends it to EventForm.
        //
        // EventForm will automatically switch into Edit mode.
        // =====================================================
        private void btnEditEvent_Click(
            object sender,
            EventArgs e)
        {
            // Make sure there is a selected/current row.
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an event to edit.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Because the DataGridView is bound to a
            // List<LocalEvent>, DataBoundItem gives us the
            // LocalEvent object represented by that row.
            LocalEvent selectedEvent =
                dgvEvents.CurrentRow.DataBoundItem
                as LocalEvent;


            if (selectedEvent == null)
            {
                MessageBox.Show(
                    "Please select a valid event to edit.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Pass the selected event to EventForm.
            //
            // Supplying an event tells EventForm that
            // it should operate in Edit mode.
            using (EventForm eventForm =
                   new EventForm(selectedEvent))
            {
                DialogResult result =
                    eventForm.ShowDialog();


                // If changes were successfully saved,
                // refresh the table.
                if (result == DialogResult.OK)
                {
                    LoadEvents();
                }
            }
        }


        // =====================================================
        // DELETE SELECTED EVENT
        // =====================================================
        // Deletes the selected event after asking the
        // administrator for confirmation.
        // =====================================================
        private void btnDeleteEvent_Click(
            object sender,
            EventArgs e)
        {
            // Make sure there is an event available.
            if (dgvEvents.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an event to delete.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Get the LocalEvent represented by the
            // currently selected row.
            LocalEvent selectedEvent =
                dgvEvents.CurrentRow.DataBoundItem
                as LocalEvent;


            if (selectedEvent == null)
            {
                MessageBox.Show(
                    "Please select a valid event to delete.",
                    "No Event Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // =================================================
            // DELETE CONFIRMATION
            // =================================================
            // We ask for confirmation because deletion will
            // also update Data\events.txt.
            // =================================================
            DialogResult confirmation =
                MessageBox.Show(
                    "Are you sure you want to delete the event:\n\n" +
                    selectedEvent.Title + "?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            // Cancel the operation if Admin selects No.
            if (confirmation != DialogResult.Yes)
            {
                return;
            }


            // =================================================
            // DELETE EVENT
            // =================================================
            // EventManager.DeleteEvent:
            //
            // 1. Removes the event from the main collection.
            // 2. Rebuilds the SortedDictionary.
            // 3. Rebuilds the Dictionary.
            // 4. Rebuilds the HashSet.
            // 5. Rebuilds the Queue.
            // 6. Updates Data\events.txt.
            // =================================================
            bool deleted =
                EventManager.DeleteEvent(
                    selectedEvent.EventId);


            if (deleted)
            {
                MessageBox.Show(
                    "The event was deleted successfully.",
                    "Event Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // Reload the table so that the deleted
                // event disappears immediately.
                LoadEvents();
            }
            else
            {
                MessageBox.Show(
                    "The selected event could not be deleted.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}