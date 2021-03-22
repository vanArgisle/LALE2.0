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
    public partial class OwlStatueEditor : Form
    {
        private Game LAGame;
        private int index;
        public OwlStatueEditor(Game game)
        {
            LAGame = game;
            InitializeComponent();
            cDungeon.SelectedIndex = 0;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                if (cDungeon.SelectedIndex != 8)
                {
                    LAGame.gbROM.BufferLocation = 0xD8A3C + ((cDungeon.SelectedIndex << 1) & 0xFF);
                    LAGame.gbROM.BufferLocation = (LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation)) + index;
                    LAGame.gbROM.WriteByte((byte)nMap.Value);

                    LAGame.gbROM.BufferLocation = 0xD8A14 + ((cDungeon.SelectedIndex << 1) & 0xFF);
                    LAGame.gbROM.BufferLocation = (LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation)) + lMaps.SelectedIndex;
                    LAGame.gbROM.WriteByte((byte)nPointer.Value);
                }
                else
                    LAGame.gbROM.WriteByte(0x61EB5, (byte)nPointer.Value);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cDungeon_SelectedIndexChanged(object sender, EventArgs e)
        {
            lMaps.Items.Clear();
            index = -1;
            nMap.Enabled = false;
            nPointer.Enabled = false;
            nMap.Value = 0;
            nPointer.Value = 0;
            int dungeon = cDungeon.SelectedIndex;
            if (dungeon != 0x8)
            {
                int q = 0;
                for (int i = 0; i < 3; i++)
                {
                    q++;
                    lMaps.Items.Add(q.ToString());
                }
            }
            else
            {
                lMaps.Items.Add(1.ToString());
            }
        }

        private void lMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = lMaps.SelectedIndex;
            if (index != -1)
            {
                nMap.Enabled = true;
                nPointer.Enabled = true;
            }
            if (cDungeon.SelectedIndex != 8)
            {
                LAGame.gbROM.BufferLocation = 0xD8A14 + ((cDungeon.SelectedIndex << 1) & 0xFF);
                LAGame.gbROM.BufferLocation = (LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation)) + lMaps.SelectedIndex;
                nPointer.Value = LAGame.gbROM.ReadByte();

                LAGame.gbROM.BufferLocation = 0xD8A3C + ((cDungeon.SelectedIndex << 1) & 0xFF);
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                nMap.Value = LAGame.gbROM.ReadByte(LAGame.gbROM.BufferLocation + lMaps.SelectedIndex);
            }
            else
            {
                nPointer.Value = LAGame.gbROM.ReadByte(0x61EB5);
                nMap.Enabled = false;
            }
        }
    }
}
