
using PlugLibInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLib2
{
    class CreatorP2 : ICreator
    {
        public IPlugin FactoryMethod()
        {
            return new Plugin2();
        }
    }
}
