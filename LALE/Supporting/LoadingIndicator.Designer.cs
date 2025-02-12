namespace LALE.Supporting
{
    partial class LoadingIndicator
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
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(35, 35);
            this.pBar.Maximum = 256;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(188, 23);
            this.pBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(94, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Loading Data";
            // 
            // LoadingIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 123);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingIndicator";
            this.ShowIcon = false;
            this.Text = "Loading Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLoadingIndicator_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label lblStatus;
    }
}