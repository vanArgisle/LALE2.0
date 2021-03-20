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
    public partial class StartEditor : Form
    {
        Game LAGame;
        private byte dungeon;
        private byte map;
        private byte xPos;
        private byte yPos;
        private bool overworld;

        public StartEditor(Game game)
        {
            LAGame = game;
            InitializeComponent();
            getAndSetStartData();
        }

        private void getAndSetStartData()
        {
            LAGame.gbROM.BufferLocation = 0x53DE;
            xPos = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0x53E3;
            yPos = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0x53DA;
            dungeon = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0x53CB;
            map = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0x53D5;
            byte b = LAGame.gbROM.ReadByte();
            if (b == 0)
                overworld = true;
            else
                overworld = false;

            nDungeon.Value = dungeon;
            nMap.Value = map;
            nLinkXPos.Value = xPos;
            nLinkYPos.Value = yPos;
            cOverworld.Checked = overworld;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            LAGame.gbROM.BufferLocation = 0x53DE;
            LAGame.gbROM.WriteByte((byte)nLinkXPos.Value);
            LAGame.gbROM.BufferLocation = 0x53E3;
            LAGame.gbROM.WriteByte((byte)nLinkYPos.Value);
            LAGame.gbROM.BufferLocation = 0x53DA;
            LAGame.gbROM.WriteByte((byte)nDungeon.Value);
            LAGame.gbROM.BufferLocation = 0x53CB;
            LAGame.gbROM.WriteByte((byte)nMap.Value);
            LAGame.gbROM.BufferLocation = 0x53D5;
            if (cOverworld.Checked)
                LAGame.gbROM.WriteByte(0);
            else
                LAGame.gbROM.WriteByte(1);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cOverworld_CheckedChanged(object sender, EventArgs e)
        {
            if (cOverworld.Checked)
            {
                nDungeon.Enabled = false;
            }
            else
            {
                nDungeon.Enabled = true;            
            }
            nDungeon.Value = 0;
        }
    }
}
