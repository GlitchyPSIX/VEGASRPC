namespace VegasDiscordRPC.Forms
{
    partial class ConfigForm
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
            this.gbOtherSetts = new System.Windows.Forms.GroupBox();
            this.cbIdling = new System.Windows.Forms.CheckBox();
            this.nudIdleSeconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDetailStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llbGLITCHYPSI = new System.Windows.Forms.LinkLabel();
            this.cbStartupTimer = new System.Windows.Forms.CheckBox();
            this.llbGithub = new System.Windows.Forms.LinkLabel();
            this.gbOtherSetts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdleSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOtherSetts
            // 
            this.gbOtherSetts.Controls.Add(this.cbStartupTimer);
            this.gbOtherSetts.Controls.Add(this.label2);
            this.gbOtherSetts.Controls.Add(this.cbDetailStyle);
            this.gbOtherSetts.Controls.Add(this.label1);
            this.gbOtherSetts.Controls.Add(this.nudIdleSeconds);
            this.gbOtherSetts.Controls.Add(this.cbIdling);
            this.gbOtherSetts.Location = new System.Drawing.Point(12, 12);
            this.gbOtherSetts.Name = "gbOtherSetts";
            this.gbOtherSetts.Size = new System.Drawing.Size(376, 175);
            this.gbOtherSetts.TabIndex = 1;
            this.gbOtherSetts.TabStop = false;
            this.gbOtherSetts.Text = "Other settings";
            // 
            // cbIdling
            // 
            this.cbIdling.AutoSize = true;
            this.cbIdling.Location = new System.Drawing.Point(15, 30);
            this.cbIdling.Name = "cbIdling";
            this.cbIdling.Size = new System.Drawing.Size(110, 17);
            this.cbIdling.TabIndex = 0;
            this.cbIdling.Text = "Enable Idle status";
            this.cbIdling.UseVisualStyleBackColor = true;
            this.cbIdling.CheckedChanged += new System.EventHandler(this.cbIdling_CheckedChanged);
            // 
            // nudIdleSeconds
            // 
            this.nudIdleSeconds.Location = new System.Drawing.Point(15, 86);
            this.nudIdleSeconds.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudIdleSeconds.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudIdleSeconds.Name = "nudIdleSeconds";
            this.nudIdleSeconds.Size = new System.Drawing.Size(72, 20);
            this.nudIdleSeconds.TabIndex = 1;
            this.nudIdleSeconds.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set Idle after seconds:";
            // 
            // cbDetailStyle
            // 
            this.cbDetailStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDetailStyle.FormattingEnabled = true;
            this.cbDetailStyle.Location = new System.Drawing.Point(15, 140);
            this.cbDetailStyle.Name = "cbDetailStyle";
            this.cbDetailStyle.Size = new System.Drawing.Size(142, 21);
            this.cbDetailStyle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detail Display";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // llbGLITCHYPSI
            // 
            this.llbGLITCHYPSI.AutoSize = true;
            this.llbGLITCHYPSI.Location = new System.Drawing.Point(14, 196);
            this.llbGLITCHYPSI.Name = "llbGLITCHYPSI";
            this.llbGLITCHYPSI.Size = new System.Drawing.Size(113, 13);
            this.llbGLITCHYPSI.TabIndex = 5;
            this.llbGLITCHYPSI.TabStop = true;
            this.llbGLITCHYPSI.Text = "made by GLITCHYPSI";
            this.llbGLITCHYPSI.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbStartupTimer
            // 
            this.cbStartupTimer.Location = new System.Drawing.Point(169, 18);
            this.cbStartupTimer.Name = "cbStartupTimer";
            this.cbStartupTimer.Size = new System.Drawing.Size(192, 40);
            this.cbStartupTimer.TabIndex = 5;
            this.cbStartupTimer.Text = "Show Time Since Project Opened instead of Elapsed Render Time";
            this.cbStartupTimer.UseVisualStyleBackColor = true;
            // 
            // llbGithub
            // 
            this.llbGithub.AutoSize = true;
            this.llbGithub.Location = new System.Drawing.Point(14, 216);
            this.llbGithub.Name = "llbGithub";
            this.llbGithub.Size = new System.Drawing.Size(140, 13);
            this.llbGithub.TabIndex = 6;
            this.llbGithub.TabStop = true;
            this.llbGithub.Text = "Vegas4Discord Github page";
            this.llbGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbGithub_LinkClicked);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 254);
            this.ControlBox = false;
            this.Controls.Add(this.llbGithub);
            this.Controls.Add(this.llbGLITCHYPSI);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOtherSetts);
            this.Name = "ConfigForm";
            this.Text = "Vegas4Discord Config";
            this.gbOtherSetts.ResumeLayout(false);
            this.gbOtherSetts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdleSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbOtherSetts;
        private System.Windows.Forms.NumericUpDown nudIdleSeconds;
        private System.Windows.Forms.CheckBox cbIdling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDetailStyle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llbGLITCHYPSI;
        private System.Windows.Forms.CheckBox cbStartupTimer;
        private System.Windows.Forms.LinkLabel llbGithub;
    }
}