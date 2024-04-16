using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lr1
{
    
    public partial class MainWindow : Window
    {
        public List<string> UnloadedPlugins { get; set; }
        public List<string> LoadedPlugins { get; set; }
        public List<string> WorkingPlugins { get; set; }
        public MainWindow()
        {
            UnloadedPlugins=new List<string>();

            PluginManager pluginManager = new PluginManager();
            UnloadedPlugins= pluginManager.GetPluginNames();
            DataContext = this;
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Execute_click(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}