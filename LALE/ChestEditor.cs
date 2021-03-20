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
    public partial class ChestEditor : Form
    {
        Game LAGame;
        private int location;
        public ChestEditor(Game game)
        {
            LAGame = game;
            InitializeComponent();
            loadChestData();
        }
        private void loadChestData()
        {
            setChestReadLocation();
            nItem.Value = LAGame.gbROM.ReadByte();
            labelChestLocation.Text = "Chest Location: 0x" + location.ToString("X");
        }

        private void setChestReadLocation()
        {
            if (LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x50560 + LAGame.map;
                location = LAGame.gbROM.BufferLocation;
            }
            else if (LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A && LAGame.dungeon != 0xFF)
            {
                LAGame.gbROM.BufferLocation = 0x50660 + LAGame.map;
                location = LAGame.gbROM.BufferLocation;
            }
            else if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
            {
                LAGame.gbROM.BufferLocation = 0x50760 + LAGame.map;
                location = LAGame.gbROM.BufferLocation;
            }
            else if (LAGame.dungeon == 0xFF)
            {
                LAGame.gbROM.BufferLocation = 0x50860 + LAGame.map;
                location = LAGame.gbROM.BufferLocation;

            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            setChestReadLocation();
            LAGame.gbROM.WriteByte((byte)nItem.Value);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
