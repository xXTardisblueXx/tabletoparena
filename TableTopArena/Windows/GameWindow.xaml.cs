using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TableTopArena.Sources;

namespace TableTopArena.Windows
{
    /// <summary>
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Map _Map { get; set; }

        public GameWindow()
        {
            InitializeComponent();           

            int mapWidth = 10;
            int mapHeight = 10;
        
            _Map = new Map(mapWidth, mapHeight);

            MapDataGrid.Children.Add(_Map);
        }




    }
}
