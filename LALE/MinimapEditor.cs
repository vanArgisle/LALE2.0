using LALE.Core;
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
    public partial class MinimapEditor : Form
    {
        public Game LAGame;
        private Color[] bwPalette = new Color[] { Color.White, Color.LightGray, Color.FromArgb(44, 50, 89), Color.Black };
        private Color[] chestPalette = new Color[] { Color.FromArgb(248, 248, 168), Color.FromArgb(216, 168, 32), Color.FromArgb(136, 80, 0), Color.Black };
        private Color[,] palette = new Color[8, 4];
        private byte selectedTile;
        private byte selectedPalette;
        private int index;
        private byte[] minimapData;
        private byte[] roomIndexes;
        private byte[] overworldPalette;

        public MinimapEditor(Game game)
        {
            LAGame = new Game(game);

            InitializeComponent();

            loadData();
            loadMinimaps();
            if (!LAGame.overworldFlag)
            {
                drawDungeonItems();
                this.Width = 270;
                this.Height = 277;
                gBoxDungeon.Visible = true;
                gBoxOverWorld.Visible = false;
                gBoxDungeon.Location = new Point(4, 4);
            }
            else
            {
                this.Width = 305;
                this.Height = 277;
                gBoxDungeon.Visible = false;
                gBoxOverWorld.Visible = true;
                drawOverworldItems();
                pTile.Image = drawOverworldTile();
            }

        }
        private void loadMinimaps()
        {
            MinimapLoader minimapLoader = new MinimapLoader(LAGame);
            TileDrawer tileDrawer = new TileDrawer();

            if (LAGame.overworldFlag)
            {
                pMinimapO.Image = tileDrawer.drawOverworldMinimapTiles(minimapLoader.loadMinimapOverworld(), minimapLoader.minimapGraphics, minimapLoader.overworldPal, minimapLoader.palette);
                overworldPalette = minimapLoader.overworldPal;
            }
            else
            {
                minimapLoader.loadMinimapDData();
                pMinimapD.Image = tileDrawer.drawDungeonMinimapTiles(minimapLoader.loadMinimapDungeon(), minimapLoader.minimapGraphics);
            }

            minimapData = minimapLoader.minimapGraphics;
            roomIndexes = minimapLoader.roomIndexes;

        }
        private void loadData()
        {
            if (!LAGame.overworldFlag)
            {
                if (LAGame.dungeon == 0xFF)
                {
                    nMap.Maximum = 0x15;
                    LAGame.gbROM.BufferLocation = 0x19B3;
                    nDeathMinimap.Value = LAGame.gbROM.ReadByte();
                    LAGame.gbROM.BufferLocation = 0x50E3D;
                    nDeathDungeon.Value = LAGame.gbROM.ReadByte();
                    nDeathMap.Value = LAGame.gbROM.ReadByte();
                    LAGame.gbROM.BufferLocation = 0x6E8D + (0xF * 2);
                    nArrow.Value = LAGame.gbROM.ReadByte() - 0xB;
                }
                else
                {
                    LAGame.gbROM.BufferLocation = 0x50E41 + LAGame.dungeon;
                    nDeathMinimap.Value = LAGame.gbROM.ReadByte();
                    LAGame.gbROM.BufferLocation = 0x6E8D + (LAGame.dungeon * 2);
                    nArrow.Value = LAGame.gbROM.ReadByte() - 0xB;
                    LAGame.gbROM.BufferLocation = 0x50DF2 + (LAGame.dungeon * 5);
                    nDeathDungeon.Value = LAGame.gbROM.ReadByte();
                    nDeathMap.Value = LAGame.gbROM.ReadByte();
                }
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x8786E;
                for (int i = 0; i < 8; i++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        palette[i, k] = LAGame.gbROM.GetRealColor(LAGame.gbROM.BufferLocation);
                    }
                }

            }
        }

        private void drawOverworldItems()
        {
            MinimapLoader minimapLoader = new MinimapLoader(LAGame);
            byte[,,] graphicsData = minimapLoader.loadMinimapOverworld();

            Bitmap bmp = new Bitmap(128, 64);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[128 * 64 * 4];
            fp.Lock();
            int i = 0;
            for (int y = 1; y < 8; y++)
            {
                for (int x = 0; x < 16; x++)
                {

                    for (int y1 = 0; y1 < 8; y1++)
                    {
                        for (int x1 = 0; x1 < 8; x1++)
                        {
                            if (y == 7 && x < 6)
                            {
                                fp.SetPixel(x1 + (x * 8), y1 + ((y - 1) * 8), palette[(byte)nPalette.Value, graphicsData[x + (y * 16), x1, y1]]);
                                fp.SetPixel(x1 + (x * 8), y1 + (y * 8), palette[(byte)nPalette.Value, graphicsData[x + 10 + ((y - 7) * 16), x1, y1]]);
                            }
                            else
                                fp.SetPixel(x1 + (x * 8), y1 + ((y - 1) * 8), palette[(byte)nPalette.Value, graphicsData[x + (y * 16), x1, y1]]);


                        }
                    }

                    i++;
                }
            }
            fp.Unlock(true);
            gridBoxOverworldTile.Image = bmp;

        }
        private void drawDungeonItems()
        {
            MinimapLoader minimapLoader = new MinimapLoader(LAGame);
            minimapLoader.loadMinimapDData();
            byte[,,] graphicsData = minimapLoader.loadMinimapDungeon();

            Bitmap bmp = new Bitmap(128, 128);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[128 * 128 * 4];
            fp.Lock();
            for (int x = 0; x < 4; x++)
            {
                for (int y1 = 0; y1 < 8; y1++)
                {
                    for (int x1 = 0; x1 < 8; x1++)
                    {
                        if (x == 0)
                            fp.SetPixel(x1 + (x * 8), y1, chestPalette[graphicsData[0, x1, y1]]);
                        else if (x == 3)
                            fp.SetPixel(x1 + (x * 8), y1, Color.FromArgb(44, 50, 89));
                        else
                            fp.SetPixel(x1 + (x * 8), y1, bwPalette[graphicsData[x, x1, y1]]);
                    }
                }
            }
            fp.Unlock(true);
            pTiles.Image = bmp;
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

        private void pTiles_MouseClick(object sender, MouseEventArgs e)
        {
            selectedTile = (byte)pTiles.SelectedIndex;
            if (e.Button == MouseButtons.Right)
                pTiles.SelectedIndex = -1;
        }

        private void pMinimapD_MouseDown(object sender, MouseEventArgs e)
        {
            int s = (e.X / 8) + ((e.Y / 8) * 8);
            index = s;
            nMap.Value = roomIndexes[s];
            if (pTiles.SelectedIndex != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Graphics g = Graphics.FromImage(pMinimapD.Image);
                    if (pTiles.SelectionRectangle.Width == 1 && pTiles.SelectionRectangle.Height == 1)
                    {
                        g.DrawImage(pTiles.Image, new Rectangle(e.X / 8 * 8, e.Y / 8 * 8, 8, 8), (selectedTile % 8) * 8, (selectedTile / 8) * 8, 8, 8, GraphicsUnit.Pixel);
                        if (pTiles.SelectedIndex != 3)
                        {
                            minimapData[index] = (byte)(pTiles.SelectedIndex + 0xED);
                            if (LAGame.dungeon == 0xFF)
                                LAGame.gbROM.WriteByte(0xA49A + (64 * 0x9) + index, (byte)(pTiles.SelectedIndex + 0xED));
                            else
                                LAGame.gbROM.WriteByte(0xA49A + (64 * LAGame.dungeon) + index, (byte)(pTiles.SelectedIndex + 0xED));
                        }
                        else
                        {
                            minimapData[index] = 0x7D;
                            if (LAGame.dungeon == 0xFF)
                                LAGame.gbROM.WriteByte(0xA49A + (64 * 0x9) + index, 0x7D);
                            else
                                LAGame.gbROM.WriteByte(0xA49A + (64 * LAGame.dungeon) + index, 0x7D);
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                selectedTile = minimapData[index];

                if (selectedTile == 0x7D)
                {
                    pTiles.SelectedIndex = 3;
                }
                else
                {
                    pTiles.SelectedIndex = selectedTile - 0xED;
                }

                selectedTile = (byte)pTiles.SelectedIndex;
            }
        }

        private void nMap_ValueChanged(object sender, EventArgs e)
        {
            roomIndexes[index] = (byte)nMap.Value;
            if (LAGame.dungeon == 0xFF)
            {
                LAGame.gbROM.WriteByte(0x504E0 + index, (byte)nMap.Value);
            }
            else
            {
                LAGame.gbROM.WriteByte(0x50220 + (64 * LAGame.dungeon) + index, (byte)nMap.Value);
            }
        }

        private void nArrow_ValueChanged(object sender, EventArgs e)
        {
            if (LAGame.dungeon == 0xFF)
                LAGame.gbROM.BufferLocation = 0x6E8D + (0xF * 2);
            else
                LAGame.gbROM.BufferLocation = 0x6E8D + (LAGame.dungeon * 2);
            LAGame.gbROM.WriteByte((byte)(nArrow.Value + 0xB));
        }

        private void nDeathMap_ValueChanged(object sender, EventArgs e)
        {
            if (LAGame.dungeon == 0xFF)
                LAGame.gbROM.BufferLocation = 0x50E3D + 1;
            else
                LAGame.gbROM.BufferLocation = 0x50DF2 + ((LAGame.dungeon * 5) + 1);

            LAGame.gbROM.WriteByte((byte)nDeathMap.Value);
        }

        private void nDeathDungeon_ValueChanged(object sender, EventArgs e)
        {
            if (LAGame.dungeon == 0xFF)
                LAGame.gbROM.BufferLocation = 0x50E3D;
            else
                LAGame.gbROM.BufferLocation = 0x50DF2 + (LAGame.dungeon * 5);

            LAGame.gbROM.WriteByte((byte)nDeathDungeon.Value);
        }

        private void nDeathMinimap_ValueChanged(object sender, EventArgs e)
        {
            if (LAGame.dungeon == 0xFF)
                LAGame.gbROM.BufferLocation = 0x19B3;
            else
                LAGame.gbROM.BufferLocation = 0x50E41 + LAGame.dungeon;
            LAGame.gbROM.WriteByte((byte)nDeathMinimap.Value);
        }

        private void nPalette_ValueChanged(object sender, EventArgs e)
        {
            selectedPalette = (byte)nPalette.Value;
            drawOverworldItems();
            pTile.Image = drawOverworldTile();
        }

        private void nTile_ValueChanged(object sender, EventArgs e)
        {
            selectedTile = (byte)nTile.Value;
            gridBoxOverworldTile.SelectedIndex = (byte)nTile.Value;
            pTile.Image = drawOverworldTile();
        }

        private Bitmap drawOverworldTile()
        {
            MinimapLoader minimapLoader = new MinimapLoader(LAGame);
            byte[,,] graphicsData = minimapLoader.loadMinimapOverworld();

            Bitmap bmp = new Bitmap(8, 8);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[8 * 8 * 4];
            fp.Lock();

            byte i;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    byte miniD = (byte)nTile.Value;
                    byte pal = (byte)nPalette.Value;
                    if (miniD == 0x70 || miniD == 0x71 || miniD == 0x72 || miniD == 0x73 || miniD == 0x74 || miniD == 0x75)
                        i = (byte)(miniD - 0x66);
                    else
                        i = (byte)(miniD + 16);
                    fp.SetPixel(x, y, palette[pal, graphicsData[i, x, y]]);
                }
            }
            fp.Unlock(true);
            return bmp;
        }

        private void gridBoxOverworldTile_MouseDown(object sender, MouseEventArgs e)
        {
            if (gridBoxOverworldTile.SelectedIndex <= 0x75)
                nTile.Value = gridBoxOverworldTile.SelectedIndex;
        }

        private void pMinimapO_MouseDown(object sender, MouseEventArgs e)
        {
            MinimapLoader minimapLoader = new MinimapLoader(LAGame);
            minimapLoader.loadMinimapOverworld();


            if (e.Button == MouseButtons.Right)
            {
                selectedTile = minimapData[(e.X / 8) + (e.Y / 8) * 16];
                selectedPalette = overworldPalette[((e.X / 8) + (e.Y / 8) * 16)];
                if (selectedTile > 0x6F)
                    selectedTile -= 0x8A;
                nTile.Value = selectedTile;
                nPalette.Value = selectedPalette;
            }
            else if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(pMinimapO.Image);
                g.DrawImage(pTile.Image, new Rectangle(e.X / 8 * 8, e.Y / 8 * 8, 8, 8));

                overworldPalette[((e.X / 8) + (e.Y / 8) * 16)] = selectedPalette;
                LAGame.gbROM.WriteByte((0x81797 + ((e.X / 8) + (e.Y / 8) * 16)), selectedPalette);
                if (selectedTile > 0x6F)
                    selectedTile += 0x8A;
                minimapData[(e.X / 8) + (e.Y / 8) * 16] = selectedTile;
                LAGame.gbROM.WriteByte(0x81697 + ((e.X / 8) + (e.Y / 8) * 16), selectedTile);
                if (selectedTile > 0x6F)
                    selectedTile -= 0x8A;
            }
        }

        private void pMinimapD_MouseMove(object sender, MouseEventArgs e)
        {
            lblHoverPos.Text = "Minimap Byte: " + ((e.X / 8) + ((e.Y / 8) * 8)).ToString("X");
        }

        private void MinimapEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
