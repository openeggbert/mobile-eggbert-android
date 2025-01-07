// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Resource
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

//[DebuggerNonUserCode]
//[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
//[CompilerGenerated]

namespace WindowsPhoneSpeedyBlupi
{
    internal class Resource
    {
        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                {
                    ResourceManager resourceManager = new ResourceManager("WindowsPhoneSpeedyBlupi.Resource", typeof(Resource).Assembly);
                    resourceMan = resourceManager;
                }
                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string Title
        {
            get
            {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }

        internal Resource()
        {
        }
    }

}