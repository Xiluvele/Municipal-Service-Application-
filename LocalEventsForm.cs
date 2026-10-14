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
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();

            dtpEventDate.Checked = false;

            LoadCategories();
            DisplayUpcomingEvents();
            DisplayAnnouncements();
            DisplayRecentSearches();
        }
        private void LoadCategories()
        {
            cmbCategory.Items.Clear();

            // Default option
            cmbCategory.Items.Add("All Categories");

            // Categories come from our HashSet in EventManager
            foreach (string category in EventManager.Categories.OrderBy(c => c))
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }
        private void DisplayUpcomingEvents( System.Collections.Generic.List<LocalEvent> events = null)
        {
            // Clear the current event cards
            flpEvents.Controls.Clear();

            // If search results were provided, display them.
            // Otherwise, display all upcoming events.
            var upcomingEvents = events ?? EventManager.GetAllUpcomingEvents();

            // If no events were found
            if (upcomingEvents.Count == 0)
            {
                Label lblNoEvents = new Label();

                lblNoEvents.Text = "No events found matching your search.";
                lblNoEvents.AutoSize = true;
                lblNoEvents.Font = new Font("Segoe UI", 10);
                lblNoEvents.ForeColor = Color.DimGray;
                lblNoEvents.Margin = new Padding(10);

                flpEvents.Controls.Add(lblNoEvents);

                return;
            }

            // Create an event card for every event
            foreach (LocalEvent localEvent in upcomingEvents)
            {
                Panel eventCard = CreateEventCard(localEvent);

                flpEvents.Controls.Add(eventCard);
            }
        }

        private Panel CreateEventCard(LocalEvent localEvent)
        {
            Panel card = new Panel();

            card.Width = 250;
            card.Height = 145;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(8);


            // EVENT TITLE
            Label lblTitle = new Label();

            lblTitle.Text = localEvent.Title;
            lblTitle.Location = new Point(12, 10);
            lblTitle.Size = new Size(225, 25);
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 78, 121);


            // DATE
            Label lblDate = new Label();

            lblDate.Text = localEvent.EventDate.ToString("dd MMMM yyyy");
            lblDate.Location = new Point(12, 42);
            lblDate.Size = new Size(225, 20);
            lblDate.Font = new Font("Segoe UI", 9);
            lblDate.ForeColor = Color.FromArgb(60, 60, 60);


            // CATEGORY
            Label lblCategory = new Label();

            lblCategory.Text = "Category: " + localEvent.Category;
            lblCategory.Location = new Point(12, 68);
            lblCategory.Size = new Size(225, 20);
            lblCategory.Font = new Font("Segoe UI", 9);
            lblCategory.ForeColor = Color.DimGray;


            // LOCATION
            Label lblLocation = new Label();

            lblLocation.Text = "Location: " + localEvent.Location;
            lblLocation.Location = new Point(12, 94);
            lblLocation.Size = new Size(225, 38);
            lblLocation.Font = new Font("Segoe UI", 9);
            lblLocation.ForeColor = Color.DimGray;


            // Add everything to the card
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblCategory);
            card.Controls.Add(lblLocation);

            return card;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the keyword entered by the user
            string keyword = txtSearch.Text.Trim();

            // Get the selected category
            string category =
                cmbCategory.SelectedItem != null
                ? cmbCategory.SelectedItem.ToString()
                : "All Categories";

            // Date is optional
            DateTime? selectedDate = null;

            if (dtpEventDate.Checked)
            {
                selectedDate = dtpEventDate.Value.Date;
            }


            // =====================================================
            // SEARCH FOR EVENTS
            // =====================================================
            var results = EventManager.SearchEvents(keyword, category, selectedDate);


            // =====================================================
            // RECORD CATEGORY PREFERENCE
            // Used by the recommendation algorithm
            // =====================================================
            EventManager.RecordSearchPreference(category);


            // =====================================================
            // DISPLAY SEARCH RESULTS
            // =====================================================
            DisplayUpcomingEvents(results);


            // =====================================================
            // UPDATE PERSONALISED RECOMMENDATIONS
            // =====================================================
            DisplayRecommendations();


            // =====================================================
            // STORE SEARCH IN THE STACK
            // =====================================================
            string searchDescription = "";


            // Add keyword to search description
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                searchDescription += keyword;
            }


            // Add category
            if (category != "All Categories")
            {
                if (searchDescription.Length > 0)
                {
                    searchDescription += " | ";
                }

                searchDescription += category;
            }


            // Add date
            if (selectedDate.HasValue)
            {
                if (searchDescription.Length > 0)
                {
                    searchDescription += " | ";
                }

                searchDescription +=selectedDate.Value.ToString("dd MMM yyyy");
            }


            // Store meaningful searches in the Stack
            if (!string.IsNullOrWhiteSpace(searchDescription))
            {
                EventManager.RecentSearches.Push( searchDescription );
            }

            // Refresh the recent searches shown on screen
            DisplayRecentSearches();
        }

        private void DisplayRecommendations()
        {
            // Clear previous recommendations
            flpRecommendations.Controls.Clear();

            // Get recommended events from EventManager
            var recommendations = EventManager.GetRecommendedEvents();

            // Get the user's favourite category
            string favouriteCategory =  EventManager.GetFavouriteCategory();

            // If the user has not searched for a category yet
            if (recommendations.Count == 0 || string.IsNullOrWhiteSpace(favouriteCategory))
            {
                lblRecommendedInfo.Text = "Search for events to receive personalised recommendations.";

                return;
            }

            // Explain why the events are being recommended
            lblRecommendedInfo.Text = $"Recommended because you are interested in {favouriteCategory} events.";

            // Display each recommended event
            foreach (LocalEvent localEvent in recommendations)
            {
                Label recommendation = new Label();

                recommendation.Text = $"{localEvent.Title}  •  " +  $"{localEvent.EventDate:dd MMM yyyy}";                            
                recommendation.AutoSize = true;

                recommendation.Font = new Font( "Segoe UI",  9,  FontStyle.Bold);                 
                recommendation.ForeColor =Color.FromArgb(31, 78, 121);
                recommendation.Margin = new Padding(10, 5, 20, 5);
                recommendation.Cursor = Cursors.Hand;
                flpRecommendations.Controls.Add(recommendation);
            }
        }

        private void DisplayAnnouncements()
        {
            // Clear the existing controls from the announcements panel
            pnlAnnouncements.Controls.Clear();

            // Get announcements from the Priority Queue
            var announcements =
                EventManager.Announcements.GetAllAnnouncements();


            // =====================================================
            // SECTION HEADING
            // =====================================================
            Label lblHeading = new Label();

            lblHeading.Text = "Important Announcements";
            lblHeading.Location = new Point(20, 15);
            lblHeading.AutoSize = true;

            lblHeading.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            lblHeading.ForeColor =
                Color.FromArgb(31, 78, 121);

            pnlAnnouncements.Controls.Add(lblHeading);


            // =====================================================
            // NO ANNOUNCEMENTS
            // =====================================================
            if (announcements.Count == 0)
            {
                Label lblEmpty = new Label();

                lblEmpty.Text =
                    "No important announcements at the moment.";

                lblEmpty.Location =
                    new Point(20, 50);

                lblEmpty.AutoSize = true;

                lblEmpty.Font =
                    new Font("Segoe UI", 9);

                lblEmpty.ForeColor =
                    Color.DimGray;

                pnlAnnouncements.Controls.Add(lblEmpty);

                return;
            }


            // Starting position for first announcement
            int yPosition = 50;


            // =====================================================
            // DISPLAY ANNOUNCEMENTS
            // =====================================================
            foreach (Announcement announcement in announcements)
            {
                string priorityText;

                Color priorityColor;


                // Determine priority name and colour
                switch (announcement.Priority)
                {
                    case 1:
                        priorityText = "CRITICAL";
                        priorityColor = Color.DarkRed;
                        break;

                    case 2:
                        priorityText = "HIGH";
                        priorityColor = Color.DarkOrange;
                        break;

                    default:
                        priorityText = "NORMAL";
                        priorityColor =
                            Color.FromArgb(60, 60, 60);
                        break;
                }


                // Create announcement label
                Label lblAnnouncement = new Label();

                lblAnnouncement.Text =
                    $"[{priorityText}] {announcement.Title}\r\n" +
                    $"{announcement.Message}";

                lblAnnouncement.Location =
                    new Point(20, yPosition);

                lblAnnouncement.Size =
                    new Size(
                        pnlAnnouncements.ClientSize.Width - 40,
                        45);

                lblAnnouncement.Font =
                    new Font(
                        "Segoe UI",
                        9,
                        announcement.Priority == 1
                            ? FontStyle.Bold
                            : FontStyle.Regular);

                lblAnnouncement.ForeColor =
                    priorityColor;

                pnlAnnouncements.Controls.Add(
                    lblAnnouncement);


                // Move the next announcement down
                yPosition += 50;
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            cmbCategory.SelectedIndex = 0;

            dtpEventDate.Checked = false;

            DisplayUpcomingEvents();

            txtSearch.Focus();
        }
        private void DisplayRecentSearches()
        {
            if (EventManager.RecentSearches.Count == 0)
            {
                lblRecentSearches.Text =
                    "Recent Searches: None";

                return;
            }

            // Stack uses LIFO:
            // newest search appears first.
            var recentSearches =
                EventManager.RecentSearches
                    .Take(3)
                    .ToList();

            lblRecentSearches.Text =
                "Recent Searches: " +
                string.Join("   |   ", recentSearches);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
