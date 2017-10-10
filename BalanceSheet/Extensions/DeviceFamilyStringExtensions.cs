using BalanceSheet.Models;

namespace BalanceSheet.Extensions
{
    public static class DeviceFamilyStringExtensions
    {
        public static DeviceFamily ToDeviceFamily(this string value)
        {
            switch (value)
            {
                case "Windows.Desktop":
                    return DeviceFamily.Desktop;
                case "Windows.Mobile":
                    return DeviceFamily.Mobile;
                default:
                    return DeviceFamily.Other;
            }
        }
    }
}