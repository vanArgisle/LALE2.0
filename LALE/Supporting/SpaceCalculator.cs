
using LALE.Core;
using System;
using System.Collections.Generic;

namespace LALE
{
    public class SpaceCalculator
    {
        private Game LAGame;
        private MapTileData mapTileData;


        public SpaceCalculator(Game game, MapTileData mtd)
        {
            LAGame = new Game(game);
            mapTileData = mtd;
        }

        public int getUsedSpace()
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

        public int getUsedSpace(List<CollisionObject> collisionObjects, List<Warps> warpObjects)
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
            List<Int32> unSortedPointers = new List<Int32>();
            int[] pointers = new int[262];
            int cMapPointer = 0;
            
            int map = 0;
            int index;
            int space = 0;

            while (map < 256)
            {
                int secondhalf;
                int i = 0;
                int i2 = 0;
                secondhalf = 0x24000 + (map * 2);
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);
                if (map > 0x7F)
                    secondhalf = 0x68000 + (secondhalf - 0x24000);
                if (map == LAGame.map)
                    cMapPointer = secondhalf;
                pointers[map] = secondhalf;
                switch (map)
                {
                    case 0x06: i = 0x31F4; i2 = 1; break;
                    case 0x0E: i = 0x31C4; i2 = 2; break;
                    case 0x1B: i = 0x3204; i2 = 3; break;
                    case 0x2B: i = 0x3214; i2 = 4; break;
                    case 0x79: i = 0x31E4; i2 = 5; break;
                    case 0x8C: i = 0x31D4; i2 = 6; break;
                }
                if (i > 0)
                {
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                    if (map > 0x7F)
                        secondhalf += 0x68000;
                    else
                        secondhalf += 0x24000;
                    if (LAGame.specialFlag && map == LAGame.map)
                        cMapPointer = secondhalf;
                    pointers[i2 + 0xFF] = secondhalf;
                }
                map++;
            }

            foreach (int point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);
            if (LAGame.map == 0xFF || index == pointers.Length - 1)
            {
                LAGame.gbROM.BufferLocation = cMapPointer;
                space = 0x69E73 - cMapPointer;
            }
            else if (LAGame.map == 0x7F || index == pointers.Length - 1)
            {
                LAGame.gbROM.BufferLocation = cMapPointer;
                space = 0x2668B - cMapPointer;
            }
            else if (index < pointers.Length)
            {
                while ((int)pointers.GetValue(index + 1) == cMapPointer)
                    index++;
                space = ((int)pointers.GetValue(index + 1) - 3) - cMapPointer;
            }
            return space;
        }

        public int getFreeSpaceOverworld(int mapToCheckSpace)
        {
            List<Int32> unSortedPointers = new List<Int32>();
            int[] pointers = new int[262];
            int cMapPointer = 0;

            int map = 0;
            int index;
            int space = 0;

            while (map < 256)
            {
                int secondhalf;
                int i = 0;
                int i2 = 0;
                secondhalf = 0x24000 + (map * 2);
                secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(secondhalf);
                if (map > 0x7F)
                    secondhalf = 0x68000 + (secondhalf - 0x24000);
                if (map == mapToCheckSpace)
                    cMapPointer = secondhalf;
                pointers[map] = secondhalf;
                switch (map)
                {
                    case 0x06: i = 0x31F4; i2 = 1; break;
                    case 0x0E: i = 0x31C4; i2 = 2; break;
                    case 0x1B: i = 0x3204; i2 = 3; break;
                    case 0x2B: i = 0x3214; i2 = 4; break;
                    case 0x79: i = 0x31E4; i2 = 5; break;
                    case 0x8C: i = 0x31D4; i2 = 6; break;
                }
                if (i > 0)
                {
                    secondhalf = LAGame.gbROM.Get2BytePointerAtAddress(i);
                    if (map > 0x7F)
                        secondhalf += 0x68000;
                    else
                        secondhalf += 0x24000;
                    if (LAGame.specialFlag && map == mapToCheckSpace)
                        cMapPointer = secondhalf;
                    pointers[i2 + 0xFF] = secondhalf;
                }
                map++;
            }

            foreach (int point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);
            if (mapToCheckSpace == 0xFF)
            {
                LAGame.gbROM.BufferLocation = cMapPointer;
                space = 0x69E73 - cMapPointer;
            }
            else if (mapToCheckSpace == 0x7F)
            {
                LAGame.gbROM.BufferLocation = cMapPointer;
                space = 0x2668B - cMapPointer;
            }
            else
            {
                while ((int)pointers.GetValue(index + 1) == cMapPointer)
                    index++;
                space = ((int)pointers.GetValue(index + 1) - 3) - cMapPointer;
            }
            return space;
        }

        public int getFreeSpaceDungeon()
        {
            int[] pointers = new int[257];
            List<Int32> unSortedPointers = new List<Int32>();
            int cMapPointer = 0;
            int map = 0;
            int index;
            int space = 0;
            if (LAGame.dungeon == 0xFF)
            {
                pointers = new int[0x16];
                while (map < 0x16)
                {
                    LAGame.gbROM.BufferLocation = 0x2BB77 + (map * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    if (map == LAGame.map)
                        cMapPointer = LAGame.gbROM.BufferLocation;
                    pointers[map] = LAGame.gbROM.BufferLocation;
                    map++;
                }
            }
            else
            {
                while (map < 256)
                {
                    LAGame.gbROM.BufferLocation = 0x28000 + (map * 2);
                    if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                        LAGame.gbROM.BufferLocation += 0x4000;
                    else if (LAGame.dungeon == 0xFF)
                        LAGame.gbROM.BufferLocation = 0x2BB77 + (map * 2);
                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(LAGame.gbROM.BufferLocation);
                    if (map == LAGame.map)
                        cMapPointer = LAGame.gbROM.BufferLocation;
                    pointers[map] = LAGame.gbROM.BufferLocation;
                    if (LAGame.dungeon >= 0x1A || LAGame.dungeon < 0x6)
                    {
                        switch (map)
                        {
                            case 0xF5:
                                {
                                    LAGame.gbROM.BufferLocation = LAGame.gbROM.Get2BytePointerAtAddress(0x3198);
                                    LAGame.gbROM.BufferLocation += 0x28000;
                                    if (LAGame.magnifyGlass && map == LAGame.map)
                                        cMapPointer = LAGame.gbROM.BufferLocation;
                                    pointers[1 + 0xFF] = LAGame.gbROM.BufferLocation;
                                    break;
                                }

                        }
                    }
                    map++;
                }
            }
            foreach (int point in pointers)
                unSortedPointers.Add(point);
            Array.Sort(pointers);
            index = Array.IndexOf(pointers, cMapPointer);

            if (LAGame.dungeon == 0xFF && LAGame.map == 0x15)
                space = 0x2BF43 - (cMapPointer + 3);
            else if (LAGame.map != 0xFF || LAGame.dungeon == 0xFF && LAGame.map != 0x15)
            {
                while ((int)pointers.GetValue(index + 1) == cMapPointer)
                    index++;
                space = ((int)pointers.GetValue(index + 1) - 3) - cMapPointer;
            }
            else
            {
                LAGame.gbROM.BufferLocation = cMapPointer;
                if (LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A)
                    space = 0x2BB77 - (cMapPointer + 3);
                else
                    space = 0x2FFFF - (cMapPointer + 2);
            }
            return space;
        }
    }
}
