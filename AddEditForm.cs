using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class AddEditForm : Form
    {
        private int taskId;

        // Constructor to optionally receive a taskId for editing
        public AddEditForm()
        {
            InitializeComponent();
        }

        public AddEditForm(int taskId, string taskName, string description, DateTime dueDate)
        {
            this.taskId = taskId;
            TaskName = taskName;
            Description = description;
            DueDate = dueDate;
        }

        public AddEditForm(int taskId, string taskName, string description, DateTime dueDate, string priority)
        {
            InitializeComponent();
            this.taskId = taskId;
            txtTitle.Text = taskName;
            txtDescription.Text = description;
            dtpDueDate.Value = dueDate;
            cmbPriority.SelectedItem = priority;
        }

        public string TaskName { get; }
        public string Description { get; }
        public DateTime DueDate { get; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string taskName = txtTitle.Text;
            string description = txtDescription.Text;
            DateTime dueDate = dtpDueDate.Value;
            string priority = cmbPriority.SelectedItem?.ToString();
            string status = txtstatus.Text;// Get priority

            // Validate that a priority has been selected
            if (string.IsNullOrEmpty(priority))
            {
                MessageBox.Show("Please select a priority for the task.");
                return;
            }

            string connectionString = "Server=MSI\\SQLEXPRESS02;Database=TaskmanagementDb;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (taskId == 0) // If taskId is 0, it's a new task (Add)
                {
                    string query = "INSERT INTO Tasks (title, Description, DueDate, Priority,status) VALUES (@TaskName, @Description, @DueDate, @Priority,@status)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TaskName", taskName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@Priority", priority);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
                else // If taskId is not 0, it's an existing task (Edit)
                {
                    string query = "UPDATE Tasks SET title = @TaskName, Description = @Description, DueDate = @DueDate, Priority = @Priority WHERE TaskID = @TaskID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TaskName", taskName);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@Priority", priority);
                    cmd.Parameters.AddWithValue("@TaskID", taskId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Task saved successfully!");
            this.Close(); // Close the AddEditForm
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
