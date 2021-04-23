using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE.Supporting
{
    class EntityLoader
    {
        private Game LAGame;
        public List<Entity> entities;
        public int entityAddress;

        public EntityLoader(Game game)
        {
            LAGame = game;
        }

        public void loadEntities()
        {
            entities = new List<Entity>();

            if (LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation = 0x58000;
            else
            {
                LAGame.gbROM.BufferLocation = 0x58200;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x58400;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x58600;
            }
            LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation + (LAGame.map * 2));
            entityAddress = LAGame.gbROM.BufferLocation;
            byte b;
            while ((b = LAGame.gbROM.ReadByte()) != 0xFF) //0xFE = End of room
            {
                Entity ent = new Entity(); // 2-Byte tiles
                ent.yPos = (byte)(b >> 4);
                ent.xPos = (byte)(b & 0xF);
                ent.id = LAGame.gbROM.ReadByte();
                entities.Add(ent);
            }
        }
    }
}
