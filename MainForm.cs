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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            UpdateQuickOverview();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // REPORT ISSUES
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            using (ReportIssueForm reportIssueForm = new ReportIssueForm())
            {
                reportIssueForm.ShowDialog();
            }

            // Update the number of reported issues after returning
            UpdateQuickOverview();
        }

       

        // LOGOUT
        // Returns the citizen to the existing LoginForm
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lnkViewEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // OpenLocalEvents();
            using (LocalEventsForm eventsForm = new LocalEventsForm())
            {
                eventsForm.ShowDialog();
            }

            UpdateQuickOverview();

        }

        private void lnkViewAnnouncements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //OpenLocalEvents();
            using (LocalEventsForm eventsForm = new LocalEventsForm())
            {
                eventsForm.ShowDialog();
            }

            UpdateQuickOverview();
        }

        private void lnkViewMyIssues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (MyIssuesForm myIssuesForm = new MyIssuesForm())
            {
                myIssuesForm.ShowDialog();
            }

            UpdateQuickOverview();
        }
        private void UpdateQuickOverview()
        {
            // =====================================================
            // MY REPORTED ISSUES
            // =====================================================
            int issueCount = IssueManager.Issues.Count;

            lblMyIssuesCount.Text = issueCount.ToString();


            // =====================================================
            // UPCOMING EVENTS
            // =====================================================
            int eventCount = EventManager.GetAllUpcomingEvents().Count;

            lblUpcomingCount.Text = eventCount.ToString();


            // =====================================================
            // IMPORTANT ANNOUNCEMENTS
            // =====================================================
            int announcementCount = EventManager.Announcements.Count();

            lblAnnouncementsCount.Text = announcementCount.ToString();
        }

        private void pnlMyIssues_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMyIssues_Click(object sender, EventArgs e)
        {
            OpenMyIssues();
        }

        private void OpenMyIssues()
        {
            using (MyIssuesForm myIssuesForm = new MyIssuesForm())
            {
                myIssuesForm.ShowDialog();
            }

            UpdateQuickOverview();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            using (LocalEventsForm eventsForm = new LocalEventsForm())
            {
                eventsForm.ShowDialog();
            }
            UpdateQuickOverview();
        }
    }
}
