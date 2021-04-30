using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE
{
    class Sprite
    {
        private Game LAGame;
        public byte spriteBank;
        private byte[] spriteInfo;
        private byte[] spriteGraphics;
        public byte[,,] spriteData;
        private Color[] bwPalette = new Color[] { Color.White, Color.LightGray, Color.DarkGray, Color.Black };
        private Color[,] palette = new Color[7, 4];
        public Sprite(Game game)
        {
            LAGame = game;
        }

        public void loadSpriteBanks()
        {
            LAGame.gbROM.BufferLocation = 0x830DB + LAGame.map;
            if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                LAGame.gbROM.BufferLocation = 0x831DB + LAGame.map;
            if (!LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation += 0x100;
            spriteBank = LAGame.gbROM.ReadByte();
            //nSpriteBank.Value = spriteBank;

            if (!LAGame.overworldFlag)
            {
                if (LAGame.dungeon == 0x10 && LAGame.map == 0xB5)
                    spriteBank = 0x3D;
            }
            //else
            //{
            //0x0DBD Look into??
            //}

            int a = (spriteBank << 2);
            if (LAGame.dungeon != 0xFF)
            {
                LAGame.gbROM.BufferLocation = 0x833FB + a;
                if (!LAGame.overworldFlag)
                    LAGame.gbROM.BufferLocation = 0x83643 + a;
                int loc = LAGame.gbROM.BufferLocation;

                int i = 0;
                byte h = LAGame.gbROM.ReadByte();
                spriteInfo = new byte[4];

                while (i < 4)
                {
                    if (h == 0xFF)
                        h = 0;
                    spriteInfo[i] = h;
                    h = LAGame.gbROM.ReadByte();
                    i++;
                }
            }
            else
                spriteInfo = new byte[4];
        }

        public void getSpriteLocation()
        {
            spriteGraphics = new byte[0x400];
            int skip = 0;

            for (int i = 0; i < 4; i++)
            {
                byte B1 = spriteInfo[i];

                if (B1 != 0)
                {
                    int b = (byte)(B1 & 0x3F);
                    int bank = ((((B1 & 0xF) * 0x10) + (B1 >> 4)) >> 2) & 3;

                    LAGame.gbROM.BufferLocation = 0x2E66 + bank;
                    byte B2 = LAGame.gbROM.ReadByte();
                    if (B2 != 0)
                    {
                        bank = (byte)(B2 | 0x20);
                    }
                    LAGame.gbROM.BufferLocation = (bank * 0x4000) + (b * 0x100);

                    for (int h = 0; h < 0x100; h++)
                    {
                        spriteGraphics[h + skip] = LAGame.gbROM.ReadByte();
                    }
                }
                skip += 0x100;
            }

            spriteData = new byte[64, 8, 8];
            LAGame.gbROM.ReadTiles(16, 4, spriteGraphics, ref spriteData);
        }

        public void loadPalette()
        {
            palette = LAGame.gbROM.GetPalette(0x85518);
        }

        public Bitmap drawSpritePair16(byte[] tileData, byte entityTileOffset)
        {
            Bitmap bmp = new Bitmap(16, 16);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[16 * 16 * 4];
            fp.Lock();

            loadPalette();

            int ctr;
            if (tileData == null)
            {
                for (int yy = 0; yy < 16; yy++)
                {
                    for (int xx = 0; xx < 16; xx++)
                    {
                        fp.SetPixel(xx, yy, Color.Black);
                    }
                }
                fp.Unlock(true);

                return bmp;
            }

            byte palOffset = 0;
            for (int i = 0; i < tileData.Length; i += 2)
            {
                palOffset = ((byte)(tileData[i + 1] & 0x0f));

                for (int y = 0; y < 8; y++)
                {
                    ctr = 7;
                    for (int x = 0; x < 8; x++)
                    {                           
                        if ((tileData[i + 1] & 0x60) == 0x60)
                        {
                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, ctr, ctr]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, ctr, ctr]]);
                            ctr--;
                        }
                        else if ((tileData[i + 1] & 0x20) == 0x20)
                        {

                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, ctr, y]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, ctr, y]]);
                            ctr--;
                        }
                        else if ((tileData[i + 1] & 0x40) == 0x40)
                        {
                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, x, ctr]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, x, ctr]]);
                            ctr--;
                        }
                        else
                        {
                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, x, y]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, x, y]]);
                        }
                    }
                }


            }
            
            fp.Unlock(true);
            if (spriteBank != 0)
                bmp.MakeTransparent(palette[palOffset, 0]);
            return bmp;
        }

        public void saveSpriteBank()
        {
            LAGame.gbROM.BufferLocation = 0x830DB + LAGame.map;
            if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                LAGame.gbROM.BufferLocation = 0x831DB + LAGame.map;
            if (!LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation += 0x100;
            LAGame.gbROM.WriteByte(spriteBank);
        }

    }
}
