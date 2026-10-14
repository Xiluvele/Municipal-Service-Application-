using System;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class EventForm : Form
    {
        // =====================================================
        // EVENT TO EDIT
        // =====================================================
        // If this variable is null, the form is being used
        // to ADD a new event.
        //
        // If it contains an event, the form is being used
        // to EDIT an existing event.
        // =====================================================
        private LocalEvent eventToEdit;


        // =====================================================
        // ADD EVENT CONSTRUCTOR
        // =====================================================
        // This constructor is used when the administrator
        // clicks the "Add Event" button.
        // =====================================================
        public EventForm()
        {
            InitializeComponent();

            // No event was supplied, so this is Add mode.
            eventToEdit = null;

            SetupForm();

            lblHeading.Text = "Add Municipal Event";
            btnSave.Text = "Save Event";
        }


        // =====================================================
        // EDIT EVENT CONSTRUCTOR
        // =====================================================
        // This constructor receives the selected event from
        // ManageEventsForm.
        //
        // The existing event information will be displayed
        // so that the administrator can edit it.
        // =====================================================
        public EventForm(LocalEvent localEvent)
        {
            InitializeComponent();

            // Store the selected event.
            eventToEdit = localEvent;

            SetupForm();

            lblHeading.Text = "Edit Municipal Event";
            btnSave.Text = "Save Changes";

            // Display the existing event information.
            LoadEventDetails();
        }


        // =====================================================
        // SETUP FORM
        // =====================================================
        // Loads all existing categories into the category
        // ComboBox.
        //
        // EventManager.Categories is a HashSet, which means
        // duplicate categories are automatically prevented.
        // =====================================================
        private void SetupForm()
        {
            cmbCategory.Items.Clear();

            foreach (string category in
                     EventManager.Categories.OrderBy(c => c))
            {
                cmbCategory.Items.Add(category);
            }

            // When adding a new event, today's date will
            // initially be selected.
            dtpEventDate.Value = DateTime.Today;
        }


        // =====================================================
        // LOAD EVENT DETAILS
        // =====================================================
        // Used only when editing an event.
        //
        // It takes the information from the selected event
        // and displays it inside the form controls.
        // =====================================================
        private void LoadEventDetails()
        {
            if (eventToEdit == null)
            {
                return;
            }

            txtTitle.Text = eventToEdit.Title;
            txtDescription.Text = eventToEdit.Description;
            cmbCategory.Text = eventToEdit.Category;
            dtpEventDate.Value = eventToEdit.EventDate;
            txtLocation.Text = eventToEdit.Location;
        }


        // =====================================================
        // SAVE EVENT BUTTON
        // =====================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // =================================================
            // VALIDATION - EVENT TITLE
            // =================================================
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(
                    "Please enter the event title.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitle.Focus();
                return;
            }


            // =================================================
            // VALIDATION - DESCRIPTION
            // =================================================
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show(
                    "Please enter the event description.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescription.Focus();
                return;
            }


            // =================================================
            // VALIDATION - CATEGORY
            // =================================================
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show(
                    "Please enter or select an event category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }


            // =================================================
            // VALIDATION - LOCATION
            // =================================================
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the event location.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLocation.Focus();
                return;
            }


            // =================================================
            // VALIDATION - EVENT DATE
            // =================================================
            // Prevent administrators from creating an event
            // with a date that has already passed.
            // =================================================
            if (dtpEventDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "The event date cannot be in the past.",
                    "Invalid Event Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpEventDate.Focus();
                return;
            }


            // =================================================
            // ADD NEW EVENT
            // =================================================
            // eventToEdit will be null when this form was opened
            // using:
            //
            // new EventForm()
            // =================================================
            if (eventToEdit == null)
            {
                // Ask EventManager for the next unique Event ID.
                int newEventId =
                    EventManager.GetNextEventId();


                // Create the new LocalEvent object.
                LocalEvent newEvent =
                    new LocalEvent(
                        newEventId,
                        txtTitle.Text.Trim(),
                        txtDescription.Text.Trim(),
                        cmbCategory.Text.Trim(),
                        dtpEventDate.Value.Date,
                        txtLocation.Text.Trim()
                    );


                // AddEvent will:
                //
                // 1. Add the event to the main collection.
                // 2. Rebuild the SortedDictionary.
                // 3. Rebuild the Dictionary.
                // 4. Rebuild the HashSet.
                // 5. Rebuild the Queue.
                // 6. Save the event to Data\events.txt.
                EventManager.AddEvent(newEvent);


                MessageBox.Show(
                    "The event was added successfully.",
                    "Event Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


            // =================================================
            // EDIT EXISTING EVENT
            // =================================================
            else
            {
                // Keep the same EventId because we are updating
                // an existing event instead of creating a new one.
                LocalEvent updatedEvent =
                    new LocalEvent(
                        eventToEdit.EventId,
                        txtTitle.Text.Trim(),
                        txtDescription.Text.Trim(),
                        cmbCategory.Text.Trim(),
                        dtpEventDate.Value.Date,
                        txtLocation.Text.Trim()
                    );


                // UpdateEvent finds the existing event by its
                // EventId and saves the updated information.
                bool updated =
                    EventManager.UpdateEvent(updatedEvent);


                if (!updated)
                {
                    MessageBox.Show(
                        "The selected event could not be updated.",
                        "Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                MessageBox.Show(
                    "The event was updated successfully.",
                    "Event Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


            // =================================================
            // RETURN SUCCESS TO MANAGE EVENTS FORM
            // =================================================
            // ManageEventsForm checks for DialogResult.OK.
            //
            // When it receives OK, it reloads the DataGridView
            // so the administrator immediately sees the change.
            // =================================================
            DialogResult = DialogResult.OK;

            Close();
        }


        // =====================================================
        // CANCEL BUTTON
        // =====================================================
        // Closes the form without adding or editing anything.
        // =====================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}