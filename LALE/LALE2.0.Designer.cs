namespace LALE
{
    partial class LALE2
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LALE2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.repointCollisionAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trimCollisionAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRepointCollisionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collisionBordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDownMap = new System.Windows.Forms.NumericUpDown();
            this.labelMap = new System.Windows.Forms.Label();
            this.radioButtonOverlay = new System.Windows.Forms.RadioButton();
            this.radioButtonCollisions = new System.Windows.Forms.RadioButton();
            this.buttonMapData = new System.Windows.Forms.Button();
            this.gBoxCollisions = new System.Windows.Forms.GroupBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bCollisionDown = new System.Windows.Forms.Button();
            this.bCollisionUp = new System.Windows.Forms.Button();
            this.pObject = new System.Windows.Forms.PictureBox();
            this.nSelected = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CollisionList = new System.Windows.Forms.ListBox();
            this.nObjectID = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.comDirection = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nLength = new System.Windows.Forms.NumericUpDown();
            this.labelSelectedTile = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelHoverCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAddressPointer = new System.Windows.Forms.ToolStripStatusLabel();
            this.gridBoxMap = new LALE.GridBox();
            this.gridBoxTileset = new LALE.GridBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pMinimap = new LALE.GridBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cMagGlass1 = new System.Windows.Forms.CheckBox();
            this.cSideview = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pMinimapD = new LALE.GridBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cMagGlass = new System.Windows.Forms.CheckBox();
            this.cSideview2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nRegion = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSpecialMap = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMap)).BeginInit();
            this.gBoxCollisions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nObjectID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLength)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxTileset)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimap)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimapD)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openROMToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // openROMToolStripMenuItem
            // 
            this.openROMToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openROMToolStripMenuItem.Image")));
            this.openROMToolStripMenuItem.Name = "openROMToolStripMenuItem";
            this.openROMToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openROMToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.openROMToolStripMenuItem.Text = "Open ROM";
            this.openROMToolStripMenuItem.Click += new System.EventHandler(this.openROMToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearOverlayToolStripMenuItem,
            this.toolStripSeparator1,
            this.repointCollisionAddressToolStripMenuItem,
            this.trimCollisionAddressToolStripMenuItem,
            this.autoRepointCollisionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearOverlayToolStripMenuItem
            // 
            this.clearOverlayToolStripMenuItem.Name = "clearOverlayToolStripMenuItem";
            this.clearOverlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.clearOverlayToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.clearOverlayToolStripMenuItem.Text = "Clear Overlay";
            this.clearOverlayToolStripMenuItem.Click += new System.EventHandler(this.clearOverlayToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // repointCollisionAddressToolStripMenuItem
            // 
            this.repointCollisionAddressToolStripMenuItem.Name = "repointCollisionAddressToolStripMenuItem";
            this.repointCollisionAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.repointCollisionAddressToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.repointCollisionAddressToolStripMenuItem.Text = "Repoint Collision Address";
            this.repointCollisionAddressToolStripMenuItem.Click += new System.EventHandler(this.repointCollisionAddressToolStripMenuItem_Click);
            // 
            // trimCollisionAddressToolStripMenuItem
            // 
            this.trimCollisionAddressToolStripMenuItem.Name = "trimCollisionAddressToolStripMenuItem";
            this.trimCollisionAddressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.trimCollisionAddressToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.trimCollisionAddressToolStripMenuItem.Text = "Trim Collision Address";
            this.trimCollisionAddressToolStripMenuItem.Click += new System.EventHandler(this.trimCollisionAddressToolStripMenuItem_Click);
            // 
            // autoRepointCollisionsToolStripMenuItem
            // 
            this.autoRepointCollisionsToolStripMenuItem.Checked = true;
            this.autoRepointCollisionsToolStripMenuItem.CheckOnClick = true;
            this.autoRepointCollisionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRepointCollisionsToolStripMenuItem.Name = "autoRepointCollisionsToolStripMenuItem";
            this.autoRepointCollisionsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.autoRepointCollisionsToolStripMenuItem.Text = "Auto Repoint Collisions";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collisionBordersToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // collisionBordersToolStripMenuItem
            // 
            this.collisionBordersToolStripMenuItem.Checked = true;
            this.collisionBordersToolStripMenuItem.CheckOnClick = true;
            this.collisionBordersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.collisionBordersToolStripMenuItem.Name = "collisionBordersToolStripMenuItem";
            this.collisionBordersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.collisionBordersToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.collisionBordersToolStripMenuItem.Text = "Collision Borders";
            this.collisionBordersToolStripMenuItem.Click += new System.EventHandler(this.collisionBordersToolStripMenuItem_Click);
            // 
            // numericUpDownMap
            // 
            this.numericUpDownMap.Enabled = false;
            this.numericUpDownMap.Hexadecimal = true;
            this.numericUpDownMap.Location = new System.Drawing.Point(341, 32);
            this.numericUpDownMap.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownMap.Name = "numericUpDownMap";
            this.numericUpDownMap.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMap.TabIndex = 2;
            this.numericUpDownMap.ValueChanged += new System.EventHandler(this.numericUpDownMap_ValueChanged);
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(294, 34);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(31, 13);
            this.labelMap.TabIndex = 3;
            this.labelMap.Text = "Map:";
            // 
            // radioButtonOverlay
            // 
            this.radioButtonOverlay.AutoSize = true;
            this.radioButtonOverlay.Enabled = false;
            this.radioButtonOverlay.Location = new System.Drawing.Point(400, 196);
            this.radioButtonOverlay.Name = "radioButtonOverlay";
            this.radioButtonOverlay.Size = new System.Drawing.Size(61, 17);
            this.radioButtonOverlay.TabIndex = 6;
            this.radioButtonOverlay.TabStop = true;
            this.radioButtonOverlay.Text = "Overlay";
            this.radioButtonOverlay.UseVisualStyleBackColor = true;
            this.radioButtonOverlay.CheckedChanged += new System.EventHandler(this.radioButtonOverlay_CheckedChanged);
            // 
            // radioButtonCollisions
            // 
            this.radioButtonCollisions.AutoSize = true;
            this.radioButtonCollisions.Enabled = false;
            this.radioButtonCollisions.Location = new System.Drawing.Point(297, 196);
            this.radioButtonCollisions.Name = "radioButtonCollisions";
            this.radioButtonCollisions.Size = new System.Drawing.Size(68, 17);
            this.radioButtonCollisions.TabIndex = 7;
            this.radioButtonCollisions.TabStop = true;
            this.radioButtonCollisions.Text = "Collisions";
            this.radioButtonCollisions.UseVisualStyleBackColor = true;
            this.radioButtonCollisions.CheckedChanged += new System.EventHandler(this.radioButtonCollisions_CheckedChanged);
            // 
            // buttonMapData
            // 
            this.buttonMapData.Location = new System.Drawing.Point(297, 219);
            this.buttonMapData.Name = "buttonMapData";
            this.buttonMapData.Size = new System.Drawing.Size(164, 23);
            this.buttonMapData.TabIndex = 8;
            this.buttonMapData.Text = "Map Data";
            this.buttonMapData.UseVisualStyleBackColor = true;
            this.buttonMapData.Click += new System.EventHandler(this.buttonMapData_Click);
            // 
            // gBoxCollisions
            // 
            this.gBoxCollisions.Controls.Add(this.bAdd);
            this.gBoxCollisions.Controls.Add(this.bDelete);
            this.gBoxCollisions.Controls.Add(this.bCollisionDown);
            this.gBoxCollisions.Controls.Add(this.bCollisionUp);
            this.gBoxCollisions.Controls.Add(this.pObject);
            this.gBoxCollisions.Controls.Add(this.nSelected);
            this.gBoxCollisions.Controls.Add(this.label13);
            this.gBoxCollisions.Controls.Add(this.label12);
            this.gBoxCollisions.Controls.Add(this.CollisionList);
            this.gBoxCollisions.Controls.Add(this.nObjectID);
            this.gBoxCollisions.Controls.Add(this.label11);
            this.gBoxCollisions.Controls.Add(this.comDirection);
            this.gBoxCollisions.Controls.Add(this.label10);
            this.gBoxCollisions.Controls.Add(this.label9);
            this.gBoxCollisions.Controls.Add(this.nLength);
            this.gBoxCollisions.Enabled = false;
            this.gBoxCollisions.Location = new System.Drawing.Point(482, 27);
            this.gBoxCollisions.Name = "gBoxCollisions";
            this.gBoxCollisions.Size = new System.Drawing.Size(211, 299);
            this.gBoxCollisions.TabIndex = 24;
            this.gBoxCollisions.TabStop = false;
            this.gBoxCollisions.Text = "Collisions:";
            // 
            // bAdd
            // 
            this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
            this.bAdd.Location = new System.Drawing.Point(151, 156);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(20, 20);
            this.bAdd.TabIndex = 39;
            this.bAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bDelete
            // 
            this.bDelete.Image = ((System.Drawing.Image)(resources.GetObject("bDelete.Image")));
            this.bDelete.Location = new System.Drawing.Point(151, 182);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(20, 20);
            this.bDelete.TabIndex = 38;
            this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bCollisionDown
            // 
            this.bCollisionDown.Image = ((System.Drawing.Image)(resources.GetObject("bCollisionDown.Image")));
            this.bCollisionDown.Location = new System.Drawing.Point(125, 182);
            this.bCollisionDown.Name = "bCollisionDown";
            this.bCollisionDown.Size = new System.Drawing.Size(20, 20);
            this.bCollisionDown.TabIndex = 37;
            this.bCollisionDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCollisionDown.UseVisualStyleBackColor = true;
            this.bCollisionDown.Click += new System.EventHandler(this.bCollisionDown_Click);
            // 
            // bCollisionUp
            // 
            this.bCollisionUp.Image = ((System.Drawing.Image)(resources.GetObject("bCollisionUp.Image")));
            this.bCollisionUp.Location = new System.Drawing.Point(125, 156);
            this.bCollisionUp.Name = "bCollisionUp";
            this.bCollisionUp.Size = new System.Drawing.Size(20, 20);
            this.bCollisionUp.TabIndex = 36;
            this.bCollisionUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCollisionUp.UseVisualStyleBackColor = true;
            this.bCollisionUp.Click += new System.EventHandler(this.bCollisionUp_Click);
            // 
            // pObject
            // 
            this.pObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pObject.Location = new System.Drawing.Point(125, 213);
            this.pObject.Name = "pObject";
            this.pObject.Size = new System.Drawing.Size(20, 20);
            this.pObject.TabIndex = 35;
            this.pObject.TabStop = false;
            this.pObject.Paint += new System.Windows.Forms.PaintEventHandler(this.pObject_Paint);
            // 
            // nSelected
            // 
            this.nSelected.Location = new System.Drawing.Point(62, 18);
            this.nSelected.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nSelected.Name = "nSelected";
            this.nSelected.Size = new System.Drawing.Size(99, 20);
            this.nSelected.TabIndex = 33;
            this.nSelected.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nSelected.ValueChanged += new System.EventHandler(this.nSelected_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Type:        ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Selected:";
            // 
            // CollisionList
            // 
            this.CollisionList.AccessibleName = "";
            this.CollisionList.FormattingEnabled = true;
            this.CollisionList.Location = new System.Drawing.Point(9, 157);
            this.CollisionList.Name = "CollisionList";
            this.CollisionList.Size = new System.Drawing.Size(110, 134);
            this.CollisionList.TabIndex = 25;
            this.CollisionList.SelectedIndexChanged += new System.EventHandler(this.CollisionList_SelectedIndexChanged);
            this.CollisionList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CollisionList_MouseDown);
            // 
            // nObjectID
            // 
            this.nObjectID.Hexadecimal = true;
            this.nObjectID.Location = new System.Drawing.Point(55, 114);
            this.nObjectID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nObjectID.Name = "nObjectID";
            this.nObjectID.Size = new System.Drawing.Size(106, 20);
            this.nObjectID.TabIndex = 31;
            this.nObjectID.ValueChanged += new System.EventHandler(this.nObjectID_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "ID:";
            // 
            // comDirection
            // 
            this.comDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comDirection.FormattingEnabled = true;
            this.comDirection.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.comDirection.Location = new System.Drawing.Point(64, 50);
            this.comDirection.Name = "comDirection";
            this.comDirection.Size = new System.Drawing.Size(97, 21);
            this.comDirection.TabIndex = 29;
            this.comDirection.SelectedIndexChanged += new System.EventHandler(this.comDirection_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Direction:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Length:";
            // 
            // nLength
            // 
            this.nLength.Location = new System.Drawing.Point(55, 84);
            this.nLength.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nLength.Name = "nLength";
            this.nLength.Size = new System.Drawing.Size(106, 20);
            this.nLength.TabIndex = 26;
            this.nLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nLength.ValueChanged += new System.EventHandler(this.nLength_ValueChanged);
            // 
            // labelSelectedTile
            // 
            this.labelSelectedTile.AutoSize = true;
            this.labelSelectedTile.Location = new System.Drawing.Point(9, 321);
            this.labelSelectedTile.Name = "labelSelectedTile";
            this.labelSelectedTile.Size = new System.Drawing.Size(77, 13);
            this.labelSelectedTile.TabIndex = 25;
            this.labelSelectedTile.Text = "Selected tile: 0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelHoverCoords,
            this.toolStripStatusLabelSpace,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelAddressPointer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(893, 24);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelHoverCoords
            // 
            this.toolStripStatusLabelHoverCoords.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelHoverCoords.Name = "toolStripStatusLabelHoverCoords";
            this.toolStripStatusLabelHoverCoords.Size = new System.Drawing.Size(52, 19);
            this.toolStripStatusLabelHoverCoords.Text = "X: 0 Y: 0";
            // 
            // toolStripStatusLabelSpace
            // 
            this.toolStripStatusLabelSpace.Name = "toolStripStatusLabelSpace";
            this.toolStripStatusLabelSpace.Size = new System.Drawing.Size(0, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(4, 19);
            // 
            // toolStripStatusLabelAddressPointer
            // 
            this.toolStripStatusLabelAddressPointer.Name = "toolStripStatusLabelAddressPointer";
            this.toolStripStatusLabelAddressPointer.Size = new System.Drawing.Size(79, 19);
            this.toolStripStatusLabelAddressPointer.Text = "Data Address:";
            // 
            // gridBoxMap
            // 
            this.gridBoxMap.AllowMultiSelection = false;
            this.gridBoxMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBoxMap.BoxSize = new System.Drawing.Size(16, 16);
            this.gridBoxMap.CanvasSize = new System.Drawing.Size(160, 128);
            this.gridBoxMap.HoverBox = true;
            this.gridBoxMap.HoverColor = System.Drawing.Color.White;
            this.gridBoxMap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.gridBoxMap.Location = new System.Drawing.Point(297, 58);
            this.gridBoxMap.Name = "gridBoxMap";
            this.gridBoxMap.Selectable = false;
            this.gridBoxMap.SelectedIndex = -1;
            this.gridBoxMap.SelectionColor = System.Drawing.Color.Red;
            this.gridBoxMap.SelectionRectangle = new System.Drawing.Rectangle(-1, 0, 1, 1);
            this.gridBoxMap.Size = new System.Drawing.Size(164, 132);
            this.gridBoxMap.TabIndex = 5;
            this.gridBoxMap.TabStop = false;
            this.gridBoxMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridBoxMap_MouseDoubleClick);
            this.gridBoxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridBoxMap_MouseDown);
            this.gridBoxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridBoxMap_MouseMove);
            this.gridBoxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridBoxMap_MouseUp);
            // 
            // gridBoxTileset
            // 
            this.gridBoxTileset.AllowMultiSelection = false;
            this.gridBoxTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBoxTileset.BoxSize = new System.Drawing.Size(16, 16);
            this.gridBoxTileset.CanvasSize = new System.Drawing.Size(260, 260);
            this.gridBoxTileset.HoverBox = true;
            this.gridBoxTileset.HoverColor = System.Drawing.Color.White;
            this.gridBoxTileset.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.gridBoxTileset.Location = new System.Drawing.Point(12, 58);
            this.gridBoxTileset.Name = "gridBoxTileset";
            this.gridBoxTileset.Selectable = true;
            this.gridBoxTileset.SelectedIndex = 0;
            this.gridBoxTileset.SelectionColor = System.Drawing.Color.Red;
            this.gridBoxTileset.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.gridBoxTileset.Size = new System.Drawing.Size(260, 260);
            this.gridBoxTileset.TabIndex = 4;
            this.gridBoxTileset.TabStop = false;
            this.gridBoxTileset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridBoxTileset_MouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(699, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(173, 179);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pMinimap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(165, 153);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overworld";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pMinimap
            // 
            this.pMinimap.AllowMultiSelection = false;
            this.pMinimap.BackColor = System.Drawing.SystemColors.Control;
            this.pMinimap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMinimap.BoxSize = new System.Drawing.Size(8, 8);
            this.pMinimap.CanvasSize = new System.Drawing.Size(128, 128);
            this.pMinimap.HoverBox = true;
            this.pMinimap.HoverColor = System.Drawing.Color.White;
            this.pMinimap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pMinimap.Location = new System.Drawing.Point(13, 7);
            this.pMinimap.Name = "pMinimap";
            this.pMinimap.Selectable = true;
            this.pMinimap.SelectedIndex = -2;
            this.pMinimap.SelectionColor = System.Drawing.Color.Red;
            this.pMinimap.SelectionRectangle = new System.Drawing.Rectangle(-2, 0, 1, 1);
            this.pMinimap.Size = new System.Drawing.Size(132, 132);
            this.pMinimap.TabIndex = 13;
            this.pMinimap.TabStop = false;
            this.pMinimap.Click += new System.EventHandler(this.pMinimap_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cMagGlass1);
            this.tabPage2.Controls.Add(this.cSideview);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.pMinimapD);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(165, 153);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dungeon";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cMagGlass1
            // 
            this.cMagGlass1.AutoSize = true;
            this.cMagGlass1.Location = new System.Drawing.Point(6, 105);
            this.cMagGlass1.Name = "cMagGlass1";
            this.cMagGlass1.Size = new System.Drawing.Size(106, 17);
            this.cMagGlass1.TabIndex = 21;
            this.cMagGlass1.Text = "Magnifying Glass";
            this.cMagGlass1.UseVisualStyleBackColor = true;
            this.cMagGlass1.Visible = false;
            // 
            // cSideview
            // 
            this.cSideview.AutoSize = true;
            this.cSideview.Enabled = false;
            this.cSideview.Location = new System.Drawing.Point(6, 85);
            this.cSideview.Name = "cSideview";
            this.cSideview.Size = new System.Drawing.Size(73, 17);
            this.cSideview.TabIndex = 19;
            this.cSideview.Text = "Side View";
            this.cSideview.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Level 1",
            "Level 2",
            "Level 3",
            "Level 4",
            "Level 5",
            "Level 6 ",
            "Level 7",
            "Level 8",
            "Colour"});
            this.comboBox1.Location = new System.Drawing.Point(80, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(74, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // pMinimapD
            // 
            this.pMinimapD.AllowMultiSelection = false;
            this.pMinimapD.BackColor = System.Drawing.SystemColors.Control;
            this.pMinimapD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMinimapD.BoxSize = new System.Drawing.Size(8, 8);
            this.pMinimapD.CanvasSize = new System.Drawing.Size(64, 64);
            this.pMinimapD.HoverBox = true;
            this.pMinimapD.HoverColor = System.Drawing.Color.White;
            this.pMinimapD.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pMinimapD.Location = new System.Drawing.Point(6, 11);
            this.pMinimapD.Name = "pMinimapD";
            this.pMinimapD.Selectable = true;
            this.pMinimapD.SelectedIndex = -2;
            this.pMinimapD.SelectionColor = System.Drawing.Color.Red;
            this.pMinimapD.SelectionRectangle = new System.Drawing.Rectangle(-2, 0, 1, 1);
            this.pMinimapD.Size = new System.Drawing.Size(68, 68);
            this.pMinimapD.TabIndex = 14;
            this.pMinimapD.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cMagGlass);
            this.tabPage3.Controls.Add(this.cSideview2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.nRegion);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(165, 153);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Indoor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cMagGlass
            // 
            this.cMagGlass.AutoSize = true;
            this.cMagGlass.Location = new System.Drawing.Point(9, 69);
            this.cMagGlass.Name = "cMagGlass";
            this.cMagGlass.Size = new System.Drawing.Size(106, 17);
            this.cMagGlass.TabIndex = 20;
            this.cMagGlass.Text = "Magnifying Glass";
            this.cMagGlass.UseVisualStyleBackColor = true;
            this.cMagGlass.Visible = false;
            // 
            // cSideview2
            // 
            this.cSideview2.AutoSize = true;
            this.cSideview2.Enabled = false;
            this.cSideview2.Location = new System.Drawing.Point(9, 46);
            this.cSideview2.Name = "cSideview2";
            this.cSideview2.Size = new System.Drawing.Size(73, 17);
            this.cSideview2.TabIndex = 19;
            this.cSideview2.Text = "Side View";
            this.cSideview2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Region:";
            // 
            // nRegion
            // 
            this.nRegion.Enabled = false;
            this.nRegion.Hexadecimal = true;
            this.nRegion.Location = new System.Drawing.Point(56, 14);
            this.nRegion.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.nRegion.Name = "nRegion";
            this.nRegion.Size = new System.Drawing.Size(98, 20);
            this.nRegion.TabIndex = 0;
            // 
            // checkBoxSpecialMap
            // 
            this.checkBoxSpecialMap.AutoSize = true;
            this.checkBoxSpecialMap.Enabled = false;
            this.checkBoxSpecialMap.Location = new System.Drawing.Point(297, 248);
            this.checkBoxSpecialMap.Name = "checkBoxSpecialMap";
            this.checkBoxSpecialMap.Size = new System.Drawing.Size(118, 17);
            this.checkBoxSpecialMap.TabIndex = 28;
            this.checkBoxSpecialMap.Text = "View Alternate Map";
            this.checkBoxSpecialMap.UseVisualStyleBackColor = true;
            this.checkBoxSpecialMap.CheckedChanged += new System.EventHandler(this.checkBoxSpecialMap_CheckedChanged);
            // 
            // LALE2
            // 
            this.ClientSize = new System.Drawing.Size(893, 366);
            this.Controls.Add(this.checkBoxSpecialMap);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelSelectedTile);
            this.Controls.Add(this.gBoxCollisions);
            this.Controls.Add(this.buttonMapData);
            this.Controls.Add(this.radioButtonCollisions);
            this.Controls.Add(this.radioButtonOverlay);
            this.Controls.Add(this.gridBoxMap);
            this.Controls.Add(this.gridBoxTileset);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.numericUpDownMap);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LALE2";
            this.Text = "LALE";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LALE_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMap)).EndInit();
            this.gBoxCollisions.ResumeLayout(false);
            this.gBoxCollisions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nObjectID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLength)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxTileset)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pMinimap)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMinimapD)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region Windows Form Designer generated code


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openROMToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownMap;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.RadioButton radioButtonOverlay;
        private System.Windows.Forms.RadioButton radioButtonCollisions;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collisionBordersToolStripMenuItem;
        private GridBox gridBoxTileset;
        private GridBox gridBoxMap;
        private System.Windows.Forms.Button buttonMapData;
        private System.Windows.Forms.GroupBox gBoxCollisions;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bCollisionDown;
        private System.Windows.Forms.Button bCollisionUp;
        private System.Windows.Forms.PictureBox pObject;
        private System.Windows.Forms.NumericUpDown nSelected;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox CollisionList;
        private System.Windows.Forms.NumericUpDown nObjectID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comDirection;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nLength;
        private System.Windows.Forms.Label labelSelectedTile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHoverCoords;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpace;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearOverlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoRepointCollisionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trimCollisionAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem repointCollisionAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAddressPointer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private GridBox pMinimap;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cMagGlass1;
        private System.Windows.Forms.CheckBox cSideview;
        private System.Windows.Forms.ComboBox comboBox1;
        private GridBox pMinimapD;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cMagGlass;
        private System.Windows.Forms.CheckBox cSideview2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nRegion;
        private System.Windows.Forms.CheckBox checkBoxSpecialMap;
    }
}

