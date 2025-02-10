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

        public byte[] spriteTileData;
        public byte entityTileOffset;

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

        public void loadSpriteTileData()
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
                case 0x24: //Iron mask
                    LAGame.gbROM.BufferLocation = 0xDB76;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x27: //Spike trap
                    LAGame.gbROM.BufferLocation = 0x1B4F6;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x28: //Mimic
                    LAGame.gbROM.BufferLocation = 0x66A93;
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
                    if (!LAGame.overworldFlag)
                        LAGame.gbROM.BufferLocation = 0x14932;
                    else
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
                case 0x4D: //Shop owner
                    LAGame.gbROM.BufferLocation = 0x136CB;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x4F: //Trendy game owner
                    LAGame.gbROM.BufferLocation = 0x136CB;
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
                case 0x55: //Bouncing bombite
                    if (LAGame.dungeon == 0x7)
                        LAGame.gbROM.BufferLocation = 0x13E09;
                    else
                        LAGame.gbROM.BufferLocation = 0x13E01;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
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
                case 0x74: //Papahls wife
                    spriteTileData = new byte[] { 0x60, 0x01, 0x62, 0x01 };
                    break;
                case 0x75: //Grandma Ulrira
                    LAGame.gbROM.BufferLocation = 0x60CFF;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x76: //Mister Write
                    spriteTileData = new byte[] { 0x70, 0x01, 0x72, 0x01 };
                    break;
                case 0x77: //Grandpa Ulrira
                    spriteTileData = new byte[] { 0x74, 0x02, 0x76, 0x02 };
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
                case 0x85: //Mister Write's bird
                    LAGame.gbROM.BufferLocation = 0x1B208;
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
                case 0x95: //Richard
                    LAGame.gbROM.BufferLocation = 0x18000;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0x96: //Richard frog
                    LAGame.gbROM.BufferLocation = 0x65BA8;
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
                case 0xAA: //Horizontal cheep cheep
                    LAGame.gbROM.BufferLocation = 0x66B4A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xAB: //Vertical cheep cheep
                    LAGame.gbROM.BufferLocation = 0x66B4A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xAC: //Jumping cheep cheep
                    LAGame.gbROM.BufferLocation = 0x66B4A;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
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
                case 0xD0: //Animal D0
                    LAGame.gbROM.BufferLocation = 0x17F3D;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xD1: //Animal D1
                    LAGame.gbROM.BufferLocation = 0x57F88;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xD2: //Animal D2
                    LAGame.gbROM.BufferLocation = 0x6125F;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xD3: //Bunny D3
                    LAGame.gbROM.BufferLocation = 0x611BC;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xE0: //Monkey
                    spriteTileData = new byte[] { 0x74, 0x02, 0x74, 0x22 };
                    break;
                case 0xE3: //Pokey
                    spriteTileData = new byte[] { 0x74, 0x01, 0x74, 0x21 };
                    //0x54B17 something weirds going on with the data split and palette.
                    break;
                case 0xE9: //Colour dungeon shell red          
                    spriteTileData = new byte[] { 0x40, 0x02, 0x42, 0x22 };
                    break;
                case 0xEA: //Colour dungeon shell green             
                    spriteTileData = new byte[] { 0x40, 0x00, 0x42, 0x20 };
                    break;
                case 0xEB: //Colour dungeon shell blue     
                    spriteTileData = new byte[] { 0x40, 0x03, 0x42, 0x23 };
                    break;
                case 0xEC: //Colour dungeon ghoul red          
                    spriteTileData = new byte[] { 0x60, 0x02, 0x60, 0x22 };
                    break;
                case 0xED: //Colour dungeon ghoul green             
                    spriteTileData = new byte[] { 0x60, 0x00, 0x60, 0x20 };
                    break;
                case 0xEE: //Colour dungeon ghoul blue     
                    spriteTileData = new byte[] { 0x60, 0x03, 0x60, 0x23 };
                    break;
                case 0xEF: //Colour dungeon rotoswitch red          
                    spriteTileData = new byte[] { 0x70, 0x02, 0x70, 0x22 };
                    break;
                case 0xF0: //Colour dungeon rotoswitch          
                    spriteTileData = new byte[] { 0x70, 0x01, 0x70, 0x21 };
                    break;
                case 0xF1: //Colour dungeon rotoswitch blue     
                    spriteTileData = new byte[] { 0x70, 0x03, 0x70, 0x23 };
                    break;
                case 0xF2: //Colour dungeon flying hopper     
                    spriteTileData = new byte[] { 0x76, 0x03, 0x78, 0x23 };
                    break;
                case 0xF3: //Colour dungeon hopper     
                    spriteTileData = new byte[] { 0x76, 0x03, 0x78, 0x23 };
                    break;
                case 0xF6: //Colour dungeon guardian blue
                    LAGame.gbROM.BufferLocation = 0xD9A9B;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                case 0xF7: //Colour dungeon guardian red
                    LAGame.gbROM.BufferLocation = 0xD9AB3;
                    spriteTileData = LAGame.gbROM.ReadBytes(4);
                    break;
                default:
                    break;
            }
        }
    }
}
