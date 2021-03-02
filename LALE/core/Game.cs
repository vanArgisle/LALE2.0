using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE
{
    public class Game
    {
        public ROM gbROM { get; set; }
        public byte dungeon { get; set; }
        public byte map { get; set; }
        public bool overworldFlag { get; set; }
        public bool raisingFloorFlag { get; set; }
        public bool sideviewFlag { get; set; }
        public bool specialFlag { get; set; }

        public Game(byte[] buffer, string filename)
        {
            gbROM = new ROM((byte[])buffer.Clone(), filename);
            dungeon = 0;
            map = 0;
            overworldFlag = true;
            raisingFloorFlag = false;
            sideviewFlag = false;
            specialFlag = false;
        }

        public Game(Game gameValues)
        {
            gbROM = new ROM(gameValues.gbROM.Buffer, gameValues.gbROM.Filename);
            dungeon = gameValues.dungeon;
            map = gameValues.map;
            overworldFlag = gameValues.overworldFlag;
            raisingFloorFlag = gameValues.raisingFloorFlag;
            sideviewFlag = gameValues.sideviewFlag;
            specialFlag = gameValues.specialFlag;
        }
    }
}
