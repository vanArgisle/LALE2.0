using LALE.Core;
using LALE.Supporting;
using LALE.Tileset;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LALE
{
    public partial class LALE2 : Form
    {

        private Game LAGame;
        private ROM gbROMoriginal;
        private TileDrawer tilesetDrawer;
        private MapTileData mapTileData;
        private MinimapLoader minimapLoader;
        private int collisionDataAddress;

        private byte selectedTile;
        private List<byte[]> mapSnapshotsUndo = new List<byte[]>(); //Snapshot feature for the Ctrl+Z undo function
        private List<byte[]> mapSnapshotsRedo = new List<byte[]>(); //Snapshot feature for the Ctrl+Y redo function
        private List<List<CollisionObject>> collisionSnapshotsUndo = new List<List<CollisionObject>>();
        private List<List<CollisionObject>> collisionSnapshotsRedo = new List<List<CollisionObject>>();

        int selectedObjectOrigX;
        int selectedObjectOrigY;
        private CollisionObject selectedCollisionObject;

        private Point lastMapHoverPoint = new Point(-1, -1);

        public LALE2()
        {
            InitializeComponent();
        }

        private void openROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a V1.2 Link's Awakening ROM";
            ofd.Filter = "Gameboy ROM|*.gbc;*.gb";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
                gbROMoriginal = new ROM(br.ReadBytes((Int32)br.BaseStream.Length), ofd.FileName);
                LAGame = new Game(gbROMoriginal.Buffer, ofd.FileName);

                InitializeLALE();
            }
        }

        private void InitializeLALE()
        {
            tilesetDrawer = new TileDrawer();
            mapTileData = new MapTileData(LAGame);

            numericUpDownMap.Enabled = true;
            //Turn on the map viewer
            radioButtonCollisions.Enabled = true;
            radioButtonOverlay.Enabled = true;
            radioButtonOverlay.Checked = true;
            tabControl1.Enabled = true;
        }

        /// <summary>
        /// Loads in the tileset using current game values
        /// </summary>
        private void loadTileset()
        {
            TilesetLoader tilesetLoader = new TilesetLoader(LAGame);
            tilesetLoader.loadPalette();


            gridBoxTileset.Image = tilesetDrawer.drawTileset(tilesetLoader.loadTileset(), tilesetLoader.paletteTiles, tilesetLoader.formationData, tilesetLoader.palette);
        }

        /// <summary>
        /// Loads in the minimap. 
        /// </summary>
        private void loadMinimap()
        {
            minimapLoader = new MinimapLoader(LAGame);

            TileDrawer tileDrawer = new TileDrawer();

            if (gridBoxTileset.Image != null)
                pMinimap.Image = tileDrawer.drawOverworldMinimapTiles(minimapLoader.loadMinimapOverworld(), minimapLoader.minimapGraphics, minimapLoader.overworldPal, minimapLoader.palette);
            pMinimap.Invalidate();

        }
        /// <summary>
        /// Loads in fresh map data using the current map value. 
        /// </summary>
        private void loadMap()
        {

            if (radioButtonOverlay.Checked)
            {
                gridBoxMap.Image = tilesetDrawer.drawMap((Bitmap)gridBoxTileset.Image, mapTileData.GetOverlayMapData());

                mapSnapshotsUndo.Clear();
                mapSnapshotsRedo.Clear();

                toolStripStatusLabelSpace.Text = "";
            }
            else if (radioButtonCollisions.Checked)
            {
                mapTileData.LoadCollisionDataOverworld();
                gridBoxMap.Image = tilesetDrawer.drawMap((Bitmap)gridBoxTileset.Image, mapTileData.getCollisionOverworldMapData());
                if (collisionBordersToolStripMenuItem.Checked)
                    gridBoxMap.Image = tilesetDrawer.drawBorders((Bitmap)gridBoxMap.Image, mapTileData.collisionObjects);

                collisionSnapshotsUndo.Clear();
                collisionSnapshotsRedo.Clear();

                SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
                toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();
                collisionDataAddress = mapTileData.mapAddress + spaceCalculator.getUsedSpace();
            }
            toolStripStatusLabelAddressPointer.Text = "Data Address: 0x" + mapTileData.mapAddress.ToString("X");
            saveSnapshot();
        }

        private void numericUpDownMap_ValueChanged(object sender, EventArgs e)
        {
            LAGame.map = (byte)numericUpDownMap.Value;
            loadTileset();
            loadMap();

            pMinimap.SelectedIndex = (int)numericUpDownMap.Value;

            if (radioButtonCollisions.Checked)
            {
                collisionListView();
            }

            switch (LAGame.map)
            {
                case 0x06:
                case 0x0E:
                case 0x1B:
                case 0x2B:
                case 0x79:
                case 0x8C:
                    checkBoxSpecialMap.Enabled = true;
                    break;
                default:
                    checkBoxSpecialMap.Checked = false;
                    checkBoxSpecialMap.Enabled = false;
                    break;
            }
        }

        private void radioButtonOverlay_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOverlay.Checked)
            {
                radioButtonCollisions.Checked = false;
                gBoxCollisions.Enabled = false;
                CollisionList.Items.Clear();
                nSelected.Value = -1;
            }
            loadTileset();
            loadMap();
            loadMinimap();

        }

        private void radioButtonCollisions_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCollisions.Checked)
            {
                radioButtonOverlay.Checked = false;
                gBoxCollisions.Enabled = true;
                collisionListView();
            }

            loadTileset();
            loadMap();
        }

        private void collisionBordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LAGame != null)
            {
                redrawMap();
                if (selectedCollisionObject != null)
                    drawSelectedObject();
            }
        }

        private void buttonMapData_Click(object sender, EventArgs e)
        {
            if (LAGame != null)
            {
                MapData MapDataForm = new MapData(LAGame);
                MapDataForm.ShowDialog();
                loadTileset();
                loadMap();

            }
        }

        /// <summary>
        /// This loads the collision list and populates it with entries. 
        /// </summary>
        private void collisionListView()
        {
            CollisionList.Items.Clear();
            string collisionListEntry;

            foreach (CollisionObject ob in mapTileData.collisionObjects)
            {
                if (ob.is3Byte)
                    collisionListEntry = "3-Byte";
                else
                    collisionListEntry = "2-Byte";
                collisionListEntry += "      0x" + ob.id.ToString("X");
                CollisionList.Items.Add(collisionListEntry);
            }
            nSelected.Maximum = CollisionList.Items.Count - 1;
            if (nSelected.Value != -1)
                CollisionList.SelectedIndex = (int)nSelected.Value;
            else if (CollisionList.SelectedIndex != -1 && nSelected.Value == -1)
                CollisionList.SetSelected(CollisionList.SelectedIndex, false);
        }

        private void CollisionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            nSelected.Value = CollisionList.SelectedIndex;
            if (nSelected.Value != -1)
            {
                selectedCollisionObject = mapTileData.collisionObjects[CollisionList.SelectedIndex];
                gridBoxTileset.SelectedIndex = selectedCollisionObject.id;
                labelSelectedTile.Text = "Selected tile: " + gridBoxTileset.SelectedIndex.ToString("X");

                if (selectedCollisionObject.direction == 8)
                    comDirection.SelectedIndex = 0;
                else
                    comDirection.SelectedIndex = 1;
                nLength.Value = selectedCollisionObject.length;
                nObjectID.Value = selectedCollisionObject.id;

                drawSelectedObject();
            }
        }

        /// <summary>
        /// Draws a white border around the selected collision object
        /// </summary>
        private void drawSelectedObject()
        {
            TileDrawer tileDrawer = new TileDrawer();

            //Reset the map to get rid of previously selected collision.
            redrawMap();

            if (nSelected.Value != -1)
                gridBoxMap.Image = tileDrawer.drawSelectedObject((Bitmap)gridBoxMap.Image, mapTileData.collisionObjects, (int)nSelected.Value);
            pObject.Invalidate();
        }

        private void nSelected_ValueChanged(object sender, EventArgs e)
        {
            CollisionList.SelectedIndex = (int)nSelected.Value;
            if (nSelected.Value == -1)
            {
                if (CollisionList.SelectedIndex != -1)
                    CollisionList.SetSelected(CollisionList.SelectedIndex, false);

                selectedCollisionObject = null;

                //Disable controls
                comDirection.Enabled = false;
                nLength.Enabled = false;
                nObjectID.Value = 0;

                //Draw map to clear selected collision object border
                redrawMap();
            }
            else
            {
                comDirection.Enabled = true;
                nLength.Enabled = true;
            }
            pObject.Invalidate();
        }

        /// <summary>
        /// This method redraws the map without loading in fresh map data.
        /// </summary>
        private void redrawMap()
        {
            if (radioButtonCollisions.Checked)
            {
                gridBoxMap.Image = tilesetDrawer.drawMap((Bitmap)gridBoxTileset.Image, mapTileData.getCollisionOverworldMapData());
                if (collisionBordersToolStripMenuItem.Checked)
                    gridBoxMap.Image = tilesetDrawer.drawBorders((Bitmap)gridBoxMap.Image, mapTileData.collisionObjects);
            }
            else
                gridBoxMap.Image = tilesetDrawer.drawMap((Bitmap)gridBoxTileset.Image, mapTileData.overlayMapData);

        }

        private void gridBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (gridBoxMap.Image == null)
                return;

            if (radioButtonOverlay.Checked)//Overlay mouse down event
            {
                if (e.Button == MouseButtons.Left)
                {
                    Graphics g = Graphics.FromImage(gridBoxMap.Image);
                    if (gridBoxTileset.SelectionRectangle.Width == 1 && gridBoxTileset.SelectionRectangle.Height == 1)
                    {
                        g.DrawImage(gridBoxTileset.Image, new Rectangle(e.X / 16 * 16, e.Y / 16 * 16, 16, 16), (selectedTile % 16) * 16, (selectedTile / 16) * 16, 16, 16, GraphicsUnit.Pixel);
                        mapTileData.overlayMapData[e.X / 16 + (e.Y / 16) * 10] = selectedTile;
                        mapTileData.saveOverlayOverworldMapData();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    selectTile(mapTileData.overlayMapData[e.X / 16 + (e.Y / 16) * 10]);
                }
            }
            else //Collision mouse down event
            {
                if (e.Button == MouseButtons.Left)
                {
                    int ind = getSelectedObjectID(e.X, e.Y);
                    if (ind > -1)
                    {
                        selectCollision(mapTileData.collisionObjects[ind], ind);
                        selectedObjectOrigX = mapTileData.collisionObjects[ind].xPos;
                        selectedObjectOrigY = mapTileData.collisionObjects[ind].yPos;
                    }
                    else
                        selectCollision(null, ind);
                }
            }
            lastMapHoverPoint = new Point(e.X / 16, e.Y / 16);
        }

        private void gridBoxTileset_MouseClick(object sender, MouseEventArgs e)
        {
            selectTile(gridBoxTileset.SelectedIndex);
        }

        /// <summary>
        /// This selects a tile so that we can edit the map data.
        /// Also changes the selected tile text beneath the tileset.
        /// </summary>
        private void selectTile(int tile)
        {
            selectedTile = (byte)tile;
            if (gridBoxTileset.SelectedIndex != tile || (gridBoxTileset.SelectionRectangle.Width != 1 || gridBoxTileset.SelectionRectangle.Height != 1))
                gridBoxTileset.SelectedIndex = selectedTile;
            labelSelectedTile.Text = "Selected tile: " + gridBoxTileset.SelectedIndex.ToString("X");
            gridBoxTileset.Invalidate();
        }

        private void gridBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (gridBoxMap.Image == null)
                return;


            toolStripStatusLabelHoverCoords.Text = "X: " + (e.X / 16).ToString("X") + " Y: " + (e.Y / 16).ToString("X");
            //Overlay mouse movement
            if (radioButtonOverlay.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Graphics g = Graphics.FromImage(gridBoxMap.Image);
                    if (gridBoxTileset.SelectionRectangle.Width == 1 && gridBoxTileset.SelectionRectangle.Height == 1)
                    {
                        if (e.X / 16 > 9 || e.Y / 16 > 7 || e.X / 16 < 0 || e.Y / 16 < 0)
                            return;
                        g.DrawImage(gridBoxTileset.Image, new Rectangle(e.X / 16 * 16, e.Y / 16 * 16, 16, 16), (selectedTile % 16) * 16, (selectedTile / 16) * 16, 16, 16, GraphicsUnit.Pixel);
                        mapTileData.overlayMapData[e.X / 16 + (e.Y / 16) * 10] = selectedTile;
                        mapTileData.saveOverlayOverworldMapData();
                    }
                }
            }
            else //Collision editor mouse movement
            {
                TileDrawer tileDrawer = new TileDrawer();
                int ind = (int)nSelected.Value;
                int x = e.X / 16;
                int y = e.Y / 16;

                if (e.Button == MouseButtons.Left)
                {
                    if (ind > -1)
                    {
                        if (selectedObjectOrigX == 0xF)
                            selectedObjectOrigX = -1;
                        if (selectedObjectOrigY == 0xF)
                            selectedObjectOrigY = -1;
                        mapTileData.collisionObjects[ind].xPos = (byte)(selectedObjectOrigX + (x - lastMapHoverPoint.X));
                        mapTileData.collisionObjects[ind].yPos = (byte)(selectedObjectOrigY + (y - lastMapHoverPoint.Y));
                        if (selectedObjectOrigX + (x - lastMapHoverPoint.X) < 0 || selectedObjectOrigX + (x - lastMapHoverPoint.X) > 9)
                        {
                            if (!mapTileData.collisionObjects[ind].is3Byte && !mapTileData.collisionObjects[ind].multiTileFlag || !mapTileData.collisionObjects[ind].multiTileFlag)
                            {
                                mapTileData.collisionObjects[ind].xPos = 0;
                                mapTileData.collisionObjects[ind].hFlip = false;
                            }
                            else
                            {
                                mapTileData.collisionObjects[ind].xPos = 0xF;
                                mapTileData.collisionObjects[ind].hFlip = true;
                            }
                        }
                        else
                            mapTileData.collisionObjects[ind].hFlip = false;
                        if (selectedObjectOrigY + (y - lastMapHoverPoint.Y) < 0 || selectedObjectOrigY + (y - lastMapHoverPoint.Y) > 7)
                        {
                            if (!mapTileData.collisionObjects[ind].is3Byte && !mapTileData.collisionObjects[ind].multiTileFlag || !mapTileData.collisionObjects[ind].multiTileFlag)
                            {
                                mapTileData.collisionObjects[ind].yPos = 0;
                                mapTileData.collisionObjects[ind].vFlip = false;
                            }
                            else
                            {
                                mapTileData.collisionObjects[ind].yPos = 0x0F;
                                mapTileData.collisionObjects[ind].vFlip = true;
                            }
                        }
                        else
                            mapTileData.collisionObjects[ind].vFlip = false;

                        mapTileData.saveCollisionOverworldData();
                        drawSelectedObject();
                    }
                }
            }
        }

        private void gridBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (gridBoxMap.Image == null)
                return;

            if (e.Button == MouseButtons.Left)
                saveSnapshot();

        }

        /// <summary>
        /// This method handles saving a snapshot to the undo list. It will check to make sure a change has occured to the map data before saving.
        /// </summary>
        private void saveSnapshot()
        {
            if (radioButtonOverlay.Checked)
            {
                //This section is to make sure we dont save a snapshot when the user doesnt change any tiles. 
                bool changedFlag = true;
                if (mapSnapshotsUndo.Count > 0)
                {
                    if (mapSnapshotsUndo[mapSnapshotsUndo.Count - 1].Length == mapTileData.overlayMapData.Length)
                    {
                        for (int i = 0; i < mapTileData.overlayMapData.Length; i++)
                        {
                            if (mapSnapshotsUndo[mapSnapshotsUndo.Count - 1][i] != (mapTileData.overlayMapData[i]))
                            {
                                changedFlag = true;
                                break;
                            }
                            else
                                changedFlag = false;
                        }
                    }
                }
                if (changedFlag) //Create the snapshot
                {

                    byte[] mapData = new byte[mapTileData.overlayMapData.Length];

                    for (int i = 0; i < mapData.Length; i++)
                        mapData[i] = mapTileData.overlayMapData[i];

                    mapSnapshotsUndo.Add(mapData);
                    mapSnapshotsRedo.Clear();
                }
            }
            else
            {
                //This section is to make sure we dont save a snapshot when the user just selects a collision. 
                bool changedFlag = true;
                if (collisionSnapshotsUndo.Count > 0)
                {
                    if (collisionSnapshotsUndo[collisionSnapshotsUndo.Count - 1].Count == mapTileData.collisionObjects.Count)
                    {
                        for (int i = 0; i < mapTileData.collisionObjects.Count; i++)
                        {
                            if (!collisionSnapshotsUndo[collisionSnapshotsUndo.Count - 1][i].Equals(mapTileData.collisionObjects[i]))
                            {
                                changedFlag = true;
                                break;
                            }
                            else
                                changedFlag = false;
                        }
                    }
                }
                if (changedFlag) //Create the snapshot
                {
                    List<CollisionObject> mapData = new List<CollisionObject>();
                    foreach (CollisionObject o  in mapTileData.collisionObjects)
                    {
                        mapData.Add(new CollisionObject(o));
                    }


                    collisionSnapshotsUndo.Add(mapData);
                    collisionSnapshotsRedo.Clear();
                }
            }
        }

        /// <summary>
        /// This method handles returning the map data back to a previous snapshot for both collisions and overlay.
        /// Undos from the undo list are added to the redo list.
        /// </summary>
        private void undoSnapshot()
        {
            if (radioButtonCollisions.Checked)
            {

                if (collisionSnapshotsUndo.Count == 0 || collisionSnapshotsUndo.Count == 1)//The first item in our list is always the base map.
                    return;

                mapTileData.collisionObjects.Clear();
                foreach (CollisionObject o in collisionSnapshotsUndo[collisionSnapshotsUndo.Count - 2])
                    mapTileData.collisionObjects.Add(new CollisionObject(o));


                List<CollisionObject> collisions = new List<CollisionObject>();
                foreach (CollisionObject o in collisionSnapshotsUndo[collisionSnapshotsUndo.Count - 1])
                    collisions.Add(new CollisionObject(o));

                collisionSnapshotsRedo.Add(collisions);
                collisionSnapshotsUndo.RemoveAt(collisionSnapshotsUndo.Count - 1);

                collisionListView();
                drawSelectedObject();

                mapTileData.saveCollisionOverworldData();

                SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
                toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();

            }
            else
            {
                if (mapSnapshotsUndo.Count == 0 || mapSnapshotsUndo.Count == 1)//The first item in our list is always the base map.
                    return;

                byte[] mapData = new byte[mapTileData.overlayMapData.Length];//Map data for the MapTileData class
                byte[] mapData2 = new byte[mapTileData.overlayMapData.Length];//Map data to pass between Undo and Redo lists

                for (int i = 0; i < mapData.Length; i++)
                    mapData[i] = mapSnapshotsUndo[mapSnapshotsUndo.Count - 2][i];

                mapTileData.overlayMapData = mapData;

                redrawMap();

                for (int i = 0; i < mapData2.Length; i++)
                    mapData2[i] = mapSnapshotsUndo[mapSnapshotsUndo.Count - 1][i];

                mapSnapshotsRedo.Add(mapData2);
                mapSnapshotsUndo.RemoveAt(mapSnapshotsUndo.Count - 1);
            }
        }

        /// <summary>
        /// This method handles returning the map data back to a previous future snapshot for both collisions and overlay.
        /// </summary>
        private void redoSnapshot()
        {
            if (radioButtonCollisions.Checked)
            {
                if (collisionSnapshotsRedo.Count == 0)
                    return;

                mapTileData.collisionObjects.Clear();
                foreach (CollisionObject o in collisionSnapshotsRedo[collisionSnapshotsRedo.Count - 1])
                    mapTileData.collisionObjects.Add(new CollisionObject(o));

                List<CollisionObject> collisions = new List<CollisionObject>();
                foreach (CollisionObject o in collisionSnapshotsRedo[collisionSnapshotsRedo.Count - 1])
                    collisions.Add(new CollisionObject(o));

                collisionSnapshotsUndo.Add(collisions);
                collisionSnapshotsRedo.RemoveAt(collisionSnapshotsRedo.Count - 1);

                collisionListView();
                drawSelectedObject();

                mapTileData.saveCollisionOverworldData();

                SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
                toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();

            }
            else
            {
                if (mapSnapshotsRedo.Count == 0)
                    return;

                byte[] mapData = new byte[mapTileData.overlayMapData.Length];//Map data for the MapTileData class
                byte[] mapData2 = new byte[mapTileData.overlayMapData.Length];//Map data to pass between Undo and Redo lists

                for (int i = 0; i < mapData.Length; i++)
                    mapData[i] = mapSnapshotsRedo[mapSnapshotsRedo.Count - 1][i];

                mapTileData.overlayMapData = mapData;

                redrawMap();

                for (int i = 0; i < mapData2.Length; i++)
                    mapData2[i] = mapSnapshotsRedo[mapSnapshotsRedo.Count - 1][i];

                mapSnapshotsUndo.Add(mapData2);
                mapSnapshotsRedo.RemoveAt(mapSnapshotsRedo.Count - 1);

            }
        }

        private void LALE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "Z")
                undoSnapshot();
            else if (e.Control && e.KeyCode.ToString() == "Y")
                redoSnapshot();
            else if (e.Control && e.KeyCode.ToString() == "A")
                bAdd.PerformClick();
            else if (e.KeyCode == Keys.Delete)
                bDelete.PerformClick();
        }

        /// <summary>
        /// This activates/deactives control elements for the collision list based on the selected collision.
        /// </summary>
        private void selectCollision(CollisionObject collisionObject, int index)
        {
            if (index == -1)
            {
                nSelected.Value = -1;
                comDirection.Enabled = false;
                nLength.Enabled = false;
                nObjectID.Value = 0;
                pObject.Invalidate();
            }
            else
            {
                nSelected.Value = index;
                if (collisionObject.is3Byte)
                {
                    comDirection.Enabled = true;
                    nLength.Enabled = true;
                }
                comDirection.SelectedIndex = (collisionObject.direction == 8 ? 0 : 1);
                nLength.Value = collisionObject.length;
                nObjectID.Value = collisionObject.id;
            }
        }

        /// <summary>
        /// This returns the object ID of the selected object
        /// </summary>
        private int getSelectedObjectID(int x, int y)
        {
            x /= 16;
            y /= 16;
            for (int i = mapTileData.collisionObjects.Count - 1; i > -1; i--)
            {
                if (mapTileData.collisionObjects[i].xPos == x && mapTileData.collisionObjects[i].yPos == y)
                    return i;
                else
                {
                    CollisionObject o = mapTileData.collisionObjects[i];
                    int dx = (o.xPos == 0xF ? (o.xPos - 16) : o.xPos);
                    int dy = (o.yPos == 0xF ? (o.yPos - 16) : o.yPos);
                    if (o.is3Byte)
                    {
                        if (o.direction == 8)
                        {
                            if (o.multiTileFlag)
                            {
                                if (x >= dx && y >= dy && y < dy + o.height && x < dx + (o.width * o.length))
                                    return i;
                            }
                            if (x >= dx && x < o.length + dx && y == dy)
                                return i;
                        }
                        else
                        {
                            if (o.multiTileFlag)
                            {
                                if (x >= dx && y >= dy && y < dy + (o.height * o.length) && x < dx + o.width)
                                    return i;
                            }
                            if (x == dx && y >= dy && y < dy + o.length)
                                return i;
                        }
                    }
                    else if (o.multiTileFlag)
                    {
                        if (x >= dx && y >= dy && y < dy + o.height && x < dx + o.width)
                            return i;
                    }
                }
            }
            return -1;
        }

        private void comDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nSelected.Value == -1)
                return;
            CollisionObject o = new CollisionObject();
            if (LAGame.overworldFlag)
                o = mapTileData.collisionObjects[(byte)nSelected.Value];
            else
                o = mapTileData.collisionObjects[(byte)nSelected.Value];
            if (comDirection.SelectedIndex == 0)
                o.direction = 8;
            else
                o.direction = 0xC;

            saveSnapshot();
            mapTileData.saveCollisionOverworldData();
            drawSelectedObject();
        }

        private void nLength_ValueChanged(object sender, EventArgs e)
        {
            if (nSelected.Value == -1)
                return;
            CollisionObject o = new CollisionObject();
            if (LAGame.overworldFlag)
                o = mapTileData.collisionObjects[(byte)nSelected.Value];
            else
                o = mapTileData.collisionObjects[(byte)nSelected.Value];
            o.length = (byte)nLength.Value;

            if (nLength.Value > 1)
                o.is3Byte = true;
            else
                o.is3Byte = false;
            collisionListView();

            //Repoint map collisions if able to
            SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);

            if (autoRepointCollisionsToolStripMenuItem.Checked)
            {
                if (spaceCalculator.getUsedSpace() > spaceCalculator.getFreeSpace())
                {
                    CollisionRepointer collisionRepointer = new CollisionRepointer(LAGame, mapTileData);
                    collisionRepointer.expandCollisionAddress();
                }
            }


            saveSnapshot();
            mapTileData.saveCollisionOverworldData();
            drawSelectedObject();

            toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();
        }

        private void nObjectID_ValueChanged(object sender, EventArgs e)
        {
            if (nSelected.Value == -1)
                return;
            string s; //Used for the text inside our collision list
            CollisionObject o = new CollisionObject();

            //Change the object ID.
            o = mapTileData.collisionObjects[(int)nSelected.Value];
            o.id = (byte)nObjectID.Value;
            o.getOverworldObjs(o);
            mapTileData.collisionObjects[(int)nSelected.Value] = o;

            //Do the text for the list
            if (o.is3Byte)
                s = "3-Byte";
            else
                s = "2-Byte";
            s += "      0x" + o.id.ToString("X");
            CollisionList.Items[(int)nSelected.Value] = s;

            saveSnapshot();
            mapTileData.saveCollisionOverworldData();
            pObject.Invalidate();
        }

        private void deleteCollisionObject(int index)
        {
            mapTileData.collisionObjects.RemoveAt(index);
            if (nSelected.Value == mapTileData.collisionObjects.Count)
                nSelected.Value--;
            saveSnapshot();
            collisionListView();

            if (nSelected.Value != -1)
                selectedCollisionObject = mapTileData.collisionObjects[(int)nSelected.Value];

            mapTileData.saveCollisionOverworldData();
            drawSelectedObject();

            SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
            toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();

        }

        private void gridBoxMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radioButtonCollisions.Checked)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int index = getSelectedObjectID(e.X, e.Y);
                    if (index > -1)
                    {
                        deleteCollisionObject(index);
                    }
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (nSelected.Value == -1)
                return;

            deleteCollisionObject((int)nSelected.Value);
        }

        private void bCollisionUp_Click(object sender, EventArgs e)
        {
            if (CollisionList.Items.Count == 0 || nSelected.Value == -1)
                return;

            byte index = (byte)nSelected.Value;
            object selectedCollision = CollisionList.Items[index];
            List<CollisionObject> objects = new List<CollisionObject>();
            objects = mapTileData.collisionObjects;

            CollisionObject O = objects[index];
            if (index == 0)
                return;
            objects.Remove(O);
            objects.Insert(index - 1, O);
            CollisionList.Items.Remove(selectedCollision);
            CollisionList.Items.Insert(index - 1, selectedCollision);

            collisionListView();
            CollisionList.SelectedIndex = index - 1;
            saveSnapshot();
        }

        private void bCollisionDown_Click(object sender, EventArgs e)
        {
            if (CollisionList.Items.Count == 0 || nSelected.Value == -1)
                return;

            byte index = (byte)nSelected.Value;
            object selectedCollision = CollisionList.Items[index];
            List<CollisionObject> objects = new List<CollisionObject>();
            objects = mapTileData.collisionObjects;

            CollisionObject O = objects[index];
            if (index == nSelected.Maximum)
                return;
            objects.Remove(O);
            objects.Insert(index + 1, O);
            CollisionList.Items.Remove(selectedCollision);
            CollisionList.Items.Insert(index + 1, selectedCollision);

            collisionListView();
            CollisionList.SelectedIndex = index + 1;
            saveSnapshot();
        }

        private void pObject_Paint(object sender, PaintEventArgs e)
        {
            if (gridBoxTileset.Image != null)
            {
                if (nSelected.Value == -1)
                {
                    pObject.Width = 20;
                    pObject.Height = 20;
                    return;
                }
                if (selectedCollisionObject != null)
                {
                    if (selectedCollisionObject.id < 0xF5 || selectedCollisionObject.id >= 0xFE)
                    {
                        pObject.Width = (selectedCollisionObject.width * 16) + 4;
                        pObject.Height = (selectedCollisionObject.height * 16) + 4;
                        e.Graphics.DrawImage(gridBoxTileset.Image, new Rectangle(0, 0, 16, 16), (selectedCollisionObject.id % 16) * 16, (selectedCollisionObject.id / 16) * 16, 16, 16, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        pObject.Width = (selectedCollisionObject.width * 16) + 4;
                        pObject.Height = (selectedCollisionObject.height * 16) + 4;
                        for (int y = 0; y < selectedCollisionObject.height; y++)
                        {
                            for (int x = 0; x < selectedCollisionObject.width; x++)
                            {
                                int id = selectedCollisionObject.tiles[(y * selectedCollisionObject.width) + x];
                                e.Graphics.DrawImage(gridBoxTileset.Image, new Rectangle(0 + (x * 16), 0 + (y * 16), 16, 16), (id % 16) * 16, (id / 16) * 16, 16, 16, GraphicsUnit.Pixel);
                            }
                        }
                    }
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if ((LAGame.map < 0x80 && collisionDataAddress + 2 >= 0x2668B) || (LAGame.map > 0x7F && collisionDataAddress + 2 >= 0x69E73))
            {
                MessageBox.Show("You are trying to add more collision objects than can fit in the allotted space. Delete some objects first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CollisionObject O = new CollisionObject();
            O.id = (byte)gridBoxTileset.SelectedIndex;
            O.xPos = 0;
            O.yPos = 0;
            O.length = 1;
            O.getOverworldObjs(O);

            selectedCollisionObject = O.objectIDs[0];

            if (nSelected.Value == -1)
                mapTileData.collisionObjects.Add(selectedCollisionObject);
            else
                mapTileData.collisionObjects.Insert((byte)nSelected.Value, selectedCollisionObject);
            collisionListView();

            if (nSelected.Value == -1)
                nSelected.Value = mapTileData.collisionObjects.Count - 1;

            //Repoint map collisions if able to
            SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
            if (autoRepointCollisionsToolStripMenuItem.Checked)
            {
                if (spaceCalculator.getUsedSpace() > spaceCalculator.getFreeSpace())
                {
                    CollisionRepointer collisionRepointer = new CollisionRepointer(LAGame, mapTileData);
                    collisionRepointer.expandCollisionAddress();
                }
            }

            mapTileData.saveCollisionOverworldData();
            drawSelectedObject();
            saveSnapshot();

            toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();
            collisionDataAddress = mapTileData.mapAddress + spaceCalculator.getUsedSpace();
        }

        private void CollisionList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CollisionList.ContextMenuStrip = new ContextMenuStrip();
                CollisionList.ContextMenuStrip.Items.Add("Clear All");
                CollisionList.ContextMenuStrip.Show(Cursor.Position);
                CollisionList.ContextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(clearAllCollisions_ItemClicked);
            }
        }

        private void clearAllCollisions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mapTileData.collisionObjects.Clear();
            nSelected.Value = -1;

            collisionListView();
            saveSnapshot();
            redrawMap();

            mapTileData.saveCollisionOverworldData();

            SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
            toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();
        }

        private void clearOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButtonOverlay.Checked && gridBoxTileset.Image != null)
            {
                int i = 0;
                foreach (byte b in mapTileData.overlayMapData)
                {
                    mapTileData.overlayMapData[i] = 0;
                    i++;
                }
                saveSnapshot();
                mapTileData.saveOverlayOverworldMapData();
                redrawMap();
            }
        }

        private void trimCollisionAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButtonCollisions.Checked)
            {
                CollisionRepointer collisionRepointer = new CollisionRepointer(LAGame, mapTileData);
                collisionRepointer.trimCollisionAddress();

                SpaceCalculator spaceCalculator = new SpaceCalculator(LAGame, mapTileData);
                toolStripStatusLabelSpace.Text = "Used/Free Space: " + spaceCalculator.getUsedSpace().ToString() + "/" + spaceCalculator.getFreeSpace().ToString();
            }
        }

        private void repointCollisionAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButtonCollisions.Checked)
            {
                RepointCollisions rc = new RepointCollisions(LAGame, mapTileData);
                rc.ShowDialog();

                if (rc.DialogResult == DialogResult.OK)
                {
                    loadMap();
                    collisionListView();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridBoxTileset.Image != null)
            {
                //Check if were on the overworld tab
                if (tabControl1.SelectedIndex == 0)
                {
                    radioButtonOverlay.Enabled = true;
                    loadMinimap();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    //loadMinimap();
                    radioButtonOverlay.Enabled = false;
                    radioButtonCollisions.Checked = true;
                }
            }
        }

        private void pMinimap_Click(object sender, EventArgs e)
        {
            if (gridBoxTileset.Image != null)
            {
                //Check if were on the overworld tab
                if (tabControl1.SelectedIndex == 0)
                {
                    numericUpDownMap.Value = (byte)pMinimap.SelectedIndex;
                }
            }
        }

        private void checkBoxSpecialMap_CheckedChanged(object sender, EventArgs e)
        {
            LAGame.specialFlag = checkBoxSpecialMap.Checked;
            loadMap();
            redrawMap();
            
            if (radioButtonCollisions.Checked)
                collisionListView();
        }
    }
}
