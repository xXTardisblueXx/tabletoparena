using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Controls;

namespace TableTopArena.Sources.MapClasses
{
    public class MapTile : Button
    {
        public MapTile(int x, int y)
        {
            SetPosition(new MapPoint(x, y)); 
        }

        public MapTile(MapPoint point)
        {
            SetPosition(point);
        }

        public MapPoint Position
        {
            get
            {
                return new MapPoint(Grid.GetColumn(this), Grid.GetRow(this));
            }
        }

        public MapTileType TileType { get; set; }

        public void SetPosition(MapPoint point)
        {
            Grid.SetColumn(this, point.X);
            Grid.SetRow(this, point.Y);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class MapPoint
    {
        public MapPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            MapPoint p = obj as MapPoint;
            if ((System.Object)p == null) return false;

            return Equals(p);
        }

        public bool Equals(MapPoint point)
        {
            if ((object)point == null) return false;

            else return (X == point.X) && (Y == point.Y);
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
}
