namespace TaskManagementApp
{
    partial class TaskListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTaskList;
        private System.Windows.Forms.Button btnRefresh;

        // Method to clean up any resources.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Method to initialize and set up form components.
        private void InitializeComponent()
        {
            this.dgvTaskList = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();

            // 
            // dgvTaskList
            // 
            this.dgvTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskList.Location = new System.Drawing.Point(12, 12);
            this.dgvTaskList.Name = "dgvTaskList";
            this.dgvTaskList.Size = new System.Drawing.Size(760, 400);
            this.dgvTaskList.TabIndex = 0;

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 420);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // TaskListForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvTaskList);
            this.Name = "TaskListForm";
            this.Text = "Task List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskList)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
