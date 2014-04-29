using System;
using System.Windows.Controls;
using TableTopArena.Sources.MapClasses;

namespace TableTopArena.Sources
{
    public partial class Map : Control
    {

        public event EventHandler<MapClickEventArgs> Click;
        void RaiseClickEvent(GridButton button)
        {
            if (Click != null)
                Click(this, new MapClickEventArgs(button));
        }                
    }

    public class MapClickEventArgs : EventArgs
    {
        internal MapClickEventArgs(GridButton button)
        {
            ClickedButton = button;
        }
        public GridButton ClickedButton { get; set; }
    }
}
