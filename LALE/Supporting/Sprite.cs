using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE
{
    public class Sprite
    {
        private Game LAGame;
        public byte spriteBank;
        public byte[] colourDungeonSpriteBanks;
        public byte[] spriteInfo;
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
            if (LAGame.dungeon != 0xFF)
            {
                LAGame.gbROM.BufferLocation = 0x830DB + LAGame.map;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x831DB + LAGame.map;
                if (!LAGame.overworldFlag)
                    LAGame.gbROM.BufferLocation += 0x100;
            }

            //Camera shop
            if (LAGame.dungeon == 0x10 && LAGame.map == 0xB5)
                LAGame.gbROM.BufferLocation = 0x0DBA;

            if (LAGame.dungeon == 0xFF)
                spriteBank = 0;
            else
                spriteBank = LAGame.gbROM.ReadByte();

            getSpritesheets();
        }

        public void getSpriteLocation()
        {
            spriteGraphics = new byte[0x400];
            int skip = 0;

            for (int i = 0; i < 4; i++)
            {
                byte B1 = spriteInfo[i];
                if (B1 == 0xFF)
                    B1 = 0;

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
                    if (LAGame.dungeon == 0xFF)
                        bank = colourDungeonSpriteBanks[i];

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
                        if ((tileData[i + 1] & 0x60) == 0x60) //Y and X Flip
                        {
                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, ctr, ctr]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, ctr, ctr]]);
                            ctr--;
                        }
                        else if ((tileData[i + 1] & 0x20) == 0x20)//X Flip
                        {

                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, ctr, y]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, ctr, y]]);
                            ctr--;
                        }
                        else if ((tileData[i + 1] & 0x40) == 0x40)//Y Flip
                        {
                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, x, ctr]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, x, ctr]]);
                            ctr--;
                        }
                        else //Normal
                        {
                            fp.SetPixel(x + ((i / 2) * 8), y, palette[palOffset, spriteData[tileData[i] + entityTileOffset - 0x40, x, y]]);
                            fp.SetPixel(x + ((i / 2) * 8), y + 8, palette[palOffset, spriteData[tileData[i] + 1 + entityTileOffset - 0x40, x, y]]);
                        }
                    }
                }
            }
            
            fp.Unlock(true);
            if (spriteBank != 0 || LAGame.dungeon == 0xFF)
                bmp.MakeTransparent(palette[palOffset, 0]);
            return bmp;
        }

        public void saveSpriteBank()
        {
            if (LAGame.dungeon != 0xFF)
            {
                LAGame.gbROM.BufferLocation = 0x830DB + LAGame.map;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x831DB + LAGame.map;
                if (!LAGame.overworldFlag)
                    LAGame.gbROM.BufferLocation += 0x100;

                if (LAGame.dungeon == 0x10 && LAGame.map == 0xB5)
                {
                    LAGame.gbROM.BufferLocation = 0x0DBA;
                }

                LAGame.gbROM.WriteByte(spriteBank);
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x806AA + (LAGame.map * 2) + 1; //First sprite graphics bank
                LAGame.gbROM.WriteByte(colourDungeonSpriteBanks[0]);
                LAGame.gbROM.BufferLocation = 0x806D6 + (LAGame.map * 2) + 1; //Second sprite graphics bank
                LAGame.gbROM.WriteByte(colourDungeonSpriteBanks[1]);
                LAGame.gbROM.BufferLocation = 0x80702 + (LAGame.map * 2) + 1; //Third sprite graphics bank
                LAGame.gbROM.WriteByte(colourDungeonSpriteBanks[2]);
                LAGame.gbROM.BufferLocation = 0x8072E + (LAGame.map * 2) + 1; //Fourth sprite graphics bank
                LAGame.gbROM.WriteByte(colourDungeonSpriteBanks[3]);
            }
        }

        public Bitmap drawSprites(int row)
        {
            Bitmap bmp = new Bitmap(128, 8);
            FastPixel fp = new FastPixel(bmp);
            fp.rgbValues = new byte[128 * 8 * 4];
            fp.Lock();
            for (int i = row * 16; i < (16 * (row + 1)); i++)
            {

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        fp.SetPixel(x + ((i % 16) * 8), y, bwPalette[spriteData[i, x, y]]);
                    }
                }

            }
            fp.Unlock(true);

            return bmp;
        }

        public void saveSpritesheets()
        {
            if (LAGame.dungeon != 0xFF)
            {
                int a = (spriteBank << 2);
                LAGame.gbROM.BufferLocation = 0x833FB + a;
                if (!LAGame.overworldFlag)
                    LAGame.gbROM.BufferLocation = 0x83643 + a;
                int loc = LAGame.gbROM.BufferLocation;

                int i = 0;

                while (i < 4)
                {
                    LAGame.gbROM.WriteByte(spriteInfo[i]);
                    i++;
                }
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x806AA + (LAGame.map * 2); //First spritesheet
                LAGame.gbROM.WriteByte(spriteInfo[0]);
                LAGame.gbROM.BufferLocation = 0x806D6 + (LAGame.map * 2); //Second spritesheet
                LAGame.gbROM.WriteByte(spriteInfo[1]);
                LAGame.gbROM.BufferLocation = 0x80702 + (LAGame.map * 2); //Third spritesheet
                LAGame.gbROM.WriteByte(spriteInfo[2]);
                LAGame.gbROM.BufferLocation = 0x8072E + (LAGame.map * 2); //Fourth spritesheet
                LAGame.gbROM.WriteByte(spriteInfo[3]);
            }
        }

        public void getSpritesheets()
        {

            //Grab spritesheets using the spritebank.
            if (LAGame.dungeon != 0xFF)
            {
                int a = (spriteBank << 2);
                LAGame.gbROM.BufferLocation = 0x833FB + a;
                if (!LAGame.overworldFlag)
                    LAGame.gbROM.BufferLocation = 0x83643 + a;
                int loc = LAGame.gbROM.BufferLocation;

                int i = 0;
                byte h = LAGame.gbROM.ReadByte();
                spriteInfo = new byte[4];

                while (i < 4)
                {
                    spriteInfo[i] = h;
                    h = LAGame.gbROM.ReadByte();
                    i++;
                }
            }
            else //Grab colour dungeon sprite graphics banks and sprite sheets
            {
                spriteInfo = new byte[4];
                colourDungeonSpriteBanks = new byte[4];

                LAGame.gbROM.BufferLocation = 0x806AA + (LAGame.map * 2); //First spritesheet
                spriteInfo[0] = LAGame.gbROM.ReadByte();
                colourDungeonSpriteBanks[0] = LAGame.gbROM.ReadByte();
                LAGame.gbROM.BufferLocation = 0x806D6 + (LAGame.map * 2); //Second spritesheet
                spriteInfo[1] = LAGame.gbROM.ReadByte();
                colourDungeonSpriteBanks[1] = LAGame.gbROM.ReadByte();
                LAGame.gbROM.BufferLocation = 0x80702 + (LAGame.map * 2); //Third spritesheet
                spriteInfo[2] = LAGame.gbROM.ReadByte();
                colourDungeonSpriteBanks[2] = LAGame.gbROM.ReadByte();
                LAGame.gbROM.BufferLocation = 0x8072E + (LAGame.map * 2); //Fourth spritesheet
                spriteInfo[3] = LAGame.gbROM.ReadByte();
                colourDungeonSpriteBanks[3] = LAGame.gbROM.ReadByte();

            }
        }
    }
}
