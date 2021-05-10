
using LALE.Core;
using LALE.Supporting;
using System;
using System.Collections.Generic;

namespace LALE
{
    public class SpaceCalculator
    {
        private Game LAGame;
        private MapTileData mapTileData;

        public class Pointer : IComparable<Pointer>
        {
            public int map;
            public int pointer;

            public int CompareTo(Pointer point)
            {
                return this.pointer.CompareTo(point.pointer);
            }

            public bool Equals(Pointer point)
            {
                if (point.map == this.map && point.pointer == this.pointer)
                    return true;
                else
                    return false;
            }
        }

        public SpaceCalculator(Game game, MapTileData mtd)
        {
            LAGame = new Game(game);
            mapTileData = mtd;
        }

        public int getUsedSpaceCollisions()
        {
            int s = 0;
            foreach (CollisionObject o in mapTileData.collisionObjects)
            {
                if (o.is3Byte)
                    s += 3;
                else
                    s += 2;
            }
            if (mapTileData.warpObjects.Count != 0)
            {
                foreach (Warps w in mapTileData.warpObjects)
                    s += 5;
            }
            return s;
        }

        public int getUsedSpaceCollisions(List<CollisionObject> collisionObjects, List<Warps> warpObjects)
        {
            int s = 0;
            foreach (CollisionObject o in collisionObjects)
            {
                if (o.is3Byte)
                    s += 3;
                else
                    s += 2;
            }
            if (warpObjects.Count != 0)
            {
                foreach (Warps w in warpObjects)
                    s += 5;
            }
            return s;
        }

        public int getFreeSpaceOverworld()
        {
            List<Pointer> unSortedPointers = new List<Pointer>();
            Pointer[] pointers;
            if (LAGame.map > 0x7F)
                pointers = new Pointer[129];
            else
                pointers = new Pointer[133];
            Pointer cMapPointer = new Pointer();

            int map = 0;
            int index;
            int space = 0;

            if (LAGame.map < 0x80)
            {
                while (map <= 0x7F)
                {
                    int secondhalf;
                    int i = 0;
                    int i2 = 0;
                    Pointer mapPointer = new Pointer();
                    mapPointer.map = map;

                    secondhalf = 0x24000 + (map * 2);
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);

                    mapPointer.pointer = secondhalf;
                    pointers[map] = mapPointer;

                    if (map == LAGame.map)
                        cMapPointer = mapPointer;

                    switch (map)
                    {
                        case 0x06: i = 0x31F4; i2 = 1; break;
                        case 0x0E: i = 0x31C4; i2 = 2; break;
                        case 0x1B: i = 0x3204; i2 = 3; break;
                        case 0x2B: i = 0x3214; i2 = 4; break;
                        case 0x79: i = 0x31E4; i2 = 5; break;
                    }
                    if (i > 0)
                    {
                        Pointer specialMapPointer = new Pointer();
                        specialMapPointer.map = map;

                        secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                        secondhalf += 0x24000;

                        specialMapPointer.pointer = secondhalf;
                        pointers[i2 + 0x7F] = specialMapPointer;

                        if (LAGame.specialFlag && map == LAGame.map)
                            cMapPointer = specialMapPointer;
                    }
                    map++;
                }
            }
            else
            {
                map = 0x80;
                while (map < 256)
                {
                    int secondhalf;
                    int i = 0;
                    int i2 = 0;
                    Pointer mapPointer = new Pointer();
                    mapPointer.map = map;

                    secondhalf = 0x24000 + (map * 2);
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);
                    secondhalf = 0x68000 + (secondhalf - 0x24000);

                    mapPointer.pointer = secondhalf;
                    pointers[map - 0x80] = mapPointer;

                    if (map == LAGame.map)
                        cMapPointer = mapPointer;

                    switch (map)
                    {
                        case 0x8C: i = 0x31D4; i2 = 1; break;
                    }
                    if (i > 0)
                    {
                        Pointer specialMapPointer = new Pointer();
                        specialMapPointer.map = map;

                        secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                        secondhalf += 0x68000;

                        specialMapPointer.pointer = secondhalf;
                        pointers[i2 + 0x7F] = specialMapPointer;

                        if (LAGame.specialFlag && map == LAGame.map)
                            cMapPointer = specialMapPointer;
                    }
                    map++;
                }
            }

            foreach (Pointer point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);
           
            if (index == pointers.Length - 1)
            {
                if (LAGame.map > 0x7F)
                {
                    space = 0x69E73 - cMapPointer.pointer;
                }
                else
                {
                    space = 0x2668B - cMapPointer.pointer;
                }
            }
            else if (index < pointers.Length)
            {
                try
                {
                    while (pointers.GetValue(index + 1) == cMapPointer)
                        index++;
                }
                catch
                {
                    index--;
                    Console.WriteLine("Out of bounds map lower than FF/7F");
                }

                Pointer p = (Pointer)(pointers.GetValue(index + 1));
                if (p.pointer == cMapPointer.pointer)
                    space = p.pointer - cMapPointer.pointer;
                else
                    space = p.pointer - 3 - cMapPointer.pointer;
            }
            return space;
        }

        public int getFreeSpaceOverworld(int mapToCheckSpace)
        {
            List<Pointer> unSortedPointers = new List<Pointer>();
            Pointer[] pointers;
            if (LAGame.map > 0x7F)
                pointers = new Pointer[129];
            else
                pointers = new Pointer[133];
            Pointer cMapPointer = new Pointer();

            int map = 0;
            int index;
            int space = 0;

            if (LAGame.map < 0x80)
            {
                while (map <= 0x7F)
                {
                    int secondhalf;
                    int i = 0;
                    int i2 = 0;
                    Pointer mapPointer = new Pointer();
                    mapPointer.map = map;

                    secondhalf = 0x24000 + (map * 2);
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);

                    mapPointer.pointer = secondhalf;
                    pointers[map] = mapPointer;

                    if (map == mapToCheckSpace)
                        cMapPointer = mapPointer;

                    switch (map)
                    {
                        case 0x06: i = 0x31F4; i2 = 1; break;
                        case 0x0E: i = 0x31C4; i2 = 2; break;
                        case 0x1B: i = 0x3204; i2 = 3; break;
                        case 0x2B: i = 0x3214; i2 = 4; break;
                        case 0x79: i = 0x31E4; i2 = 5; break;
                    }
                    if (i > 0)
                    {
                        Pointer specialMapPointer = new Pointer();
                        specialMapPointer.map = map;

                        secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                        secondhalf += 0x24000;

                        specialMapPointer.pointer = secondhalf;
                        pointers[i2 + 0x7F] = specialMapPointer;

                        if (LAGame.specialFlag && map == mapToCheckSpace)
                            cMapPointer = specialMapPointer;
                    }
                    map++;
                }
            }
            else
            {
                map = 0x80;
                while (map < 256)
                {
                    int secondhalf;
                    int i = 0;
                    int i2 = 0;
                    Pointer mapPointer = new Pointer();
                    mapPointer.map = map;

                    secondhalf = 0x24000 + (map * 2);
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);
                    secondhalf = 0x68000 + (secondhalf - 0x24000);

                    mapPointer.pointer = secondhalf;
                    pointers[map - 0x80] = mapPointer;

                    if (map == mapToCheckSpace)
                        cMapPointer = mapPointer;

                    switch (map)
                    {
                        case 0x8C: i = 0x31D4; i2 = 1; break;
                    }
                    if (i > 0)
                    {
                        Pointer specialMapPointer = new Pointer();
                        specialMapPointer.map = map;

                        secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                        secondhalf += 0x68000;

                        specialMapPointer.pointer = secondhalf;
                        pointers[i2 + 0x7F] = specialMapPointer;

                        if (LAGame.specialFlag && map == mapToCheckSpace)
                            cMapPointer = specialMapPointer;
                    }
                    map++;
                }
            }

            foreach (Pointer point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);

            if (index == pointers.Length - 1)
            {
                if (LAGame.map > 0x7F)
                {
                    space = 0x69E73 - cMapPointer.pointer;
                }
                else
                {
                    space = 0x2668B - cMapPointer.pointer;
                }
            }
            else if (index < pointers.Length)
            {
                try
                {
                    while (pointers.GetValue(index + 1) == cMapPointer)
                        index++;
                }
                catch
                {
                    index--;
                    Console.WriteLine("Out of bounds map lower than FF/7F");
                }

                Pointer p = (Pointer)(pointers.GetValue(index + 1));
                if (p.pointer == cMapPointer.pointer)
                    space = p.pointer - cMapPointer.pointer;
                else
                    space = p.pointer - 3 - cMapPointer.pointer;
            }
            return space;
        }

        public int getFreeSpaceDungeon()
        {
            List<Pointer> unSortedPointers = new List<Pointer>();
            Pointer[] pointers;
            if (LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A)
                pointers = new Pointer[257];
            else
                pointers = new Pointer[256];
            Pointer cMapPointer = new Pointer();
            int map = 0;
            int index;
            int space = 0;
            if (LAGame.dungeon == 0xFF)
            {
                pointers = new Pointer[0x16];
                
                while (map < 0x16)
                {
                    Pointer point = new Pointer();
                    point.map = map;

                    LAGame.gbROM.BufferLocation = 0x2BB77 + (map * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                 
                    point.pointer = LAGame.gbROM.BufferLocation;
                    pointers[map] = point;

                    if (map == LAGame.map)
                        cMapPointer = point;

                    map++;
                }
            }
            else
            {
             
                while (map < 256)
                {
                    Pointer point = new Pointer();
                    point.map = map;

                    LAGame.gbROM.BufferLocation = 0x28000 + (map * 2);
                    if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                        LAGame.gbROM.BufferLocation += 0x4000;
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);

                    point.pointer = LAGame.gbROM.BufferLocation;
                    pointers[map] = point;

                    if (map == LAGame.map)
                        cMapPointer = point;

                    if (LAGame.dungeon >= 0x1A || LAGame.dungeon < 0x6)
                    {
                        switch (map)
                        {
                            case 0xF5:
                                {
                                    Pointer specialPointer = new Pointer();
                                    specialPointer.map = map;

                                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(0x3198);
                                    LAGame.gbROM.BufferLocation += 0x28000;

                                    specialPointer.pointer = LAGame.gbROM.BufferLocation;
                                    pointers[1 + 0xFF] = specialPointer;

                                    if (LAGame.specialFlag && map == LAGame.map)
                                        cMapPointer = specialPointer;
                                    break;
                                }

                        }
                    }
                    map++;
                }
            }
            foreach (Pointer point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);

            if (index == pointers.Length - 1)
            {
                if (LAGame.dungeon == 0xFF)
                    space = 0x2BF43 - (cMapPointer.pointer + 3);
                else
                {
                    if (LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A)
                        space = 0x2BB77 - (cMapPointer.pointer + 3);
                    else
                        space = 0x2FFFF - (cMapPointer.pointer + 2);
                }
            }
            else if (index < pointers.Length)
            {
                    try
                    {
                        while (pointers.GetValue(index + 1) == cMapPointer)
                            index++;
                    }
                    catch
                    {
                        index--;
                        Console.WriteLine("Out of bounds map lower than FF");
                    }
                    Pointer p = (Pointer)(pointers.GetValue(index + 1));
                    if (p.pointer == cMapPointer.pointer)
                        space = p.pointer - cMapPointer.pointer;
                    else
                        space = p.pointer - 3 - cMapPointer.pointer;
            }

            return space;
        }

        public int getUsedSpaceEntities(List<Entity> entities)
        {
            int s = 0;
            foreach (Entity e in entities)
                s += 2;
            return s;
        }

        public int getFreeSpaceEntities()
        {
            List<Pointer> unSortedPointers = new List<Pointer>();
            Pointer[] pointers = new Pointer[256];
            Pointer cMapPointer = new Pointer();
            int map = 0;
            int index;
            int space = 0;

            if (LAGame.dungeon == 0xFF)
            {
                pointers = new Pointer[0x16];
                while (map < 0x16)
                {
                    Pointer point = new Pointer();
                    point.map = map;

                    LAGame.gbROM.BufferLocation = 0x58600 + (map * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);

                    point.pointer = LAGame.gbROM.BufferLocation;
                    pointers[map] = point;

                    if (map == LAGame.map)
                        cMapPointer = point;
                    map++;
                }
            }
            else
            {
                while (map < 256)
                {
                    Pointer point = new Pointer();
                    point.map = map;

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
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation + (map * 2));

                    point.pointer = LAGame.gbROM.BufferLocation;
                    pointers[map] = point;

                    if (map == LAGame.map)
                        cMapPointer = point;

                    map++;
                }
            }


            foreach (Pointer point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);

            if (index == pointers.Length - 1)
            {
                if (LAGame.overworldFlag)
                    space = 0x59663 - cMapPointer.pointer;
                else if (LAGame.dungeon == 0xFF)
                    space = 0x596FF - cMapPointer.pointer;
                else if (LAGame.dungeon >= 0x1A || LAGame.dungeon < 6)
                    space = 0x58CA3 - cMapPointer.pointer;
                else
                    space = 0x59185 - cMapPointer.pointer;
            }
            else if (index < pointers.Length)
            {
                try
                {
                    while (pointers.GetValue(index + 1) == cMapPointer)
                        index++;
                }
                catch
                {
                    index--;
                    Console.WriteLine("Out of bounds map lower than FF");
                }
                Pointer p = (Pointer)(pointers.GetValue(index + 1));
                if (p.pointer == cMapPointer.pointer)
                    space = p.pointer - cMapPointer.pointer;
                else
                    space = p.pointer - 1 - cMapPointer.pointer;
            }
            return space;
        }
    }
}
