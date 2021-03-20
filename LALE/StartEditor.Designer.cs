
namespace LALE
{
    partial class StartEditor
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
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cOverworld = new System.Windows.Forms.CheckBox();
            this.nLinkXPos = new System.Windows.Forms.NumericUpDown();
            this.nLinkYPos = new System.Windows.Forms.NumericUpDown();
            this.nDungeon = new System.Windows.Forms.NumericUpDown();
            this.nMap = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nLinkXPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLinkYPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDungeon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(232, 37);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 21;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(232, 75);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Link\'s Y Pos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Link\'s X Pos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Map:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Dungeon:";
            // 
            // cOverworld
            // 
            this.cOverworld.AutoSize = true;
            this.cOverworld.Location = new System.Drawing.Point(214, 8);
            this.cOverworld.Name = "cOverworld";
            this.cOverworld.Size = new System.Drawing.Size(114, 17);
            this.cOverworld.TabIndex = 15;
            this.cOverworld.Text = "Start on Overworld";
            this.cOverworld.UseVisualStyleBackColor = true;
            this.cOverworld.CheckedChanged += new System.EventHandler(this.cOverworld_CheckedChanged);
            // 
            // nLinkXPos
            // 
            this.nLinkXPos.Hexadecimal = true;
            this.nLinkXPos.Location = new System.Drawing.Point(86, 59);
            this.nLinkXPos.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.nLinkXPos.Name = "nLinkXPos";
            this.nLinkXPos.Size = new System.Drawing.Size(110, 20);
            this.nLinkXPos.TabIndex = 14;
            // 
            // nLinkYPos
            // 
            this.nLinkYPos.Hexadecimal = true;
            this.nLinkYPos.Location = new System.Drawing.Point(86, 85);
            this.nLinkYPos.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nLinkYPos.Name = "nLinkYPos";
            this.nLinkYPos.Size = new System.Drawing.Size(110, 20);
            this.nLinkYPos.TabIndex = 13;
            // 
            // nDungeon
            // 
            this.nDungeon.Hexadecimal = true;
            this.nDungeon.Location = new System.Drawing.Point(86, 7);
            this.nDungeon.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nDungeon.Name = "nDungeon";
            this.nDungeon.Size = new System.Drawing.Size(110, 20);
            this.nDungeon.TabIndex = 12;
            // 
            // nMap
            // 
            this.nMap.Hexadecimal = true;
            this.nMap.Location = new System.Drawing.Point(86, 33);
            this.nMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nMap.Name = "nMap";
            this.nMap.Size = new System.Drawing.Size(110, 20);
            this.nMap.TabIndex = 11;
            // 
            // StartEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 121);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cOverworld);
            this.Controls.Add(this.nLinkXPos);
            this.Controls.Add(this.nLinkYPos);
            this.Controls.Add(this.nDungeon);
            this.Controls.Add(this.nMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartEditor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Position Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nLinkXPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLinkYPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDungeon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cOverworld;
        private System.Windows.Forms.NumericUpDown nLinkXPos;
        private System.Windows.Forms.NumericUpDown nLinkYPos;
        private System.Windows.Forms.NumericUpDown nDungeon;
        private System.Windows.Forms.NumericUpDown nMap;
    }
}