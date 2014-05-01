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
        
        private void LoadMap(SaveGame saveGame)
        {
            throw new NotImplementedException();
        }

        void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RaiseClickEvent(sender as MapTile);
        }

        public void Save(String mapName)
        {
            throw new NotImplementedException();
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

        public void EditTile(MapTile button, MapTileType newType)        
        {
            MapPoint referencedPosition = button.Position;
            MapPoint unreferencedPosition = new MapPoint(button.Position.X, button.Position.Y);
            MapTile mapTile = Tiles.FirstOrDefault(t => t.Position == referencedPosition);
            MapTile mapTileToo = Tiles.FirstOrDefault(t => t.Position == unreferencedPosition);
            mapTile.TileType = newType;
            
            SetButtonContentAccordingToType(button, mapTile);
        }

        private void SetButtonContentAccordingToType(MapTile button, MapTile tile)
        {
            button.Content = EnumHelper.ToTypeCodeString(tile.TileType);
        }
    }
}
