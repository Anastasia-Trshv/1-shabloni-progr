using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugLibInterfaces
{
     public interface ICreator
    {
        public IPlugin FactoryMethod();
    }
}
