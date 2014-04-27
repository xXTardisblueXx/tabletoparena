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

        public void AddGameObject(int row, int column, GameObject gameObject)
        {
            GetTile(row, column).Object = gameObject;
        }

        public void AddGameObject(int row, int column, GameCharacter character)
        {
            GetTile(row, column).Character = character;
        }
        public void AddGameCharacter(int row, int column, GameCharacter gameCharacter)
        {
            GetTile(row, column).Character = gameCharacter;
        }

        public void MoveGameObject(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            MapTile fromTile = GetTile(fromRow, fromColumn);
            MapTile toTile = GetTile(toRow, toColumn);
            toTile.Object = fromTile.Object;
            fromTile.Object = null;
        }

        private MapTile GetTile(int row, int column)
        {
            return Tiles.Find(t => t.RowNumber == row && t.ColumnNumber == column);
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
                    RowNumber = rowNumber,
                    ColumnNumber = i,
                    Background = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)))
                });
            }
        }
        public List<MapTile> Tiles { get; set; }



    }

    public class MapTile
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public SolidColorBrush Background { get; set; }
        public GameObject Object { get; set; }
        public GameCharacter Character { get; set; }
        public GamePlayer Player { get; set; }

    }


}
