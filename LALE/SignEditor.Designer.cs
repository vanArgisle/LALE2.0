
namespace LALE
{
    partial class SignEditor
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
            this.labelTextPointer = new System.Windows.Forms.Label();
            this.nPointer = new System.Windows.Forms.NumericUpDown();
            this.labelTextPointerAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(131, 69);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(97, 23);
            this.bAccept.TabIndex = 11;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(15, 69);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(97, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // labelTextPointer
            // 
            this.labelTextPointer.AutoSize = true;
            this.labelTextPointer.Location = new System.Drawing.Point(12, 14);
            this.labelTextPointer.Name = "labelTextPointer";
            this.labelTextPointer.Size = new System.Drawing.Size(67, 13);
            this.labelTextPointer.TabIndex = 9;
            this.labelTextPointer.Text = "Text Pointer:";
            // 
            // nPointer
            // 
            this.nPointer.Hexadecimal = true;
            this.nPointer.Location = new System.Drawing.Point(108, 12);
            this.nPointer.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nPointer.Name = "nPointer";
            this.nPointer.Size = new System.Drawing.Size(120, 20);
            this.nPointer.TabIndex = 8;
            this.nPointer.ValueChanged += new System.EventHandler(this.nPointer_ValueChanged);
            // 
            // labelTextPointerAddress
            // 
            this.labelTextPointerAddress.AutoSize = true;
            this.labelTextPointerAddress.Location = new System.Drawing.Point(12, 44);
            this.labelTextPointerAddress.Name = "labelTextPointerAddress";
            this.labelTextPointerAddress.Size = new System.Drawing.Size(108, 13);
            this.labelTextPointerAddress.TabIndex = 12;
            this.labelTextPointerAddress.Text = "Text Pointer Address:";
            // 
            // SignEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 104);
            this.Controls.Add(this.labelTextPointerAddress);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.labelTextPointer);
            this.Controls.Add(this.nPointer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SignEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label labelTextPointer;
        private System.Windows.Forms.NumericUpDown nPointer;
        private System.Windows.Forms.Label labelTextPointerAddress;
    }
}