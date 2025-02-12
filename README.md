LALE 2.1

New features:

	Help Provider
		- Click the ? button in the top right of the caption bar and then click an element in the editor to get information on that element. Pretty much every feature has help associated with it.
	Automatic Alternate Tileset Graphics Functionality
		- LALE can now automatically detect if there are raising block tiles on the map, or if you are in a sideview room (side scrolling functionality can be faulty, particularly if there are no entrances/exits) and update the tileset automatically.
	Indoor Region Map Viewer
		- You can now see a preview of the entire region's worth of maps while the Indoor tab is selected. Loading all the maps can take a minute.
	Export Entire Map Image
		An old feature reimplemented. Under the File menu, you can export the entire selected region's maps to a PNG file. If automatic alternate tileset graphics are turned on, it will show up in the map image.

Bug fixes:

	- Fixed a bug where, when viewing the raised tiles alternate graphics, some tiles displayed were not correct (as an example, key blocks in level 7 were not drawn properly).



Modifications:

	- A number of elements have been renamed to better explain what they do (particularly within the dungeon minimap editor), along with added context via the new help provider.
	- Modified the dungeon minimap editor to provide copy and click functionality for minimap tiles.
	- Some dropdown menu elements now have tooltips.

	Spritesheet Entity Comparer
		- You can now test up to two entities for spritesheet compatibility

	Text Associated Editors Quick Edit
		- Both the Owl Statue editor and Sign Post editor can now open into the text editor for quick editing.
