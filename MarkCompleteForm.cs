using System;
using System.Data;
using System.Windows.Forms;
using TaskManagementApp.Helpers;  // Ensure to include your DatabaseHelper namespace

namespace TaskManagementApp
{
    public partial class MarkCompleteForm : Form
    {
        public MarkCompleteForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            DataTable dt = DatabaseHelper.GetAllTasks(); // Call the method to fetch all tasks
            dgvTasks.DataSource = dt;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTasks.Rows)
            {
                if (row.Cells["Is Complete"].Value != DBNull.Value)
                {
                    bool isComplete = Convert.ToBoolean(row.Cells["Is Complete"].Value);
                    int taskId = Convert.ToInt32(row.Cells["TaskId"].Value); // Ensure TaskId column exists
                    DatabaseHelper.UpdateTaskStatus(taskId, isComplete); // Update task status
                }
            }
            MessageBox.Show("Task completion status updated.");
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle any required cell click events here
        }
    }
}



