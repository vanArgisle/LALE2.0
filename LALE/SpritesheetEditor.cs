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
    public partial class SpritesheetEditor : Form
    {
        public Game LAGame;
        public Sprite spriteLoader;
        public SpritesheetEditor(Game game)
        {
            InitializeComponent();
            LAGame = new Game(game);
            spriteLoader = new Sprite(LAGame);
            spriteLoader.loadSpriteBanks();
            spriteLoader.getSpriteLocation();

            pictureBox1.Image = spriteLoader.drawSprites(0);
            pictureBox2.Image = spriteLoader.drawSprites(1);
            pictureBox3.Image = spriteLoader.drawSprites(2);
            pictureBox4.Image = spriteLoader.drawSprites(3);

            numericUpDown1.Value = spriteLoader.spriteInfo[0];
            numericUpDown2.Value = spriteLoader.spriteInfo[1];
            numericUpDown3.Value = spriteLoader.spriteInfo[2];
            numericUpDown4.Value = spriteLoader.spriteInfo[3];

            if (LAGame.dungeon == 0xFF)
            {
                numericUpDownBank2.Enabled = true;
                numericUpDownBank3.Enabled = true;
                numericUpDownBank4.Enabled = true;

                numericUpDownBank1.Value = spriteLoader.colourDungeonSpriteBanks[0];
                numericUpDownBank2.Value = spriteLoader.colourDungeonSpriteBanks[1];
                numericUpDownBank3.Value = spriteLoader.colourDungeonSpriteBanks[2];
                numericUpDownBank4.Value = spriteLoader.colourDungeonSpriteBanks[3];

                numericUpDownBank1.Maximum = 63;

            }
            else
            {
                numericUpDownBank1.Value = spriteLoader.spriteBank;
            }

        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.spriteInfo[0] = (byte)numericUpDown1.Value;
            spriteLoader.saveSpritesheets();
            spriteLoader.getSpriteLocation();
            pictureBox1.Image = spriteLoader.drawSprites(0);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.spriteInfo[1] = (byte)numericUpDown2.Value;
            spriteLoader.saveSpritesheets();
            spriteLoader.getSpriteLocation();
            pictureBox2.Image = spriteLoader.drawSprites(1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.spriteInfo[2] = (byte)numericUpDown3.Value;
            spriteLoader.saveSpritesheets();
            spriteLoader.getSpriteLocation();
            pictureBox3.Image = spriteLoader.drawSprites(2);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.spriteInfo[3] = (byte)numericUpDown4.Value;
            spriteLoader.saveSpritesheets();
            spriteLoader.getSpriteLocation();
            pictureBox4.Image = spriteLoader.drawSprites(3);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numericUpDownBank1_ValueChanged(object sender, EventArgs e)
        {
            if (LAGame.dungeon != 0xFF)
            {
                spriteLoader.spriteBank = (byte)numericUpDownBank1.Value;
                spriteLoader.getSpritesheets();
                spriteLoader.getSpriteLocation();

                pictureBox1.Image = spriteLoader.drawSprites(0);
                pictureBox2.Image = spriteLoader.drawSprites(1);
                pictureBox3.Image = spriteLoader.drawSprites(2);
                pictureBox4.Image = spriteLoader.drawSprites(3);

                numericUpDown1.Value = spriteLoader.spriteInfo[0];
                numericUpDown2.Value = spriteLoader.spriteInfo[1];
                numericUpDown3.Value = spriteLoader.spriteInfo[2];
                numericUpDown4.Value = spriteLoader.spriteInfo[3];

                spriteLoader.saveSpriteBank();
            }
            else
            {
                spriteLoader.colourDungeonSpriteBanks[0] = (byte)numericUpDownBank1.Value;
                spriteLoader.getSpriteLocation();

                pictureBox1.Image = spriteLoader.drawSprites(0);

                spriteLoader.saveSpriteBank();
            }
        }

        private void numericUpDownBank2_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.colourDungeonSpriteBanks[1] = (byte)numericUpDownBank2.Value;
            spriteLoader.getSpriteLocation();

            pictureBox2.Image = spriteLoader.drawSprites(1);

            spriteLoader.saveSpriteBank();
        }

        private void numericUpDownBank3_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.colourDungeonSpriteBanks[2] = (byte)numericUpDownBank3.Value;
            spriteLoader.getSpriteLocation();

            pictureBox3.Image = spriteLoader.drawSprites(2);

            spriteLoader.saveSpriteBank();
        }

        private void numericUpDownBank4_ValueChanged(object sender, EventArgs e)
        {
            spriteLoader.colourDungeonSpriteBanks[3] = (byte)numericUpDownBank4.Value;
            spriteLoader.getSpriteLocation();

            pictureBox4.Image = spriteLoader.drawSprites(3);

            spriteLoader.saveSpriteBank();
        }
    }
}
