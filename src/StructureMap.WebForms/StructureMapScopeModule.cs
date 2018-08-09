namespace StructureMap.WebForms {
  using System.Web;

  public class StructureMapScopeModule : IHttpModule {
    public void Init(HttpApplication context) {
      context.BeginRequest += (s, e) => StructureMapScope.AddContainer();
      context.EndRequest += (s, e) => StructureMapScope.RemoveContainer();
    }

    public void Dispose() {
    }
  }
}
