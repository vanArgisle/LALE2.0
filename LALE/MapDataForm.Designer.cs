namespace LALE
{
    partial class MapDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapDataForm));
            this.gridBoxTileset = new LALE.GridBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxTileset)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBoxTileset
            // 
            this.gridBoxTileset.AllowMultiSelection = false;
            this.gridBoxTileset.BoxSize = new System.Drawing.Size(12, 10);
            this.gridBoxTileset.CanvasSize = new System.Drawing.Size(160, 128);
            this.gridBoxTileset.HoverBox = true;
            this.gridBoxTileset.HoverColor = System.Drawing.Color.White;
            this.gridBoxTileset.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.gridBoxTileset.Location = new System.Drawing.Point(218, 12);
            this.gridBoxTileset.Name = "gridBoxTileset";
            this.gridBoxTileset.Selectable = false;
            this.gridBoxTileset.SelectedIndex = -1;
            this.gridBoxTileset.SelectionColor = System.Drawing.Color.Red;
            this.gridBoxTileset.SelectionRectangle = new System.Drawing.Rectangle(-1, 0, 1, 1);
            this.gridBoxTileset.Size = new System.Drawing.Size(260, 260);
            this.gridBoxTileset.TabIndex = 0;
            this.gridBoxTileset.TabStop = false;
            // 
            // MapDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 288);
            this.Controls.Add(this.gridBoxTileset);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapDataForm";
            this.Text = "Map Data";
            ((System.ComponentModel.ISupportInitialize)(this.gridBoxTileset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridBox gridBoxTileset;
    }
}