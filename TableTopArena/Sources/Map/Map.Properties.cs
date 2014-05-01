using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TableTopArena.Sources.MapClasses;

namespace TableTopArena.Sources
{
    public partial class Map
    {
        #region Properties

        public int Rows { get; private set; }
        public int Columns { get; private set; }        

        public List<MapTile> Tiles { get; set; }

        private MapTile _ClickFrom { get; set; }

        #endregion

    }
}
