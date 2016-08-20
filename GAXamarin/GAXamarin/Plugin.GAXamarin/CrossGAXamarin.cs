using Plugin.GAXamarin.Abstractions;
using System;

namespace Plugin.GAXamarin
{
  /// <summary>
  /// Cross platform GAXamarin implemenations
  /// </summary>
  public class CrossGAXamarin
  {
    static Lazy<IGAXamarin> Implementation = new Lazy<IGAXamarin>(() => CreateGAXamarin(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IGAXamarin Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IGAXamarin CreateGAXamarin()
    {
#if PORTABLE
        return null;
#else
        return new GAXamarinImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
