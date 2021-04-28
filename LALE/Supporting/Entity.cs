using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE.Supporting
{
    public class Entity
    {
        private Game LAGame;
        public byte xPos { get; set; }
        public byte yPos { get; set; }
        public byte id { get; set; }

        private byte[] spriteTileData;
        private byte entityTileOffset;

        public Bitmap sprite;

        public Entity(Game game)
        {
            LAGame = game;
        }
        public void loadSprite()
        {
            loadSpriteTileData();

            Sprite spriteLoader = new Sprite(LAGame);
            spriteLoader.loadSpriteBanks();
            spriteLoader.getSpriteLocation();
            sprite = spriteLoader.drawSpritePair16(spriteTileData, entityTileOffset);
        }

        private void loadSpriteTileData()
        {
            entityTileOffset = 0;

            switch (id)
            {
                case 0x09://Octorock
                    LAGame.gbROM.BufferLocation = 0xD7F2;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    LAGame.gbROM.BufferLocation = 0xD7EB;
                    entityTileOffset = LAGame.gbROM.ReadByte();
                    break;
                case 0x0B://Moblin
                    LAGame.gbROM.BufferLocation = 0xD90E;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x0E://Leever
                    LAGame.gbROM.BufferLocation = 0x13EF5;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x16: //Spark Counter Clockwise
                    LAGame.gbROM.BufferLocation = 0x1A617;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x17: //Spark Clockwise
                    LAGame.gbROM.BufferLocation = 0x1A617;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x19: //Keese
                    LAGame.gbROM.BufferLocation = 0x1A70A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x1B: //Gel
                    LAGame.gbROM.BufferLocation = 0x1BC0D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x1C: //Mini gel
                    LAGame.gbROM.BufferLocation = 0x1BBF6;
                    spriteTileData = LAGame.gbROM.ReadBytes(2);
                    break;
                case 0x1E: //Stalfos Evasive
                    LAGame.gbROM.BufferLocation = 0x54E7D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x20: //Hardhat beetle
                    LAGame.gbROM.BufferLocation = 0x18F2C;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x27: //Spike trap
                    LAGame.gbROM.BufferLocation = 0x1B4F6;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x29: //Mini-moldorm
                    //LAGame.gbROM.BufferLocation = ;
                    spriteTileData = new byte[] { 0x70, 0x01, 0x70, 0x21};
                    break;
                case 0x2C: //Spiked Beetle
                    LAGame.gbROM.BufferLocation = 0x1F7C0;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x3F: //Racoon
                    LAGame.gbROM.BufferLocation = 0x14912;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x41: //Owl event
                    LAGame.gbROM.BufferLocation = 0x1AA33;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x42: //Owl statue
                    LAGame.gbROM.BufferLocation = 0x61E05;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x6C://Cucco
                    LAGame.gbROM.BufferLocation = 0x14514;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x6E: //Butterfly
                    //LAGame.gbROM.BufferLocation = ;
                    spriteTileData = new byte[] { 0x5E, 0x01 };
                    break;
                case 0x71: //Kid with ball
                    LAGame.gbROM.BufferLocation = 0x1A077;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x72: //Kid with ball
                    LAGame.gbROM.BufferLocation = 0x1A06F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x7A: //Crow
                    LAGame.gbROM.BufferLocation = 0x19C89;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x7E: //Gaponga Flower
                    LAGame.gbROM.BufferLocation = 0x1A3F6;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x90: //Three of a Kind
                    LAGame.gbROM.BufferLocation = 0x18911;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x9B: //Hiding Gel
                    LAGame.gbROM.BufferLocation = 0x1F2E7;
                    spriteTileData = LAGame.gbROM.ReadBytes(2);
                    break;
                case 0xC5://Urchin
                    LAGame.gbROM.BufferLocation = 0x57385;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xC6://Sand Crab
                    LAGame.gbROM.BufferLocation = 0x57322;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xCC: //Fish
                    LAGame.gbROM.BufferLocation = 0x544B3;
                    spriteTileData = LAGame.gbROM.ReadBytes(2);
                    break;
                default:
                    break;
            }
        }
    }
}
