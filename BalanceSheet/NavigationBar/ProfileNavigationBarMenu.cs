using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using BalanceSheet.Models;
using BalanceSheet.Views;

namespace BalanceSheet.NavigationBar
{
    class ProfileNavigationBarMenu : BaseNavigationBarMenu, INavigationBarMenu
    {

        //public ProfileNavigationBarMenu()
        //{
        //    //AppEnvironment.Instance.CurrentUserChanged += CurrentUserChanged;
        //}
        public string Label
        {
            get
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                return loader.GetString("SingIn");
            }
        }

        void CurrentUserChanged(object sender, User e)
        {
            // Notify UI that user has changed.
            NotifyPropertyChanged(nameof(Image));
            NotifyPropertyChanged(nameof(Symbol));
            NotifyPropertyChanged(nameof(Label));
            NotifyPropertyChanged(nameof(SymbolAsChar));
        }

        public override Symbol Symbol
        {
            get { return Symbol.Contact; }
        }

        public Type TypePage
        {
            get { return typeof(SignInPage); /*return AppEnvironment.Instance.CurrentUser == null ? typeof(SignInPage) : typeof(ProfilePage); */}
        }

        public override NavigationBarPosition Position
        {
            get { return NavigationBarPosition.Bottom; }
        }

        //public override ImageSource Image
        //{
        //    get
        //    {
        //        if (AppEnvironment.Instance.CurrentUser?.ProfilePictureUrl == null)
        //        {
        //            return null;
        //        }

        //        return new BitmapImage(new Uri(AppEnvironment.Instance.CurrentUser.ProfilePictureUrl));
        //    }
        //}
    }
}