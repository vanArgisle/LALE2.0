using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE.Supporting
{
    class Patches
    {
        Game LAGame;
        public Patches(Game game)
        {
            LAGame = game;
        }

        public void defaultMusic(bool music)
        {
            if (music)
            {
                LAGame.gbROM.WriteBytes(0x8156, new byte[] { 0x58, 0x41 });
                LAGame.gbROM.WriteByte(0xBB47, 0);

                MessageBox.Show("Bytes 0x58, 0x41 written to 0x8156. Byte 0 written to 0xBB47");
            }
            else
            {
                LAGame.gbROM.WriteBytes(0x8156, new byte[] { 0xA2, 0x41 });
                LAGame.gbROM.WriteByte(0xBB47, 0x41);

                MessageBox.Show("Bytes 0xA2, 0x41 written to 0x8156. Byte 0x41 written to 0xBB47");
            }
        }
    }
}
