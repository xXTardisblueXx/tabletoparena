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
        private List<Row> _rowObjects;
        private List<Tile> _tiles;

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
        public virtual List<Row> Rows
        {
            get
            {
                return _rowObjects;
            }
            set
            {
                _rowObjects = value;
            }
        }

        public virtual List<Tile> Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }
        public Map(int rows, int columns)
        {
            RowCount = rows;
            ColumnCount = columns;

            Rows = new List<Row>();
            Tiles = new List<Tile>();

            for (int i = 0; i < rows; i++)
            {
                Row row = new Row(columns, i);
                Tiles.AddRange(row.Tiles);
                Rows.Add(row);
            }
        }


    }

    public class Row
    {
        public Row(int columns, int rowNumber)
        {
            Tiles = new List<Tile>();
            Random random = new Random();
            for (int i = 0; i < columns; i++)
            {
                Tiles.Add(new Tile()
                {
                    Data = "A",
                    RowNumber = rowNumber,
                    ColumnNumber = i,
                    Background = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256))) 
                });
            }
        }
        public virtual List<Tile> Tiles { get; set; }
    }

    public class Tile
    {
        public String Data { get; set; }
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public SolidColorBrush Background { get; set; }

    }
}
