using BalanceSheet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace BalanceSheet.ViewModels
{
    class InfoViewModel
    {
        private string _appVersion;
        private string _assemblyVersion;

        /// <summary>
        /// The constructor.
        /// </summary>
        public InfoViewModel()
        {
            // Read package version
            AppVersion = Package.Current.Id.Version.ToFormattedString();

            // Read assembly version
            var assembly = GetType().GetTypeInfo().Assembly;
            var versionAttribute =
                assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            AssemblyVersion = versionAttribute?.Version;
        }

        /// <summary>
        /// Gets or sets the app package version.
        /// </summary>
        public string AppVersion
        {
            get { return _appVersion; }
            set
            {
                if (value != _appVersion)
                {
                    _appVersion = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the assembly version
        /// </summary>
        public string AssemblyVersion
        {
            get { return _assemblyVersion; }
            set
            {
                if (value != _assemblyVersion)
                {
                    _assemblyVersion = value;
                }
            }
        }
    }
}
