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
    public partial class SignEditor : Form
    {
        Game LAGame;
        public SignEditor(Game game)
        {
            LAGame = game;
            InitializeComponent();
            loadSignPointer();
        }

        private void loadSignPointer()
        {
            LAGame.gbROM.BufferLocation = 0x51118 + LAGame.map;
            labelTextPointerAddress.Text = "Text Pointer Address: " + LAGame.gbROM.BufferLocation.ToString("X");

            byte b = LAGame.gbROM.ReadByte();
            int p = 1;
            if (b == 0x83)
                p = 0;
            if (b == 0x2D)
                p = 2;

            nPointer.Value = b;
            labelTextPointer.Text = "Text Pointer:  0x0" + p.ToString();
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            LAGame.gbROM.BufferLocation = 0x51118 + LAGame.map;
            LAGame.gbROM.WriteByte((byte)nPointer.Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nPointer_ValueChanged(object sender, EventArgs e)
        {
            if (nPointer.Value == 0x83)
                labelTextPointer.Text = "Text Pointer:  0x00";
            else if (nPointer.Value == 0x2D)
                labelTextPointer.Text = "Text Pointer:  0x02";
            else
                labelTextPointer.Text = "Text Pointer:  0x01";
           
        }
    }
}
