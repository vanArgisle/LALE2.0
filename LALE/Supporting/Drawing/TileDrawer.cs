using LALE.Supporting;
using LALE.Tileset;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE
{
    class TileDrawer
    {
        public Bitmap drawTileset(byte[,,] graphicsData, TilesetLoader.Tile[] tiles, byte[,] formationData, Color[,] palette)
        {
            Bitmap bmp = new Bitmap(256, 256);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[256 * 256 * 4];
            fp.Lock();
            for (int tile = 0; tile < 256; tile++)
            {
                for (int corner = 0; corner < 4; corner++)
                {
                    byte i = formationData[tile, corner];
                    TilesetLoader.Tile t = tiles[tile];
                    if (i >= 0xB0 && i < 0xB4 || i == 0xC0)
                        i -= i;

                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            Color pal = palette[t.palette[corner] % 8, graphicsData[(byte)(i + 0x10), x, y]];
                            int mainX = (tile % 16) * 16;
                            int mainY = (tile / 16) * 16;
                            int xx = mainX + ((corner % 2) * 8) + x;
                            int yy = mainY + ((corner / 2) * 8) + y;
                            if (t.hFlip[corner])
                                xx = mainX + ((corner % 2) * 8) + (7 - x);
                            if (t.vFlip[corner])
                                yy = mainY + ((corner / 2) * 8) + (7 - y);
                            fp.SetPixel(xx, yy, pal);
                        }
                    }
                }
            }
            fp.Unlock(true);
            return bmp;
        }


        public Bitmap drawMap(Bitmap tiles, byte[] mapData)
        {
            Bitmap bmp = new Bitmap(160, 128);
            FastPixel fp = new FastPixel(bmp);
            FastPixel src = new FastPixel(tiles);
            fp.rgbValues = new byte[160 * 128 * 4];
            src.rgbValues = new byte[256 * 256 * 4];
            fp.Lock();
            src.Lock();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    byte v = mapData[x + (y * 10)];

                    for (int yy = 0; yy < 16; yy++)
                    {
                        for (int xx = 0; xx < 16; xx++)
                        {
                            fp.SetPixel(x * 16 + xx, y * 16 + yy, src.GetPixel((v % 16) * 16 + xx, (v / 16) * 16 + yy));
                        }
                    }
                }
            }
            fp.Unlock(true);
            src.Unlock(true);

            return bmp;
        }

        public Bitmap drawBorders(Bitmap image, List<CollisionObject> objects)
        {
            FastPixel fp = new FastPixel(image);
            Color border;
            fp.rgbValues = new byte[160 * 128 * 4];
            fp.Lock();
            foreach (CollisionObject obj in objects)
            {
                if (obj.is3Byte && !obj.multiTileFlag && obj.direction == 8)
                    border = Color.DarkRed;
                else if (obj.is3Byte && !obj.multiTileFlag && obj.direction == 0xC)
                    border = Color.DarkBlue;
                else if (obj.is3Byte && obj.multiTileFlag && obj.direction == 8)
                    border = Color.DarkGoldenrod;
                else if (obj.is3Byte && obj.multiTileFlag && obj.direction == 0xC)
                    border = Color.Purple;
                else if (!obj.is3Byte && !obj.multiTileFlag)
                    border = Color.DarkGreen;
                else
                    border = Color.DeepPink;
                int x = obj.xPos * 16;
                int y = obj.yPos * 16;
                if (obj.hFlip)
                    x = -16;
                if (obj.vFlip)
                    y = -16;
                bool v = false;
                bool h = false;
                if (!obj.is3Byte && !obj.multiTileFlag)
                {
                    if (obj.xPos > 9 || obj.yPos > 7)
                        continue;
                }
                if (!obj.is3Byte)
                {
                    if (!obj.multiTileFlag)
                    {
                        for (int yy = 0; yy < 16; yy++)
                        {
                            for (int xx = 0; xx < 16; xx++)
                            {
                                if (yy > 0 && yy != 15)
                                {
                                    if (xx == 0 || xx == 15)
                                    {
                                        fp.SetPixel(x + xx, y + yy, border);
                                    }
                                }
                                else
                                {
                                    fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int yy = 0; yy < obj.height * 16; yy++)
                        {
                            for (int xx = 0; xx < obj.width * 16; xx++)
                            {
                                if (x < 0 && !h)
                                {
                                    xx = xx + 16;
                                    h = true;
                                }
                                if (y < 0 && !v)
                                {
                                    yy = yy + 16;
                                    v = true;
                                }
                                if (x + xx >= 160 || x + xx < 0)
                                    continue;
                                if (y + yy >= 128 || y + yy < 0)
                                    continue;
                                if (yy > 0 && yy != ((obj.height * 16) - 1))
                                {
                                    if (xx == 0 || xx == (obj.width * 16) - 1)
                                        fp.SetPixel(x + xx, y + yy, border);
                                }
                                else
                                    fp.SetPixel(x + xx, y + yy, border);
                            }
                        }
                    }
                }
                else
                {
                    if (!obj.multiTileFlag)
                    {
                        if (obj.direction == 8)
                        {
                            for (int yy = 0; yy < 16; yy++)
                            {
                                for (int xx = 0; xx < (obj.length * 16); xx++)
                                {
                                    if (x < 0 && !h)
                                    {
                                        xx = xx + 16;
                                        h = true;
                                    }
                                    if (y < 0 && !v)
                                    {
                                        yy = yy + 16;
                                        v = true;
                                    }
                                    if (x + xx >= 160 || x + xx < 0)
                                        continue;
                                    if (y + yy >= 128 || y + yy < 0)
                                        continue;
                                    if (yy > 0 && yy != 15)
                                    {
                                        if (xx == 0 || xx == (obj.length * 16) - 1)
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                    else
                                        fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                        }
                        else
                        {
                            for (int yy = 0; yy < obj.length * 16; yy++)
                            {
                                for (int xx = 0; xx < 16; xx++)
                                {
                                    if (x < 0 && !h)
                                    {
                                        xx = xx + 16;
                                        h = true;
                                    }
                                    if (y < 0 && !v)
                                    {
                                        yy = yy + 16;
                                        v = true;
                                    }
                                    if (x + xx >= 160 || x + xx < 0)
                                        continue;
                                    if (y + yy >= 128 || y + yy < 0)
                                        continue;
                                    if (yy > 0 && yy != (obj.length * 16) - 1)
                                    {
                                        if (xx == 0 || xx == 15)
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                    else
                                        fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (obj.direction == 8)
                        {
                            for (int i = 0; i < obj.length; i++)
                            {
                                for (int yy = 0; yy < obj.height * 16; yy++)
                                {
                                    for (int xx = 0 + (i * 16); xx < obj.width * (obj.length * 16); xx++)
                                    {
                                        if (x < 0 && !h)
                                        {
                                            xx = xx + 16;
                                            h = true;
                                        }
                                        if (y < 0 && !v)
                                        {
                                            yy = yy + 16;
                                            v = true;
                                        }
                                        if (x + xx >= 160 || x + xx < 0)
                                            continue;
                                        if (y + yy >= 128 || y + yy < 0)
                                            continue;
                                        if (yy > 0 && yy != ((obj.height * 16) - 1))
                                        {
                                            if (xx == 0 || xx == ((obj.length * 16) * obj.width) - 1)
                                                fp.SetPixel(x + xx, y + yy, border);
                                        }
                                        else
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < obj.length; i++)
                            {
                                for (int yy = 0 + (i * 16); yy < obj.height * (obj.length * 16); yy++)
                                {
                                    for (int xx = 0; xx < obj.width * 16; xx++)
                                    {
                                        if (x < 0 && !h)
                                        {
                                            xx = xx + 16;
                                            h = true;
                                        }
                                        if (y < 0 && !v)
                                        {
                                            yy = yy + 16;
                                            v = true;
                                        }
                                        if (x + xx >= 160 || x + xx < 0)
                                            continue;
                                        if (y + yy >= 128 || y + yy < 0)
                                            continue;
                                        if (yy > 0 && yy != ((obj.length * 16) * obj.height) - 1)
                                        {
                                            if (xx == 0 || xx == (obj.width * 16) - 1)
                                                fp.SetPixel(x + xx, y + yy, border);
                                        }
                                        else
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            fp.Unlock(true);
            return image;
        }

        public Bitmap drawSelectedObject(Bitmap image, List<CollisionObject> collisionObjects, int selectedObjectIndex)
        {
            FastPixel fp = new FastPixel(image);
            Color border = Color.White;
            fp.rgbValues = new byte[160 * 128 * 4];
            fp.Lock();
            CollisionObject selected = collisionObjects[selectedObjectIndex];
            foreach (CollisionObject obj in collisionObjects)
            {
                if (obj.xPos != selected.xPos)
                    continue;
                if (obj.yPos != selected.yPos)
                    continue;
                if (obj.direction != selected.direction)
                    continue;
                if (obj.length != selected.length)
                    continue;
                if (obj.id != selected.id)
                    continue;
                int x = obj.xPos * 16;
                int y = obj.yPos * 16;
                if (obj.hFlip)
                    x = -16;
                if (obj.vFlip)
                    y = -16;
                bool v = false;
                bool h = false;
                if (!obj.is3Byte && !obj.multiTileFlag)
                {
                    if (obj.xPos > 9 || obj.yPos > 7)
                        continue;
                }
                if (!obj.is3Byte)
                {
                    if (!obj.multiTileFlag)
                    {
                        for (int yy = 0; yy < 16; yy++)
                        {
                            for (int xx = 0; xx < 16; xx++)
                            {
                                if (yy > 0 && yy != 15)
                                {
                                    if (xx == 0 || xx == 15)
                                    {
                                        fp.SetPixel(x + xx, y + yy, border);
                                    }
                                }
                                else
                                {
                                    fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int yy = 0; yy < obj.height * 16; yy++)
                        {
                            for (int xx = 0; xx < obj.width * 16; xx++)
                            {
                                if (x < 0 && !h)
                                {
                                    xx = xx + 16;
                                    h = true;
                                }
                                if (y < 0 && !v)
                                {
                                    yy = yy + 16;
                                    v = true;
                                }
                                if (x + xx >= 160 || x + xx < 0)
                                    continue;
                                if (y + yy >= 128 || y + yy < 0)
                                    continue;
                                if (yy > 0 && yy != ((obj.height * 16) - 1))
                                {
                                    if (xx == 0 || xx == (obj.width * 16) - 1)
                                        fp.SetPixel(x + xx, y + yy, border);
                                }
                                else
                                    fp.SetPixel(x + xx, y + yy, border);
                            }
                        }
                    }
                }
                else
                {
                    if (!obj.multiTileFlag)
                    {
                        if (obj.direction == 8)
                        {
                            for (int yy = 0; yy < 16; yy++)
                            {
                                for (int xx = 0; xx < (obj.length * 16); xx++)
                                {
                                    if (x < 0 && !h)
                                    {
                                        xx = xx + 16;
                                        h = true;
                                    }
                                    if (y < 0 && !v)
                                    {
                                        yy = yy + 16;
                                        v = true;
                                    }
                                    if (x + xx >= 160 || x + xx < 0)
                                        continue;
                                    if (y + yy >= 128 || y + yy < 0)
                                        continue;
                                    if (yy > 0 && yy != 15)
                                    {
                                        if (xx == 0 || xx == (obj.length * 16) - 1)
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                    else
                                        fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                        }
                        else
                        {
                            for (int yy = 0; yy < obj.length * 16; yy++)
                            {
                                for (int xx = 0; xx < 16; xx++)
                                {
                                    if (x < 0 && !h)
                                    {
                                        xx = xx + 16;
                                        h = true;
                                    }
                                    if (y < 0 && !v)
                                    {
                                        yy = yy + 16;
                                        v = true;
                                    }
                                    if (x + xx >= 160 || x + xx < 0)
                                        continue;
                                    if (y + yy >= 128 || y + yy < 0)
                                        continue;
                                    if (yy > 0 && yy != (obj.length * 16) - 1)
                                    {
                                        if (xx == 0 || xx == 15)
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                    else
                                        fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (obj.direction == 8)
                        {
                            for (int i = 0; i < obj.length; i++)
                            {
                                for (int yy = 0; yy < obj.height * 16; yy++)
                                {
                                    for (int xx = 0 + (i * 16); xx < obj.width * (obj.length * 16); xx++)
                                    {
                                        if (x < 0 && !h)
                                        {
                                            xx = xx + 16;
                                            h = true;
                                        }
                                        if (y < 0 && !v)
                                        {
                                            yy = yy + 16;
                                            v = true;
                                        }
                                        if (x + xx >= 160 || x + xx < 0)
                                            continue;
                                        if (y + yy >= 128 || y + yy < 0)
                                            continue;
                                        if (yy > 0 && yy != ((obj.height * 16) - 1))
                                        {
                                            if (xx == 0 || xx == ((obj.length * 16) * obj.width) - 1)
                                                fp.SetPixel(x + xx, y + yy, border);
                                        }
                                        else
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < obj.length; i++)
                            {
                                for (int yy = 0 + (i * 16); yy < obj.height * (obj.length * 16); yy++)
                                {
                                    for (int xx = 0; xx < obj.width * 16; xx++)
                                    {
                                        if (x < 0 && !h)
                                        {
                                            xx = xx + 16;
                                            h = true;
                                        }
                                        if (y < 0 && !v)
                                        {
                                            yy = yy + 16;
                                            v = true;
                                        }
                                        if (x + xx >= 160 || x + xx < 0)
                                            continue;
                                        if (y + yy >= 128 || y + yy < 0)
                                            continue;
                                        if (yy > 0 && yy != ((obj.length * 16) * obj.height) - 1)
                                        {
                                            if (xx == 0 || xx == (obj.width * 16) - 1)
                                                fp.SetPixel(x + xx, y + yy, border);
                                        }
                                        else
                                            fp.SetPixel(x + xx, y + yy, border);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            fp.Unlock(true);
            return image;
        }

        public Bitmap drawOverworldMinimapTiles(byte[,,] graphicsData, byte[] minimapGraphics, byte[] overworldPal, Color[,] palette)
        {
            Bitmap bmp = new Bitmap(128, 128);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[128 * 128 * 4];
            fp.Lock();
            byte i;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    byte miniD = minimapGraphics[x + (y * 16)];
                    if (miniD == 0xFF || miniD == 0xFE || miniD == 0xFD || miniD == 0xFC || miniD == 0xFB || miniD == 0xFA)
                        i = (byte)(miniD - 0xF0);
                    else
                        i = (byte)(miniD + 16);
                    for (int y1 = 0; y1 < 8; y1++)
                    {
                        for (int x1 = 0; x1 < 8; x1++)
                            fp.SetPixel(x1 + (x * 8), y1 + (y * 8), palette[overworldPal[x + (y * 16)], graphicsData[i, x1, y1]]);
                    }
                }
            }
            fp.Unlock(true);
            return bmp;
        }

        public Bitmap drawDungeonMinimapTiles(byte[,,] graphicsData, byte[] minimapGraphics)
        {
            Color[] bwPalette = new Color[] { Color.White, Color.LightGray, Color.FromArgb(44, 50, 89), Color.Black };
            Color[] chestPalette = new Color[] { Color.FromArgb(248, 248, 168), Color.FromArgb(216, 168, 32), Color.FromArgb(136, 80, 0), Color.Black };

            Bitmap bmp = new Bitmap(128, 128);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[128 * 128 * 4];
            fp.Lock();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    byte miniD = minimapGraphics[x + (y * 8)];
                    for (int y1 = 0; y1 < 8; y1++)
                    {
                        for (int x1 = 0; x1 < 8; x1++)
                        {
                            if (miniD == 0xEF) //Regular room
                                fp.SetPixel(x1 + (x * 8), y1 + (y * 8), bwPalette[graphicsData[2, x1, y1]]);
                            else if (miniD == 0x7D) //Empty room
                                fp.SetPixel(x1 + (x * 8), y1 + (y * 8), Color.FromArgb(44, 50, 89));
                            else if (miniD == 0xED) //Chest room
                                fp.SetPixel(x1 + (x * 8), y1 + (y * 8), chestPalette[graphicsData[0, x1, y1]]);
                            else if (miniD == 0xEE) //Boss room
                                fp.SetPixel(x1 + (x * 8), y1 + (y * 8), bwPalette[graphicsData[1, x1, y1]]);
                        }
                    }
                }
            }
            fp.Unlock(true);
            return bmp;
        }

        public Bitmap drawSelectedEntity(Bitmap image, Entity selectedEntity)
        {
            FastPixel fp = new FastPixel(image);
            Color border = Color.White;
            fp.rgbValues = new byte[160 * 128 * 4];
            fp.Lock();

            int x = selectedEntity.xPos * 16;
            int y = selectedEntity.yPos * 16;

            if (selectedEntity.yPos < 8)
            {
                if (selectedEntity.xPos < 10)
                {
                    for (int yy = 0; yy < 16; yy++)
                    {
                        for (int xx = 0; xx < 16; xx++)
                        {
                            if (yy > 0 && yy != 15)
                            {
                                if (xx == 0 || xx == 15)
                                {
                                    fp.SetPixel(x + xx, y + yy, border);
                                }
                            }
                            else
                            {
                                fp.SetPixel(x + xx, y + yy, border);
                            }
                        }
                    }
                }
            }

            fp.Unlock(true);
            return image;
        }

        public Bitmap drawEntities(Bitmap image, List<Entity> entities)
        {
            FastPixel fp = new FastPixel(image);
            fp.rgbValues = new byte[160 * 128 * 4];
            fp.Lock();


            foreach (Entity selectedEntity in entities)
            {
                FastPixel src = new FastPixel(selectedEntity.sprite);
                src.rgbValues = new byte[16 * 16 * 4];
                src.Lock();

                int x = selectedEntity.xPos * 16;
                int y = selectedEntity.yPos * 16;

                if (selectedEntity.yPos < 8)
                {
                    if (selectedEntity.xPos < 10)
                    {
                        for (int yy = 0; yy < 16; yy++)
                        {
                            for (int xx = 0; xx < 16; xx++)
                            {
                                try
                                {
                                    if (src.GetPixel(xx, yy).A == 0)
                                        continue;
                                    fp.SetPixel(x + xx, y + yy, src.GetPixel(xx, yy));
                                }
                                catch
                                {
                                    System.Console.WriteLine("Out of bounds Y or X position.");
                                    break;
                                }
                            }
                        }
                    }
                }
                src.Unlock(true);
            }


            fp.Unlock(true);
            return image;
        }
    }
}
