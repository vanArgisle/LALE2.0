
namespace LALE.Supporting.Text_Editor
{
    partial class TextEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
            this.pText = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nAddress = new System.Windows.Forms.NumericUpDown();
            this.cQuestion = new System.Windows.Forms.CheckBox();
            this.bClose = new System.Windows.Forms.Button();
            this.tTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nTextBank = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRepoint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTextBank)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pText
            // 
            this.pText.BackColor = System.Drawing.Color.Black;
            this.pText.Location = new System.Drawing.Point(15, 285);
            this.pText.Name = "pText";
            this.pText.Size = new System.Drawing.Size(298, 257);
            this.pText.TabIndex = 25;
            this.pText.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Text Address:";
            // 
            // nAddress
            // 
            this.nAddress.Hexadecimal = true;
            this.nAddress.Location = new System.Drawing.Point(88, 69);
            this.nAddress.Maximum = new decimal(new int[] {
            1048575,
            0,
            0,
            0});
            this.nAddress.Name = "nAddress";
            this.nAddress.Size = new System.Drawing.Size(225, 20);
            this.nAddress.TabIndex = 23;
            this.nAddress.ValueChanged += new System.EventHandler(this.nAddress_ValueChanged);
            // 
            // cQuestion
            // 
            this.cQuestion.AutoSize = true;
            this.cQuestion.Enabled = false;
            this.cQuestion.Location = new System.Drawing.Point(15, 552);
            this.cQuestion.Name = "cQuestion";
            this.cQuestion.Size = new System.Drawing.Size(108, 17);
            this.cQuestion.TabIndex = 22;
            this.cQuestion.Text = "Yes/No Question";
            this.cQuestion.UseVisualStyleBackColor = true;
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(128, 548);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(184, 23);
            this.bClose.TabIndex = 21;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // tTextBox
            // 
            this.tTextBox.Location = new System.Drawing.Point(15, 107);
            this.tTextBox.Multiline = true;
            this.tTextBox.Name = "tTextBox";
            this.tTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tTextBox.Size = new System.Drawing.Size(298, 172);
            this.tTextBox.TabIndex = 19;
            this.tTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Text Pointer:";
            // 
            // nTextBank
            // 
            this.nTextBank.Hexadecimal = true;
            this.nTextBank.Location = new System.Drawing.Point(88, 29);
            this.nTextBank.Maximum = new decimal(new int[] {
            687,
            0,
            0,
            0});
            this.nTextBank.Name = "nTextBank";
            this.nTextBank.Size = new System.Drawing.Size(225, 20);
            this.nTextBank.TabIndex = 17;
            this.nTextBank.ValueChanged += new System.EventHandler(this.nTextBank_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripButtonRepoint,
            this.toolStripButtonSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(324, 25);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save Text";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRepoint
            // 
            this.toolStripButtonRepoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRepoint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRepoint.Image")));
            this.toolStripButtonRepoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRepoint.Name = "toolStripButtonRepoint";
            this.toolStripButtonRepoint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRepoint.Text = "Repoint Text Pointers";
            this.toolStripButtonRepoint.Click += new System.EventHandler(this.toolStripButtonRepoint_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Search Text";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 583);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nAddress);
            this.Controls.Add(this.cQuestion);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.tTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nTextBank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TextEditor";
            this.Text = "Text Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTextBank)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nAddress;
        private System.Windows.Forms.CheckBox cQuestion;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TextBox tTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nTextBank;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRepoint;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
    }
}