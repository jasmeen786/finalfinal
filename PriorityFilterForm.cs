using System;
using System.Data;
using System.Windows.Forms;
using TaskManagementApp.Helpers;

namespace TaskManagementApp
{
    public partial class PriorityFilterForm : Form
    {
        public PriorityFilterForm()
        {
            InitializeComponent();
        }

        private void cmbPriorityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPriority = cmbPriorityFilter.SelectedItem.ToString();
            FilterTasksByPriority(selectedPriority);
        }

        private void FilterTasksByPriority(string priority)
        {
            lstFilteredTasks.Items.Clear();  // Clear existing items in ListBox

            try
            {
                // Fetch tasks from the database based on the selected priority
                DataTable filteredTasks = DatabaseHelper.GetTasksByPriority(priority);

                // Check if the DataTable is not empty
                if (filteredTasks.Rows.Count > 0)
                {
                    foreach (DataRow row in filteredTasks.Rows)
                    {
                        string taskTitle = row["Title"].ToString();
                        string taskDescription = row["Description"].ToString();
                        string taskDueDate = DateTime.Parse(row["DueDate"].ToString()).ToString("MM/dd/yyyy");
                        string taskPriority = row["Priority"].ToString();

                        // Format the task details and add it to the ListBox
                        lstFilteredTasks.Items.Add($"Task: {taskTitle} - Priority: {taskPriority} - Due: {taskDueDate} - Description: {taskDescription}");
                    }
                }
                else
                {
                    lstFilteredTasks.Items.Add("No tasks found for this priority.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching tasks: " + ex.Message);
            }
        }
    }
}
