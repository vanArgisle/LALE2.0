using LALE.Tileset;
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
    public partial class MapData : Form
    {
        private Game LAGame;
        private TilesetLoader tilesetLoader;

        public MapData(Game gameValues)
        {
            InitializeComponent();

            LAGame = gameValues;
            tilesetLoader = new TilesetLoader(LAGame);

            getSOGOffset();
            numericUpDownSOG.Value = LAGame.gbROM.ReadByte();
            getAnimationsOffset();
            numericUpDownAnimations.Value = LAGame.gbROM.ReadByte();

            getMusicOffset();
            numericUpDownMusic.Value = LAGame.gbROM.ReadByte();
            
            getTilePresetOffset();
            numericUpDownPresetTiles.Value = LAGame.gbROM.ReadByte(); 

            drawMapAndTiles();
        }

        private void drawMapAndTiles()
        {
            TileDrawer tileDrawer = new TileDrawer();
            tilesetLoader.loadPalette();

            gridBoxTileset.Image = tileDrawer.drawTileset(tilesetLoader.loadTileset(), tilesetLoader.paletteTiles, tilesetLoader.formationData, tilesetLoader.palette);

            byte[] mapData = new byte[80];
            for (int i = 0; i < 80; i++)
                mapData[i] = (byte)(numericUpDownPresetTiles.Value);
            gridBoxMap.Image = tileDrawer.drawMap((Bitmap)gridBoxTileset.Image, mapData);
        }

        private void numericUpDownSOG_ValueChanged(object sender, EventArgs e)
        {
            getSOGOffset();
            LAGame.gbROM.WriteByte((byte)numericUpDownSOG.Value);

            drawMapAndTiles();
        }

        private void numericUpDownAnimations_ValueChanged(object sender, EventArgs e)
        {
            getAnimationsOffset();
            LAGame.gbROM.WriteByte((byte)numericUpDownAnimations.Value);

            drawMapAndTiles();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void getMusicOffset()
        {
            LAGame.gbROM.BufferLocation = 0x8000 + LAGame.map;
        }

        private void getTilePresetOffset()
        {
            int secondhalf;
            int i = -1;
            if (LAGame.specialFlag)
            {
                switch (LAGame.map)
                {
                    case 0x06: i = 0x31F4; break;
                    case 0x0E: i = 0x31C4; break;
                    case 0x1B: i = 0x3204; break;
                    case 0x2B: i = 0x3214; break;
                    case 0x79: i = 0x31E4; break;
                    case 0x8C: i = 0x31D4; break;
                }
            }
            if (i > 0)
            {
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i) + 1;
                if (LAGame.map > 0x7F)
                    secondhalf += 0x68000;
                else
                    secondhalf += 0x24000;
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            else
            {
                secondhalf = 0x24000 + (LAGame.map * 2);
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf) + 1;
                if (LAGame.map > 0x7F)
                    secondhalf = 0x68000 + (secondhalf - 0x24000);
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            //byte TilePreset = LAGame.gbROM.ReadByte();
            //byte[] TilePreset = new byte[2];
            //TilePreset[0] = (byte)(b & 0xF); //Floor
            //TilePreset[1] = (byte)(b >> 4); //Wall
            //return TilePreset;
        }

        private void numericUpDownPresetTiles_ValueChanged(object sender, EventArgs e)
        {
            gridBoxTileset.SelectedIndex = (byte)numericUpDownPresetTiles.Value;

            getTilePresetOffset();
            LAGame.gbROM.WriteByte((byte)numericUpDownPresetTiles.Value);

            drawMapAndTiles();
        }

        private void numericUpDownMusic_ValueChanged(object sender, EventArgs e)
        {
            getMusicOffset();
            LAGame.gbROM.WriteByte((byte)numericUpDownMusic.Value);
        }

        private void gridBoxTileset_Click(object sender, EventArgs e)
        {
            numericUpDownPresetTiles.Value = gridBoxTileset.SelectedIndex;
        }

        private void getSOGOffset()
        {
            if (LAGame.overworldFlag)
            {
                //0x9000-0x9200
                int map = LAGame.map;
                if (LAGame.map == 0x7)
                    map++;
                byte b = (byte)((map >> 2) & 0xF8);
                byte b1 = (byte)(((map >> 1) & 0x07) | b);
                LAGame.gbROM.BufferLocation = 0x82E7B + b1;
            }
            else
            {
                //0x9000-0x9100
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x82FBB + LAGame.map;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x830BB + LAGame.map;
                else
                    LAGame.gbROM.BufferLocation = 0x82EBB + LAGame.map;
            }
        }

        private void getAnimationsOffset()
        {
            if (LAGame.overworldFlag)
            {
                int i = -1;
                int secondhalf;
                if (LAGame.specialFlag)
                {
                    switch (LAGame.map)
                    {
                        case 0x06: i = 0x31F4; break;
                        case 0x0E: i = 0x31C4; break;
                        case 0x1B: i = 0x3204; break;
                        case 0x2B: i = 0x3214; break;
                        case 0x79: i = 0x31E4; break;
                        case 0x8C: i = 0x31D4; break;
                    }
                }
                if (i > 0)
                {
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                    if (LAGame.map > 0x7F)
                        secondhalf += 0x68000;
                    else
                        secondhalf += 0x24000;
                    LAGame.gbROM.BufferLocation = secondhalf;
                }
                else
                {
                    LAGame.gbROM.BufferLocation = 0x24000 + (LAGame.map * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    if (LAGame.map > 0x7F)
                        LAGame.gbROM.BufferLocation = 0x68000 + (LAGame.gbROM.BufferLocation - 0x24000);
                }
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x28000;
                if (LAGame.dungeon >= 0x06 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation += 0x4000;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x2BB77;
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get3BytePointerAtAddress(LAGame.gbROM.BufferLocation + (LAGame.map * 2));
            }
        }
    }
}
