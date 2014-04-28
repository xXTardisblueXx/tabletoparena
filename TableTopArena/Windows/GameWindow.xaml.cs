using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TableTopArena.Sources;

namespace TableTopArena.Windows
{
    /// <summary>
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GridButton _ClickFrom { get; set; }
        private Map _Map { get; set; }

        public GameWindow()
        {
            InitializeComponent();           

            int mapWidth = 10;
            int mapHeight = 10;
        
            _Map = new Map(mapWidth, mapHeight);

            for (var i = 1; i < mapWidth + 1; i++)
            {
                MapDataGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (var o = 1; o < mapHeight + 1; o++)
            {
                MapDataGrid.RowDefinitions.Add(new RowDefinition());
            }

            foreach (MapTile tile in _Map.Tiles)
            {
                GridButton button = new GridButton()
                {
                    Tile = tile
                };
          
                button.Click += MapClick;

                Grid.SetRow(button, tile.Position.Row);
                Grid.SetColumn(button, tile.Position.Column);
                MapDataGrid.Children.Add(button);
            }
        }
        void MapClick(object sender, RoutedEventArgs e)
        {
            GridButton button = sender as GridButton;
            if (button != null)
            {
                if (_ClickFrom == null) _ClickFrom = button;
                else
                {
                    _Map.EditTile(_ClickFrom, MapTileType.Empty);
                    _Map.EditTile(button, MapTileType.Player);
                    _ClickFrom = null;
                }
            }

        }

    }
}
