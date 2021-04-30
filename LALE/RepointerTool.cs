using LALE.Core;
using LALE.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE
{
    public partial class RepointerTool : Form
    {
        private Game LAGame;
        private MapTileData mapTileData;
        private EntityLoader entityLoader;
        private bool entities;

        public RepointerTool(Game game, MapTileData mtd, EntityLoader entityL, bool entity)
        {
            InitializeComponent();
            LAGame = game;
            mapTileData = mtd;
            entityLoader = entityL;
            entities = entity;

            if (entities)
            {
                if (LAGame.overworldFlag)
                {
                    nAddress.Minimum = 0x59186;
                    nAddress.Maximum = 0x59661;
                }
                else
                {
                    if (LAGame.dungeon == 0xFF)
                    {
                        nAddress.Minimum = 0x59664;
                        nAddress.Maximum = 0x596FD;
                    }
                    else if (LAGame.dungeon >= 0x1A || LAGame.dungeon < 6)
                    {
                        nAddress.Minimum = 0x58640;
                        nAddress.Maximum = 0x58CA1;
                    }
                    else
                    {
                        nAddress.Minimum = 0x58CA4;
                        nAddress.Maximum = 0x59183;
                    }
                }
            }
            else if (LAGame.overworldFlag)
            {
                if (LAGame.map < 0x80)
                {
                    nAddress.Minimum = 0x24200;
                    nAddress.Maximum = 0x2668B;
                        //0x27FFD;
                }
                else
                {
                    nAddress.Minimum = 0x68000;
                    nAddress.Maximum = 0x69E73;
                        //0x6BFFD;
                }
            }
            else
            {
                if (LAGame.dungeon >= 6 && LAGame.dungeon < 0x1A)
                {
                    nAddress.Minimum = 0x2C200;
                    nAddress.Maximum = 0x2FFFD;
                }
                else if (LAGame.dungeon < 6 || LAGame.dungeon >= 0x1A && LAGame.dungeon != 0xFF)
                {
                    nAddress.Minimum = 0x28200;
                    nAddress.Maximum = 0x2BB75;
                }
                else
                {
                    nAddress.Minimum = 0x2BBB7;
                    nAddress.Maximum = 0x2BF41;
                }
            }

        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            if (entities)
            {
                SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
                EntityRepointer entityRepointer = new EntityRepointer(LAGame, entityLoader, spaceCalculator);
                entityRepointer.repointMapEntities((int)nAddress.Value);

            }
            else
            {
                CollisionRepointer collisionRepointer = new CollisionRepointer(LAGame, mapTileData);
                collisionRepointer.repointMapCollisions((int)nAddress.Value);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
