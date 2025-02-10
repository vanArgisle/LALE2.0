
namespace LALE
{
    partial class WarpEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarpEditor));
            this.bDeleteWarp = new System.Windows.Forms.Button();
            this.bCreateWarp = new System.Windows.Forms.Button();
            this.nMap = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nDestY = new System.Windows.Forms.NumericUpDown();
            this.nDestX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nRegion = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nIndex = new System.Windows.Forms.NumericUpDown();
            this.bAccept = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDestY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDestX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // bDeleteWarp
            // 
            this.bDeleteWarp.Location = new System.Drawing.Point(110, 204);
            this.bDeleteWarp.Name = "bDeleteWarp";
            this.bDeleteWarp.Size = new System.Drawing.Size(76, 23);
            this.bDeleteWarp.TabIndex = 32;
            this.bDeleteWarp.Text = "Delete Warp";
            this.bDeleteWarp.UseVisualStyleBackColor = true;
            this.bDeleteWarp.Click += new System.EventHandler(this.bDeleteWarp_Click);
            // 
            // bCreateWarp
            // 
            this.bCreateWarp.Location = new System.Drawing.Point(15, 204);
            this.bCreateWarp.Name = "bCreateWarp";
            this.bCreateWarp.Size = new System.Drawing.Size(76, 23);
            this.bCreateWarp.TabIndex = 31;
            this.bCreateWarp.Text = "Create Warp";
            this.bCreateWarp.UseVisualStyleBackColor = true;
            this.bCreateWarp.Click += new System.EventHandler(this.bCreateWarp_Click);
            // 
            // nMap
            // 
            this.nMap.Enabled = false;
            this.helpProvider1.SetHelpString(this.nMap, "The map value to warp the player to.");
            this.nMap.Hexadecimal = true;
            this.nMap.Location = new System.Drawing.Point(87, 103);
            this.nMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nMap.Name = "nMap";
            this.helpProvider1.SetShowHelp(this.nMap, true);
            this.nMap.Size = new System.Drawing.Size(99, 20);
            this.nMap.TabIndex = 30;
            this.nMap.ValueChanged += new System.EventHandler(this.nMap_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label6, "The map value to warp the player to.");
            this.label6.Location = new System.Drawing.Point(12, 105);
            this.label6.Name = "label6";
            this.helpProvider1.SetShowHelp(this.label6, true);
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Map:";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(15, 242);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(76, 23);
            this.bCancel.TabIndex = 28;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.comboBox1, resources.GetString("comboBox1.HelpString"));
            this.comboBox1.Items.AddRange(new object[] {
            "Overworld",
            "Dungeon",
            "Side-Scroller"});
            this.comboBox1.Location = new System.Drawing.Point(87, 39);
            this.comboBox1.Name = "comboBox1";
            this.helpProvider1.SetShowHelp(this.comboBox1, true);
            this.comboBox1.Size = new System.Drawing.Size(99, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label5, resources.GetString("label5.HelpString"));
            this.label5.Location = new System.Drawing.Point(12, 42);
            this.label5.Name = "label5";
            this.helpProvider1.SetShowHelp(this.label5, true);
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Type:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label4, "The coordinates the player will spawn at after using the warp.");
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Dest. Y Pos:";
            // 
            // nDestY
            // 
            this.nDestY.Enabled = false;
            this.helpProvider1.SetHelpString(this.nDestY, "The coordinates the player will spawn at after using the warp.");
            this.nDestY.Hexadecimal = true;
            this.nDestY.Location = new System.Drawing.Point(87, 167);
            this.nDestY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nDestY.Name = "nDestY";
            this.helpProvider1.SetShowHelp(this.nDestY, true);
            this.nDestY.Size = new System.Drawing.Size(99, 20);
            this.nDestY.TabIndex = 24;
            this.nDestY.ValueChanged += new System.EventHandler(this.nDestY_ValueChanged);
            // 
            // nDestX
            // 
            this.nDestX.Enabled = false;
            this.helpProvider1.SetHelpString(this.nDestX, "The coordinates the player will spawn at after using the warp.");
            this.nDestX.Hexadecimal = true;
            this.nDestX.Location = new System.Drawing.Point(87, 135);
            this.nDestX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nDestX.Name = "nDestX";
            this.helpProvider1.SetShowHelp(this.nDestX, true);
            this.nDestX.Size = new System.Drawing.Size(99, 20);
            this.nDestX.TabIndex = 23;
            this.nDestX.ValueChanged += new System.EventHandler(this.nDestX_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label3, "The coordinates the player will spawn at after using the warp.");
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Dest. X Pos:";
            // 
            // nRegion
            // 
            this.nRegion.Enabled = false;
            this.helpProvider1.SetHelpString(this.nRegion, "The region to change to when the player uses this warp.");
            this.nRegion.Hexadecimal = true;
            this.nRegion.Location = new System.Drawing.Point(87, 71);
            this.nRegion.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nRegion.Name = "nRegion";
            this.helpProvider1.SetShowHelp(this.nRegion, true);
            this.nRegion.Size = new System.Drawing.Size(99, 20);
            this.nRegion.TabIndex = 21;
            this.nRegion.ValueChanged += new System.EventHandler(this.nRegion_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label2, "The region to change to when the player uses this warp.");
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Region:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label1, resources.GetString("label1.HelpString"));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Warp Index:";
            // 
            // nIndex
            // 
            this.helpProvider1.SetHelpString(this.nIndex, resources.GetString("nIndex.HelpString"));
            this.nIndex.Location = new System.Drawing.Point(87, 7);
            this.nIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nIndex.Name = "nIndex";
            this.helpProvider1.SetShowHelp(this.nIndex, true);
            this.nIndex.Size = new System.Drawing.Size(99, 20);
            this.nIndex.TabIndex = 18;
            this.nIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nIndex.ValueChanged += new System.EventHandler(this.nIndex_ValueChanged);
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(110, 242);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(76, 23);
            this.bAccept.TabIndex = 17;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // WarpEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 276);
            this.Controls.Add(this.bDeleteWarp);
            this.Controls.Add(this.bCreateWarp);
            this.Controls.Add(this.nMap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nDestY);
            this.Controls.Add(this.nDestX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nIndex);
            this.Controls.Add(this.bAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarpEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warp Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDestY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDestX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bDeleteWarp;
        private System.Windows.Forms.Button bCreateWarp;
        private System.Windows.Forms.NumericUpDown nMap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nDestY;
        public System.Windows.Forms.NumericUpDown nDestX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nIndex;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}