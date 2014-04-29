using SaveDataModel;
using System.Collections.Generic;
using System.Linq;
using TableTopArena.Sources.MapClasses;

namespace TableTopArena.Sources
{
    public partial class Map
    {
        public Map(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            CreateMap(Rows, Columns);
        }
    }
}
