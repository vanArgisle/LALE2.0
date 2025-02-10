
namespace LALE
{
    partial class ChestEditor
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
            this.nItem = new System.Windows.Forms.NumericUpDown();
            this.labelChestLocation = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.nItem)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(106, 47);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 9;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(15, 47);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label2, "The value of the item to be found within every chest on the current map.");
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item:";
            // 
            // nItem
            // 
            this.helpProvider1.SetHelpString(this.nItem, "The value of the item to be found within every chest on the current map.");
            this.nItem.Hexadecimal = true;
            this.nItem.Location = new System.Drawing.Point(61, 7);
            this.nItem.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nItem.Name = "nItem";
            this.helpProvider1.SetShowHelp(this.nItem, true);
            this.nItem.Size = new System.Drawing.Size(120, 20);
            this.nItem.TabIndex = 6;
            // 
            // labelChestLocation
            // 
            this.labelChestLocation.AutoSize = true;
            this.helpProvider1.SetHelpString(this.labelChestLocation, "The location of the current map\'s chest data within the ROM file.");
            this.labelChestLocation.Location = new System.Drawing.Point(12, 31);
            this.labelChestLocation.Name = "labelChestLocation";
            this.helpProvider1.SetShowHelp(this.labelChestLocation, true);
            this.labelChestLocation.Size = new System.Drawing.Size(122, 13);
            this.labelChestLocation.TabIndex = 10;
            this.labelChestLocation.Text = "Chest Address Location:";
            // 
            // ChestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 82);
            this.Controls.Add(this.labelChestLocation);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChestEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChestEditor";
            ((System.ComponentModel.ISupportInitialize)(this.nItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nItem;
        private System.Windows.Forms.Label labelChestLocation;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}