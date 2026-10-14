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
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
            UpdateDashboard();
        }

        private void UpdateDashboard()
        {
            // Total citizen-reported issues
            lblAdminIssuesCount.Text = IssueManager.Issues.Count.ToString();

            // Total upcoming events
            lblAdminEventsCount.Text = EventManager.GetAllUpcomingEvents().Count.ToString();
            // Total announcements
            lblAdminAnnouncementsCount.Text = EventManager.Announcements.Count().ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Are you sure you want to log out?", "Logout",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblOverview_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1lnkViewIssues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (AdminIssuesForm issuesForm = new AdminIssuesForm())
            {
                issuesForm.ShowDialog();
            }

            UpdateDashboard();
        }

        private void lnkManageEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ManageEventsForm manageEventsForm = new ManageEventsForm())
            {
                manageEventsForm.ShowDialog();
            }

            UpdateDashboard();
        }

        private void lnkManageAnnouncements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the administrator's announcement
            // management screen.
            using (ManageAnnouncementsForm manageAnnouncementsForm = new ManageAnnouncementsForm())
            {
                manageAnnouncementsForm.ShowDialog();
            }

            // Refresh the dashboard after the form closes.
            //
            // This is important because the administrator may
            // have added or deleted announcements.
            UpdateDashboard();
        }
    }
}
