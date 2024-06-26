﻿using System;
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
        string[] PluginsPaths= Array.Empty<string>();
        string directoryPath = @"C:\Users\mtspr\Desktop\Учеба\4 семестр\Шаблоны проектирования\1 лр\lr1\Pluginsdll";
        List<Assembly> assemblies = new List<Assembly>();
        public Dictionary<string, Type> PluginCreatorPairs = new Dictionary<string, Type>();



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

        public Dictionary<string, Type> GetPluginNames()
        {
            //List<string> pluginNames = new List<string>();
            string a="";
            Type b=null;
            Dictionary<string,Type> temp = new Dictionary<string,Type>();

            foreach (Assembly assembly in this.assemblies)
            {
                // Получаем все типы в текущей сборке
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                    {
                       // pluginNames.Add(type.Name);
                        a = type.FullName;
                    }
                    else
                    {
                        b = type;
                    }
                        
                }
               
               PluginCreatorPairs.Add(a,b);
                temp.Add(a,b);
            }
            return temp;
        }

            public PluginManager()
        { 
            PluginsPaths = GetPluginPaths();
            LoadPlugins();
        }
    }
}
