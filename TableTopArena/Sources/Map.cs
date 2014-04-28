using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TableTopArena.Sources
{
    public class Map
    {
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public Dictionary<MapPoint, MapTile> Tiles { get; set; }
        
        public Map(int rows, int columns)
        {
            RowCount = rows;
            ColumnCount = columns;
            Tiles = new Dictionary<MapPoint, MapTile>();

            for (int i = 0; i < rows; i++)
            {
                for (int o = 0; o < columns; o++)
                {
                    MapPoint position = new MapPoint(i, o);
                    Tiles.Add(position, new MapTile(position));
                }                
            }
        }

        public void EditTile(GridButton button, MapTileType newType)
        {
            MapTile mapTile = GetTile(button.Position);
            mapTile.TileType = newType;
            Tiles[mapTile.Position] = mapTile;
            SetButtonContentAccordingToType(button, mapTile);
        }

        private void SetButtonContentAccordingToType(GridButton button, MapTile tile)
        {
            switch (tile.TileType)
            {
                case MapTileType.Empty:
                    button.Content = String.Empty;
                    break;
                case MapTileType.Object:
                    button.Content = "O";
                    break;
                case MapTileType.Character:
                    button.Content = "C";
                    break;
                case MapTileType.Player:
                    button.Content = "P";
                    break;
            }      
        }

        private MapTile GetTile(MapPoint Position)
        {
            MapTile tile;
            Tiles.TryGetValue(Position, out tile);
            return tile;
        }
    }

    public class MapTile
    {
        public MapTile(int row, int column)
        {
            Position = new MapPoint(row, column);
        }
        public MapTile(MapPoint position)
        {
            Position = position;
        }
        public MapPoint Position { get; set; }
        public MapTileType TileType { get; set; }

    }

    public class MapPoint
    {
        public MapPoint(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row { get; set; }
        public int Column { get; set; }
    }


    public enum MapTileType
    {
        Empty = 0,
        Object = 1,
        Character = 2,
        Player = 3
    }

    public class GridButton : Button
    {
        public GridButton(MapPoint position)
        {
            Position = position;
        }
        public MapPoint Position { get; private set; }
    }

    

}
