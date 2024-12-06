using finalfinal;
using System;
using System.Drawing;
using System.Windows.Forms;
using TaskManagementApp.Helpers; // Ensure DatabaseHelper is referenced

namespace TaskManagementApp
{
    public partial class Form1 : Form
    {
        private SignupForm form;
        public Form1()
        {
            InitializeComponent();
            SetBackgroundImage();
        }
        private void SetBackgroundImage()
        {
            // Set the background image of the form
            this.BackgroundImage = Image.FromFile("download.jpg");

            // Optionally, you can set the background image layout
            this.BackgroundImageLayout = ImageLayout.Stretch; // or ImageLayout.Center, ImageLayout.Zoom, etc.
        }

        // Login button click handler
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                // Authenticate user using DatabaseHelper
                bool isAuthenticated = DatabaseHelper.AuthenticateUser(username, password);
                if (isAuthenticated)
                {
                    MessageBox.Show("Login Successful! You can now access your tasks across devices.");

                    // Open AllTaskForm after successful login
                    AllTaskForm allTaskForm = new AllTaskForm();
                    allTaskForm.ShowDialog(); // Opens AllTaskForm as a modal form

                    ;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while authenticating: " + ex.Message);
            }
        }

        // Optional: Form closing event to handle any cleanup, like database connection closure
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close or cleanup resources if necessary
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
 SignupForm form = new SignupForm();
            form.ShowDialog();  
        }
    }
}
