
namespace LALE
{
    partial class OwlStatueEditor
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
            this.label4 = new System.Windows.Forms.Label();
            this.lMaps = new System.Windows.Forms.ListBox();
            this.nPointer = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nMap = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.cDungeon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(123, 232);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(87, 23);
            this.bAccept.TabIndex = 20;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label4, "This is a list of the selected dungeon\'s owl statues. Each dungeon has 3 owl stat" +
        "ues except for the colour dungeon which has only 1.");
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Owl Statues:";
            // 
            // lMaps
            // 
            this.lMaps.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.lMaps, "This is a list of the selected dungeon\'s owl statues. Each dungeon has 3 owl stat" +
        "ues except for the colour dungeon which has only 1.");
            this.lMaps.Location = new System.Drawing.Point(81, 43);
            this.lMaps.Name = "lMaps";
            this.helpProvider1.SetShowHelp(this.lMaps, true);
            this.lMaps.Size = new System.Drawing.Size(129, 56);
            this.lMaps.TabIndex = 18;
            this.lMaps.SelectedIndexChanged += new System.EventHandler(this.lMaps_SelectedIndexChanged);
            // 
            // nPointer
            // 
            this.nPointer.Enabled = false;
            this.helpProvider1.SetHelpString(this.nPointer, "The text pointer that the selected owl statue will use for its message. This valu" +
        "e can be put into the text editor.");
            this.nPointer.Hexadecimal = true;
            this.nPointer.Location = new System.Drawing.Point(81, 150);
            this.nPointer.Maximum = new decimal(new int[] {
            175,
            0,
            0,
            0});
            this.nPointer.Name = "nPointer";
            this.helpProvider1.SetShowHelp(this.nPointer, true);
            this.nPointer.Size = new System.Drawing.Size(129, 20);
            this.nPointer.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label3, "The text pointer that the selected owl statue will use for its message. This valu" +
        "e can be put into the text editor.");
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pointer: 0x02";
            // 
            // nMap
            // 
            this.nMap.Enabled = false;
            this.helpProvider1.SetHelpString(this.nMap, "The map that the selected owl statue will be located.");
            this.nMap.Hexadecimal = true;
            this.nMap.Location = new System.Drawing.Point(81, 112);
            this.nMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nMap.Name = "nMap";
            this.helpProvider1.SetShowHelp(this.nMap, true);
            this.nMap.Size = new System.Drawing.Size(129, 20);
            this.nMap.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label2, "The map that the selected owl statue will be located.");
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Map:";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(15, 232);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(87, 23);
            this.bCancel.TabIndex = 13;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cDungeon
            // 
            this.cDungeon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.helpProvider1.SetHelpString(this.cDungeon, "The dungeon to edit the owl statues of.");
            this.cDungeon.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5",
            "Level 6",
            "Level 7",
            "Level 8",
            "Colour Dungeon"});
            this.cDungeon.Location = new System.Drawing.Point(81, 16);
            this.cDungeon.Name = "cDungeon";
            this.helpProvider1.SetShowHelp(this.cDungeon, true);
            this.cDungeon.Size = new System.Drawing.Size(129, 21);
            this.cDungeon.TabIndex = 12;
            this.cDungeon.SelectedIndexChanged += new System.EventHandler(this.cDungeon_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label1, "The dungeon to edit the owl statues of.");
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Dungeon:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Open Pointer in Text Editor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OwlStatueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 267);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lMaps);
            this.Controls.Add(this.nPointer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nMap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.cDungeon);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OwlStatueEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owl Statue Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nPointer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lMaps;
        private System.Windows.Forms.NumericUpDown nPointer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox cDungeon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button1;
    }
}