using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PlugLibInterfaces;
using System.IO;


namespace lr1
{

    class PluginManager
    {
        string[] PluginsPaths=new string[0];
        string directoryPath = @"C:\Users\mtspr\Desktop\Учеба\4 семестр\Шаблоны проектирования\1 лр\lr1\Pluginsdll";
        List<Assembly> assemblies = new List<Assembly>();



        public void LoadPlugins()
        {
            foreach(string path in PluginsPaths)
            {
                Assembly pluginAssembly = Assembly.LoadFile(path);
                assemblies.Add(pluginAssembly);
            } 
        }

        public string[] GetPluginPaths()
        {
            string[] projectFiles = Directory.GetFiles(this.directoryPath, "*.dll", SearchOption.AllDirectories);
            return projectFiles;
        }

        public List<string> GetPluginNames()
        {
            List<string> pluginNames = new List<string>();

            foreach (Assembly assembly in this.assemblies)
            {
                // Получаем все типы в текущей сборке
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        pluginNames.Add(type.Name);
                    }
                        
                }
            }
            return pluginNames;
        }

            public PluginManager()
        { 
            PluginsPaths = GetPluginPaths();
            LoadPlugins();
        }
    }
}
