
namespace LALE
{
    partial class PaletteEditor
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
            this.labelIndex = new System.Windows.Forms.Label();
            this.nIndex = new System.Windows.Forms.NumericUpDown();
            this.labelRGB = new System.Windows.Forms.Label();
            this.labelPaletteLocation = new System.Windows.Forms.Label();
            this.labelDungeon = new System.Windows.Forms.Label();
            this.nDungeon = new System.Windows.Forms.NumericUpDown();
            this.nMap = new System.Windows.Forms.NumericUpDown();
            this.labelMap = new System.Windows.Forms.Label();
            this.pPalette = new LALE.GridBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bAccept = new System.Windows.Forms.Button();
            this.pTileset = new LALE.GridBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDungeon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTileset)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.helpProvider1.SetHelpString(this.labelIndex, "The palette index that you want to edit.");
            this.labelIndex.Location = new System.Drawing.Point(146, 14);
            this.labelIndex.Name = "labelIndex";
            this.helpProvider1.SetShowHelp(this.labelIndex, true);
            this.labelIndex.Size = new System.Drawing.Size(36, 13);
            this.labelIndex.TabIndex = 42;
            this.labelIndex.Text = "Index:";
            // 
            // nIndex
            // 
            this.helpProvider1.SetHelpString(this.nIndex, "The palette index that you want to edit.");
            this.nIndex.Hexadecimal = true;
            this.nIndex.Location = new System.Drawing.Point(206, 12);
            this.nIndex.Name = "nIndex";
            this.helpProvider1.SetShowHelp(this.nIndex, true);
            this.nIndex.Size = new System.Drawing.Size(66, 20);
            this.nIndex.TabIndex = 41;
            this.nIndex.ValueChanged += new System.EventHandler(this.nIndex_ValueChanged);
            // 
            // labelRGB
            // 
            this.labelRGB.AutoSize = true;
            this.labelRGB.Location = new System.Drawing.Point(155, 410);
            this.labelRGB.Name = "labelRGB";
            this.labelRGB.Size = new System.Drawing.Size(45, 13);
            this.labelRGB.TabIndex = 40;
            this.labelRGB.Text = "R: G: B:";
            // 
            // labelPaletteLocation
            // 
            this.labelPaletteLocation.AutoSize = true;
            this.labelPaletteLocation.Location = new System.Drawing.Point(9, 410);
            this.labelPaletteLocation.Name = "labelPaletteLocation";
            this.labelPaletteLocation.Size = new System.Drawing.Size(87, 13);
            this.labelPaletteLocation.TabIndex = 39;
            this.labelPaletteLocation.Text = "Palette Location:";
            // 
            // labelDungeon
            // 
            this.labelDungeon.AutoSize = true;
            this.helpProvider1.SetHelpString(this.labelDungeon, "This will load the selected dungeon\'s palette into the editor.");
            this.labelDungeon.Location = new System.Drawing.Point(146, 62);
            this.labelDungeon.Name = "labelDungeon";
            this.helpProvider1.SetShowHelp(this.labelDungeon, true);
            this.labelDungeon.Size = new System.Drawing.Size(54, 13);
            this.labelDungeon.TabIndex = 38;
            this.labelDungeon.Text = "Dungeon:";
            // 
            // nDungeon
            // 
            this.helpProvider1.SetHelpString(this.nDungeon, "This will load the selected dungeon\'s palette into the editor.");
            this.nDungeon.Hexadecimal = true;
            this.nDungeon.Location = new System.Drawing.Point(206, 60);
            this.nDungeon.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nDungeon.Name = "nDungeon";
            this.helpProvider1.SetShowHelp(this.nDungeon, true);
            this.nDungeon.Size = new System.Drawing.Size(66, 20);
            this.nDungeon.TabIndex = 37;
            this.nDungeon.ValueChanged += new System.EventHandler(this.nDungeon_ValueChanged);
            // 
            // nMap
            // 
            this.helpProvider1.SetHelpString(this.nMap, "This will load the selected map\'s palette into the editor.");
            this.nMap.Hexadecimal = true;
            this.nMap.Location = new System.Drawing.Point(206, 36);
            this.nMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nMap.Name = "nMap";
            this.helpProvider1.SetShowHelp(this.nMap, true);
            this.nMap.Size = new System.Drawing.Size(66, 20);
            this.nMap.TabIndex = 36;
            this.nMap.ValueChanged += new System.EventHandler(this.nMap_ValueChanged);
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.helpProvider1.SetHelpString(this.labelMap, "This will load the selected map\'s palette into the editor.");
            this.labelMap.Location = new System.Drawing.Point(146, 38);
            this.labelMap.Name = "labelMap";
            this.helpProvider1.SetShowHelp(this.labelMap, true);
            this.labelMap.Size = new System.Drawing.Size(31, 13);
            this.labelMap.TabIndex = 35;
            this.labelMap.Text = "Map:";
            // 
            // pPalette
            // 
            this.pPalette.AllowMultiSelection = false;
            this.pPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPalette.BoxSize = new System.Drawing.Size(32, 16);
            this.pPalette.CanvasSize = new System.Drawing.Size(128, 128);
            this.helpProvider1.SetHelpString(this.pPalette, "The palette currently being edited.");
            this.pPalette.HoverBox = true;
            this.pPalette.HoverColor = System.Drawing.Color.White;
            this.pPalette.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pPalette.Location = new System.Drawing.Point(12, 12);
            this.pPalette.Name = "pPalette";
            this.pPalette.Selectable = false;
            this.pPalette.SelectedIndex = 0;
            this.pPalette.SelectionColor = System.Drawing.Color.Red;
            this.pPalette.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.helpProvider1.SetShowHelp(this.pPalette, true);
            this.pPalette.Size = new System.Drawing.Size(128, 129);
            this.pPalette.TabIndex = 34;
            this.pPalette.TabStop = false;
            this.pPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pPalette_MouseDown);
            this.pPalette.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPalette_MouseMove);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(149, 118);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(123, 23);
            this.bCancel.TabIndex = 33;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(149, 89);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(123, 23);
            this.bAccept.TabIndex = 32;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // pTileset
            // 
            this.pTileset.AllowMultiSelection = false;
            this.pTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pTileset.BoxSize = new System.Drawing.Size(16, 16);
            this.pTileset.CanvasSize = new System.Drawing.Size(256, 256);
            this.helpProvider1.SetHelpString(this.pTileset, "A tileset to preview how the change in palettes affects the tileset.");
            this.pTileset.HoverBox = true;
            this.pTileset.HoverColor = System.Drawing.Color.White;
            this.pTileset.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pTileset.Location = new System.Drawing.Point(12, 147);
            this.pTileset.Name = "pTileset";
            this.pTileset.Selectable = false;
            this.pTileset.SelectedIndex = 0;
            this.pTileset.SelectionColor = System.Drawing.Color.Red;
            this.pTileset.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.helpProvider1.SetShowHelp(this.pTileset, true);
            this.pTileset.Size = new System.Drawing.Size(260, 260);
            this.pTileset.TabIndex = 31;
            this.pTileset.TabStop = false;
            // 
            // PaletteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 436);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.nIndex);
            this.Controls.Add(this.labelRGB);
            this.Controls.Add(this.labelPaletteLocation);
            this.Controls.Add(this.labelDungeon);
            this.Controls.Add(this.nDungeon);
            this.Controls.Add(this.nMap);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.pPalette);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.pTileset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDungeon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTileset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIndex;
        public System.Windows.Forms.NumericUpDown nIndex;
        private System.Windows.Forms.Label labelRGB;
        private System.Windows.Forms.Label labelPaletteLocation;
        private System.Windows.Forms.Label labelDungeon;
        public System.Windows.Forms.NumericUpDown nDungeon;
        public System.Windows.Forms.NumericUpDown nMap;
        private System.Windows.Forms.Label labelMap;
        private GridBox pPalette;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bAccept;
        private GridBox pTileset;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}