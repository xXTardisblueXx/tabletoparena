using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TableTopArena.Sources
{
    public class Map
    {

        private int _rows;
        private int _columns;
        private List<MapRow> _rowObjects;
        private List<MapTile> _tiles;

        public int RowCount
        {
            set
            {
                _rows = value;
            }
            get
            {
                return _rows;
            }
        }
        public int ColumnCount
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }
        public virtual List<MapRow> Rows
        {
            get
            {
                if (_rowObjects == null)
                {
                    _rowObjects = new List<MapRow>();
                }
                return _rowObjects;
            }
            set
            {
                _rowObjects = value;
            }
        }
        public virtual List<MapTile> Tiles
        {
            get
            {
                if (_tiles == null) _tiles = new List<MapTile>();
                return _tiles;
            }
            set { _tiles = value; }
        }
        public Map(int rows, int columns)
        {
            RowCount = rows;
            ColumnCount = columns;

            Rows = new List<MapRow>();
            Tiles = new List<MapTile>();

            for (int i = 0; i < rows; i++)
            {
                MapRow row = new MapRow(columns, i);
                Tiles.AddRange(row.Tiles);
                Rows.Add(row);
            }
        }

        public void EditTile(GridButton button, MapTileType newType)
        {
            MapTile mapTile = button.Tile;
            int index = Tiles.IndexOf(mapTile);
            mapTile.TileType = newType;
            Tiles[index] = mapTile;
            RefreshType(button);
        }

        private void RefreshType(GridButton button)
        {
            switch (button.Tile.TileType)
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
            return Tiles.Find(t => t.Position == Position);
        }
    }


    public class MapRow
    {
        public MapRow(int columns, int rowNumber)
        {
            Tiles = new List<MapTile>();
            Random random = new Random();
            for (int i = 0; i < columns; i++)
            {
                Tiles.Add(new MapTile()
                {
                    Position = new MapPoint() {
                        Row = rowNumber,
                        Column = i
                    },
                    Background = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)))
                });
            }
        }
        public List<MapTile> Tiles { get; set; }



    }

    public class MapTile
    {
        public MapPoint Position { get; set; }
        public SolidColorBrush Background { get; set; }

        public MapTileType TileType { get; set; }

    }

    public class MapPoint
    {
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
        public MapTile Tile { get; set; }
    }

    

}
