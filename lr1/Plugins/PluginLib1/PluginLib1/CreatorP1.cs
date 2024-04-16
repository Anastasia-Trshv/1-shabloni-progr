
using PlugLibInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLib1
{
    class CreatorP1 : ICreator
    {
        public IPlugin FactoryMethod()
        {
            return new Plugin1();
        }
    }
}
