namespace LALE
{
    partial class RepointerTool
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
            this.bAccept = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.labelAddress = new System.Windows.Forms.Label();
            this.nAddress = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(110, 34);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 12;
            this.bAccept.Text = "Repoint";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(27, 34);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(24, 9);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 10;
            this.labelAddress.Text = "Address:";
            // 
            // nAddress
            // 
            this.nAddress.Hexadecimal = true;
            this.nAddress.Location = new System.Drawing.Point(81, 7);
            this.nAddress.Maximum = new decimal(new int[] {
            1048575,
            0,
            0,
            0});
            this.nAddress.Name = "nAddress";
            this.nAddress.Size = new System.Drawing.Size(107, 20);
            this.nAddress.TabIndex = 9;
            // 
            // RepointerTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 64);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.nAddress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepointerTool";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repoint Address";
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label labelAddress;
        public System.Windows.Forms.NumericUpDown nAddress;
    }
}