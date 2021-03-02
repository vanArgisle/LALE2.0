namespace LALE
{
    partial class RepointCollisions
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
            this.checkBoxCopyData = new System.Windows.Forms.CheckBox();
            this.bAccept = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.labelAddress = new System.Windows.Forms.Label();
            this.nAddress = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxCopyData
            // 
            this.checkBoxCopyData.AutoSize = true;
            this.checkBoxCopyData.Location = new System.Drawing.Point(27, 33);
            this.checkBoxCopyData.Name = "checkBoxCopyData";
            this.checkBoxCopyData.Size = new System.Drawing.Size(112, 17);
            this.checkBoxCopyData.TabIndex = 13;
            this.checkBoxCopyData.Text = "Copy existing data";
            this.checkBoxCopyData.UseVisualStyleBackColor = true;
            this.checkBoxCopyData.Visible = false;
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(110, 55);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 12;
            this.bAccept.Text = "Repoint";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(27, 55);
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
            // RepointCollisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 93);
            this.Controls.Add(this.checkBoxCopyData);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.nAddress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepointCollisions";
            this.ShowIcon = false;
            this.Text = "Repoint Collision Address";
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCopyData;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label labelAddress;
        public System.Windows.Forms.NumericUpDown nAddress;
    }
}