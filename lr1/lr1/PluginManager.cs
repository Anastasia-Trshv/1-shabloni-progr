using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PlugLibInterfaces;

namespace lr1
{

    class PluginManager
    {
        public List<string> GetPluginNames()
        {
            List<string> pluginNames = new List<string>();

            // Загружаем все сборки в текущем домене приложения


            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                // Получаем все типы в текущей сборке
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    // Проверяем, реализует ли тип интерфейс IPlugin
                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        // Извлекаем название класса и добавляем его в список
                        pluginNames.Add(type.Name);
                    }
                }
            }

            return pluginNames;
        }
    }
}
