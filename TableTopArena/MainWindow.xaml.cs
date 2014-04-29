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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TableTopArena.Windows;

namespace TableTopArena
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGameWindowClick(object sender, RoutedEventArgs e)
        {
            GameWindow startgame = new GameWindow();
            startgame.Show();
        }

        private void StartMapEditorClick(object sender, RoutedEventArgs e)
        {
            MapEditorWindow mapEditor = new MapEditorWindow();
            mapEditor.Show();
        }
    }
}
