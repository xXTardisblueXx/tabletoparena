using System;
using System.Windows.Controls;
using TableTopArena.Sources.MapClasses;

namespace TableTopArena.Sources
{
    public partial class Map
    {

        public event EventHandler<MapClickEventArgs> Click;
        void RaiseClickEvent(MapTile button)
        {
            if (Click != null)
                Click(this, new MapClickEventArgs(button));
        }                
    }

    public class MapClickEventArgs : EventArgs
    {
        internal MapClickEventArgs(MapTile button)
        {
            ClickedButton = button;
        }
        public MapTile ClickedButton { get; set; }
    }
}
