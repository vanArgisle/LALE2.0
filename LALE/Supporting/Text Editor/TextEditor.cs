using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LALE.Supporting.Text_Editor
{
    public partial class TextEditor : Form
    {
        Game LAGame;
        char[] hexChar = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        Color[] palette = new Color[] { Color.FromArgb(248, 248, 168), Color.FromArgb(152, 120, 180), Color.FromArgb(56, 24, 90), Color.Black };
        List<int> textAddresses;
        int textLocation;
        int textBank;
        int textOffset;
        byte[] textBytes;
        byte[] textASCII;

        public TextEditor(Game game)
        {
            InitializeComponent();
            LAGame = game;
            getTextAddresses();
        }
        
        public TextEditor(Game game, int pointerToGoTo)
        {
            InitializeComponent();
            LAGame = game;
            getTextAddresses();

            textBank = pointerToGoTo;
            nTextBank.Value = textBank;
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void getTextAddresses()
        {
            textAddresses = new List<int>();
            for (int i = 0; i < 0x2B0; i++)
            {
                textBank = (i >> 8);
                textOffset = (i & 0xFF);

                int t = (((textBank << 1) & 0xFF) * 0x100);
                int o = (textOffset << 1);
                int n = (t + o);

                LAGame.gbROM.BufferLocation = (0x1C * 0x4000) + (n + 1);
                int loc = (LAGame.gbROM.ReadByte() + (LAGame.gbROM.ReadByte() * 0x100));

                LAGame.gbROM.BufferLocation = ((0x741 + i) + (0x1C * 0x4000));
                int bank = LAGame.gbROM.ReadByte() & 0x3F;

                LAGame.gbROM.BufferLocation = ((bank * 0x4000) + (loc - 0x4000));

                textAddresses.Add(LAGame.gbROM.BufferLocation);
            }
            nAddress.Value = textAddresses[(int)nTextBank.Value];
        }

        private void nTextBank_ValueChanged(object sender, EventArgs e)
        {
            //tTextBox.Clear();
            //pText.Image = null;
            int i = 0;
            cQuestion.Enabled = true;
            cQuestion.Checked = false;

            textLocation = textAddresses[(int)nTextBank.Value];
            LAGame.gbROM.BufferLocation = textLocation;
            byte h = LAGame.gbROM.ReadByte();
            while (h != 0xFF)
            {
                i++;
                h = LAGame.gbROM.ReadByte();
                if (h == 0xFE)
                {
                    cQuestion.Checked = true;
                    break;
                }
            }
            int length = i;
            textASCII = new byte[i];
            if (length % 16 != 0)
            {
                int add = 16 - (length % 16);
                i += add;
                textBytes = new byte[0x10 * i];
                for (int black = 0; black < (add * 0x10); black++)
                    textBytes[(length * 0x10) + black] = 0xFF;
                length = i;
            }
            else
                textBytes = new byte[0x10 * i];
            i = 0;
            int g;
            LAGame.gbROM.BufferLocation = textLocation;
            h = LAGame.gbROM.ReadByte();
            while (h != 0xFF)
            {
                if (h == 0xFE)
                {
                    cQuestion.Checked = true;
                    break;
                }
                textASCII[i] = h;
                if (h == 0x20)
                {
                    for (int i2 = 0; i2 < 0x10; i2++)
                        textBytes[(i * 0x10) + i2] = 0xFF;
                    i++;
                    h = LAGame.gbROM.ReadByte();
                    continue;
                }
                g = (LAGame.gbROM.ReadByte(0x70641 + h) << 4);
                LAGame.gbROM.BufferLocation = g + 0x3D000;
                for (int i2 = 0; i2 < 0x10; i2++)
                    textBytes[(i * 0x10) + i2] = LAGame.gbROM.ReadByte();
                i++;
                LAGame.gbROM.BufferLocation = textLocation + i;
                h = LAGame.gbROM.ReadByte();
            }

            nAddress.Value = textLocation;
        }

        private void nAddress_ValueChanged(object sender, EventArgs e)
        {
            tTextBox.Clear();
            pText.Image = null;
            cQuestion.Enabled = true;
            cQuestion.Checked = false;
            int index;

            textLocation = (int)nAddress.Value;
            LAGame.gbROM.BufferLocation = textLocation;
            int i = 0;
            byte h = LAGame.gbROM.ReadByte();
            while (h != 0xFF)
            {
                i++;
                h = LAGame.gbROM.ReadByte();
                if (h == 0xFE)
                    break;
            }

            int length = i;
            if (length != 0)
            {
                textASCII = new byte[i];
                if (length % 16 != 0)
                {
                    int add = 16 - (length % 16);
                    i += add;
                    textBytes = new byte[0x10 * i];
                    for (int black = 0; black < (add * 0x10); black++)
                        textBytes[(length * 0x10) + black] = 0xFF;
                    length = i;
                }
                else
                    textBytes = new byte[0x10 * i];
                i = 0;
                int g;
                LAGame.gbROM.BufferLocation = textLocation;
                h = LAGame.gbROM.ReadByte();
                while (h != 0xFF)
                {
                    if (h == 0xFE)
                    {
                        cQuestion.Checked = true;
                        break;
                    }
                    textASCII[i] = h;
                    if (h == 0x20)
                    {
                        for (int i2 = 0; i2 < 0x10; i2++)
                            textBytes[(i * 0x10) + i2] = 0xFF;
                        i++;
                        h = LAGame.gbROM.ReadByte();
                        continue;
                    }
                    g = (LAGame.gbROM.ReadByte(0x70641 + h) << 4);
                    LAGame.gbROM.BufferLocation = g + 0x3D000;
                    for (int i2 = 0; i2 < 0x10; i2++)
                        textBytes[(i * 0x10) + i2] = LAGame.gbROM.ReadByte();
                    i++;
                    LAGame.gbROM.BufferLocation = textLocation + i;
                    h = LAGame.gbROM.ReadByte();
                }

                byte[,,] data = new byte[length, 8, 8];
                LAGame.gbROM.ReadTiles(16, length / 16, textBytes, ref data);
                Bitmap bmp = new Bitmap(128, length / 2);
                FastPixel fp = new FastPixel(bmp);
                fp.rgbValues = new byte[128 * (length / 2) * 4];
                fp.Lock();
                for (int q = 0; q < length; q++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            fp.SetPixel(x + ((q % 16) * 8), y + ((q / 16) * 8), palette[data[q, x, y]]);
                        }
                    }
                }
                fp.Unlock(true);

                pText.Image = bmp;

                StringBuilder builder = new StringBuilder();
                for (int s = 0; s < i; s++)
                {
                    if ((textASCII[s] >> 4) > 7)
                    {
                        builder.Append('#');
                        builder.Append(hexChar[textASCII[s] >> 4]);
                        builder.Append(hexChar[textASCII[s] & 0xF]);
                        continue;
                    }
                    builder.Append((char)textASCII[s]);
                }
                tTextBox.Text = builder.ToString();
            }
            else
                pText.Image = null;
            try
            {
                index = textAddresses.FindIndex(item => item == textLocation);
                nTextBank.Value = index;
            }
            catch
            {
                ;
            }

        }

        private void tTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                pText.Image = null;
                int index = 0;
                int skip = 0;
                int r = 0;
                textASCII = new byte[tTextBox.Text.Length];
                foreach (char c in tTextBox.Text)
                {
                    if (c == '#')
                    {
                        if (index + 1 != textASCII.Length)
                        {
                            char ch = tTextBox.Text[index + r + 1];
                            if (Array.IndexOf(hexChar, ch) != -1 && Array.IndexOf(hexChar, tTextBox.Text[index + r + 2]) != -1)
                            {
                                int b1 = Array.IndexOf(hexChar, ch);
                                int b2 = Array.IndexOf(hexChar, tTextBox.Text[index + r + 2]);
                                int b = ((b1 << 4) + b2);
                                textASCII[index] = (byte)b;
                                r += 2;
                                byte[] textASCIIp = new byte[tTextBox.Text.Length - r];
                                skip = 2;
                                Array.Copy(textASCII, textASCIIp, tTextBox.Text.Length - r);
                                textASCII = textASCIIp;
                                index++;
                                continue;
                            }
                        }
                    }
                    if (skip != 0)
                    {
                        skip--;
                        continue;
                    }
                    textASCII[index] = Convert.ToByte(c);
                    index++;
                }
                int i = textASCII.Length;
                int length = i;
                if (length != 0)
                {
                    if (length % 16 != 0)
                    {
                        int add = 16 - (length % 16);
                        i += add;
                        textBytes = new byte[0x10 * i];
                        for (int black = 0; black < (add * 0x10); black++)
                            textBytes[(length * 0x10) + black] = 0xFF;
                        length = i;
                    }
                    else
                        textBytes = new byte[0x10 * i];

                    i = 0;
                    int g;

                    foreach (byte q in textASCII)
                    {
                        if (q == 0x20)
                        {
                            for (int i2 = 0; i2 < 0x10; i2++)
                                textBytes[(i * 0x10) + i2] = 0xFF;
                            i++;
                            continue;
                        }
                        g = (LAGame.gbROM.ReadByte(0x70641 + q) << 4);
                        LAGame.gbROM.BufferLocation = g + 0x3D000;
                        for (int i2 = 0; i2 < 0x10; i2++)
                            textBytes[(i * 0x10) + i2] = LAGame.gbROM.ReadByte();
                        i++;
                        LAGame.gbROM.BufferLocation = textLocation + i;
                    }

                    byte[,,] data = new byte[length, 8, 8];
                    LAGame.gbROM.ReadTiles(16, length / 16, textBytes, ref data);
                    Bitmap bmp = new Bitmap(128, length / 2);
                    FastPixel fp = new FastPixel(bmp);
                    fp.rgbValues = new byte[128 * (length / 2) * 4];
                    fp.Lock();
                    for (int q = 0; q < length; q++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                fp.SetPixel(x + ((q % 16) * 8), y + ((q / 16) * 8), palette[data[q, x, y]]);
                            }
                        }
                    }
                    fp.Unlock(true);

                    pText.Image = bmp;
                }
                else
                    pText.Image = null;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            LAGame.gbROM.BufferLocation = textLocation;
            int index = 0;
            int skip = 0;
            int r = 0;
            textASCII = new byte[tTextBox.Text.Length];
            foreach (char c in tTextBox.Text)
            {
                if (c == '#')
                {
                    char ch = tTextBox.Text[index + r + 1];
                    if (Array.IndexOf(hexChar, ch) != -1 && Array.IndexOf(hexChar, tTextBox.Text[index + r + 2]) != -1)
                    {
                        int b1 = Array.IndexOf(hexChar, ch);
                        int b2 = Array.IndexOf(hexChar, tTextBox.Text[index + r + 2]);
                        int b = ((b1 << 4) + b2);
                        textASCII[index] = (byte)b;
                        r += 2;
                        byte[] textASCIIp = new byte[tTextBox.Text.Length - r];
                        skip = 2;
                        Array.Copy(textASCII, textASCIIp, tTextBox.Text.Length - r);
                        textASCII = textASCIIp;
                        index++;
                        continue;
                    }
                }
                if (skip != 0)
                {
                    skip--;
                    continue;
                }
                textASCII[index] = Convert.ToByte(c);
                index++;
            }

            LAGame.gbROM.WriteBytes(textASCII);

            if (cQuestion.Checked == true)
                LAGame.gbROM.WriteByte(0xFE);
            else
                LAGame.gbROM.WriteByte(0xFF);
        }

        private void toolStripButtonRepoint_Click(object sender, EventArgs e)
        {
            RepointText textRepointer = new RepointText(LAGame, (int)nTextBank.Value);
            textRepointer.ShowDialog();
            if (textRepointer.DialogResult == DialogResult.OK)
            {
                int address = textRepointer.textAddress;
                int pointer = textRepointer.textPointer;
                int bank = address / 0x4000;
                int writeAddress = (address - (bank * 0x4000)) + 0x4000;

                textBank = (pointer >> 8);
                textOffset = (pointer & 0xFF);

                int t = (((textBank << 1) & 0xFF) * 0x100);
                int o = (textOffset << 1);
                int n = (t + o);

                textBank = (writeAddress >> 8);
                textOffset = (writeAddress & 0xFF);

                LAGame.gbROM.BufferLocation = (0x1C * 0x4000) + (n + 1);
                LAGame.gbROM.WriteByte((byte)textOffset);
                LAGame.gbROM.WriteByte((byte)textBank);

                LAGame.gbROM.BufferLocation = ((0x741 + pointer) + (0x1C * 0x4000));
                LAGame.gbROM.WriteByte((byte)bank);

                getTextAddresses();
            }
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            SearchPhrase searchPhraseForm = new SearchPhrase(LAGame);
            searchPhraseForm.ShowDialog();
            if (searchPhraseForm.DialogResult == DialogResult.OK)
            {
                textLocation = searchPhraseForm.address;
                nAddress.Value = textLocation;
            }
        }
    }
}
