using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugLibInterfaces;

namespace  PluginLib3
{
    class CreatorP3 : ICreator
    {
        public IPlugin FactoryMethod()
        {
            return new Plugin3();
        }
    }
}
