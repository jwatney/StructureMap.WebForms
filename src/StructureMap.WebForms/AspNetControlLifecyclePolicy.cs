namespace StructureMap.WebForms {
  using System;
  using Pipeline;

  public class AspNetControlLifecyclePolicy : IInstancePolicy {
    public void Apply(Type pluginType, Instance instance) {
      /*
       * The lifecycle for each control should always be unique. The default
       * namespace for pages and user controls compiled by the ASP.NET
       * runtime is 'ASP'.
       */

      if((instance.ReturnedType.Namespace ?? "").StartsWith("ASP")) {
        instance.SetLifecycleTo(new UniquePerRequestLifecycle());
      }
    }
  }
}
