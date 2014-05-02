using Newtonsoft.Json;
using SaveDataModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using TableTopArena.Sources.MapClasses;
using System.Text;
using System.Windows;

namespace TableTopArena.Sources
{
    public partial class Map
    {
        private void CreateMap(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Tiles = new List<MapTile>();
            for (int i = 0; i < rows; i++)
            {
                this.RowDefinitions.Add(new RowDefinition());
                for (int o = 0; o < columns; o++)
                {
                    MapTile tile = new MapTile(o, i);
                    tile.Click += button_Click;

                    Tiles.Add(tile);
                    Children.Add(tile);
                }
            }
            for (int c = 0; c < columns; c++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RaiseClickEvent(sender as MapTile);
        }

        public void EditTile(MapTile tile, MapTileType newType)
        {
            int position = Tiles.IndexOf(tile);
            Tiles.RemoveAt(position);

            tile.TileType = newType;

            Tiles.Insert(position, tile);
        }
    }
}
