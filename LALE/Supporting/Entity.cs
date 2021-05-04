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
            spriteTileData = null;

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
                case 0x0D://Tektite
                    LAGame.gbROM.BufferLocation = 0x1B8B3;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x0E://Leever
                    LAGame.gbROM.BufferLocation = 0x13EF5;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x0F://Armos statue
                    LAGame.gbROM.BufferLocation = 0x1B442;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x10://Hiding Ghini
                    LAGame.gbROM.BufferLocation = 0x11BFC;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x12://Ghini
                    LAGame.gbROM.BufferLocation = 0x11BFC;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x14://Moblin sword
                    LAGame.gbROM.BufferLocation = 0x1FAD1;
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
                case 0x18: //Pols Voice
                    LAGame.gbROM.BufferLocation = 0x1B36F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x19: //Keese
                    LAGame.gbROM.BufferLocation = 0x1A70A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x1A: //Stalfos Aggresive
                    LAGame.gbROM.BufferLocation = 0x18AA8;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x1B: //Gel
                    LAGame.gbROM.BufferLocation = 0x1BC05;
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
                case 0x1F: //Gibdo
                    LAGame.gbROM.BufferLocation = 0x1BE6B;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x20: //Hardhat beetle
                    LAGame.gbROM.BufferLocation = 0x18F2C;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x21: //Wizrobe
                    LAGame.gbROM.BufferLocation = 0x1B604;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x23: //LikeLike
                    LAGame.gbROM.BufferLocation = 0x1BDD0;
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
                case 0x3E: //Marin
                    LAGame.gbROM.BufferLocation = 0x14E0A;
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
                case 0x45: //Falling boulders
                    LAGame.gbROM.BufferLocation = 0x543AE;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x50: //Boo buddy
                    LAGame.gbROM.BufferLocation = 0x1B985;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x52: //Tractor device
                    LAGame.gbROM.BufferLocation = 0x1281C;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x53: //Tractor device reverse
                    LAGame.gbROM.BufferLocation = 0x1281C;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x54: //Fisherman fishing game
                    //LAGame.gbROM.BufferLocation = 0x11F58;
                    spriteTileData = new byte[] { 0x70, 0x01, 0x72, 0x01 };
                    break;
                case 0x57: //Pairodd
                    LAGame.gbROM.BufferLocation = 0x11DD1;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x6C://Cucco
                    LAGame.gbROM.BufferLocation = 0x14514;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x6D: //Bow-wow
                    LAGame.gbROM.BufferLocation = 0x14000;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x6E: //Butterfly
                    spriteTileData = new byte[] { 0x5E, 0x01 };
                    break;
                case 0x6F: //Dog
                    LAGame.gbROM.BufferLocation = 0x648CA;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x70: //Kid by dream house
                    LAGame.gbROM.BufferLocation = 0x1A04F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x71: //Kid with ball
                    LAGame.gbROM.BufferLocation = 0x1A077;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x72: //Kid with ball
                    LAGame.gbROM.BufferLocation = 0x1A06F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x73: //Kid by trendy game
                    LAGame.gbROM.BufferLocation = 0x1A04F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x75: //Grandma Ulrira
                    LAGame.gbROM.BufferLocation = 0x60CFF;
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
                case 0x7F: //Turtle rock head
                    LAGame.gbROM.BufferLocation = 0x63304;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x80: //Telephone
                    LAGame.gbROM.BufferLocation = 0x1AA74;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x8F: //Masked mimic goriya
                    LAGame.gbROM.BufferLocation = 0x64796;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x90: //Three of a Kind
                    LAGame.gbROM.BufferLocation = 0x18911;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x93: //Mad bomber
                    LAGame.gbROM.BufferLocation = 0x1812E;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x99: //Water Tektite
                    LAGame.gbROM.BufferLocation = 0x118F2;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x9B: //Hiding Gel
                    LAGame.gbROM.BufferLocation = 0x1BC0D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x9F: //Goomba
                    LAGame.gbROM.BufferLocation = 0x1E60A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xA0: //Peahat
                    LAGame.gbROM.BufferLocation = 0x1E73D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xA1: //Snake
                    LAGame.gbROM.BufferLocation = 0x1E87A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xA2: //Piranha plant
                    spriteTileData = new byte[] { 0x74, 0x02, 0x74, 0x22 };
                    break;
                case 0xAD://Kiki the monkey
                    LAGame.gbROM.BufferLocation = 0x1D82E;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xAE://Winged Octorok
                    LAGame.gbROM.BufferLocation = 0x1D62D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB0: //Pincer
                    LAGame.gbROM.BufferLocation = 0x1D42F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB2: //Beetle spawner
                    LAGame.gbROM.BufferLocation = 0x57579;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB3: //Honeycomb
                    LAGame.gbROM.BufferLocation = 0x1CC93;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB4: //Tarin
                    LAGame.gbROM.BufferLocation = 0x1CE8D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB6: //Papahl
                    LAGame.gbROM.BufferLocation = 0x1C9F7;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB7: //Mermaid
                    LAGame.gbROM.BufferLocation = 0x1C683;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xB9: //Buzz blob
                    LAGame.gbROM.BufferLocation = 0x63738;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xBA://Bomber
                    spriteTileData = new byte[] { 0x70, 0x02, 0x72, 0x22 };
                    //0x637FC something weirds going on with the data split.
                    break;
                case 0xBB: //Bush crawler
                    LAGame.gbROM.BufferLocation = 0x1C00A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xBD: //Vire
                    //LAGame.gbROM.BufferLocation = 0x62EE8;
                    spriteTileData = new byte[] { 0x60, 0x02, 0x62, 0x22 };
                    break;
                case 0xBF: //Zombie
                    LAGame.gbROM.BufferLocation = 0x6240F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xC5://Urchin
                    LAGame.gbROM.BufferLocation = 0x57385;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xC6://Sand Crab
                    LAGame.gbROM.BufferLocation = 0x57322;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xCB: //Zora
                    LAGame.gbROM.BufferLocation = 0x609D0;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xCC: //Fish
                    LAGame.gbROM.BufferLocation = 0x544B3;
                    spriteTileData = LAGame.gbROM.ReadBytes(2);
                    break;
                case 0xCD: //Bananas
                    spriteTileData = new byte[] { 0x70, 0x01, 0x72, 0x21 };
                    break;
                case 0xE0: //Monkey
                    spriteTileData = new byte[] { 0x74, 0x02, 0x74, 0x22 };
                    break;
                case 0xE3: //Pokey
                    spriteTileData = new byte[] { 0x74, 0x01, 0x74, 0x21 };
                    //0x54B17 something weirds going on with the data split and palette.
                    break;
                default:
                    break;
            }
        }
    }
}
