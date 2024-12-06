using System;
using System.Data;
using System.Windows.Forms;
using TaskManagementApp.Helpers;  // Assuming this is where DatabaseHelper is
using TaskManagementApp;   // Use the correct namespace for AddEditForm

namespace TaskManagementApp
{
    public partial class TaskListForm : Form
    {
        public TaskListForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            // Fetch all tasks from the database using DatabaseHelper
            DataTable taskTable = DatabaseHelper.GetAllTasks();

            // Bind the DataTable to a DataGridView or ListBox (in this case, DataGridView)
            dgvTaskList.DataSource = taskTable;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh the task list when clicking the refresh button
            LoadTasks();
        }

        private void dgvTaskList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           /* // Handle row double-click event to edit a task
            int taskId = Convert.ToInt32(dgvTaskList.Rows[e.RowIndex].Cells["TaskId"].Value);
            // Open an edit form with the selected task details
            AddEditForm addEditForm = new AddEditForm(taskId); // Use AddEditForm instead of EditTaskForm
            addEditForm.ShowDialog();*/
        }
    }
}
