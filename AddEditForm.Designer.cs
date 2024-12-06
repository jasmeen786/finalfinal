using System;

namespace TaskManagementApp
{
    partial class AddEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbPriority;

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(260, 22);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Task Title";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 38);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(260, 80);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Text = "Description";
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(12, 124);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(260, 22);
            this.dtpDueDate.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Task";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(12, 160);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(260, 24);
            this.cmbPriority.TabIndex = 4;
            // 
            // txtstatus
            // 
            this.txtstatus.Location = new System.Drawing.Point(12, 189);
            this.txtstatus.Multiline = true;
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(260, 23);
            this.txtstatus.TabIndex = 5;
            this.txtstatus.Text = "status";
            // 
            // AddEditForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 270);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Name = "AddEditForm";
            this.Text = "Add/Edit Task";
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            // Your logic for the form load event
        }

        private System.Windows.Forms.TextBox txtstatus;
    }
}
