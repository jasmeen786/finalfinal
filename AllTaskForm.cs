using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class AllTaskForm : Form
    {
        private AddEditForm addEditForm;
        private CalendarForm calendarForm;
        private Form1 form;

        public AllTaskForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        // Load tasks into the DataGridView
        private void LoadTasks()
        {
            string connectionString = "Server=MSI\\SQLEXPRESS02;Database=TaskmanagementDb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tasks"; // Adjust table name as needed
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTasks.DataSource = dt;
            }
        }

        // Add Task button click event
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            addEditForm = new AddEditForm(); // Create AddEditForm instance
            addEditForm.ShowDialog(); // Show the form modally
            LoadTasks(); // Reload tasks after adding a new task
        }

        // Edit Task button click event
        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);
                string taskName = dgvTasks.SelectedRows[0].Cells["Title"].Value.ToString();
                string description = dgvTasks.SelectedRows[0].Cells["Description"].Value.ToString();
                DateTime dueDate = Convert.ToDateTime(dgvTasks.SelectedRows[0].Cells["DueDate"].Value);

                addEditForm = new AddEditForm(taskId, taskName, description, dueDate); // Pass selected task data
                addEditForm.ShowDialog(); // Show the form modally
                LoadTasks(); // Reload tasks after editing
            }
            else
            {
                MessageBox.Show("Please select a task to edit.");
            }
        }

        // Delete Task button click event
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this task?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string connectionString = "Server=MSI\\SQLEXPRESS02;Database=TaskmanagementDb;Integrated Security=True;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Tasks WHERE TaskID = @TaskID";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@TaskID", taskId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadTasks(); // Reload tasks after deleting
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }

        // Calendar button click event
        private void btnCalendar_Click(object sender, EventArgs e)
        {
            calendarForm = new CalendarForm();
            calendarForm.ShowDialog();
        }

        // Mark As Completed button click event
        private void btnMarkAsCompleted_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);

                string connectionString = "Server=MSI\\SQLEXPRESS02;Database=TaskmanagementDb;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Status = 'Completed' WHERE TaskID = @TaskID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TaskID", taskId);
                    cmd.ExecuteNonQuery();
                }
                LoadTasks(); // Reload tasks after marking as completed
                MessageBox.Show("Task marked as completed.");
            }
            else
            {
                MessageBox.Show("Please select a task to mark as completed.");
            }
        }

        // Notifications button click event
        private void btnNotifications_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            List<TaskItem> allTasks = GetAllTasks();

            var todaysTasks = allTasks.Where(t => t.DueDate.Date == today).ToList();
            var tomorrowsTasks = allTasks.Where(t => t.DueDate.Date == tomorrow).ToList();

            string notificationMessage = "Today's Tasks:\n";
            foreach (var task in todaysTasks)
            {
                notificationMessage += $"{task.Title} - {task.Description}\n";
            }

            notificationMessage += "\nTomorrow's Tasks:\n";
            foreach (var task in tomorrowsTasks)
            {
                notificationMessage += $"{task.Title} - {task.Description}\n";
            }

            MessageBox.Show(notificationMessage, "Task Notifications");
        }

        // Fetch all tasks from the database
        private List<TaskItem> GetAllTasks()
        {
            List<TaskItem> taskList = new List<TaskItem>();
            string connectionString = "Server=MSI\\SQLEXPRESS02;Database=TaskmanagementDb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tasks";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    taskList.Add(new TaskItem
                    {
                        TaskId = Convert.ToInt32(reader["TaskID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        DueDate = Convert.ToDateTime(reader["DueDate"])
                    });
                }
            }
            return taskList;
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show($"Cell clicked at row {e.RowIndex} and column {e.ColumnIndex}");
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();  

        }
    }
}
