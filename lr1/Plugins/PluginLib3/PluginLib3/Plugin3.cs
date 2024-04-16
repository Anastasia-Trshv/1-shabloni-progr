
using PlugLibInterfaces;

namespace PluginLib3
{
    public class Plugin3 : IPlugin
    {
        public bool Status { get; set; }
        public string Execute()
        {
            return "Plugin3 is executing";
        }

        public string Terminate()
        {
            return "Plugin3 stoped";
        }
        public override string ToString()
        {

            return $"Plugin3";
        }
    }
}
