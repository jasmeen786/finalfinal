namespace TaskManagementApp
{
    partial class NotificationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstNotifications;

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
            this.lstNotifications = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // 
            // lstNotifications
            // 
            this.lstNotifications.FormattingEnabled = true;
            this.lstNotifications.Location = new System.Drawing.Point(12, 12);
            this.lstNotifications.Name = "lstNotifications";
            this.lstNotifications.Size = new System.Drawing.Size(260, 212);
            this.lstNotifications.TabIndex = 0;

            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lstNotifications);
            this.Name = "NotificationForm";
            this.Text = "Notifications";
            this.ResumeLayout(false);
        }
    }
}

       