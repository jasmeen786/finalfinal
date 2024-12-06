using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskManagementApp
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            // Query tasks from the database due within the next 24 hours (mock data here)
            List<string> notifications = new List<string>
            {
                "Task 1 due in 2 hours.",
                "Task 2 due in 12 hours."
            };

            foreach (var notification in notifications)
            {
                lstNotifications.Items.Add(notification); // Add notifications to ListBox
            }
        }
    }
}
