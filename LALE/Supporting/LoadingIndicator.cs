using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE.Supporting
{
    public partial class LoadingIndicator : Form
    {
        bool setClose = false;

        public LoadingIndicator(int pBarMaximum)
        {
            InitializeComponent();
            setValue(0, pBarMaximum);
        }

        public void setValue(int map, int max)
        {
            setPBarValue(map);
            setLabelText("Map " + map + "/" + max + " - " + (int)((decimal)((decimal)map / (decimal)max) * (decimal)100) + "%");
            if (map == max)
            {
                setClose = true;
                close();
            }
        }

        private void setPBarValue(int value)
        {
            if (pBar.InvokeRequired)
            {
                pBar.BeginInvoke(new MethodInvoker(delegate () { setPBarValue(value); }));
            }
            else
            {
                pBar.Value = value;
            }
        }

        private void setLabelText(string text)
        {
            if (pBar.InvokeRequired)
            {
                pBar.BeginInvoke(new MethodInvoker(delegate () { setLabelText(text); }));
            }
            else
            {
                lblStatus.Text = text;
            }
        }

        private void close()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate () { close(); }));
            }
            else
            {
                this.Close();
            }
        }

        private void frmLoadingIndicator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!setClose)
                e.Cancel = true;
        }
    }
}
