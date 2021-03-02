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
    public partial class RepointCollisions : Form
    {
        private Game LAGame;
        private MapTileData mapTileData;

        public RepointCollisions(Game game, MapTileData mtd)
        {
            InitializeComponent();
            LAGame = game;
            mapTileData = mtd;

            if (LAGame.overworldFlag)
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

        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            CollisionRepointer collisionRepointer = new CollisionRepointer(LAGame, mapTileData);
            collisionRepointer.repointMapCollisions((int)nAddress.Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
