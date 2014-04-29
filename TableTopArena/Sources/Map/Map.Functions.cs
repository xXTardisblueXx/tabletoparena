using Newtonsoft.Json;
using SaveDataModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using TableTopArena.Sources.MapClasses;
using System.Text;

namespace TableTopArena.Sources
{
    public partial class Map
    {
        private MapTile GetTile(MapPoint Position)
        {
            MapTile tile;
            Tiles.TryGetValue(Position, out tile);
            return tile;
        }

        private void CreateMap(int rows, int columns)
        {
            CreateTiles(rows, columns);

            CreateGrid(rows, columns);
        }
        
        private void LoadMap(SaveGame saveGame)
        {
            List<string> tiles = JsonConvert.DeserializeObject<List<string>>(saveGame.MapString);
            Dictionary<MapPoint, MapTile> dict = new Dictionary<MapPoint, MapTile>();
            foreach (string tileString in tiles)
            {
                MapTile tile = JsonConvert.DeserializeObject<MapTile>(tileString);
                dict[tile.Position] = tile;
            }
            Tiles = dict;
            CreateGrid(saveGame.Rows, saveGame.Columns);

        }

        private void CreateTiles(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
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

        private void CreateGrid(int rows, int columns)
        {
            MapGrid = new Grid();
            for (var i = 1; i < rows + 1; i++)
            {
                AddRow();
            }
            for (var o = 1; o < columns + 1; o++)
            {
                AddColumn();
            }

            foreach (KeyValuePair<MapPoint, MapTile> keyValue in Tiles)
            {
                MapPoint position = keyValue.Key;
                MapTile tile = keyValue.Value;


                GridButton button = new GridButton(position);
                button.Click += button_Click;

                Grid.SetRow(button, position.Row);
                Grid.SetColumn(button, position.Column);
                MapGrid.Children.Add(button);
            }
        }

        void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RaiseClickEvent(sender as GridButton);
        }

        private void AddColumn()
        {
            MapGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        private void AddRow()
        {
            MapGrid.RowDefinitions.Add(new RowDefinition());
        }

        public void Save(String mapName)
        {
            using (SaveDataContext context = new SaveDataContext())
            {
                List<string> list = new List<string>();
                for (int i = 0; i < Rows; i++)
                {
                    for (int o = 0; o < Columns; o++)
                    {
                        MapPoint position = new MapPoint(i, o);
                        MapTile tile = GetTile(position);
                        list.Add(tile.ToString());                        
                    }
                }
                SaveGame save = new SaveGame()
                {
                    Id = Guid.NewGuid(),
                    MapString = JsonConvert.SerializeObject(list),
                    MapName = mapName,
                    Rows = Rows,
                    Columns = Columns
                };
                context.SaveGames.Add(save);
                context.SaveChanges();
            }
        }

        public void Load(Guid saveGameId)
        {
            using (SaveDataContext context = new SaveDataContext())
            {
                SaveGame game = context.SaveGames.FirstOrDefault(s => s.Id == saveGameId);
                Load(game);
            }
        }

        public void Load(SaveGame saveGame)
        {            
            LoadMap(saveGame);
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
            button.Content = EnumHelper.ToTypeCodeString(tile.TileType);
        }
    }
}
