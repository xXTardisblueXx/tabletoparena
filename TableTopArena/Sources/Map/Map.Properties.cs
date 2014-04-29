using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TableTopArena.Sources.MapClasses;

namespace TableTopArena.Sources
{
    public partial class Map
    {
        #region Properties

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        private Grid _grid;
        public Grid MapGrid
        {
            set
            {
                if (value is Grid) _grid = value;
            }
            get
            {
                if (_grid == null) _grid = new Grid();
                return _grid;
            }
        }

        public Dictionary<MapPoint, MapTile> Tiles { get; set; }

        private GridButton _ClickFrom { get; set; }

        #endregion

    }
}
