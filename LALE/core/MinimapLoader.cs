using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE.Core
{
    class MinimapLoader
    {
        private Game LAGame;
        public byte[] minimapGraphics { get; set; }
        public byte[] overworldPal { get; set; }

        public Color[,] palette = new Color[8, 4];
        public MinimapLoader(Game gameValues)
        {
            LAGame = gameValues;
        }
        public byte[,,] loadMinimapOverworld()
        {
            minimapGraphics = new byte[64];
            overworldPal = new byte[256];

            minimapGraphics = LAGame.gbROM.ReadBytes(0x81697, 0x100);
            LAGame.gbROM.BufferLocation= 0x81797;
            for (int b = 0; b < 256; b++)
                overworldPal[b] = LAGame.gbROM.ReadByte();
            LAGame.gbROM.BufferLocation = 0x8786E;
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    palette[i, k] = GetColor(LAGame.gbROM.BufferLocation);
                }
            }
            byte[] tiles = LAGame.gbROM.ReadBytes(0xB3800, 0x800);
            byte[,,] data = new byte[128, 16, 16];
            LAGame.gbROM.ReadTiles(16, 8, tiles, ref data);
            return data;
        }
        public Color GetColor(int offset)
        {
            int value = LAGame.gbROM.ReadByte(offset) + (LAGame.gbROM.ReadByte(offset + 1) << 8);
            UInt16 color2B = (UInt16)value;
            int red = (color2B & 31) << 3;
            color2B >>= 5;
            int green = (color2B & 31) << 3;
            color2B >>= 5;
            int blue = (color2B & 31) << 3;
            return Color.FromArgb(red, green, blue);
        }
    }
}
