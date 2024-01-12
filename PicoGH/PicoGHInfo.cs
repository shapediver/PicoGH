using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using Grasshopper.Kernel;

namespace PicoGH
{
    public class PicoGHInfo : GH_AssemblyInfo
    {
        public override Bitmap Icon
        {
            get
            {
                return Properties.Resources.sd_icon_24x24;
            }
        }

        public override Bitmap AssemblyIcon => Icon;

        public override string Name
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
            }
        }

        public override string AssemblyName => Name;

        public override string Description
        {
            get
            {
                var description = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
                var configuration = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyConfigurationAttribute>().Configuration;
                if (configuration.ToLowerInvariant().Contains("debug"))
                {
                    description = $"{description} ({configuration})";
                }
                return description;
            }
        }

        public override string AssemblyDescription => Description;

        public override Guid Id
        {
            get
            {
                return new Guid(Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value);
            }
        }

        public override string AuthorName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            }
        }

        public override string AuthorContact
        {
            get
            {
                return "contact@shapediver.com";
            }
        }

        public override string Version
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
                return version.ToString();
            }
        }

        public override string AssemblyVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
                return version.ToString();
            }
        }
    }
}
