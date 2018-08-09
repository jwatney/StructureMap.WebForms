namespace StructureMap.WebForms {
  using System;
  using System.Linq;
  using System.Reflection;

  public class StructureMapServiceProvider : IServiceProvider {
    private readonly IContainer root;

    public StructureMapServiceProvider(IContainer root) {
      this.root = root ?? throw new ArgumentNullException(nameof(root));
    }

    public object GetService(Type serviceType) {
      var container = StructureMapScope.GetContainer() ?? root;
      return ShouldResolveInstance(serviceType) ? container.GetInstance(serviceType) : DefaultCreateInstance(serviceType);
    }

    protected virtual bool ShouldResolveInstance(Type serviceType) {
      return serviceType.GetConstructors().Any(c => c.IsPublic && c.GetParameters().Any());
    }

    protected virtual object DefaultCreateInstance(Type serviceType) {
      const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.CreateInstance;
      return Activator.CreateInstance(serviceType, flags, null, null, null);
    }
  }
}
