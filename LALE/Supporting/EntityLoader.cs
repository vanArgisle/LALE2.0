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
            getEntityLocation();

            byte b;
            while ((b = LAGame.gbROM.ReadByte()) != 0xFF) //0xFF = End of room
            {
                Entity ent = new Entity(LAGame); // 2-Byte tiles
                ent.yPos = (byte)(b >> 4);
                ent.xPos = (byte)(b & 0xF);
                ent.id = LAGame.gbROM.ReadByte();
                int temp = LAGame.gbROM.BufferLocation;
                ent.loadSprite();
                LAGame.gbROM.BufferLocation = temp;
                entities.Add(ent);
            }
        }

        private void getEntityLocation()
        {  
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
        }
        public void saveEntities()
        {
            getEntityLocation();
            foreach (Entity selectedEntity in entities)
            {
                byte b = (byte)((selectedEntity.yPos * 0x10) + selectedEntity.xPos);
                LAGame.gbROM.WriteByte(b);
                LAGame.gbROM.WriteByte(selectedEntity.id);
            }
            LAGame.gbROM.WriteByte(0xFF);
        }
    }
}
