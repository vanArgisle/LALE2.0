using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE
{
    public class CollisionObject
    {
        public byte id { get; set; }
        public int xPos { get; set; }
        public int yPos { get; set; }
        public byte height { get; set; } = 1;
        public byte width { get; set; } =  1;
        public byte length { get; set; }
        public byte direction { get; set; }
        public byte[] tiles { get; set; }
        public bool multiTileFlag { get; set; }
        public bool hFlip { get; set; }
        public bool vFlip { get; set; }
        public bool is3Byte { get; set; }

        public List<CollisionObject> objectIDs = new List<CollisionObject>();

        public CollisionObject()
        {
            this.id = 0;
        }
        public CollisionObject(CollisionObject o)
        {
            this.id = o.id;
            this.xPos = o.xPos;
            this.yPos = o.yPos;
            this.height = o.height;
            this.width = o.width;
            this.length = o.length;
            this.direction = o.direction;

            this.multiTileFlag = o.multiTileFlag;
            this.hFlip = o.hFlip;
            this.vFlip = o.vFlip;
            this.is3Byte = o.is3Byte;

            if (this.multiTileFlag)
                this.tiles = (byte[])o.tiles.Clone();
        }

        public void getOverworldObjs(CollisionObject objects)
        {
            CollisionObject obj = new CollisionObject();
            obj.height = 1;
            obj.width = 1;
            switch (objects.id)
            {
                case 0xF5: //Tree
                    {
                        obj.tiles = new byte[] { 0x25, 0x26, 0x27, 0x28 };
                        obj.width = 2;
                        obj.height = 2;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xF6: //Long House
                    {
                        obj.tiles = new byte[] { 85, 90, 90, 90, 86, 87, 89, 89, 89, 88, 91, 226, 91, 226, 91 };
                        obj.width = 5;
                        obj.height = 3;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xF7: // House
                    {
                        obj.tiles = new byte[] { 85, 90, 86, 87, 89, 88, 91, 226, 91 };
                        obj.width = 3;
                        obj.height = 3;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xF8: //Catfish's Maw
                    {
                        obj.tiles = new byte[] { 0xB6, 0xB7, 0x66, 0x67, 0xE3, 0x68 };
                        obj.width = 3;
                        obj.height = 2;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xF9: //Palace Doors
                    {
                        obj.tiles = new byte[] { 0xA4, 0xA5, 0xA6, 0xA7, 0xE3, 0xA8 };
                        obj.width = 3;
                        obj.height = 2;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xFA:
                    {
                        obj.tiles = new byte[] { 187, 188, 189, 190 };
                        obj.width = 2;
                        obj.height = 2;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xFB:
                    {
                        obj.tiles = new byte[] { 182, 183, 205, 206 };
                        obj.width = 2;
                        obj.height = 2;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xFC: //Warp hill with hole in middle
                    {
                        obj.tiles = new byte[] { 43, 44, 45, 55, 232, 56, 51, 224, 52 };
                        obj.width = 3;
                        obj.height = 3;
                        obj.multiTileFlag = true;
                        break;
                    }
                case 0xFD: //House
                    {
                        obj.tiles = new byte[] { 82, 82, 82, 91, 226, 91 };
                        obj.width = 3;
                        obj.height = 2;
                        obj.multiTileFlag = true;
                        break;
                    }          
            }
            if(objects.is3Byte)
            {
                obj.length = objects.length;
                obj.direction = objects.direction;
                obj.is3Byte = true;
            }
            if (objects.xPos == 0xF)
                obj.hFlip = true;
            if (objects.yPos == 0xF)
                obj.vFlip = true;
            obj.id = objects.id;
            obj.xPos = objects.xPos;
            obj.yPos = objects.yPos;
            objectIDs.Add(obj);

        }

        public bool Equals(CollisionObject o)
        {
            if (this.id == o.id &&
            this.xPos == o.xPos &&
            this.yPos == o.yPos &&
            this.height == o.height &&
            this.length == o.length)
            {
                if (this.is3Byte)
                {
                    if (this.direction == o.direction)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                
                return true;
            }
            return false;
        }
    }
}
