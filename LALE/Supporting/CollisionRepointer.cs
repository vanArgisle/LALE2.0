using LALE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE.Supporting
{
    public class CollisionRepointer
    {
        private Game LAGame;
        private MapTileData mapTileData;
        private SpaceCalculator spaceCalculator;
        private List<GameMapData> gameMapData;
        private List<MapPointer> bank1Maps = new List<MapPointer>();
        private List<MapPointer> bank2Maps = new List<MapPointer>();

        public class GameMapData
        {
            public GameMapData()
            {
                collisionObjects = new List<CollisionObject>();
                warpObjects = new List<Warps>();
            }
            public int map { get; set; }
            public List<CollisionObject> collisionObjects { get; set; }
            public List<Warps> warpObjects { get; set; }
            public byte animation { get; set; }
            public byte tilePreset { get; set; }
            public bool specialFlag { get; set; }

            public bool Equals(MapPointer pointer)
            {
                if (pointer.map == this.map && pointer.specialAddress == this.specialFlag)
                    return true;
                else
                    return false;
            }

        }

        public CollisionRepointer(Game game, MapTileData mtd)
        {
            LAGame = game;
            mapTileData = mtd;
            spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
        }

        public void repointMapCollisions(int mapAddress)
        {
            byte[] pointer = LAGame.gbROM.Get2BytePointer(mapAddress);

            if (LAGame.specialFlag)
            {
                switch (LAGame.map)
                {
                    case 0x06: LAGame.gbROM.BufferLocation = 0x31F4; break;
                    case 0x0E: LAGame.gbROM.BufferLocation = 0x31C4; break;
                    case 0x1B: LAGame.gbROM.BufferLocation = 0x3204; break;
                    case 0x2B: LAGame.gbROM.BufferLocation = 0x3214; break;
                    case 0x79: LAGame.gbROM.BufferLocation = 0x31E4; break;
                    case 0x8C: LAGame.gbROM.BufferLocation = 0x31D4; break;
                }
            }
            else
                LAGame.gbROM.BufferLocation = 0x24000 + (LAGame.map * 2);

            LAGame.gbROM.WriteBytes(pointer);

        }

        public void repointMapCollisions(MapPointer mapPointer)
        {
            byte[] pointer = LAGame.gbROM.Get2BytePointer(mapPointer.mapAddress);

            if (mapPointer.specialAddress)
            {
                switch (mapPointer.map)
                {
                    case 0x06: LAGame.gbROM.BufferLocation = 0x31F4; break;
                    case 0x0E: LAGame.gbROM.BufferLocation = 0x31C4; break;
                    case 0x1B: LAGame.gbROM.BufferLocation = 0x3204; break;
                    case 0x2B: LAGame.gbROM.BufferLocation = 0x3214; break;
                    case 0x79: LAGame.gbROM.BufferLocation = 0x31E4; break;
                    case 0x8C: LAGame.gbROM.BufferLocation = 0x31D4; break;
                }
            }
            else 
                LAGame.gbROM.BufferLocation = 0x24000 + (mapPointer.map * 2);

            LAGame.gbROM.WriteBytes(pointer);

        }

        private int getCollisionDataOverworldOffset(GameMapData mapData)
        {
            int i = -1;
            int secondhalf;

            if (mapData.specialFlag)
            {
                switch (mapData.map)
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
                if (mapData.map > 0x7F)
                    secondhalf += 0x68000;
                else
                    secondhalf += 0x24000;
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            else
            {
                secondhalf = 0x24000 + (mapData.map * 2);
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);
                if (mapData.map > 0x7F)
                    secondhalf = 0x68000 + (secondhalf - 0x24000);
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            return LAGame.gbROM.BufferLocation;
        }

        public void expandCollisionAddress()
        {
            getCollisionListForRewriteAndIndex();
            int index = getCollisionPointerListsAndIndex();
            List<MapPointer> maps = new List<MapPointer>();

            if (LAGame.map <= 0x7F)
                maps = bank1Maps;
            else
                maps = bank2Maps;
            
            for (int i = index; i < maps.Count; i++)
            {
                foreach (GameMapData g in gameMapData)
                {
                    if (g.Equals(maps[i]))
                    {
                        if (i == maps.Count - 1)
                            repointNextMap(g, null);
                        else
                            repointNextMap(g, maps[i + 1]);

                        saveCollisionOverworldData(g);
                    }
                }
            }
        }


        public void trimCollisionAddress()
        {
            if ((spaceCalculator.getUsedSpace() < spaceCalculator.getFreeSpace()))
            {
                int gameDataIndex = getCollisionListForRewriteAndIndex();
                int bankIndex = getCollisionPointerListsAndIndex();

                if (LAGame.map < 0x7F)
                {
                    repointNextMap(gameMapData[gameDataIndex], bank1Maps[bankIndex + 1]);
                }
                else if (LAGame.map < 0xFF && LAGame.map > 0x7F)
                {
                    repointNextMap(gameMapData[gameDataIndex], bank2Maps[bankIndex + 1]);
                }

                if (LAGame.map != 0x7F && LAGame.map != 0xFF)
                    saveCollisionOverworldData(gameMapData[gameDataIndex + 1]);
                else
                    saveCollisionOverworldData(gameMapData[gameDataIndex]);


            }
        }

        public void repointNextMap(GameMapData mapData, MapPointer nextMapPointer)
        {

            int mapAddressToRepoint = getCollisionDataOverworldOffset(mapData) + spaceCalculator.getUsedSpace(mapData.collisionObjects, mapData.warpObjects) + 3;
            //Plus 1 for animation, 1 for tile preset and 1 for 0xFE room ending byte

            if (mapData.map == 0xFF || mapData.map == 0x7F)
            {
                mapAddressToRepoint = getCollisionDataOverworldOffset(mapData);
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
                nextMapPointer.specialAddress = mapData.specialFlag;
            }
            
            repointMapCollisions(nextMapPointer);
        }

        private GameMapData LoadCollisionDataOverworld(int map, bool specialFlag)
        {
            GameMapData mapData = new GameMapData();

            mapData.map = map;
            mapData.specialFlag = specialFlag;

            //Sets the buffer address
            LAGame.gbROM.BufferLocation = getCollisionDataOverworldOffset(mapData);
            mapData.animation = LAGame.gbROM.ReadByte();
            mapData.tilePreset = LAGame.gbROM.ReadByte();

            byte b;
            while ((b = LAGame.gbROM.ReadByte()) != 0xFE) //0xFE = End of room
            {
                if (b >> 4 == 0xE)
                {
                    Warps w = new Warps();
                    w.type = (byte)(b & 0x0F);
                    w.region = LAGame.gbROM.ReadByte();
                    w.map = LAGame.gbROM.ReadByte();
                    w.x = LAGame.gbROM.ReadByte();
                    w.y = LAGame.gbROM.ReadByte();
                    mapData.warpObjects.Add(w);
                    continue;
                }
                if (b >> 4 == 8 || b >> 4 == 0xC) //3-Byte objects
                {
                    CollisionObject o = new CollisionObject();
                    o.is3Byte = true;
                    o.length = (byte)(b & 0xF);
                    o.direction = (byte)(b >> 4);
                    byte b2 = LAGame.gbROM.ReadByte();
                    o.yPos = (byte)(b2 >> 4);
                    o.xPos = (byte)(b2 & 0xF);
                    o.id = LAGame.gbROM.ReadByte();
                    o.getOverworldObjs(o);
                    mapData.collisionObjects.Add(o);
                    continue;
                }
                else
                {
                    CollisionObject o = new CollisionObject(); // 2-Byte objects
                    o.yPos = (byte)(b >> 4);
                    o.xPos = (byte)(b & 0xF);
                    o.id = LAGame.gbROM.ReadByte();
                    o.getOverworldObjs(o);
                    mapData.collisionObjects.Add(o);
                    continue;
                }
            }
            return mapData;
        }

        public void saveCollisionOverworldData(GameMapData mapData)
        {
            byte b;
            bool outofbounds = false;
            LAGame.gbROM.BufferLocation = getCollisionDataOverworldOffset(mapData);

            if (mapData.map >= 0x80 && mapData.map <= 0xFF)
            {
                if (LAGame.gbROM.BufferLocation > 0x69E73)
                {
                    LAGame.gbROM.BufferLocation = 0x69E73;
                    outofbounds = true;
                }
            }
            else if (mapData.map <= 0x7F)
            {
                if (LAGame.gbROM.BufferLocation > 0x2668B)
                {
                    LAGame.gbROM.BufferLocation = 0x2668B;
                    outofbounds = true;
                }
            }
            LAGame.gbROM.WriteByte(mapData.animation);
            LAGame.gbROM.WriteByte(mapData.tilePreset);

            if (outofbounds)
                LAGame.gbROM.WriteByte(0xFE);

            foreach (CollisionObject obj in mapData.collisionObjects)
            {
                int objectSize;

                if (obj.is3Byte)
                    objectSize = 3;
                else
                    objectSize = 2;
                if (mapData.map >= 0x80 && mapData.map <= 0xFF)
                {
                    if (LAGame.gbROM.BufferLocation + objectSize > 0x69E73)
                    {
                        return;
                    }
                }
                else if (mapData.map <= 0x7F)
                {
                    if (LAGame.gbROM.BufferLocation + objectSize > 0x2668B)
                    {
                        return;
                    }
                }

                if (obj.is3Byte)
                {
                    if (obj.direction == 8)
                    {
                        b = (byte)(0x80 + obj.length);
                        LAGame.gbROM.WriteByte(b);
                    }
                    else
                    {
                        b = (byte)(0xC0 + obj.length);
                        LAGame.gbROM.WriteByte(b);
                    }
                    b = (byte)((obj.yPos * 0x10) + obj.xPos);
                    LAGame.gbROM.WriteByte(b);
                    LAGame.gbROM.WriteByte(obj.id);
                }
                else
                {
                    b = (byte)((obj.yPos * 0x10) + obj.xPos);
                    LAGame.gbROM.WriteByte(b);
                    LAGame.gbROM.WriteByte(obj.id);
                }
            }
            if (mapData.warpObjects.Count != 0)
            {
                foreach (Warps warp in mapData.warpObjects)
                {
                    int objectSize = 5;

                    if (mapData.map >= 0x80 && mapData.map <= 0xFF)
                    {
                        if (LAGame.gbROM.BufferLocation + objectSize > 0x69E73)
                        {
                            //LAGame.gbROM.BufferLocation = 0X69E73;
                            LAGame.gbROM.WriteByte(0xFE);
                            return;
                        }
                    }
                    else if (mapData.map <= 0x7F)
                    {
                        if (LAGame.gbROM.BufferLocation + objectSize > 0x2668B)
                        {
                            //LAGame.gbROM.BufferLocation = 0x2668B;
                            LAGame.gbROM.WriteByte(0xFE);
                            return;
                        }
                    }

                    b = (byte)(0xE0 + warp.type);
                    LAGame.gbROM.WriteByte(b);
                    LAGame.gbROM.WriteByte(warp.region);
                    LAGame.gbROM.WriteByte(warp.map);
                    LAGame.gbROM.WriteByte(warp.x);
                    LAGame.gbROM.WriteByte(warp.y);
                }
            }

            LAGame.gbROM.WriteByte(0xFE);
        }

        private int getCollisionListForRewriteAndIndex()
        {
            gameMapData = new List<GameMapData>();
            int index = 0;

            for (int map = 0; map < 256; map++)
            {
                GameMapData gameData = new GameMapData();
                gameData = LoadCollisionDataOverworld(map, false);

                if (map == LAGame.map && !LAGame.specialFlag)
                {
                    gameData.collisionObjects = mapTileData.collisionObjects;
                    gameData.warpObjects = mapTileData.warpObjects;

                }
                gameMapData.Add(gameData);

                if (map == LAGame.map && !LAGame.specialFlag)
                {
                    index = gameMapData.IndexOf(gameData);
                }
                switch (map)
                {
                    case 0x06:
                    case 0x0E:
                    case 0x1B:
                    case 0x2B:
                    case 0x79:
                    case 0x8C:
                        gameData = new GameMapData();
                        gameData = LoadCollisionDataOverworld(map, true);
                        gameData.specialFlag = true;
                        
                        if (map == LAGame.map && LAGame.specialFlag)
                        {
                            gameData.collisionObjects = mapTileData.collisionObjects;
                            gameData.warpObjects = mapTileData.warpObjects;
                        }
         
                        gameMapData.Add(gameData);

                        if (map == LAGame.map && LAGame.specialFlag)
                        {
                            index = gameMapData.IndexOf(gameData);
                        }

                        break;
                    default:
                        break;

                }
            }
            return index;

        }

        public class MapPointer : IComparable<MapPointer>
        {
            public int mapAddress { get; set; }
            public int map { get; set; }
            public bool specialAddress { get; set; }

            public int CompareTo(MapPointer pointer)
            {
                return this.mapAddress.CompareTo(pointer.mapAddress);
            }
        }
        private int getCollisionPointerListsAndIndex()
        {
            bank1Maps = new List<MapPointer>();
            bank2Maps = new List<MapPointer>();
            MapPointer cMapPointer = new MapPointer();//Current map pointers

            int map = 0;
            int index;

            for (int i = 0; i < 256; i++)
            {
                MapPointer pointer = new MapPointer();
                pointer.map = map;
                pointer.specialAddress = false;
                int pointerToBe;

                pointerToBe = 0x24000 + (map * 2);
                pointerToBe = LAGame.gbROM.Get2BytePointerAtAddress(pointerToBe);
                if (map > 0x7F)
                    pointerToBe = 0x68000 + (pointerToBe - 0x24000);

                pointer.mapAddress = pointerToBe;

                if (map == LAGame.map && LAGame.specialFlag == false)
                    cMapPointer = pointer;

                if (map < 0x80)
                    bank1Maps.Add(pointer);
                else
                    bank2Maps.Add(pointer);

                int specialBufferAddress = 0;
                switch (map)
                {
                    case 0x06: specialBufferAddress = 0x31F4; break;
                    case 0x0E: specialBufferAddress = 0x31C4; break;
                    case 0x1B: specialBufferAddress = 0x3204; break;
                    case 0x2B: specialBufferAddress = 0x3214; break;
                    case 0x79: specialBufferAddress = 0x31E4; break;
                    case 0x8C: specialBufferAddress = 0x31D4; break;
                }
                if (specialBufferAddress > 0)
                {
                    MapPointer specialMapPointer = new MapPointer();
                    specialMapPointer.map = map;
                    specialMapPointer.specialAddress = true;

                    pointerToBe = LAGame.gbROM.Get2BytePointerAtAddress(specialBufferAddress);
                    if (map > 0x7F)
                        pointerToBe += 0x68000;
                    else
                        pointerToBe += 0x24000;
                    specialMapPointer.mapAddress = pointerToBe;

                    if (map == LAGame.map && LAGame.specialFlag == true)
                            cMapPointer = specialMapPointer;

                    if (map < 0x80)
                        bank1Maps.Add(specialMapPointer);
                    else
                        bank2Maps.Add(specialMapPointer);
                }
                map++;
            }

            bank1Maps.Sort();
            bank2Maps.Sort();


            if (LAGame.map < 0x80)
                index = bank1Maps.IndexOf(cMapPointer);
            else
                index = bank2Maps.IndexOf(cMapPointer);
            return index;
        }
    }
}
