using System;
using System.Reflection;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using BalanceSheet.Commands;
using BalanceSheet.Extensions;
using BalanceSheet.Models;
using BalanceSheet.Services;
using BalanceSheet.Views;

namespace BalanceSheet.ViewModels
{
    class CalendarViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;
        private readonly IPhotoService photoService;

        public CalendarViewModel(IPhotoService photo, IDialogService dialog)
        {
            photoService = photo;
            dialogService = dialog;
        }
    }
}