# StructureMap integration for ASP.NET WebForms


This repository contains the source of one NuGet package:

 - StructureMap.WebForms

These packages provide integration with ASP.NET WebForms in .NET Framework 4.7.2.

## StructureMap.Webforms

Adds StructureMap support for ASP.NET WebForms.

### Installation

Add `StructureMap.WebForms` to your project:

```json
<ItemGroup>
  <PackageReference Include="StructureMap.WebForms" Version"<version>" />
</ItemGroup>
```

### Usage

The package contains a single, public extension method, `Populate`.

#### Example

```csharp
using System;
using System.Web;
using StructureMap;
using StructureMap.WebForms;

namespace WebApplication3 {
  public class Global : HttpApplication {
    void Application_Start(object sender, EventArgs e) {
      var container = new Container(config => {
        // Do lots of configuration...
      });

      StructureMapWebForms.RegisterServices(container);
    }
  }
}
```
