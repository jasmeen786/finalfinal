namespace TaskManagementApp
{
    partial class CalendarForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.ListBox lstTasksForDay;

        private void InitializeComponent()
        {
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.lstTasksForDay = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // lstTasksForDay
            // 
            this.lstTasksForDay.FormattingEnabled = true;
            this.lstTasksForDay.ItemHeight = 16;
            this.lstTasksForDay.Location = new System.Drawing.Point(286, 66);
            this.lstTasksForDay.Name = "lstTasksForDay";
            this.lstTasksForDay.Size = new System.Drawing.Size(300, 100);
            this.lstTasksForDay.TabIndex = 1;
            // 
            // CalendarForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 451);
            this.Controls.Add(this.lstTasksForDay);
            this.Controls.Add(this.monthCalendar);
            this.Name = "CalendarForm";
            this.Text = "Task Calendar";
            this.ResumeLayout(false);

        }
    }
}
