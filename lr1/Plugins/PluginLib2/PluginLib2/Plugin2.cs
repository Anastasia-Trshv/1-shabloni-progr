using PlugLibInterfaces;

namespace PluginLib2
{
    public class Plugin2 :IPlugin
    {
        public bool Status { get; set; }
        public string Execute()
        {
            return "Plugin2 is executing";
        }

        public string Terminate()
        {
            return "Plugin2 stoped";
        }
    }
}
