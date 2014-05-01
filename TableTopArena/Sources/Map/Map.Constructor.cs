using SaveDataModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TableTopArena.Sources.MapClasses;

namespace TableTopArena.Sources
{
    public partial class Map : Grid
    {
        public Map(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            CreateMap(Rows, Columns);
        }
    }
}
