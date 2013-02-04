using Caliburn.Micro;
using Cramit.Data;
using Cramit.Views;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Cramit.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            RootMenuItems = new BindableCollection<MainPageButtonModel>
            {
                new MainPageButtonModel 
                {
                    Text = "Quiz Definitions",
                    Image = new BitmapImage(new Uri(@"ms-appx:///Assets/DefineQuizData.jpg")),
                    NavigateTo = typeof(QuizDefinitionsView)
                },
                new MainPageButtonModel 
                {
                    Text = "Take Quiz",
                    Image = new BitmapImage(new Uri(@"ms-appx:///Assets/TakeQuiz.jpg")),
                    NavigateTo = null // TODO
                },
            };
        }

        public BindableCollection<MainPageButtonModel> RootMenuItems { get; private set; }

        public void MenuItemClicked(ItemClickEventArgs e)
        {
            var itemClicked = (MainPageButtonModel)e.ClickedItem;
            NavigationService.Navigate(itemClicked.NavigateTo);
        }
    }
}
