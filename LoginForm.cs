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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          
        
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Validate empty fields
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(  "Please enter your email address and password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Authenticate user
            User user = UserManager.AuthenticateUser(email, password);

            if (user == null)
            {
                MessageBox.Show( "Incorrect email address or password.", "Login Failed",  MessageBoxButtons.OK,  MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();

                return;
            }

            MessageBox.Show( $"Welcome, {user.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Hide the Login form
            this.Hide();

            // Check user role
            if (user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Admin goes to Admin Dashboard
                using (AdminDashboardForm adminDashboard = new AdminDashboardForm())
                {
                    adminDashboard.ShowDialog();
                }
            }
            else
            {
                // Citizen goes to Main Form
                using (MainForm mainForm = new MainForm())
                {
                    mainForm.ShowDialog();
                }
            }

            // Show Login again after logout/form closes
            this.Show();

            // Clear login fields
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }
        

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
