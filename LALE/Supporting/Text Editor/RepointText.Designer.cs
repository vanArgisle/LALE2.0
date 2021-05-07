
namespace LALE.Supporting.Text_Editor
{
    partial class RepointText
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
            this.label2 = new System.Windows.Forms.Label();
            this.nAddress = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nPointer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(119, 74);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(86, 23);
            this.bAccept.TabIndex = 11;
            this.bAccept.Text = "Repoint";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(15, 74);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(86, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Text Address:";
            // 
            // nAddress
            // 
            this.nAddress.Hexadecimal = true;
            this.nAddress.Location = new System.Drawing.Point(85, 43);
            this.nAddress.Maximum = new decimal(new int[] {
            1048575,
            0,
            0,
            0});
            this.nAddress.Name = "nAddress";
            this.nAddress.Size = new System.Drawing.Size(120, 20);
            this.nAddress.TabIndex = 8;
            this.nAddress.ValueChanged += new System.EventHandler(this.nAddress_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Text Pointer:";
            // 
            // nPointer
            // 
            this.nPointer.Hexadecimal = true;
            this.nPointer.Location = new System.Drawing.Point(85, 7);
            this.nPointer.Maximum = new decimal(new int[] {
            687,
            0,
            0,
            0});
            this.nPointer.Name = "nPointer";
            this.nPointer.Size = new System.Drawing.Size(120, 20);
            this.nPointer.TabIndex = 6;
            this.nPointer.ValueChanged += new System.EventHandler(this.nPointer_ValueChanged);
            // 
            // RepointText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 104);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nPointer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RepointText";
            this.Text = "Repoint Text Pointers";
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nPointer;
    }
}