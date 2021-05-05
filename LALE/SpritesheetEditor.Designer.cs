
namespace LALE
{
    partial class SpritesheetEditor
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownBank1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBank2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBank3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBank4 = new System.Windows.Forms.NumericUpDown();
            this.labelSpritesheet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank4)).BeginInit();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(204, 160);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(117, 23);
            this.bAccept.TabIndex = 8;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 8);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(13, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(132, 8);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(13, 83);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(132, 8);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(13, 117);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(132, 8);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Hexadecimal = true;
            this.numericUpDown1.Location = new System.Drawing.Point(151, 8);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Hexadecimal = true;
            this.numericUpDown2.Location = new System.Drawing.Point(151, 44);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown2.TabIndex = 14;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Hexadecimal = true;
            this.numericUpDown3.Location = new System.Drawing.Point(151, 78);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown3.TabIndex = 15;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Hexadecimal = true;
            this.numericUpDown4.Location = new System.Drawing.Point(151, 112);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown4.TabIndex = 16;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(13, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(117, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numericUpDownBank1
            // 
            this.numericUpDownBank1.Hexadecimal = true;
            this.numericUpDownBank1.Location = new System.Drawing.Point(239, 8);
            this.numericUpDownBank1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBank1.Name = "numericUpDownBank1";
            this.numericUpDownBank1.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownBank1.TabIndex = 18;
            this.numericUpDownBank1.ValueChanged += new System.EventHandler(this.numericUpDownBank1_ValueChanged);
            // 
            // numericUpDownBank2
            // 
            this.numericUpDownBank2.Enabled = false;
            this.numericUpDownBank2.Hexadecimal = true;
            this.numericUpDownBank2.Location = new System.Drawing.Point(239, 44);
            this.numericUpDownBank2.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericUpDownBank2.Name = "numericUpDownBank2";
            this.numericUpDownBank2.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownBank2.TabIndex = 19;
            this.numericUpDownBank2.ValueChanged += new System.EventHandler(this.numericUpDownBank2_ValueChanged);
            // 
            // numericUpDownBank3
            // 
            this.numericUpDownBank3.Enabled = false;
            this.numericUpDownBank3.Hexadecimal = true;
            this.numericUpDownBank3.Location = new System.Drawing.Point(239, 78);
            this.numericUpDownBank3.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericUpDownBank3.Name = "numericUpDownBank3";
            this.numericUpDownBank3.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownBank3.TabIndex = 20;
            this.numericUpDownBank3.ValueChanged += new System.EventHandler(this.numericUpDownBank3_ValueChanged);
            // 
            // numericUpDownBank4
            // 
            this.numericUpDownBank4.Enabled = false;
            this.numericUpDownBank4.Hexadecimal = true;
            this.numericUpDownBank4.Location = new System.Drawing.Point(239, 112);
            this.numericUpDownBank4.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericUpDownBank4.Name = "numericUpDownBank4";
            this.numericUpDownBank4.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownBank4.TabIndex = 21;
            this.numericUpDownBank4.ValueChanged += new System.EventHandler(this.numericUpDownBank4_ValueChanged);
            // 
            // labelSpritesheet
            // 
            this.labelSpritesheet.AutoSize = true;
            this.labelSpritesheet.Location = new System.Drawing.Point(157, 135);
            this.labelSpritesheet.Name = "labelSpritesheet";
            this.labelSpritesheet.Size = new System.Drawing.Size(60, 13);
            this.labelSpritesheet.TabIndex = 22;
            this.labelSpritesheet.Text = "Spritesheet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Bank";
            // 
            // SpritesheetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 193);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSpritesheet);
            this.Controls.Add(this.numericUpDownBank4);
            this.Controls.Add(this.numericUpDownBank3);
            this.Controls.Add(this.numericUpDownBank2);
            this.Controls.Add(this.numericUpDownBank1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpritesheetEditor";
            this.ShowIcon = false;
            this.Text = "Sprite Sheet Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBank4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownBank1;
        private System.Windows.Forms.NumericUpDown numericUpDownBank2;
        private System.Windows.Forms.NumericUpDown numericUpDownBank3;
        private System.Windows.Forms.NumericUpDown numericUpDownBank4;
        private System.Windows.Forms.Label labelSpritesheet;
        private System.Windows.Forms.Label label1;
    }
}