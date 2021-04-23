using LALE.Core;
using System.Collections.Generic;

namespace LALE
{
    public class MapTileData
    {
        private Game LAGame;
        public List<CollisionObject> collisionObjects { get; set; }
        public List<Warps> warpObjects { get; set; }
        public byte[] overlayMapData { get; set; }
        public int mapAddress { get; set; }
        public byte dungeonWalls { get; set; }
        public byte dungeonFloor { get; set; }
        private CollisionObject[,] wallTiles = new CollisionObject[16, 64];

        public MapTileData(Game gameValues)
        {
            LAGame = gameValues;
        }

        public byte[] GetOverlayMapData()
        {
            byte[] mapData = new byte[80];
            mapAddress = GetOverlayDataOverworldOffset();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    mapData[x + (y * 10)] = LAGame.gbROM.ReadByte();
                }

            }
            overlayMapData = mapData;
            return mapData;

        }

        private int GetOverlayDataOverworldOffset()
        {
            int i = -1;
            if (LAGame.specialFlag)
            {
                switch (LAGame.map)
                {
                    case 0x06: i = 0x5040; break;
                    case 0x0E: i = 0x5090; break;
                    case 0x1B: i = 0x50E0; break;
                    case 0x2B: i = 0x5130; break;
                    case 0x79: i = 0x5180; break;
                    case 0x8C: i = 0x51D0; break;
                }
            }
            if (i > 0)
            {
                return LAGame.gbROM.BufferLocation = 0x98000 + i;
            }
            else if (LAGame.map < 0xCC)
            {
                return LAGame.gbROM.BufferLocation = 0x98000 + 0x50 * LAGame.map;
            }
            else
            {
                return LAGame.gbROM.BufferLocation = 0x9C000 + 0x50 * (LAGame.map - 0xCC);
            }

        }

        public void LoadCollisionDataOverworld()
        {

            collisionObjects = new List<CollisionObject>();
            warpObjects = new List<Warps>();
            CollisionObject overworldObjects = new CollisionObject();

            getCollisionDataOverworldOffset();
            byte b;

            while ((b = LAGame.gbROM.ReadByte()) != 0xFE) //0xFE = End of room
            {
                if (LAGame.map < 0x80 && LAGame.gbROM.BufferLocation >= 0x2668D)
                    break;
                if (LAGame.map > 0x7F && LAGame.gbROM.BufferLocation >= 0x69E75)
                    break;

                //Check to see if we are reading empty space
                /*if (b == 0)
                {
                    //We need a 00 00 00 for it to be empty space. Otherwise it could just be an object in XY position 0.
                    byte x = LAGame.gbROM.ReadByte();
                    if (x == 0)
                    {
                        x = LAGame.gbROM.ReadByte();
                        if (x == 0 && x != 0xFE)
                        {
                            LAGame.gbROM.BufferLocation--;
                            continue;
                        }
                        if (x == 0xFE)
                            break;
                        else
                            LAGame.gbROM.BufferLocation -= 2;
                    }
                }*/

                if (b >> 4 == 0xE)
                {
                    //Plus 4 because we read a byte already
                    if (LAGame.map < 0x80 && LAGame.gbROM.BufferLocation + 4 > 0x2668D)
                        return;
                    if (LAGame.map > 0x7F && LAGame.gbROM.BufferLocation + 4 > 0x69E75)
                        return;

                    Warps w = new Warps();
                    w.type = (byte)(b & 0x0F);
                    w.region = LAGame.gbROM.ReadByte();
                    w.map = LAGame.gbROM.ReadByte();
                    w.x = LAGame.gbROM.ReadByte();
                    w.y = LAGame.gbROM.ReadByte();
                    warpObjects.Add(w);
                    continue;
                }

                if (b >> 4 == 8 || b >> 4 == 0xC) //3-Byte objects
                {
                    //Plus 2 because we read a byte already
                    if (LAGame.map < 0x80 && LAGame.gbROM.BufferLocation + 2 > 0x2668D)
                        return;
                    if (LAGame.map > 0x7F && LAGame.gbROM.BufferLocation + 2 > 0x69E75)
                        return;

                    CollisionObject o = new CollisionObject();
                    o.is3Byte = true;
                    o.length = (byte)(b & 0xF);
                    o.direction = (byte)(b >> 4);
                    byte b2 = LAGame.gbROM.ReadByte();
                    o.yPos = (byte)(b2 >> 4);
                    o.xPos = (byte)(b2 & 0xF);
                    o.id = LAGame.gbROM.ReadByte();
                    overworldObjects.getOverworldObjs(o);
                    //collisionObjects.Add(o);
                    continue;
                }
                else
                {
                    //Plus 1 because we read a byte already
                    if (LAGame.map < 0x80 && LAGame.gbROM.BufferLocation + 1 > 0x2668D)
                        return;
                    if (LAGame.map > 0x7F && LAGame.gbROM.BufferLocation + 1 > 0x69E75)
                        return;

                    CollisionObject o = new CollisionObject(); // 2-Byte tiles
                    o.yPos = (byte)(b >> 4);
                    o.xPos = (byte)(b & 0xF);
                    o.id = LAGame.gbROM.ReadByte();
                    overworldObjects.getOverworldObjs(o);
                    //collisionObjects.Add(o);
                    continue;
                }
            }

            foreach (CollisionObject obj in overworldObjects.objectIDs)
            {
                collisionObjects.Add(obj);
            }


        }

        private void getCollisionDataOverworldOffset()
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
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i) + 2;
                if (LAGame.map > 0x7F)
                    secondhalf += 0x68000;
                else
                    secondhalf += 0x24000;
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            else
            {
                secondhalf = 0x24000 + (LAGame.map * 2);
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf) + 2;
                if (LAGame.map > 0x7F)
                    secondhalf = 0x68000 + (secondhalf - 0x24000);
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            mapAddress = LAGame.gbROM.BufferLocation - 2;
        }

        public byte[] getCollisionOverworldMapData()
        {
            byte[] mapData = new byte[80];
            byte[] tilePreset = getTilePreset();

            for (int i = 0; i < 80; i++)
                mapData[i] = (byte)(tilePreset[0] + (tilePreset[1] * 0x10));
            foreach (CollisionObject obj in collisionObjects)
            {
                int dx = (obj.xPos == 0xF ? (obj.xPos - 16) : obj.xPos);
                int dy = (obj.yPos == 0xF ? (obj.yPos - 16) : obj.yPos);

                if (!obj.is3Byte)
                {
                    if (obj.multiTileFlag)
                    {
                        for (int h = 0; h < obj.height; h++)
                        {
                            for (int w = 0; w < obj.width; w++)
                            {
                                if (dy < 0)
                                {
                                    obj.yPos = 0;
                                    dy++;
                                    h++;
                                }
                                if (dx < 0)
                                {
                                    obj.xPos = 0;
                                    dx++;
                                    w++;
                                }
                                if (dx > 9)
                                {
                                    dx++;
                                    if (w == obj.width - 1)
                                    {
                                        if (obj.hFlip)
                                            dx = obj.xPos - 1;
                                        else
                                            dx = obj.xPos;
                                        if (h == obj.height - 1)
                                            dy = obj.yPos;
                                        else
                                            dy++;
                                    }
                                    continue;
                                }
                                if (dy > 7)
                                {
                                    dx++;
                                    if (w == obj.width - 1)
                                    {
                                        if (obj.vFlip)
                                            dx = obj.xPos - 1;
                                        else
                                            dx = obj.xPos;
                                        if (h == obj.height - 1)
                                            dy = obj.yPos;
                                        else
                                            dy++;
                                    }
                                    continue;
                                }
                                if (obj.hFlip && obj.vFlip)
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + (w - 1)) + ((obj.yPos + (h - 1)) * 10)] = id;
                                }
                                else if (obj.hFlip)
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + (w - 1)) + ((obj.yPos + h) * 10)] = id;
                                }
                                else if (obj.vFlip)
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + w) + ((obj.yPos + (h - 1)) * 10)] = id;
                                }
                                else
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + w) + ((obj.yPos + h) * 10)] = id;
                                }
                                dx++;
                                if (w >= (obj.width - 1))
                                {
                                    if (obj.hFlip)
                                        dx = obj.xPos - 1;
                                    else
                                        dx = obj.xPos;
                                    dy++;
                                }
                            }
                        }
                        if (obj.hFlip)
                            obj.xPos = 0x0F;
                        if (obj.vFlip)
                            obj.yPos = 0x0F;
                    }
                    else
                    {
                        if (dy < 0 || dy > 7)
                            continue;
                        if (dx < 0 || dx > 9)
                            continue;
                        mapData[obj.xPos + (obj.yPos * 10)] = (byte)obj.id;
                    }
                }
                else if (obj.is3Byte)
                {
                    if (!obj.multiTileFlag)
                    {
                        for (int i = 0; i < obj.length; i++)
                        {
                            if (obj.direction == 8) //Horizontal
                            {
                                if (dx < 0)
                                {
                                    dx++;
                                    i++;
                                }
                                if (dy < 0 || dy > 7)
                                    continue;
                                if (dx > 9)
                                    continue;
                                if (obj.hFlip)
                                {
                                    obj.xPos = 0;
                                    mapData[obj.xPos + (obj.yPos * 10) + (i - 1)] = obj.id;
                                }
                                else
                                    mapData[obj.xPos + (obj.yPos * 10) + i] = obj.id;
                                dx++;
                            }
                            else
                            {
                                if (dx < 0 || dx > 9)
                                    continue;
                                if (dy < 0)
                                {
                                    dy++;
                                    i++;
                                }
                                if (dy > 7)
                                    continue;
                                if (obj.vFlip)
                                {
                                    obj.yPos = 0;
                                    mapData[obj.xPos + (obj.yPos * 10) + ((i - 1) * 10)] = obj.id;
                                }
                                else
                                    mapData[obj.xPos + (obj.yPos * 10) + (i * 10)] = obj.id;
                                dy++;
                            }
                        }
                        if (obj.hFlip)
                            obj.xPos = 0x0F;
                        if (obj.vFlip)
                            obj.yPos = 0x0F;
                    }
                    else
                    {
                        for (int i = 0; i < obj.length; i++)
                        {
                            if (obj.direction == 8)
                            {
                                if (dx >= 0)
                                {
                                    dx = obj.xPos + (i * obj.width);
                                    if (obj.hFlip)
                                        dx = obj.xPos - 1 + (i * obj.width);
                                }
                                if (dy >= 0)
                                {
                                    dy = obj.yPos;
                                    if (obj.vFlip)
                                        dy = obj.yPos - 1;
                                }
                            }
                            else
                            {
                                if (dx >= 0)
                                {
                                    dx = obj.xPos;
                                    if (obj.hFlip)
                                        dx = obj.xPos - 1;
                                }
                                if (dy >= 0)
                                {
                                    dy = obj.yPos + (i * obj.height);
                                    if (obj.vFlip)
                                        dy = obj.yPos - 1 + (i * obj.height);
                                }
                            }
                            for (int h = 0; h < obj.height; h++)
                            {
                                for (int w = 0; w < obj.width; w++)
                                {
                                    if (dy < 0)
                                    {
                                        obj.yPos = 0;
                                        dy++;
                                        h++;
                                    }
                                    if (dx < 0)
                                    {
                                        obj.xPos = 0;
                                        dx++;
                                        w++;
                                    }
                                    if (dx > 9)
                                    {
                                        dx++;
                                        if (w == obj.width - 1)
                                        {
                                            if (obj.direction == 8)
                                            {
                                                if (obj.hFlip)
                                                    dx = obj.xPos - 1 + (i * obj.width);
                                                else
                                                    dx = obj.xPos + (i * obj.width);
                                            }
                                            else
                                            {
                                                if (obj.hFlip)
                                                    dx = obj.xPos - 1;
                                                else
                                                    dx = obj.xPos;
                                            }
                                            if (h == obj.height - 1)
                                                dy = obj.yPos;
                                            else
                                                dy++;
                                        }
                                        continue;
                                    }
                                    if (dy > 7)
                                    {
                                        dx++;
                                        if (w == obj.width - 1)
                                        {
                                            if (obj.direction == 8)
                                            {
                                                if (obj.vFlip)
                                                    dx = obj.xPos - 1 + (i * obj.width);
                                                else
                                                    dx = obj.xPos + (i * obj.width);
                                            }
                                            else
                                            {
                                                if (obj.vFlip)
                                                    dy = obj.yPos - 1 + (i * obj.height);
                                                else
                                                    dx = obj.xPos;
                                            }
                                            if (h == obj.height - 1)
                                                dy = obj.yPos;
                                            else
                                                dy++;
                                        }
                                        continue;
                                    }
                                    if (obj.hFlip && obj.vFlip)
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8)
                                            mapData[(obj.xPos + (w - 1) + (i * obj.width)) + (obj.yPos + (h - 1) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + (w - 1)) + ((obj.yPos + (h - 1) + (i * obj.height)) * 10)] = id;
                                    }
                                    else if (obj.hFlip)
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8)
                                            mapData[(obj.xPos + (w - 1) + (i * obj.width)) + ((obj.yPos + h) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + (w - 1)) + ((obj.yPos + h + (i * obj.height)) * 10)] = id;
                                    }
                                    else if (obj.vFlip)
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8)
                                            mapData[(obj.xPos + w + (i * obj.width)) + ((obj.yPos + (h - 1)) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + w) + ((obj.yPos + (h - 1) + (i * obj.height)) * 10)] = id;
                                    }
                                    else
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8) //Horizontal
                                            mapData[(obj.xPos + w + (i * obj.width)) + ((obj.yPos + h) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + w) + (((obj.yPos + h) + (i * obj.height)) * 10)] = id;
                                    }
                                    dx++;
                                    if (w >= (obj.width - 1))
                                    {
                                        if (obj.direction == 8)
                                        {
                                            dx = obj.xPos + (i * obj.width);
                                            if (obj.hFlip && h != (obj.height - 1))
                                                dx = obj.xPos - 1 + (i * obj.width);

                                        }
                                        else
                                        {
                                            dx = obj.xPos;
                                            if (obj.hFlip && h != (obj.height - 1))
                                                dx = obj.xPos - 1;
                                        }
                                        dy++;
                                    }
                                }
                            }
                        }

                        if (obj.hFlip)
                            obj.xPos = 0x0F;
                        if (obj.vFlip)
                            obj.yPos = 0x0F;
                    }
                }
            }
            return mapData;
        }

        private byte[] getTilePreset()
        {
            int secondhalf;
            int i = -1;
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
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i) + 1;
                if (LAGame.map > 0x7F)
                    secondhalf += 0x68000;
                else
                    secondhalf += 0x24000;
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            else
            {
                secondhalf = 0x24000 + (LAGame.map * 2);
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf) + 1;
                if (LAGame.map > 0x7F)
                    secondhalf = 0x68000 + (secondhalf - 0x24000);
                LAGame.gbROM.BufferLocation = secondhalf;
            }
            byte b = LAGame.gbROM.ReadByte();
            byte[] TilePreset = new byte[2];
            TilePreset[0] = (byte)(b & 0xF); //Floor
            TilePreset[1] = (byte)(b >> 4); //Wall
            return TilePreset;
        }

        public void saveOverlayOverworldMapData()
        {
            GetOverlayDataOverworldOffset();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    LAGame.gbROM.WriteByte(overlayMapData[x + (y * 10)]);
                }
            }
        }

        public void saveCollisionOverworldData()
        {
            SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, this);

            //This method is only for saving when used space < free space. Use collision repointer class for the other way around.
            if (spaceCalculator.getUsedSpaceCollisions() <= spaceCalculator.getFreeSpaceOverworld())
            {
                byte b;
                getCollisionDataOverworldOffset();
                foreach (CollisionObject obj in collisionObjects)
                {
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
                if (warpObjects.Count != 0)
                {
                    foreach (Warps warp in warpObjects)
                    {
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
        }

        public void getCollisionDataDungeonOffset()
        {
            if (LAGame.specialFlag && LAGame.map == 0xF5 && LAGame.dungeon >= 0x1A || LAGame.specialFlag && LAGame.map == 0xF5 && LAGame.dungeon < 6)
            {
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(0x3198);
                LAGame.gbROM.BufferLocation += 0x28001;
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x28000;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation += 0x4000;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x2BB77;
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation + (LAGame.map * 2)) + 1; //skip animation    
            }
            mapAddress = LAGame.gbROM.BufferLocation - 1;
        }
        public void loadCollisionDataDungeon()
        {
            collisionObjects = new List<CollisionObject>();
            warpObjects = new List<Warps>();
            getCollisionDataDungeonOffset();

            byte b = LAGame.gbROM.ReadByte();
            while ((b = LAGame.gbROM.ReadByte()) != 0xFE) //0xFE = End of room
            {
                //There is free space forroom 0xFF (dungeon >=6) but there is no room ending byte
                if (LAGame.dungeon == 0xFF && LAGame.gbROM.BufferLocation >= 0x2BF43)
                    break;
                else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && LAGame.gbROM.BufferLocation >= 0x2FFFF && LAGame.dungeon != 0xFF)
                    break;
                else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && LAGame.gbROM.BufferLocation >= 0x2BB77 && LAGame.dungeon != 0xFF)
                    break;

                //Check to see if we are reading empty space
                /*if (b == 0)
                {
                    //We need a 00 00 00 for it to be empty space. Otherwise it could just be an object in XY position 0.
                    byte x = LAGame.gbROM.ReadByte();
                    if (x == 0)
                    {
                        x = LAGame.gbROM.ReadByte();
                        if (x == 0 && x != 0xFE)
                        {
                            LAGame.gbROM.BufferLocation--;
                            continue;
                        }
                        if (x == 0xFE)
                            break;
                        else
                            LAGame.gbROM.BufferLocation -= 2;
                    }
                }*/

                if (b >> 4 == 0xE)
                {
                    if (LAGame.dungeon == 0xFF && LAGame.gbROM.BufferLocation + 4 >= 0x2BF43)
                        continue;
                    else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && LAGame.gbROM.BufferLocation + 4 >= 0x2FFFF && LAGame.dungeon != 0xFF)
                        continue;
                    else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && LAGame.gbROM.BufferLocation + 4 >= 0x2BB77 && LAGame.dungeon != 0xFF)
                        continue;

                    Warps w = new Warps();
                    w.type = (byte)(b & 0x0F);
                    w.region = LAGame.gbROM.ReadByte();
                    w.map = LAGame.gbROM.ReadByte();
                    w.x = LAGame.gbROM.ReadByte();
                    w.y = LAGame.gbROM.ReadByte();
                    warpObjects.Add(w);
                    continue;
                }
                if (b >> 4 == 8 || b >> 4 == 0xC) //3-Byte objects
                {
                    if (LAGame.dungeon == 0xFF && LAGame.gbROM.BufferLocation + 2 >= 0x2BF43)
                        continue;
                    else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && LAGame.gbROM.BufferLocation + 2 >= 0x2FFFF && LAGame.dungeon != 0xFF)
                        continue;
                    else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && LAGame.gbROM.BufferLocation + 2 >= 0x2BB77 && LAGame.dungeon != 0xFF)
                        continue;

                    CollisionObject o = new CollisionObject();
                    o.is3Byte = true;
                    o.length = (byte)(b & 0xF);
                    o.direction = (byte)(b >> 4);
                    byte b2 = LAGame.gbROM.ReadByte();
                    o.yPos = (byte)(b2 >> 4);
                    o.xPos = (byte)(b2 & 0xF);
                    o.id = LAGame.gbROM.ReadByte();
                    if (o.id >= 0xEC && o.id <= 0xFD)// Door tiles
                    {
                        int bufferloc = LAGame.gbROM.BufferLocation;
                        o.dungeonDoors(LAGame, o);
                        LAGame.gbROM.BufferLocation = bufferloc;


                        foreach (CollisionObject obj in o.objectIDs)
                        {
                            collisionObjects.Add(obj);
                        }
                    }
                    else
                        collisionObjects.Add(o);
                    continue;
                }
                else
                {
                    if (LAGame.dungeon == 0xFF && LAGame.gbROM.BufferLocation + 1 >= 0x2BF43)
                        continue;
                    else if ((LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A) && LAGame.gbROM.BufferLocation + 1 >= 0x2FFFF && LAGame.dungeon != 0xFF)
                        continue;
                    else if ((LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A) && LAGame.gbROM.BufferLocation + 1 >= 0x2BB77 && LAGame.dungeon != 0xFF)
                        continue;


                    CollisionObject ob = new CollisionObject(); // 2-Byte tiles
                    ob.yPos = (byte)(b >> 4);
                    ob.xPos = (byte)(b & 0xF);
                    ob.id = LAGame.gbROM.ReadByte();
                    if (ob.id >= 0xEC && ob.id <= 0xFD)// Door tiles
                    {
                        int bufferloc = LAGame.gbROM.BufferLocation;
                        ob.dungeonDoors(LAGame, ob);
                        LAGame.gbROM.BufferLocation = bufferloc;


                        foreach (CollisionObject obj in ob.objectIDs)
                        {
                            collisionObjects.Add(obj);
                        }
                    }
                    else
                        collisionObjects.Add(ob);
                }


            }
        }

        public byte[] loadMapDataDungeon()
        {
            byte[] mapData = new byte[80];
            for (int i = 0; i < 80; i++)
                mapData[i] = dungeonFloor;
            for (int i = 0; i < 64; i++)
            {
                CollisionObject o = wallTiles[dungeonWalls, i];
                if (o != null)
                    mapData[o.xPos + (o.yPos * 10)] = (byte)o.id;
            }
            foreach (CollisionObject obj in collisionObjects)
            {
                int dx = (obj.xPos == 0xF ? (obj.xPos - 16) : obj.xPos);
                int dy = (obj.yPos == 0xF ? (obj.yPos - 16) : obj.yPos);

                if (!obj.is3Byte)
                {
                    if (obj.multiTileFlag)
                    {
                        for (int h = 0; h < obj.height; h++)
                        {
                            for (int w = 0; w < obj.width; w++)
                            {
                                if (dy < 0)
                                {
                                    obj.yPos = 0;
                                    dy++;
                                    h++;
                                }
                                if (dx < 0)
                                {
                                    obj.xPos = 0;
                                    dx++;
                                    w++;
                                }
                                if (dx > 9)
                                {
                                    dx++;
                                    if (w == obj.width - 1)
                                    {
                                        if (obj.hFlip)
                                            dx = obj.xPos - 1;
                                        else
                                            dx = obj.xPos;
                                        if (h == obj.height - 1)
                                            dy = obj.yPos;
                                        else
                                            dy++;
                                    }
                                    continue;
                                }
                                if (dy > 7)
                                {
                                    dx++;
                                    if (w == obj.width - 1)
                                    {
                                        if (obj.vFlip)
                                            dx = obj.xPos - 1;
                                        else
                                            dx = obj.xPos;
                                        if (h == obj.height - 1)
                                            dy = obj.yPos;
                                        else
                                            dy++;
                                    }
                                    continue;
                                }
                                if (obj.hFlip && obj.vFlip)
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + (w - 1)) + ((obj.yPos + (h - 1)) * 10)] = id;
                                }
                                else if (obj.hFlip)
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + (w - 1)) + ((obj.yPos + h) * 10)] = id;
                                }
                                else if (obj.vFlip)
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + w) + ((obj.yPos + (h - 1)) * 10)] = id;
                                }
                                else
                                {
                                    byte id = obj.tiles[(h * obj.width) + w];
                                    mapData[(obj.xPos + w) + ((obj.yPos + h) * 10)] = id;
                                }
                                dx++;
                                if (w >= (obj.width - 1))
                                {
                                    if (obj.hFlip)
                                        dx = obj.xPos - 1;
                                    else
                                        dx = obj.xPos;
                                    dy++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dy < 0 || dy > 7)
                            continue;
                        if (dx < 0 || dx > 9)
                            continue;
                        mapData[obj.xPos + (obj.yPos * 10)] = (byte)obj.id;
                    }
                }
                else if (obj.is3Byte)
                {
                    if (obj.multiTileFlag)
                    {
                        for (int i = 0; i < obj.length; i++)
                        {
                            if (obj.direction == 8)
                            {
                                if (dx >= 0)
                                {
                                    dx = obj.xPos + (i * obj.width);
                                    if (obj.hFlip)
                                        dx = obj.xPos - 1 + (i * obj.width);
                                }
                                if (dy >= 0)
                                {
                                    dy = obj.yPos;
                                    if (obj.vFlip)
                                        dy = obj.yPos - 1;
                                }
                            }
                            else
                            {
                                if (dx >= 0)
                                {
                                    dx = obj.xPos;
                                    if (obj.hFlip)
                                        dx = obj.xPos - 1;
                                }
                                if (dy >= 0)
                                {
                                    dy = obj.yPos + (i * obj.height);
                                    if (obj.vFlip)
                                        dy = obj.yPos - 1 + (i * obj.height);
                                }
                            }
                            for (int h = 0; h < obj.height; h++)
                            {
                                for (int w = 0; w < obj.width; w++)
                                {
                                    if (dy < 0)
                                    {
                                        obj.yPos = 0;
                                        dy++;
                                        h++;
                                    }
                                    if (dx < 0)
                                    {
                                        obj.xPos = 0;
                                        dx++;
                                        w++;
                                    }
                                    if (dx > 9)
                                    {
                                        dx++;
                                        if (w == obj.width - 1)
                                        {
                                            if (obj.direction == 8)
                                            {
                                                if (obj.hFlip)
                                                    dx = obj.xPos - 1 + (i * obj.width);
                                                else
                                                    dx = obj.xPos + (i * obj.width);
                                            }
                                            else
                                            {
                                                if (obj.hFlip)
                                                    dx = obj.xPos - 1;
                                                else
                                                    dx = obj.xPos;
                                            }
                                            if (h == obj.height - 1)
                                                dy = obj.yPos;
                                            else
                                                dy++;
                                        }
                                        continue;
                                    }
                                    if (dy > 7)
                                    {
                                        dx++;
                                        if (w == obj.width - 1)
                                        {
                                            if (obj.direction == 8)
                                            {
                                                if (obj.vFlip)
                                                    dx = obj.xPos - 1 + (i * obj.width);
                                                else
                                                    dx = obj.xPos + (i * obj.width);
                                            }
                                            else
                                            {
                                                if (obj.vFlip)
                                                    dy = obj.yPos - 1 + (i * obj.height);
                                                else
                                                    dx = obj.xPos;
                                            }
                                            if (h == obj.height - 1)
                                                dy = obj.yPos;
                                            else
                                                dy++;
                                        }
                                        continue;
                                    }
                                    if (obj.hFlip && obj.vFlip)
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8)
                                            mapData[(obj.xPos + (w - 1) + (i * obj.width)) + (obj.yPos + (h - 1) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + (w - 1)) + ((obj.yPos + (h - 1) + (i * obj.height)) * 10)] = id;
                                    }
                                    else if (obj.hFlip)
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8)
                                            mapData[(obj.xPos + (w - 1) + (i * obj.width)) + ((obj.yPos + h) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + (w - 1)) + ((obj.yPos + h + (i * obj.height)) * 10)] = id;
                                    }
                                    else if (obj.vFlip)
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8)
                                            mapData[(obj.xPos + w + (i * obj.width)) + ((obj.yPos + (h - 1)) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + w) + ((obj.yPos + (h - 1) + (i * obj.height)) * 10)] = id;
                                    }
                                    else
                                    {
                                        byte id = obj.tiles[(h * obj.width) + w];
                                        if (obj.direction == 8) //Horizontal
                                            mapData[(obj.xPos + w + (i * obj.width)) + ((obj.yPos + h) * 10)] = id;
                                        else
                                            mapData[(obj.xPos + w) + (((obj.yPos + h) + (i * obj.height)) * 10)] = id;
                                    }
                                    dx++;
                                    if (w >= (obj.width - 1))
                                    {
                                        if (obj.direction == 8)
                                        {
                                            dx = obj.xPos + (i * obj.width);
                                            if (obj.hFlip && h != (obj.height - 1))
                                                dx = obj.xPos - 1 + (i * obj.width);

                                        }
                                        else
                                        {
                                            dx = obj.xPos;
                                            if (obj.hFlip && h != (obj.height - 1))
                                                dx = obj.xPos - 1;
                                        }
                                        dy++;
                                    }
                                }
                            }
                        }
                        if (obj.hFlip)
                            obj.xPos = 0x0F;
                        if (obj.vFlip)
                            obj.yPos = 0x0F;
                    }
                    else
                    {
                        for (int i = 0; i < obj.length; i++)
                        {
                            if (obj.direction == 8) //horizontal
                            {
                                if (dy > 7 || dy < 0)
                                    continue;
                                if (dx < 0)
                                {
                                    dx++;
                                    obj.xPos = 0;
                                    i++;
                                }
                                if (dx >= 10)
                                    continue;
                                mapData[obj.xPos + (obj.yPos * 10) + i] = obj.id;
                                dx++;

                            }
                            else
                            {
                                if (dx > 9)
                                    continue;
                                if (dy < 0)
                                {
                                    dy++;
                                    obj.yPos = 0;
                                    i++;
                                }
                                if (dy > 7)
                                    continue;
                                mapData[obj.xPos + (obj.yPos * 10) + (i * 10)] = obj.id;
                                dy++;
                            }
                        }
                    }
                }


            }
            return mapData;
        }
        public void getWallsandFloor()
        {
            if (LAGame.specialFlag && LAGame.map == 0xF5 && LAGame.dungeon >= 0x1A)
            {
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(0x3198);
                LAGame.gbROM.BufferLocation += 0x28001;
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x28000;
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                    LAGame.gbROM.BufferLocation += 0x4000;
                else if (LAGame.dungeon == 0xFF)
                    LAGame.gbROM.BufferLocation = 0x2BB77;
                LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation + (LAGame.map * 2)) + 1; //skip animation     
            }
            byte b = LAGame.gbROM.ReadByte();
            dungeonWalls = (byte)(b >> 4); //Upper nybble = wall type
            dungeonFloor = (byte)(b & 0xF); //Lower nybble = floor type
            loadWalls();
        }

        public void loadWalls()
        {
            LAGame.gbROM.BufferLocation = 0x50917;
            for (int i = 0; i < 9; i++)
            {
                byte b = 0;
                int count = 0;
                List<CollisionObject> listt = new List<CollisionObject>();
                while ((b = LAGame.gbROM.ReadByte()) != 0xFF)
                {
                    CollisionObject t = new CollisionObject();
                    t.yPos = (byte)(b / 16);
                    t.xPos = (byte)(b - (t.yPos * 16));
                    listt.Add(t);
                    count++;
                }
                byte[] buffer = LAGame.gbROM.ReadBytes(count);
                for (int k = 0; k < count; k++)
                {
                    CollisionObject t = listt[k];
                    t.id = buffer[k];
                    listt[k] = t;
                    wallTiles[i, k] = listt[k];
                }
            }
        }

        public void saveCollisionDungeonData()
        {
            SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, this);
            //This method is only for saving when used space < free space. Use collision repointer class for the other way around.
            if (spaceCalculator.getUsedSpaceCollisions() <= spaceCalculator.getFreeSpaceDungeon())
            {
                if (LAGame.specialFlag && LAGame.dungeon >= 0x1A && LAGame.map == 0xF5 || LAGame.specialFlag && LAGame.map == 0xF5 && LAGame.dungeon < 6)
                {
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(0x3198);
                    LAGame.gbROM.BufferLocation += 0x28001; //Skip animation
                }
                else
                {
                    LAGame.gbROM.BufferLocation = 0x28000;
                    if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                        LAGame.gbROM.BufferLocation += 0x4000;
                    else if (LAGame.dungeon == 0xFF)
                        LAGame.gbROM.BufferLocation = 0x2BB77;
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation + (LAGame.map * 2)) + 1; //skip animation   
                }
                byte b = (byte)((dungeonWalls * 0x10) + dungeonFloor);
                LAGame.gbROM.WriteByte(b);
                foreach (CollisionObject obj in collisionObjects)
                {
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
                if (warpObjects.Count != 0)
                {
                    foreach (Warps warp in warpObjects)
                    {
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
        }
    }
}
