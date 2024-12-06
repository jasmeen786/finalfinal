using System;
using System.Data; // For DataTable
using System.Windows.Forms;
using TaskManagementApp.Helpers; // Include namespace for DatabaseHelper

namespace TaskManagementApp
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Fetch tasks for the selected date and display them in the listbox
            DateTime selectedDate = monthCalendar.SelectionStart;
            DisplayTasksForSelectedDate(selectedDate);
        }

        private void DisplayTasksForSelectedDate(DateTime selectedDate)
        {
            // Call DatabaseHelper method to fetch tasks for the selected date
            var tasks = DatabaseHelper.GetTasksByDate(selectedDate);
            lstTasksForDay.Items.Clear();

            if (tasks != null && tasks.Rows.Count > 0)
            {
                foreach (DataRow row in tasks.Rows)
                {
                    string title = row["Title"].ToString();
                    string dueDate = Convert.ToDateTime(row["DueDate"]).ToShortDateString();
                    lstTasksForDay.Items.Add($"Task: {title} - Due: {dueDate}");
                }
            }
            else
            {
                lstTasksForDay.Items.Add("No tasks for this day.");
            }
        }
    }
}
