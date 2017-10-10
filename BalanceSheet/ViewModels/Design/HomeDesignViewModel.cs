using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using BalanceSheet.Models;
using BalanceSheet.Services;

namespace BalanceSheet.ViewModels.Design
{
    class HomeDesignViewModel
    {
        public HomeDesignViewModel()
        {
            var photoDummyService = new PhotoDummyService();
            //HeroImages = new ObservableCollection<Photo>(photoDummyService.PhotoStreams.First().Photos.Take(5));
            //SelectedHeroImage = HeroImages.FirstOrDefault();
            //TopCategories = new List<CategoryPreview>(photoDummyService.TopCategories);

        }

        //public ObservableCollection<Photo> HeroImages { get; set; }

        //public Photo SelectedHeroImage { get; set; }

        //public IList<CategoryPreview> TopCategories { get; set; }

    }

}