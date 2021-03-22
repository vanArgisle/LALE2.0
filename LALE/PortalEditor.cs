﻿using System;
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
    public partial class PortalEditor : Form
    {
        Game LAGame;
        public PortalEditor(Game game)
        {
            LAGame = game;
            InitializeComponent();

            if (!LAGame.overworldFlag)
                comDungeons.SelectedIndex = 0;
            else
            {
                comDungeons.Enabled = false;
                label2.Text = "Map:";
                label3.Text = "Warp Map:";
                nMap1.Value = LAGame.map;

                LAGame.gbROM.BufferLocation = 0x65C6A + (int)nMap1.Value;
                nMap2.Value = LAGame.gbROM.ReadByte();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            if (LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x65C6A + (int)nMap1.Value;
                LAGame.gbROM.WriteByte((byte)nMap2.Value);
            }
            else
            {
                LAGame.gbROM.BufferLocation = 0x64201 + (comDungeons.SelectedIndex * 2);
                LAGame.gbROM.WriteByte((byte)nMap1.Value);
                LAGame.gbROM.WriteByte((byte)nMap2.Value);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comDungeons_SelectedIndexChanged(object sender, EventArgs e)
        {
            LAGame.gbROM.BufferLocation = 0x64201 + (comDungeons.SelectedIndex * 2);
            nMap1.Value = LAGame.gbROM.ReadByte();
            nMap2.Value = LAGame.gbROM.ReadByte();
        }

        private void nMap1_ValueChanged(object sender, EventArgs e)
        {
            if (LAGame.overworldFlag)
            {
                LAGame.gbROM.BufferLocation = 0x65C6A + (int)nMap1.Value;
                nMap2.Value = LAGame.gbROM.ReadByte();
            }
        }
    }
}
