
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
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(131, 107);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(97, 23);
            this.bAccept.TabIndex = 11;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(15, 107);
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
            this.helpProvider1.SetHelpString(this.labelTextPointer, "The value that the selected map uses for any signs on the map. This value can be " +
        "taken into the text editor and used to find the text associated with it.");
            this.labelTextPointer.Location = new System.Drawing.Point(12, 14);
            this.labelTextPointer.Name = "labelTextPointer";
            this.helpProvider1.SetShowHelp(this.labelTextPointer, true);
            this.labelTextPointer.Size = new System.Drawing.Size(67, 13);
            this.labelTextPointer.TabIndex = 9;
            this.labelTextPointer.Text = "Text Pointer:";
            // 
            // nPointer
            // 
            this.helpProvider1.SetHelpString(this.nPointer, "The value that the selected map uses for any signs on the map. This value can be " +
        "taken into the text editor and used to find the text associated with it.");
            this.nPointer.Hexadecimal = true;
            this.nPointer.Location = new System.Drawing.Point(108, 12);
            this.nPointer.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nPointer.Name = "nPointer";
            this.helpProvider1.SetShowHelp(this.nPointer, true);
            this.nPointer.Size = new System.Drawing.Size(120, 20);
            this.nPointer.TabIndex = 8;
            this.nPointer.ValueChanged += new System.EventHandler(this.nPointer_ValueChanged);
            // 
            // labelTextPointerAddress
            // 
            this.labelTextPointerAddress.AutoSize = true;
            this.helpProvider1.SetHelpString(this.labelTextPointerAddress, "This is the location within the ROM file that the pointer is stored at. Do not co" +
        "nfuse this as a pointer to the sign text itself.");
            this.labelTextPointerAddress.Location = new System.Drawing.Point(12, 82);
            this.labelTextPointerAddress.Name = "labelTextPointerAddress";
            this.helpProvider1.SetShowHelp(this.labelTextPointerAddress, true);
            this.labelTextPointerAddress.Size = new System.Drawing.Size(108, 13);
            this.labelTextPointerAddress.TabIndex = 12;
            this.labelTextPointerAddress.Text = "Sign Pointer Address:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Open Pointer in Text Editor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SignEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 143);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTextPointerAddress);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.labelTextPointer);
            this.Controls.Add(this.nPointer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button1;
    }
}