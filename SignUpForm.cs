using System;
using System.Windows.Forms;
using TaskManagementApp.Helpers;

namespace TaskManagementApp
{
    public partial class SignupForm : Form
    {
        private AllTaskForm taskForm;
        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                // Handle user registration logic here
                // For example, save user data to a database
                bool registrationSuccess = DatabaseHelper.SignUp(username, password);

                // Corrected condition using registrationSuccess
                if (registrationSuccess)
                {
                    MessageBox.Show("Signup Successful! You can now log in.");
                    this.Hide(); // Close the SignupForm after successful registration
                    taskForm= new AllTaskForm();
                    taskForm.ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("An error occurred while signing up.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while registering: " + ex.Message);
            }
        }
    }
}
