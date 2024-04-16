
using PlugLibInterfaces;
using System.Xml.Linq;

namespace PluginLib1
{
    internal class Plugin1: IPlugin


    {
        public bool Status { get; set; }
        public string Execute()
        {
            return "Plugin1 is executing";
        }

        public string Terminate()
        {
            return "Plugin1 stoped";
        }
        public override string ToString()
        {

            return $"Plugin1";
        }
    }
}
