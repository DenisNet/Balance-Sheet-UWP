using Windows.System.Profile;
using Windows.UI.Xaml;

namespace BalanceSheet.StateTriggers
{
    /// <summary>
    /// Custom trigger for DeviceFamily UI states.
    /// </summary>
    public class DeviceFamilyTrigger : StateTriggerBase
    {
        private string currentDeviceFamily;
        private string queriedDeviceFamily;

        /// <summary>
        /// The target device family.
        /// </summary>
        public string DeviceFamily
        {
            get { return queriedDeviceFamily; }
            set
            {
                queriedDeviceFamily = value;

                // Get the current device family.
                currentDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;

                // The trigger will be activated if the current device family
                // matches the device family value in XAML.
                SetActive(queriedDeviceFamily == currentDeviceFamily);
            }
        }
    }
}