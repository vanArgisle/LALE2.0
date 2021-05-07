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
    public partial class PaletteEditor : Form
    {
        public Game LAGame;
        private TileDrawer tileDrawer;
        private TilesetLoader tilesetLoader;
        private Color[,] palette;
        private byte originalMap;
        private byte originalDungeon;
        
        public PaletteEditor(Game game)
        {
            LAGame = new Game(game);
            tilesetLoader = new TilesetLoader(LAGame);
            tileDrawer = new TileDrawer();

            originalDungeon = LAGame.dungeon;
            originalMap = LAGame.map;

            InitializeComponent();

            if (LAGame.overworldFlag)
                nDungeon.Enabled = false;
            else
                nIndex.Enabled = false;

            loadPalette();
            loadTileset();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            LAGame.map = originalMap;
            LAGame.dungeon = originalDungeon;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nDungeon_ValueChanged(object sender, EventArgs e)
        {
            if (nDungeon.Value == 0xFF)
                nMap.Maximum = 0x15;
            else
                nMap.Maximum = 0xFF;

            LAGame.dungeon = (byte)nDungeon.Value;
            loadPalette();
            loadTileset();
        }

        private void loadTileset()
        {
            pTileset.Image = tileDrawer.drawTileset(tilesetLoader.loadTileset(), tilesetLoader.paletteTiles, tilesetLoader.formationData, palette);
        }
        private void loadPalette()
        {
            getPalette();
            drawPalette();
        }
        private void drawPalette()
        {
            Bitmap b = new Bitmap(128, 128);
            Graphics g = Graphics.FromImage(b);
            for (int k = 0; k < 8; k++)
                for (int i = 0; i < 4; i++)
                    g.FillRectangle(new SolidBrush(palette[k, i]), i * 32, k * 16, 32, 16);
            pPalette.Image = b;
        }

        private void getPalette()
        {
            tilesetLoader.loadPalette();
            palette = tilesetLoader.palette;
            if (LAGame.overworldFlag)
                nIndex.Value = tilesetLoader.paletteIndexOffset;
            labelPaletteLocation.Text = "Palette Location: 0x" + tilesetLoader.paletteLocation.ToString("X");
        }

        private void nMap_ValueChanged(object sender, EventArgs e)
        {
            LAGame.map = (byte)nMap.Value;
             if (LAGame.overworldFlag)
                nIndex.Value = tilesetLoader.paletteIndexOffset;
            loadPalette();
            loadTileset();
        }

        private void pPalette_MouseMove(object sender, MouseEventArgs e)
        {
            int i = pPalette.HoverIndex;
            labelRGB.Text = "R: " + palette[i / 4, i % 4].R / 8 + " G: " + palette[i / 4, i % 4].G / 8 + " B: " + palette[i / 4, i % 4].B / 8;
        }

        private void nIndex_ValueChanged(object sender, EventArgs e)
        {
            byte offset = (byte)nIndex.Value;
            if (LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x842B1 + ((offset * 2) & 0xFF);
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);

                palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                labelPaletteLocation.Text = "Palette Location: 0x" + LAGame.gbROM.BufferLocation.ToString("X");

                LAGame.gbROM.BufferLocation = 0x842EF + LAGame.map;
                LAGame.gbROM.WriteByte((byte)nIndex.Value);

            }
            drawPalette();
            loadTileset();
        }

        private void pPalette_MouseDown(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            int i = pPalette.HoverIndex;
            colorDialog.Color = palette[i / 4, i % 4];
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                int r = (int)(colorDialog.Color.R / 8 * 8);
                int g = (int)(colorDialog.Color.G / 8 * 8);
                int b = (int)(colorDialog.Color.B / 8 * 8);
                palette[i / 4, i % 4] = Color.FromArgb(r, g, b);

                LAGame.gbROM.BufferLocation = tilesetLoader.paletteLocation;
                if (LAGame.dungeon == 0xFF)
                    saveColorDungeonPalette();
                else
                    LAGame.gbROM.WritePalette(palette);

                drawPalette();
                loadTileset();
            }
        }

        private void saveColorDungeonPalette()
        {
            int r, g, blu;

            for (int k = 0; k < 8; k++)
            {
                if (k == 7)
                {
                    if (LAGame.map == 0x1 || LAGame.map == 0x7 || LAGame.map == 0x9)
                        LAGame.gbROM.BufferLocation = 0xDACF0;
                    else if (LAGame.map == 0x13 || LAGame.map == 0xF)
                        LAGame.gbROM.BufferLocation = 0xDACE0;
                }
                for (int i = 0; i < 4; i++)
                {
                    r = palette[k, i].R / 8;
                    g = palette[k, i].G / 8;
                    blu = palette[k, i].B / 8;
                    blu *= 4;
                    g *= 2;

                    blu *= 256;
                    g *= 16;
                    int value = r + g + blu;
                    LAGame.gbROM.WriteByte((byte)(value & 0xFF));
                    LAGame.gbROM.WriteByte((byte)(value >> 8));
                }
            }
        }
    }
}
