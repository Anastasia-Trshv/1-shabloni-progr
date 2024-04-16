using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlugLibInterfaces
{
    public interface IPlugin
    {
        public bool Status { get; set; }
        public string Execute();
        public string Terminate();

        
    }
}
