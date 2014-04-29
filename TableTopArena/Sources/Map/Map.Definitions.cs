using Newtonsoft.Json;
using System;
using System.Windows.Controls;

namespace TableTopArena.Sources.MapClasses
{
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


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            MapPoint p = obj as MapPoint;
            if ((System.Object)p == null) return false;

            return Equals(p);
        }

        public bool Equals(MapPoint position)
        {
            if ((object)position == null) return false;

            else return (Row == position.Row) && (Column == position.Column);
        }
    }


    public enum MapTileType
    {
        Empty = 0,
        Object = 1,
        Character = 2,
        Player = 3
    }

    public class EnumHelper
    {
        public static string ToTypeCodeString(MapTileType type)
        {
            switch (type)
            {
                case MapTileType.Empty:
                    return String.Empty;

                case MapTileType.Object:
                    return "O";

                case MapTileType.Character:
                    return "C";

                case MapTileType.Player:
                    return "P";

                default:
                    return String.Empty;
            }
        }

        public static MapTileType FromTypeCodeString(String code)
        {
            switch (code)
            {
                case "":
                default:
                    return MapTileType.Empty;
                case "O":
                    return MapTileType.Object;
                case "C":
                    return MapTileType.Character;
                case "P":
                    return MapTileType.Player;
            }
        }
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
