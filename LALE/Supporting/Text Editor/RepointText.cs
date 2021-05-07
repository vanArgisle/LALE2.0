using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE.Supporting.Text_Editor
{
    public partial class RepointText : Form
    {
        Game LAGame;
        public int textPointer;
        int textBank;
        int textOffset;
        public int textAddress;

        public RepointText(Game game, int textBank)
        {
            InitializeComponent();
            LAGame = game;
            nPointer.Value = textBank;
            getAddress((int)nPointer.Value);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nPointer_ValueChanged(object sender, EventArgs e)
        {
            getAddress((int)nPointer.Value);
            textPointer = (int)nPointer.Value;
        }

        private void nAddress_ValueChanged(object sender, EventArgs e)
        {
            textAddress = (int)nAddress.Value;
        }

        private void getAddress(int i)
        {
            textBank = (i >> 8);
            textOffset = (i & 0xFF);

            int t = (((textBank << 1) & 0xFF) * 0x100);
            int o = (textOffset << 1);
            int n = (t + o);

            LAGame.gbROM.BufferLocation = (0x1C * 0x4000) + (n + 1);
            int loc = (LAGame.gbROM.ReadByte() + (LAGame.gbROM.ReadByte() * 0x100));

            LAGame.gbROM.BufferLocation = ((0x741 + i) + (0x1C * 0x4000));
            int bank = LAGame.gbROM.ReadByte() & 0x3F;

            LAGame.gbROM.BufferLocation = ((bank * 0x4000) + (loc - 0x4000));
            textAddress = LAGame.gbROM.BufferLocation;
            nAddress.Value = textAddress;
        }
    }
}
