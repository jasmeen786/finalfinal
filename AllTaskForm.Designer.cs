namespace TaskManagementApp
{
    partial class AllTaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btndlt;
        private System.Windows.Forms.Button btncalendar;
        private System.Windows.Forms.Button btnnotfications;
        private System.Windows.Forms.Button btnMarkAsCompleted;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btndlt = new System.Windows.Forms.Button();
            this.btncalendar = new System.Windows.Forms.Button();
            this.btnnotfications = new System.Windows.Forms.Button();
            this.btnMarkAsCompleted = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTasks
            // 
            this.dgvTasks.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(40, 112);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.Size = new System.Drawing.Size(748, 552);
            this.dgvTasks.TabIndex = 0;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(40, 12);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(96, 43);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.Location = new System.Drawing.Point(178, 12);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(96, 43);
            this.btnEditTask.TabIndex = 2;
            this.btnEditTask.Text = "Edit Task";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btndlt
            // 
            this.btndlt.Location = new System.Drawing.Point(308, 12);
            this.btndlt.Name = "btndlt";
            this.btndlt.Size = new System.Drawing.Size(96, 43);
            this.btndlt.TabIndex = 3;
            this.btndlt.Text = "Delete Task";
            this.btndlt.UseVisualStyleBackColor = true;
            this.btndlt.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btncalendar
            // 
            this.btncalendar.Location = new System.Drawing.Point(440, 12);
            this.btncalendar.Name = "btncalendar";
            this.btncalendar.Size = new System.Drawing.Size(96, 43);
            this.btncalendar.TabIndex = 4;
            this.btncalendar.Text = "Calendar";
            this.btncalendar.UseVisualStyleBackColor = true;
            this.btncalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnnotfications
            // 
            this.btnnotfications.Location = new System.Drawing.Point(572, 12);
            this.btnnotfications.Name = "btnnotfications";
            this.btnnotfications.Size = new System.Drawing.Size(96, 43);
            this.btnnotfications.TabIndex = 5;
            this.btnnotfications.Text = "Notifications";
            this.btnnotfications.UseVisualStyleBackColor = true;
            this.btnnotfications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnMarkAsCompleted
            // 
            this.btnMarkAsCompleted.Location = new System.Drawing.Point(704, 12);
            this.btnMarkAsCompleted.Name = "btnMarkAsCompleted";
            this.btnMarkAsCompleted.Size = new System.Drawing.Size(120, 43);
            this.btnMarkAsCompleted.TabIndex = 6;
            this.btnMarkAsCompleted.Text = "Mark Completed";
            this.btnMarkAsCompleted.UseVisualStyleBackColor = true;
            this.btnMarkAsCompleted.Click += new System.EventHandler(this.btnMarkAsCompleted_Click);
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(813, 619);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(75, 57);
            this.btnlogout.TabIndex = 7;
            this.btnlogout.Text = "LogOut";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // AllTaskForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.btnMarkAsCompleted);
            this.Controls.Add(this.btnnotfications);
            this.Controls.Add(this.btncalendar);
            this.Controls.Add(this.btndlt);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dgvTasks);
            this.Name = "AllTaskForm";
            this.Text = "All Tasks";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnlogout;
    }
}
