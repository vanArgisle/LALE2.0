using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE
{
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
            labelText.Text = "LALE is a tool created by Vanisle (Van Argisle).\n\n Visit LALE's github page at\n\n\n\n to contribute or learn more about LALE.";
            linkLabel1.Text =  "https://github.com/vanArgisle/LALE2.0";
            linkLabel1.Links.Add(0, 37, "https://github.com/vanArgisle/LALE2.0");
            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
        }

        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/vanArgisle/LALE2.0");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
