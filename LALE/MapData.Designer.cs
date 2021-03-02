namespace LALE
{
    partial class MapData
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMusic = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownSOG = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAnimations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownPresetTiles = new System.Windows.Forms.NumericUpDown();
            this.buttonClose = new System.Windows.Forms.Button();
            this.gridBoxTileset = new GridBox();
            this.gridBoxMap = new GridBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSOG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnimations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPresetTiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxTileset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Music:";
            // 
            // numericUpDownMusic
            // 
            this.numericUpDownMusic.Hexadecimal = true;
            this.numericUpDownMusic.Location = new System.Drawing.Point(123, 185);
            this.numericUpDownMusic.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownMusic.Name = "numericUpDownMusic";
            this.numericUpDownMusic.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownMusic.TabIndex = 1;
            this.numericUpDownMusic.ValueChanged += new System.EventHandler(this.numericUpDownMusic_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Preset Tiles:";
            // 
            // numericUpDownSOG
            // 
            this.numericUpDownSOG.Hexadecimal = true;
            this.numericUpDownSOG.Location = new System.Drawing.Point(139, 225);
            this.numericUpDownSOG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSOG.Name = "numericUpDownSOG";
            this.numericUpDownSOG.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSOG.TabIndex = 4;
            this.numericUpDownSOG.ValueChanged += new System.EventHandler(this.numericUpDownSOG_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Special Object Graphics";
            // 
            // numericUpDownAnimations
            // 
            this.numericUpDownAnimations.Hexadecimal = true;
            this.numericUpDownAnimations.Location = new System.Drawing.Point(139, 253);
            this.numericUpDownAnimations.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownAnimations.Name = "numericUpDownAnimations";
            this.numericUpDownAnimations.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAnimations.TabIndex = 6;
            this.numericUpDownAnimations.ValueChanged += new System.EventHandler(this.numericUpDownAnimations_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tile Animations:";
            // 
            // numericUpDownPresetTiles
            // 
            this.numericUpDownPresetTiles.Hexadecimal = true;
            this.numericUpDownPresetTiles.Location = new System.Drawing.Point(123, 155);
            this.numericUpDownPresetTiles.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownPresetTiles.Name = "numericUpDownPresetTiles";
            this.numericUpDownPresetTiles.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownPresetTiles.TabIndex = 9;
            this.numericUpDownPresetTiles.ValueChanged += new System.EventHandler(this.numericUpDownPresetTiles_ValueChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(200, 281);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(133, 23);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close Window";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // gridBoxTileset
            // 
            this.gridBoxTileset.AllowMultiSelection = false;
            this.gridBoxTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBoxTileset.BoxSize = new System.Drawing.Size(16, 16);
            this.gridBoxTileset.CanvasSize = new System.Drawing.Size(260, 260);
            this.gridBoxTileset.HoverBox = false;
            this.gridBoxTileset.HoverColor = System.Drawing.Color.White;
            this.gridBoxTileset.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.gridBoxTileset.Location = new System.Drawing.Point(266, 13);
            this.gridBoxTileset.Name = "gridBoxTileset";
            this.gridBoxTileset.Selectable = true;
            this.gridBoxTileset.SelectedIndex = 0;
            this.gridBoxTileset.SelectionColor = System.Drawing.Color.Red;
            this.gridBoxTileset.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.gridBoxTileset.Size = new System.Drawing.Size(260, 260);
            this.gridBoxTileset.TabIndex = 8;
            this.gridBoxTileset.TabStop = false;
            this.gridBoxTileset.Click += new System.EventHandler(this.gridBoxTileset_Click);
            // 
            // gridBoxMap
            // 
            this.gridBoxMap.AllowMultiSelection = false;
            this.gridBoxMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBoxMap.BoxSize = new System.Drawing.Size(12, 10);
            this.gridBoxMap.CanvasSize = new System.Drawing.Size(160, 128);
            this.gridBoxMap.HoverBox = false;
            this.gridBoxMap.HoverColor = System.Drawing.Color.White;
            this.gridBoxMap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.gridBoxMap.Location = new System.Drawing.Point(55, 11);
            this.gridBoxMap.Name = "gridBoxMap";
            this.gridBoxMap.Selectable = false;
            this.gridBoxMap.SelectedIndex = 0;
            this.gridBoxMap.SelectionColor = System.Drawing.Color.Red;
            this.gridBoxMap.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.gridBoxMap.Size = new System.Drawing.Size(164, 132);
            this.gridBoxMap.TabIndex = 7;
            this.gridBoxMap.TabStop = false;
            // 
            // MapData
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 316);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.numericUpDownPresetTiles);
            this.Controls.Add(this.gridBoxTileset);
            this.Controls.Add(this.gridBoxMap);
            this.Controls.Add(this.numericUpDownAnimations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownSOG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMusic);
            this.Controls.Add(this.label1);
            this.Name = "MapData";
            this.ShowIcon = false;
            this.Text = "Map Data";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSOG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnimations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPresetTiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxTileset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMusic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownSOG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAnimations;
        private System.Windows.Forms.Label label4;
        private GridBox gridBoxMap;
        private GridBox gridBoxTileset;
        private System.Windows.Forms.NumericUpDown numericUpDownPresetTiles;
        private System.Windows.Forms.Button buttonClose;
    }
}