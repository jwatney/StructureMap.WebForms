using StructureMap.WebForms;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(StructureMapWebForms), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(StructureMapWebForms), "Shutdown")]

namespace StructureMap.WebForms {
  using System.Web;
  using Microsoft.Web.Infrastructure.DynamicModuleHelper;
  using StructureMap;

  public static class StructureMapWebForms {
    internal static IContainer Container { get; private set; }

    public static void RegisterServices(IContainer container) {
      Container = container;
      HttpRuntime.WebObjectActivator = new StructureMapServiceProvider(Container);
    }

    private static void Start() {
      DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
    }

    private static void Shutdown() {
      Container?.Dispose();
      Container = null;
    }
  }
}
