namespace TaskManagementApp
{
    partial class PriorityFilterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbPriorityFilter;
        private System.Windows.Forms.ListBox lstFilteredTasks;

        private void InitializeComponent()
        {
            this.cmbPriorityFilter = new System.Windows.Forms.ComboBox();
            this.lstFilteredTasks = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // 
            // cmbPriorityFilter
            // 
            this.cmbPriorityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriorityFilter.FormattingEnabled = true;
            this.cmbPriorityFilter.Items.AddRange(new object[] {
                "High",
                "Medium",
                "Low"});
            this.cmbPriorityFilter.Location = new System.Drawing.Point(12, 12);
            this.cmbPriorityFilter.Name = "cmbPriorityFilter";
            this.cmbPriorityFilter.Size = new System.Drawing.Size(150, 24);
            this.cmbPriorityFilter.TabIndex = 0;
            this.cmbPriorityFilter.SelectedIndexChanged += new System.EventHandler(this.cmbPriorityFilter_SelectedIndexChanged);

            // 
            // lstFilteredTasks
            // 
            this.lstFilteredTasks.FormattingEnabled = true;
            this.lstFilteredTasks.ItemHeight = 16;
            this.lstFilteredTasks.Location = new System.Drawing.Point(12, 42);
            this.lstFilteredTasks.Name = "lstFilteredTasks";
            this.lstFilteredTasks.Size = new System.Drawing.Size(300, 180);
            this.lstFilteredTasks.TabIndex = 1;

            // 
            // PriorityFilterForm
            // 
            this.ClientSize = new System.Drawing.Size(340, 250);
            this.Controls.Add(this.lstFilteredTasks);
            this.Controls.Add(this.cmbPriorityFilter);
            this.Name = "PriorityFilterForm";
            this.Text = "Filter Tasks by Priority";
            this.ResumeLayout(false);
        }
    }
}
