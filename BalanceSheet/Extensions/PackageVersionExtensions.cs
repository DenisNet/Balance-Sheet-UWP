
using Windows.ApplicationModel;

namespace BalanceSheet.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="PackageVersion" /> class.
    /// </summary>
    public static class PackageVersionExtensions
    {
        /// <summary>
        /// Converts the version to a string in the following format: Major.Minor.Build.Revision.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>The formatted string.</returns>
        public static string ToFormattedString(this PackageVersion version)
        {
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}