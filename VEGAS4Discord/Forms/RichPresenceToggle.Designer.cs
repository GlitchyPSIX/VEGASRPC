namespace VegasDiscordRPC.Forms
{
    partial class RichPresenceToggle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRPCStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRPCStatus
            // 
            this.lbRPCStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPCStatus.Location = new System.Drawing.Point(12, 9);
            this.lbRPCStatus.Name = "lbRPCStatus";
            this.lbRPCStatus.Size = new System.Drawing.Size(314, 84);
            this.lbRPCStatus.TabIndex = 0;
            this.lbRPCStatus.Text = "Discord Rich Presence is now <null>.";
            this.lbRPCStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RichPresenceToggle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 102);
            this.ControlBox = false;
            this.Controls.Add(this.lbRPCStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RichPresenceToggle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RichPresenceToggle";
            this.Load += new System.EventHandler(this.RichPresenceToggle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbRPCStatus;
    }
}