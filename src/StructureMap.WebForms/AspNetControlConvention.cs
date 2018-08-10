namespace StructureMap.WebForms {
  using System.Linq;
  using System.Reflection;
  using System.Web.UI;
  using Graph;
  using Graph.Scanning;
  using Pipeline;

  public class AspNetControlConvention : IRegistrationConvention {
    public void ScanTypes(TypeSet types, Registry registry) {
      var baseType = typeof(Control);

      /*
       * The strategy here is to look for all types which inherit from Control,
       * are not abstract, and have at least one constructor parameter. When
       * that's the case then we register the type for itself and ensure we
       * get a new instance everytime.
       */

      foreach(var type in types.AllTypes()) {
        if(baseType.IsAssignableFrom(type) && !type.IsAbstract) {
          var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

          foreach(var ctor in ctors) {
            if(ctor.GetParameters().Any()) {
              registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
          }
        }
      }
    }
  }
}
