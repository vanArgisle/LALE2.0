using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE.Tileset
{
    public class TilesetLoader
    {
        private Game LAGame;

        public struct Tile
        {
            public byte[] palette;
            public bool[] hFlip;
            public bool[] vFlip;
        }

        public byte[,] formationData;
        public int animations { get; set; } = -1;
        public int SpecialObjectGraphics { get; set; } = -1;
        public Color[,] palette { get; set; } = new Color[8, 4];

        public Tile[] paletteTiles { get; set; }

        public TilesetLoader(Game gameValues)
        {
            LAGame = gameValues;

        }

        public byte[,,] loadTileset()
        {         
            List<byte> final = new List<byte>();
            byte[] animated = new byte[0x40];
            byte[] tilePreset = new byte[0x200];

            foreach (byte b in loadFirstRow())
                final.Add(b);
            animated = Animate();

            if (!LAGame.sideviewFlag)
            {
                foreach (byte b in loadSOG())
                    final.Add(b);
                if (!LAGame.overworldFlag)
                {
                    foreach (byte b in loadThird())
                        final.Add(b);
                }
                foreach (byte b in loadMain())
                    final.Add(b);

                tilePreset = roomTilePreset();

                if (!LAGame.overworldFlag)
                {
                    for (int w = 0; w < 0x200; w++)
                    {
                        final[(0x300) + w] = tilePreset[w];
                    }
                }
            }
            else
            {
                if ((LAGame.dungeon < 10 || LAGame.map == 0xE9) && LAGame.dungeon != 6)
                    LAGame.gbROM.BufferLocation = 0xB7800;
                else
                    LAGame.gbROM.BufferLocation = 0xB7000;
                foreach (byte b in LAGame.gbROM.ReadBytes(0x800))
                    final.Add(b);
            }


            for (int i = 0; i < 0x40; i++)
            {
                final[(0x7C * 16) + i] = animated[i];
            }

            byte[,,] data = new byte[144, 8, 8];
            LAGame.gbROM.ReadTiles(16, 9, final.ToArray(), ref data);

            formationData = loadFormation();

            return data;
        }



        private byte[] loadFirstRow()
        {
            //0x8F00-8E00
            if (LAGame.overworldFlag)
                return LAGame.gbROM.ReadBytes(0xB0F00, 0x100);
            else
            {
                if (LAGame.dungeon == 0xFF) //0xFF = Colour dungeon
                {
                    return LAGame.gbROM.ReadBytes(0xD6100, 0x100);
                }
                LAGame.gbROM.BufferLocation = 0x805CA + LAGame.dungeon;
                byte b = LAGame.gbROM.ReadByte();
                LAGame.gbROM.BufferLocation = 0xC8000 + ((b - 0x40) * 0x100);
                return LAGame.gbROM.ReadBytes(0x100);
            }
        }

        private byte[] loadThird()
        {
            //9100-91FF (dungeon only)
            if (LAGame.dungeon == 0xFF)
                return LAGame.gbROM.ReadBytes(0xD6000, 0x100);

            LAGame.gbROM.BufferLocation = 0x80589 + LAGame.dungeon;
            byte b = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0xB4000 + ((b - 0x40) * 0x100);
            return LAGame.gbROM.ReadBytes(0x100);
        }

        private byte getSOG()
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
                b = LAGame.gbROM.ReadByte();
                return b;
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
                byte b = LAGame.gbROM.ReadByte();
                return b;
            }
        }

        private byte[] loadSOG()
        {
            SpecialObjectGraphics = getSOG();
            
            byte[] data = new byte[0x100];
            if (LAGame.overworldFlag)
            {
                if (SpecialObjectGraphics == 0x0F)
                {
                    return new byte[0x200];
                }
                LAGame.gbROM.BufferLocation = 0xBC000 + (SpecialObjectGraphics) * 0x100;
                return LAGame.gbROM.ReadBytes(0x200);
            }
            else
            {
                if (SpecialObjectGraphics == 0xFF) //Don't load any others, keep data
                {
                    if (LAGame.raisingFloorFlag)
                    {
                        LAGame.gbROM.BufferLocation = 0xB2800;
                        for (int c = 0x40; c < 0xC0; c++)
                        {
                            if (c == 0x80)
                                LAGame.gbROM.BufferLocation = 0xB2880;
                            data[c] = LAGame.gbROM.ReadByte();
                        }
                    }
                    if (animations == 7)
                    {
                        LAGame.gbROM.BufferLocation = 0x307C0;
                        if (LAGame.dungeon == 5)
                            LAGame.gbROM.BufferLocation = 0x307C2;
                        for (int i = 0xC0; i < 256; i++)
                        {
                            data[i] = LAGame.gbROM.ReadByte();
                        }
                    }
                    return data;
                }
                if (LAGame.dungeon == 0xFF) //0xFF = Color dungeon
                {
                    LAGame.gbROM.BufferLocation = 0x805EA + (LAGame.map * 2);
                    byte location = LAGame.gbROM.ReadByte();
                    byte bank = LAGame.gbROM.ReadByte();
                    for (byte i = 0; i < 4; i++)
                    {
                        for (byte i2 = 0; i2 < 0x40; i2++)
                            data[(i * 0x40) + i2] = LAGame.gbROM.ReadByte((bank * 0x4000) + (((location - 0x40) * 0x100) + (i * 0x40) + i2));
                    }
                    return data;
                }
                LAGame.gbROM.BufferLocation = 0xB4000 + ((SpecialObjectGraphics + 0x10) * 0x100);
                if (LAGame.raisingFloorFlag && SpecialObjectGraphics != 0xE)
                {
                    for (int i = 0; i < 256; i++)
                    {
                        data[i] = LAGame.gbROM.ReadByte();
                        if (i == 0x40)
                        {
                            int buf = LAGame.gbROM.BufferLocation + 0x40;
                            LAGame.gbROM.BufferLocation = 0xB2800;
                            for (int c = 0; c < 0x80; c++)
                            {
                                if (c == 0x40)
                                    LAGame.gbROM.BufferLocation = 0xB2880;
                                data[i + c] = LAGame.gbROM.ReadByte();
                            }
                            LAGame.gbROM.BufferLocation = buf;
                            i = i + 0x80;
                            if (animations == 7 && i >= 0xC0)
                            {
                                LAGame.gbROM.BufferLocation = 0x307C0;
                                data[i] = LAGame.gbROM.ReadByte();
                            }
                        }
                    }
                    return data;
                }

                if (animations == 7)
                {
                    for (int i = 0; i < 256; i++)
                    {
                        data[i] = LAGame.gbROM.ReadByte();
                        if (i == 192)
                            LAGame.gbROM.BufferLocation = 0x307C0;
                    }
                    return data;
                }
                return LAGame.gbROM.ReadBytes(0x100);
            }
        }

        private byte[] loadMain()
        {
            //9200-97FF
            if (LAGame.overworldFlag)
                return LAGame.gbROM.ReadBytes(0xB1200, 0x600);
            else
                return LAGame.gbROM.ReadBytes(0xB4000, 0x600);
        }

        private byte getAnimations()
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
                byte b = LAGame.gbROM.ReadByte();
                return b;
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x28000;
                if (LAGame.dungeon >= 0x06 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation += 0x4000;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x2BB77;
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation + (LAGame.map * 2));
                byte b = LAGame.gbROM.ReadByte();
                return b;
            }
        }

        private byte[] Animate()
        {         
            animations = getAnimations();
            
            //96C0-9700
            if (animations == 7)
                return LAGame.gbROM.ReadBytes(0xB2D00, 0x40);

            LAGame.gbROM.BufferLocation = 0x1BD0 + (animations * 2);
            LAGame.gbROM.BufferLocation = LAGame.gbROM.ReadByte() + (LAGame.gbROM.ReadByte() * 0x100);
            while (LAGame.gbROM.ReadByte() != 0x26) ;
            byte b1 = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0xB0000 + ((b1 - 0x40) * 0x100);
            if (LAGame.dungeon == 0xFF && !LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x807CB + LAGame.map;
                byte b2 = LAGame.gbROM.ReadByte();
                if (b2 == 0)
                    LAGame.gbROM.BufferLocation = 0xB0000 + ((b1 - 0x40) * 0x100);
                else
                    LAGame.gbROM.BufferLocation = 0xD4000 + ((b2 + 0x20) * 0x100);
            }
            return LAGame.gbROM.ReadBytes(0x40);
        }

        private byte[] roomTilePreset()
        {
            //9200-93FF
            if (LAGame.dungeon == 0xFF) //Colour dungeon
                LAGame.gbROM.BufferLocation = 0x805C9;
            else
                LAGame.gbROM.BufferLocation = 0x80000 + ((0x45A9 + LAGame.dungeon) - 0x4000);

            byte b = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0xB4000 + (b - 0x40) * 0x100;
            return LAGame.gbROM.ReadBytes(0x200);
        }

        private byte[,] loadFormation()
        {
            if (LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation = 0x6AB1D;
            else if (LAGame.dungeon == 0xFF || (LAGame.dungeon == 0x10 && LAGame.map == 0xB5))
                LAGame.gbROM.BufferLocation = 0x20760;
            else
                LAGame.gbROM.BufferLocation = 0x203B0;
            byte[,] data = new byte[0x100, 4];
            for (int i = 0; i < 0x100; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    data[i, k] = LAGame.gbROM.ReadByte();
                }
            }
            return data;
        }

        public void loadPalette()
        {
            byte palOffset;
            int paletteLocation;

            paletteTiles = loadPaletteFlipIndexes();

            if (LAGame.overworldFlag)
            {            
                LAGame.gbROM.BufferLocation = 0x842EF + LAGame.map;
                byte b = LAGame.gbROM.ReadByte();
                palOffset = b;

                b *= 2;
                LAGame.gbROM.BufferLocation = 0x842B1 + b;
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                paletteLocation = LAGame.gbROM.BufferLocation;
                palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                return;
            }

            if (LAGame.sideviewFlag)
            {
                if (LAGame.dungeon != 0x07)
                {
                    LAGame.gbROM.BufferLocation = 0x84401 + (LAGame.dungeon * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                    return;
                }
                else if (LAGame.map >= 0x64 && LAGame.map <= 0x67 || LAGame.map == 0x6A || LAGame.map == 0x6B)
                {
                    LAGame.gbROM.BufferLocation = 0x86750;
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                    return;
                }
                else
                {
                    LAGame.gbROM.BufferLocation = 0x84401 + (LAGame.dungeon * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                    return;
                }
            }

            if (!LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x8523A;
                for (int i = 0; i < 0x2D; i++)
                {
                    if (LAGame.gbROM.ReadByte() != LAGame.dungeon)
                    {
                        LAGame.gbROM.BufferLocation += 3;
                        continue;
                    }
                    if (LAGame.gbROM.ReadByte() != LAGame.map)
                    {
                        LAGame.gbROM.BufferLocation += 2;
                        continue;
                    }
                    byte off = LAGame.gbROM.ReadByte();
                    if (off != 4)
                    {
                        LAGame.gbROM.BufferLocation++;
                        continue;
                    }
                    byte b = LAGame.gbROM.ReadByte();
                    palOffset = b;
                    LAGame.gbROM.BufferLocation = 0x851F6;
                    b &= 0x3F;
                    b <<= 1;
                    LAGame.gbROM.BufferLocation += b;
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                    return;
                }

                if (LAGame.dungeon == 0xFF) //0xFF = Color dungeon
                {
                    LAGame.gbROM.BufferLocation = 0x867D0;
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    if (LAGame.map != 0x1 && LAGame.map != 0x13 && LAGame.map != 0xF)
                        palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (i == 7)
                                if (LAGame.map == 0x1)
                                {
                                    paletteLocation = LAGame.gbROM.BufferLocation;
                                    LAGame.gbROM.BufferLocation = 0xDACF0;
                                }
                                else
                                {
                                    paletteLocation = LAGame.gbROM.BufferLocation;
                                    LAGame.gbROM.BufferLocation = 0xDACE0;
                                }

                            for (int k = 0; k < 4; k++)
                            {
                                palette[i, k] = LAGame.gbROM.GetColor(LAGame.gbROM.BufferLocation);
                            }
                        }
                    }
                    return;
                }
                else if (LAGame.dungeon > 0x09) //Indoor
                {
                    byte b = (byte)((LAGame.dungeon - 0x0A) << 1);
                    LAGame.gbROM.BufferLocation = 0x84413 + b;
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation)+ LAGame.map;
                    b = (byte)LAGame.gbROM.ReadByte();
                    palOffset = b;
                    b *= 2;
                    LAGame.gbROM.BufferLocation = 0x8443F + b;
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                    return;
                }
                else
                {
                    LAGame.gbROM.BufferLocation = 0x843EF + (LAGame.dungeon * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    paletteLocation = LAGame.gbROM.BufferLocation;
                    palette = LAGame.gbROM.GetPalette(LAGame.gbROM.BufferLocation);
                }
            }
        }

        private Tile[] loadPaletteFlipIndexes()
        {
            if (LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x6A476 + LAGame.map;
                int b = LAGame.gbROM.ReadByte() * 0x4000;
                LAGame.gbROM.BufferLocation = 0x69E76 + (LAGame.map * 2);
                LAGame.gbROM.BufferLocation = b + LAGame.gbROM.ReadByte() + ((LAGame.gbROM.ReadByte() - 0x40) * 0x100);
            }
            else if (LAGame.dungeon == 0xFF) //0xFF = Color dungeon
            {
                LAGame.gbROM.BufferLocation = 0x8E000;
            }
            else if (LAGame.dungeon < 9)
            {
                //gb.BufferLocation = 0x8C000 + (dungeon * 0x400);
                LAGame.gbROM.BufferLocation = 0x6A076 + LAGame.dungeon * 2;
                LAGame.gbROM.BufferLocation = 0x8C000 + LAGame.gbROM.ReadByte() + ((LAGame.gbROM.ReadByte() - 0x40) * 0x100);
            }
            else
            {
                if (LAGame.dungeon == 0x0A && LAGame.map == 0xFD)
                    LAGame.gbROM.BufferLocation = 0x6A276 + 0x1E;
                else if (LAGame.dungeon == 0x11 && (LAGame.map == 0xC0 || LAGame.map == 0xC1))
                    LAGame.gbROM.BufferLocation = 0x6A276 + 0x1E;
                else if (LAGame.dungeon == 0x0F && LAGame.map == 0xA0)
                    LAGame.gbROM.BufferLocation = 0x6A276;
                else if (LAGame.dungeon == 0x1F && (LAGame.map == 0xEB || LAGame.map == 0xEC))
                    LAGame.gbROM.BufferLocation = 0x6A276 + 0x28;
                else if (LAGame.dungeon == 0x10 && LAGame.map == 0xE9)
                    LAGame.gbROM.BufferLocation = 0x6A276 + 0x26;
                else if (LAGame.dungeon == 0x10 && LAGame.map == 0xB5)
                    LAGame.gbROM.BufferLocation = 0x6A276 + 0x01FE;
                else if (LAGame.dungeon == 0x16 && (LAGame.map == 0x6F || LAGame.map == 0x7F || LAGame.map == 0x8F))
                    LAGame.gbROM.BufferLocation = 0x6A276;
                else
                    LAGame.gbROM.BufferLocation = 0x6A276 + (LAGame.dungeon * 2);
                LAGame.gbROM.BufferLocation = 0x90000 + LAGame.gbROM.ReadByte() + ((LAGame.gbROM.ReadByte() - 0x40) * 0x100);
            }
            Tile[] tiles = new Tile[0x100];
            for (int i = 0; i < 0x100; i++)
            {
                tiles[i] = new Tile();
                tiles[i].palette = new byte[4];
                tiles[i].hFlip = new bool[4];
                tiles[i].vFlip = new bool[4];
                for (int k = 0; k < 4; k++)
                {
                    byte b = LAGame.gbROM.ReadByte();
                    tiles[i].palette[k] = (byte)(b & 0xF);
                    if ((b & 0x40) != 0)
                        tiles[i].vFlip[k] = true;
                    if ((b & 0x20) != 0)
                        tiles[i].hFlip[k] = true;
                }
            }
            return tiles;
        }
    }
}
