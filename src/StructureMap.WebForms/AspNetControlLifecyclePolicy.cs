namespace StructureMap.WebForms {
  using System;
  using System.Web.UI;
  using Pipeline;

  public class AspNetControlLifecyclePolicy : IInstancePolicy {
    public void Apply(Type pluginType, Instance instance) {
      /*
       * The lifecycle for each control should always be unique else
       * StructureMap will reuse the same instance for every control of same
       * type declared.
       */

      if(typeof(Control).IsAssignableFrom(instance.ReturnedType)) {
        instance.SetLifecycleTo(new UniquePerRequestLifecycle());
      }
    }
  }
}
