using System.Runtime.Loader;
using System.Reflection;

namespace PipiPonaPoster.Source.Model.MainMenu
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true)
        { }

        protected override Assembly Load(AssemblyName assemblyName) => null;
    }
}
