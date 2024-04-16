using PlugLibInterfaces;
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
        public Dictionary<string,Type> UnloadedPlugins { get; set; }
        public Dictionary<string, Type> AllPlugins { get; set; }
        public List<IPlugin> LoadedPlugins { get; set; }
        public List<IPlugin> WorkingPlugins { get; set; }
        public MainWindow()
        {
            
            UnloadedPlugins = new Dictionary<string, Type>();
            AllPlugins = new Dictionary<string, Type>();
            LoadedPlugins = new List<IPlugin>();
            WorkingPlugins = new List<IPlugin>();

            PluginManager pluginManager = new PluginManager();

            UnloadedPlugins= pluginManager.GetPluginNames();
            AllPlugins = pluginManager.PluginCreatorPairs;
            DataContext = this;

            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            
            var keypair = (KeyValuePair<string, Type>)UnloadPlaginListBox.SelectedItem;
           
            Type factoryType = keypair.Value;

            var factory = (ICreator)Activator.CreateInstance(factoryType);

            var factoryProduct = factory.FactoryMethod();

            bool m = false;
            foreach (IPlugin plugin in LoadedPlugins)
            {
                if (plugin.GetType() == factoryProduct.GetType())
                {
                    m = true;
                }
            }
            foreach (IPlugin plugin in WorkingPlugins)
            {
                if (plugin.GetType() == factoryProduct.GetType())
                {
                    m = true;
                }
            }
            if (!m)
            {
                LoadedPlugins.Add(factoryProduct);
                UnloadedPlugins.Remove(keypair.Key);

                UpdateUnloadListBox();
                UpdateLoadedListBox();
            }
            

        }

        private void Execute_click(object sender, RoutedEventArgs e)
        {
           IPlugin plugin = (IPlugin)LoadedPluginListBox.SelectedItem;
            plugin.Status = true;
            WorkingPlugins.Add(plugin);
            LoadedPlugins.Remove(plugin);
            UpdateLoadedListBox();
            UpdateWorkingListBox();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            IPlugin plugin=(IPlugin)WorkingPluginsListBox.SelectedItem;
            plugin.Status = false;
            WorkingPlugins.Remove(plugin);
            LoadedPlugins.Add(plugin);
            UpdateLoadedListBox();
            UpdateWorkingListBox();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string keypair =LoadedPluginListBox.SelectedItem.ToString();
            foreach (IPlugin plugin in LoadedPlugins)
            {
                if(plugin.ToString()==keypair)
                {
                    LoadedPlugins.Remove(plugin);
                    break;
                }
            }
            UnloadedPlugins.Add(keypair,AllPlugins[keypair]);
            UpdateUnloadListBox();
            UpdateLoadedListBox();
        }

        private void UpdateUnloadListBox()
        {
            UnloadPlaginListBox.ItemsSource = null;
            UnloadPlaginListBox.ItemsSource = UnloadedPlugins;
        }
        private void UpdateLoadedListBox()
        {
           LoadedPluginListBox.ItemsSource = null;
            LoadedPluginListBox.ItemsSource = LoadedPlugins;
        }
        private void UpdateWorkingListBox()
        {
            WorkingPluginListBox.ItemsSource = null;
            WorkingPluginListBox.ItemsSource = WorkingPlugins;
        }
    }
}