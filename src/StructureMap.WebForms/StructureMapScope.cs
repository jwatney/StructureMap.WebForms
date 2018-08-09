namespace StructureMap.WebForms {
  using System.Web;
  using StructureMap;

  public class StructureMapScope {
    private const string Key = "Nested.Container.Key";
    private static HttpContext HttpContext => HttpContext.Current;

    public static IContainer GetContainer() {
      var items = HttpContext?.Items;

      if(items != null && items[Key] is IContainer container) {
        return container;
      }

      return null;
    }

    public static void AddContainer() {
      var items = HttpContext?.Items;

      if(items == null || items[Key] is IContainer) {
        return;
      }

      items[Key] = StructureMapWebForms.Container.GetNestedContainer();
    }

    public static void RemoveContainer() {
      var items = HttpContext?.Items;

      if(items != null && items[Key] is IContainer container) {
        container.Dispose();
        items.Remove(Key);
      }
    }
  }
}
