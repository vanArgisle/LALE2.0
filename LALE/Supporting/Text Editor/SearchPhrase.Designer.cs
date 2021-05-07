
namespace LALE.Supporting.Text_Editor
{
    partial class SearchPhrase
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
            this.bClose = new System.Windows.Forms.Button();
            this.lBox = new System.Windows.Forms.ListBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bAccept
            // 
            this.bAccept.Enabled = false;
            this.bAccept.Location = new System.Drawing.Point(119, 229);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(89, 23);
            this.bAccept.TabIndex = 11;
            this.bAccept.Text = "Accept";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(15, 229);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(89, 23);
            this.bClose.TabIndex = 10;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // lBox
            // 
            this.lBox.FormattingEnabled = true;
            this.lBox.Location = new System.Drawing.Point(15, 78);
            this.lBox.Name = "lBox";
            this.lBox.Size = new System.Drawing.Size(193, 134);
            this.lBox.TabIndex = 9;
            this.lBox.SelectedIndexChanged += new System.EventHandler(this.lBox_SelectedIndexChanged);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(56, 41);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(113, 23);
            this.bSearch.TabIndex = 8;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Key Word:";
            // 
            // tSearch
            // 
            this.tSearch.Location = new System.Drawing.Point(81, 6);
            this.tSearch.Name = "tSearch";
            this.tSearch.Size = new System.Drawing.Size(127, 20);
            this.tSearch.TabIndex = 6;
            this.tSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tSearch_KeyDown);
            // 
            // SearchPhrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 266);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lBox);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchPhrase";
            this.Text = "Search Phrase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.ListBox lBox;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tSearch;
    }
}