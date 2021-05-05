using LALE.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE
{
    class EntityRepointer
    {
        private Game LAGame;
        private EntityLoader entityLoader;
        private SpaceCalculator spaceCalculator;
        private List<GameMapData> gameMapData;
        private List<MapPointer> mapPointerList = new List<MapPointer>();

        public class GameMapData
        {
            public GameMapData()
            {
                entities = new List<Entity>();
            }
            public int map { get; set; }
            public List<Entity> entities { get; set; }
            public bool Equals(MapPointer pointer)
            {
                if (pointer.map == this.map)
                    return true;
                else
                    return false;
            }

        }
        public class MapPointer : IComparable<MapPointer>
        {
            public int mapAddress { get; set; }
            public int map { get; set; }
            public int CompareTo(MapPointer pointer)
            {
                return this.mapAddress.CompareTo(pointer.mapAddress);
            }
        }

        public EntityRepointer(Game game, EntityLoader entityL, SpaceCalculator spaceCalc)
        {
            LAGame = game;
            entityLoader = entityL;
            spaceCalculator = spaceCalc;
        }

        public void repointMapEntities(int mapAddress)
        {
            byte[] pointer = LAGame.gbROM.Get2BytePointer(mapAddress);

            if (LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation = 0x58000 + LAGame.map * 2;
            else
            {
                LAGame.gbROM.BufferLocation = 0x58200 + LAGame.map * 2; ;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x58400 + LAGame.map * 2;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x58600 + LAGame.map * 2;
            }

            LAGame.gbROM.WriteBytes(pointer);

        }

        public void repointMapEntities(MapPointer mapAddress)
        {
            byte[] pointer = LAGame.gbROM.Get2BytePointer(mapAddress.mapAddress);

            if (LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation = 0x58000 + mapAddress.map * 2;
            else
            {
                LAGame.gbROM.BufferLocation = 0x58200 + mapAddress.map * 2; ;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x58400 + mapAddress.map * 2;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x58600 + mapAddress.map * 2;
            }

            LAGame.gbROM.WriteBytes(pointer);

        }

        public void expandEntityAddress()
        {
            int index = getEntityPointerListsAndIndex();
            getEntityListForRewriteAndIndex();

            for (int i = index; i < mapPointerList.Count; i++)
            {
                foreach (GameMapData g in gameMapData)
                {
                    if (g.Equals(mapPointerList[i]))
                    {
                        if (i == mapPointerList.Count - 1)
                            repointNextMap(g, null);
                        else
                            repointNextMap(g, mapPointerList[i + 1]);

                        saveEntityData(g);
                    }
                }
            }
        }

        public void trimEntityAddress()
        {

            if ((spaceCalculator.getUsedSpaceEntities(entityLoader.entities) < spaceCalculator.getFreeSpaceEntities()))
            {
                int gameDataIndex = getEntityListForRewriteAndIndex();
                int bankIndex = getEntityPointerListsAndIndex();

                if (LAGame.dungeon != 0xFF && LAGame.map < 0xFF || (LAGame.map < 0x15 && LAGame.dungeon == 0xFF))
                {
                    repointNextMap(gameMapData[gameDataIndex], mapPointerList[bankIndex + 1]);
                }

                if (LAGame.dungeon != 0xFF && LAGame.map != 0xFF || (LAGame.map != 0x15 && LAGame.dungeon == 0xFF))
                    saveEntityData(gameMapData[gameDataIndex + 1]);
                else
                    saveEntityData(gameMapData[gameDataIndex]);
            }
        }

        public void repointNextMap(GameMapData mapData, MapPointer nextMapPointer)
        {
            int mapAddressToRepoint;
            mapAddressToRepoint = getEntityDataOffset(mapData) + spaceCalculator.getUsedSpaceEntities(mapData.entities) + 1;
            //Plus 1 for 0xFF room ending byte

            if (mapData.map == 0xFF && LAGame.dungeon != 0xFF || (LAGame.map == 0x15 && LAGame.dungeon == 0xFF))
                mapAddressToRepoint = getEntityDataOffset(mapData);


            if (LAGame.overworldFlag)
            {
                if (mapAddressToRepoint >= 0x59663)
                    mapAddressToRepoint = 0x59661;
            }
            else
            {
                if (LAGame.dungeon == 0xFF && mapAddressToRepoint >= 0x596FF)
                    mapAddressToRepoint = 0x596FD;
                else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && mapAddressToRepoint >= 0x59185 && LAGame.dungeon != 0xFF)
                    mapAddressToRepoint = 0x59183;
                else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && mapAddressToRepoint >= 0x58CA3 && LAGame.dungeon != 0xFF)
                    mapAddressToRepoint = 0x58CA1;
            }


            if (nextMapPointer != null)
            {
                nextMapPointer.mapAddress = mapAddressToRepoint;
            }
            else
            {
                nextMapPointer = new MapPointer();
                nextMapPointer.mapAddress = mapAddressToRepoint;
                nextMapPointer.map = mapData.map;
            }

            repointMapEntities(nextMapPointer);
        }

        private GameMapData LoadEntityData(int map)
        {
            GameMapData mapData = new GameMapData();

            mapData.map = map;

            getEntityDataOffset(mapData);

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
                mapData.entities.Add(ent);
            }

            return mapData;
        }

        private int getEntityListForRewriteAndIndex()
        {
            gameMapData = new List<GameMapData>();
            int index = 0;

            if (LAGame.dungeon == 0xFF)
            {
                for (int map = 0; map < 0x16; map++)
                {
                    GameMapData gameData = new GameMapData();
                    gameData = LoadEntityData(map);

                    if (map == LAGame.map)
                    {
                        gameData.entities = entityLoader.entities;
                    }
                    gameMapData.Add(gameData);

                    if (map == LAGame.map)
                    {
                        index = gameMapData.IndexOf(gameData);
                    }
                }
            }
            else
            {
                for (int map = 0; map < 256; map++)
                {
                    GameMapData gameData = new GameMapData();
                    gameData = LoadEntityData(map);

                    if (map == LAGame.map)
                    {
                        gameData.entities = entityLoader.entities;
                    }

                    gameMapData.Add(gameData);

                    if (map == LAGame.map)
                    {
                        index = gameMapData.IndexOf(gameData);
                    }
                }
            }
            return index;
        }


        private int getEntityPointerListsAndIndex()
        {
            mapPointerList = new List<MapPointer>();
            MapPointer cMapPointer = new MapPointer();//Current map pointers

            int map = 0;
            int index;

            if (LAGame.dungeon == 0xFF)
            {
                for (int i = 0; i < 0x16; i++)
                {
                    MapPointer pointer = new MapPointer();
                    pointer.map = map;
                    int pointerToBe;

                    pointerToBe = (0x58600 + (map * 2));

                    pointer.mapAddress = LAGame.gbROM.Get2BytePointerAtAddress(pointerToBe);

                    if (map == LAGame.map && LAGame.specialFlag == false)
                        cMapPointer = pointer;

                    mapPointerList.Add(pointer);

                    map++;
                }
            }
            else
            {
                for (int i = 0; i < 256; i++)
                {
                    MapPointer pointer = new MapPointer();
                    pointer.map = map;
                    int pointerToBe;

                    if (LAGame.overworldFlag)
                        pointerToBe = 0x58000 + map * 2;
                    else
                    {
                        pointerToBe = 0x58200 + map * 2; ;
                        if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                            pointerToBe = 0x58400 + (map * 2);
                    }

                    pointer.mapAddress = LAGame.gbROM.Get2BytePointerAtAddress(pointerToBe);

                    if (map == LAGame.map)
                        cMapPointer = pointer;

                    mapPointerList.Add(pointer);

                    map++;
                }
            }

            mapPointerList.Sort();

            index = mapPointerList.IndexOf(cMapPointer);

            return index;
        }

        private int getEntityDataOffset(GameMapData mapData)
        {
            if (LAGame.overworldFlag)
                LAGame.gbROM.BufferLocation = 0x58000 + mapData.map * 2;
            else
            {
                LAGame.gbROM.BufferLocation = 0x58200 + mapData.map * 2; ;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation = 0x58400 + mapData.map * 2;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x58600 + mapData.map * 2;
            }
            LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
            return LAGame.gbROM.BufferLocation;
        }

        private void saveEntityData(GameMapData mapData)
        {
            bool outofbounds = false;

            getEntityDataOffset(mapData);

            if (LAGame.overworldFlag && LAGame.gbROM.BufferLocation >= 0x59663)
            {
                LAGame.gbROM.BufferLocation = 0x59663;
                outofbounds = true;
            }
            else if (LAGame.dungeon == 0xFF && LAGame.gbROM.BufferLocation >= 0x596FF)
            {
                LAGame.gbROM.BufferLocation = 0x596FF;
                outofbounds = true;
            }
            else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && LAGame.gbROM.BufferLocation >= 0x59185)
            {
                LAGame.gbROM.BufferLocation = 0x59185;
                outofbounds = true;
            }
            else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && LAGame.gbROM.BufferLocation >= 0x58CA3 && LAGame.dungeon != 0xFF && !LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x58CA3;
                outofbounds = true;
            }

            if (outofbounds)
            {
                LAGame.gbROM.WriteByte(0xFF);
                return;
            }

            foreach (Entity selectedEntity in mapData.entities)
            {
                if (LAGame.overworldFlag && LAGame.gbROM.BufferLocation + 2 >= 0x59663)
                {
                    LAGame.gbROM.WriteByte(0xFF);
                    return;
                }
                else if (LAGame.dungeon == 0xFF && LAGame.gbROM.BufferLocation + 2 >= 0x596FF)
                {
                    LAGame.gbROM.WriteByte(0xFF);
                    return;
                }
                else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && LAGame.gbROM.BufferLocation + 2 >= 0x59185)
                {
                    LAGame.gbROM.WriteByte(0xFF);
                    return;
                }
                else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && LAGame.gbROM.BufferLocation + 2 >= 0x58CA3 && LAGame.dungeon != 0xFF && !LAGame.overworldFlag)
                {
                    LAGame.gbROM.WriteByte(0xFF);
                    return;
                }

                byte b = (byte)((selectedEntity.yPos * 0x10) + selectedEntity.xPos);
                LAGame.gbROM.WriteByte(b);
                LAGame.gbROM.WriteByte(selectedEntity.id);
            }
            LAGame.gbROM.WriteByte(0xFF);
        }
    }
}
