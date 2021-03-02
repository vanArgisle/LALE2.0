
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

        public int getFreeSpace() //Temporary
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
            //else if (Map == 0x51 || Map == 0x63)
            // space = ((int)pointers.GetValue(index + 2) - 3) - cMapPointer;
            else if (index < pointers.Length)
            {
                while ((int)pointers.GetValue(index + 1) == cMapPointer)
                    index++;
                space = ((int)pointers.GetValue(index + 1) - 3) - cMapPointer;
            }
            return space;
        }

        public int getFreeSpace(int mapToCheckSpace) //Temporary
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
            //else if (Map == 0x51 || Map == 0x63)
            // space = ((int)pointers.GetValue(index + 2) - 3) - cMapPointer;
            else
            {
                while ((int)pointers.GetValue(index + 1) == cMapPointer)
                    index++;
                space = ((int)pointers.GetValue(index + 1) - 3) - cMapPointer;
            }
            return space;
        }
    }
}
