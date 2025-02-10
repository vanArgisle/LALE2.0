
namespace LALE
{
    partial class MinimapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinimapEditor));
            this.gBoxOverWorld = new System.Windows.Forms.GroupBox();
            this.labelPaletteLocation = new System.Windows.Forms.Label();
            this.bAccept1 = new System.Windows.Forms.Button();
            this.bCancel1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nPalette = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nTile = new System.Windows.Forms.NumericUpDown();
            this.pTile = new System.Windows.Forms.PictureBox();
            this.gBoxDungeon = new System.Windows.Forms.GroupBox();
            this.lblHoverPos = new System.Windows.Forms.Label();
            this.nDeathMinimap = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nDeathDungeon = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.nDeathMap = new System.Windows.Forms.NumericUpDown();
            this.bAccept = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nArrow = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nMap = new System.Windows.Forms.NumericUpDown();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.gridBoxOverworldTile = new LALE.GridBox();
            this.pMinimapO = new LALE.GridBox();
            this.pTiles = new LALE.GridBox();
            this.pMinimapD = new LALE.GridBox();
            this.gBoxOverWorld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTile)).BeginInit();
            this.gBoxDungeon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDeathMinimap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDeathDungeon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDeathMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxOverworldTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimapO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimapD)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxOverWorld
            // 
            this.gBoxOverWorld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gBoxOverWorld.Controls.Add(this.labelPaletteLocation);
            this.gBoxOverWorld.Controls.Add(this.gridBoxOverworldTile);
            this.gBoxOverWorld.Controls.Add(this.bAccept1);
            this.gBoxOverWorld.Controls.Add(this.bCancel1);
            this.gBoxOverWorld.Controls.Add(this.label3);
            this.gBoxOverWorld.Controls.Add(this.nPalette);
            this.gBoxOverWorld.Controls.Add(this.label2);
            this.gBoxOverWorld.Controls.Add(this.nTile);
            this.gBoxOverWorld.Controls.Add(this.pTile);
            this.gBoxOverWorld.Controls.Add(this.pMinimapO);
            this.gBoxOverWorld.Location = new System.Drawing.Point(12, 12);
            this.gBoxOverWorld.Name = "gBoxOverWorld";
            this.gBoxOverWorld.Size = new System.Drawing.Size(265, 224);
            this.gBoxOverWorld.TabIndex = 4;
            this.gBoxOverWorld.TabStop = false;
            // 
            // labelPaletteLocation
            // 
            this.labelPaletteLocation.AutoSize = true;
            this.labelPaletteLocation.Location = new System.Drawing.Point(141, 141);
            this.labelPaletteLocation.Name = "labelPaletteLocation";
            this.labelPaletteLocation.Size = new System.Drawing.Size(88, 13);
            this.labelPaletteLocation.TabIndex = 9;
            this.labelPaletteLocation.Text = "Palette: 0x8786E";
            // 
            // bAccept1
            // 
            this.bAccept1.Location = new System.Drawing.Point(144, 103);
            this.bAccept1.Name = "bAccept1";
            this.bAccept1.Size = new System.Drawing.Size(75, 23);
            this.bAccept1.TabIndex = 7;
            this.bAccept1.Text = "Accept";
            this.bAccept1.UseVisualStyleBackColor = true;
            this.bAccept1.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bCancel1
            // 
            this.bCancel1.Location = new System.Drawing.Point(144, 69);
            this.bCancel1.Name = "bCancel1";
            this.bCancel1.Size = new System.Drawing.Size(75, 23);
            this.bCancel1.TabIndex = 6;
            this.bCancel1.Text = "Cancel";
            this.bCancel1.UseVisualStyleBackColor = true;
            this.bCancel1.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label3, "Changing this value will change what palette the selected tile will use.");
            this.label3.Location = new System.Drawing.Point(141, 43);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Palette:";
            // 
            // nPalette
            // 
            this.helpProvider1.SetHelpString(this.nPalette, "Changing this value will change what palette the selected tile will use.");
            this.nPalette.Location = new System.Drawing.Point(191, 41);
            this.nPalette.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nPalette.Name = "nPalette";
            this.helpProvider1.SetShowHelp(this.nPalette, true);
            this.nPalette.Size = new System.Drawing.Size(68, 20);
            this.nPalette.TabIndex = 4;
            this.nPalette.ValueChanged += new System.EventHandler(this.nPalette_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label2, "The ID of the minimap tile that you have selected.");
            this.label2.Location = new System.Drawing.Point(141, 13);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tile:";
            // 
            // nTile
            // 
            this.helpProvider1.SetHelpString(this.nTile, "The ID of the minimap tile that you have selected.");
            this.nTile.Hexadecimal = true;
            this.nTile.Location = new System.Drawing.Point(191, 11);
            this.nTile.Maximum = new decimal(new int[] {
            117,
            0,
            0,
            0});
            this.nTile.Name = "nTile";
            this.helpProvider1.SetShowHelp(this.nTile, true);
            this.nTile.Size = new System.Drawing.Size(68, 20);
            this.nTile.TabIndex = 2;
            this.nTile.ValueChanged += new System.EventHandler(this.nTile_ValueChanged);
            // 
            // pTile
            // 
            this.pTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pTile.Location = new System.Drawing.Point(235, 91);
            this.pTile.Name = "pTile";
            this.pTile.Size = new System.Drawing.Size(12, 12);
            this.pTile.TabIndex = 1;
            this.pTile.TabStop = false;
            // 
            // gBoxDungeon
            // 
            this.gBoxDungeon.BackColor = System.Drawing.SystemColors.Control;
            this.gBoxDungeon.Controls.Add(this.lblHoverPos);
            this.gBoxDungeon.Controls.Add(this.nDeathMinimap);
            this.gBoxDungeon.Controls.Add(this.label7);
            this.gBoxDungeon.Controls.Add(this.nDeathDungeon);
            this.gBoxDungeon.Controls.Add(this.label6);
            this.gBoxDungeon.Controls.Add(this.bCancel);
            this.gBoxDungeon.Controls.Add(this.nDeathMap);
            this.gBoxDungeon.Controls.Add(this.bAccept);
            this.gBoxDungeon.Controls.Add(this.label4);
            this.gBoxDungeon.Controls.Add(this.nArrow);
            this.gBoxDungeon.Controls.Add(this.label5);
            this.gBoxDungeon.Controls.Add(this.label1);
            this.gBoxDungeon.Controls.Add(this.nMap);
            this.gBoxDungeon.Controls.Add(this.pTiles);
            this.gBoxDungeon.Controls.Add(this.pMinimapD);
            this.gBoxDungeon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gBoxDungeon.Location = new System.Drawing.Point(283, 12);
            this.gBoxDungeon.Name = "gBoxDungeon";
            this.gBoxDungeon.Size = new System.Drawing.Size(238, 224);
            this.gBoxDungeon.TabIndex = 3;
            this.gBoxDungeon.TabStop = false;
            // 
            // lblHoverPos
            // 
            this.lblHoverPos.AutoSize = true;
            this.lblHoverPos.Location = new System.Drawing.Point(6, 204);
            this.lblHoverPos.Name = "lblHoverPos";
            this.lblHoverPos.Size = new System.Drawing.Size(73, 13);
            this.lblHoverPos.TabIndex = 16;
            this.lblHoverPos.Text = "Minimap Byte:";
            // 
            // nDeathMinimap
            // 
            this.helpProvider1.SetHelpString(this.nDeathMinimap, "This value is the location of the entrance to the dungeon using the minimaps coor" +
        "dinates rather than the actual map value itself. The value used here is the Mini" +
        "map Byte found at the bottom.");
            this.nDeathMinimap.Hexadecimal = true;
            this.nDeathMinimap.Location = new System.Drawing.Point(164, 181);
            this.nDeathMinimap.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.nDeathMinimap.Name = "nDeathMinimap";
            this.helpProvider1.SetShowHelp(this.nDeathMinimap, true);
            this.nDeathMinimap.Size = new System.Drawing.Size(68, 20);
            this.nDeathMinimap.TabIndex = 14;
            this.nDeathMinimap.ValueChanged += new System.EventHandler(this.nDeathMinimap_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label7, "This value is the location of the entrance to the dungeon using the minimaps coor" +
        "dinates rather than the actual map value itself. The value used here is the Mini" +
        "map Byte found at the bottom.");
            this.label7.Location = new System.Drawing.Point(6, 184);
            this.label7.Name = "label7";
            this.helpProvider1.SetShowHelp(this.label7, true);
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Minimap Respawn Map Coords:";
            // 
            // nDeathDungeon
            // 
            this.helpProvider1.SetHelpString(this.nDeathDungeon, "This value is the dungeon that you will spawn in after death.");
            this.nDeathDungeon.Hexadecimal = true;
            this.nDeathDungeon.Location = new System.Drawing.Point(164, 155);
            this.nDeathDungeon.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nDeathDungeon.Name = "nDeathDungeon";
            this.helpProvider1.SetShowHelp(this.nDeathDungeon, true);
            this.nDeathDungeon.Size = new System.Drawing.Size(68, 20);
            this.nDeathDungeon.TabIndex = 12;
            this.nDeathDungeon.ValueChanged += new System.EventHandler(this.nDeathDungeon_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label6, "This value is the dungeon that you will spawn in after death.");
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.helpProvider1.SetShowHelp(this.label6, true);
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Respawn Dungeon/Region:";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(112, 69);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // nDeathMap
            // 
            this.helpProvider1.SetHelpString(this.nDeathMap, "This is the map value that you will respawn on after death.");
            this.nDeathMap.Hexadecimal = true;
            this.nDeathMap.Location = new System.Drawing.Point(164, 129);
            this.nDeathMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nDeathMap.Name = "nDeathMap";
            this.helpProvider1.SetShowHelp(this.nDeathMap, true);
            this.nDeathMap.Size = new System.Drawing.Size(68, 20);
            this.nDeathMap.TabIndex = 10;
            this.nDeathMap.ValueChanged += new System.EventHandler(this.nDeathMap_ValueChanged);
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(112, 41);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(75, 23);
            this.bAccept.TabIndex = 4;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label4, "This is the map value that you will respawn on after death.");
            this.label4.Location = new System.Drawing.Point(6, 132);
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Respawn Map:";
            // 
            // nArrow
            // 
            this.helpProvider1.SetHelpString(this.nArrow, "This will change the location of the arrow that typically points to the entrance " +
        "of the dungeon.");
            this.nArrow.Hexadecimal = true;
            this.nArrow.Location = new System.Drawing.Point(164, 103);
            this.nArrow.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nArrow.Name = "nArrow";
            this.helpProvider1.SetShowHelp(this.nArrow, true);
            this.nArrow.Size = new System.Drawing.Size(68, 20);
            this.nArrow.TabIndex = 8;
            this.nArrow.ValueChanged += new System.EventHandler(this.nArrow_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label5, "This will change the location of the arrow that typically points to the entrance " +
        "of the dungeon.");
            this.label5.Location = new System.Drawing.Point(6, 106);
            this.label5.Name = "label5";
            this.helpProvider1.SetShowHelp(this.label5, true);
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Arrow Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label1, "This is the map value of the associated position on the minimap. You can change t" +
        "his value to rearrange what map values are where.");
            this.label1.Location = new System.Drawing.Point(97, 18);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map Value:";
            // 
            // nMap
            // 
            this.helpProvider1.SetHelpString(this.nMap, "This is the map value of the associated position on the minimap. You can change t" +
        "his value to rearrange what map values are where.");
            this.nMap.Hexadecimal = true;
            this.nMap.Location = new System.Drawing.Point(164, 16);
            this.nMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nMap.Name = "nMap";
            this.helpProvider1.SetShowHelp(this.nMap, true);
            this.nMap.Size = new System.Drawing.Size(68, 20);
            this.nMap.TabIndex = 2;
            this.nMap.ValueChanged += new System.EventHandler(this.nMap_ValueChanged);
            // 
            // gridBoxOverworldTile
            // 
            this.gridBoxOverworldTile.AllowMultiSelection = false;
            this.gridBoxOverworldTile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBoxOverworldTile.BoxSize = new System.Drawing.Size(8, 8);
            this.gridBoxOverworldTile.CanvasSize = new System.Drawing.Size(128, 64);
            this.helpProvider1.SetHelpString(this.gridBoxOverworldTile, "This is the minimap tile selector. Clicking a tile will select it, letting you pl" +
        "ace it on the minimap box above.");
            this.gridBoxOverworldTile.HoverBox = true;
            this.gridBoxOverworldTile.HoverColor = System.Drawing.Color.White;
            this.gridBoxOverworldTile.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.gridBoxOverworldTile.Location = new System.Drawing.Point(6, 146);
            this.gridBoxOverworldTile.Name = "gridBoxOverworldTile";
            this.gridBoxOverworldTile.Selectable = true;
            this.gridBoxOverworldTile.SelectedIndex = 0;
            this.gridBoxOverworldTile.SelectionColor = System.Drawing.Color.Red;
            this.gridBoxOverworldTile.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.helpProvider1.SetShowHelp(this.gridBoxOverworldTile, true);
            this.gridBoxOverworldTile.Size = new System.Drawing.Size(132, 68);
            this.gridBoxOverworldTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gridBoxOverworldTile.TabIndex = 8;
            this.gridBoxOverworldTile.TabStop = false;
            this.gridBoxOverworldTile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridBoxOverworldTile_MouseDown);
            // 
            // pMinimapO
            // 
            this.pMinimapO.AllowMultiSelection = false;
            this.pMinimapO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMinimapO.BoxSize = new System.Drawing.Size(8, 8);
            this.pMinimapO.CanvasSize = new System.Drawing.Size(128, 128);
            this.helpProvider1.SetHelpString(this.pMinimapO, "The Overworld minimap editor. Left click to place the selected tile. Right click " +
        "to copy the tile underneath the mouse cursor.");
            this.pMinimapO.HoverBox = true;
            this.pMinimapO.HoverColor = System.Drawing.Color.White;
            this.pMinimapO.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pMinimapO.Location = new System.Drawing.Point(6, 11);
            this.pMinimapO.Name = "pMinimapO";
            this.pMinimapO.Selectable = true;
            this.pMinimapO.SelectedIndex = 0;
            this.pMinimapO.SelectionColor = System.Drawing.Color.Red;
            this.pMinimapO.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.helpProvider1.SetShowHelp(this.pMinimapO, true);
            this.pMinimapO.Size = new System.Drawing.Size(132, 132);
            this.pMinimapO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pMinimapO.TabIndex = 0;
            this.pMinimapO.TabStop = false;
            this.pMinimapO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pMinimapO_MouseDown);
            // 
            // pTiles
            // 
            this.pTiles.AllowMultiSelection = false;
            this.pTiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pTiles.BoxSize = new System.Drawing.Size(8, 8);
            this.pTiles.CanvasSize = new System.Drawing.Size(160, 128);
            this.helpProvider1.SetHelpString(this.pTiles, "This is the tile select box. The selected tile will be what is drawn on the minim" +
        "ap editor above. You can deselect the selected tile with a right click.");
            this.pTiles.HoverBox = true;
            this.pTiles.HoverColor = System.Drawing.Color.White;
            this.pTiles.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pTiles.Location = new System.Drawing.Point(8, 85);
            this.pTiles.Name = "pTiles";
            this.pTiles.Selectable = true;
            this.pTiles.SelectedIndex = -1;
            this.pTiles.SelectionColor = System.Drawing.Color.Red;
            this.pTiles.SelectionRectangle = new System.Drawing.Rectangle(-1, 0, 1, 1);
            this.helpProvider1.SetShowHelp(this.pTiles, true);
            this.pTiles.Size = new System.Drawing.Size(36, 12);
            this.pTiles.TabIndex = 1;
            this.pTiles.TabStop = false;
            this.pTiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pTiles_MouseClick);
            // 
            // pMinimapD
            // 
            this.pMinimapD.AllowMultiSelection = false;
            this.pMinimapD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMinimapD.BoxSize = new System.Drawing.Size(8, 8);
            this.pMinimapD.CanvasSize = new System.Drawing.Size(128, 128);
            this.helpProvider1.SetHelpString(this.pMinimapD, resources.GetString("pMinimapD.HelpString"));
            this.pMinimapD.HoverBox = true;
            this.pMinimapD.HoverColor = System.Drawing.Color.White;
            this.pMinimapD.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pMinimapD.Location = new System.Drawing.Point(8, 11);
            this.pMinimapD.Name = "pMinimapD";
            this.pMinimapD.Selectable = true;
            this.pMinimapD.SelectedIndex = 0;
            this.pMinimapD.SelectionColor = System.Drawing.Color.Red;
            this.pMinimapD.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.helpProvider1.SetShowHelp(this.pMinimapD, true);
            this.pMinimapD.Size = new System.Drawing.Size(68, 68);
            this.pMinimapD.TabIndex = 0;
            this.pMinimapD.TabStop = false;
            this.pMinimapD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pMinimapD_MouseDown);
            this.pMinimapD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pMinimapD_MouseMove);
            // 
            // MinimapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 250);
            this.Controls.Add(this.gBoxOverWorld);
            this.Controls.Add(this.gBoxDungeon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MinimapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minimap Editor";
            this.Load += new System.EventHandler(this.MinimapEditor_Load);
            this.gBoxOverWorld.ResumeLayout(false);
            this.gBoxOverWorld.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTile)).EndInit();
            this.gBoxDungeon.ResumeLayout(false);
            this.gBoxDungeon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDeathMinimap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDeathDungeon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDeathMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxOverworldTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimapO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimapD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxOverWorld;
        private System.Windows.Forms.Button bAccept1;
        private System.Windows.Forms.Button bCancel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nPalette;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nTile;
        private System.Windows.Forms.PictureBox pTile;
        public GridBox pMinimapO;
        private System.Windows.Forms.GroupBox gBoxDungeon;
        private System.Windows.Forms.NumericUpDown nDeathMinimap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nDeathDungeon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.NumericUpDown nDeathMap;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nArrow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nMap;
        private GridBox pTiles;
        public GridBox pMinimapD;
        public GridBox gridBoxOverworldTile;
        private System.Windows.Forms.Label labelPaletteLocation;
        private System.Windows.Forms.Label lblHoverPos;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}