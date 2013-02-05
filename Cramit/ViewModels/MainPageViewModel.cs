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
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            MainMenuItems = new BindableCollection<MainPageMenuItemViewModel>
            {
                new MainPageMenuItemViewModel 
                {
                    Text = "Define New Quiz",
                    Image = new BitmapImage(new Uri(@"ms-appx:///Assets/DefineQuiz.jpg")),
                    NavigateTo = typeof(DefineQuizView)
                },
                new MainPageMenuItemViewModel 
                {
                    Text = "Edit Existing Quiz",
                    Image = new BitmapImage(new Uri(@"ms-appx:///Assets/EditQuiz.jpg")),
                    NavigateTo = null // TODO
                },
                new MainPageMenuItemViewModel 
                {
                    Text = "Take Quiz",
                    Image = new BitmapImage(new Uri(@"ms-appx:///Assets/TakeQuiz.jpg")),
                    NavigateTo = null // TODO
                },
            };
        }

        /// <summary>
        /// Gets the main menu items.
        /// </summary>
        /// <value>
        /// The main menu items.
        /// </value>
        public BindableCollection<MainPageMenuItemViewModel> MainMenuItems { get; private set; }

        /// <summary>
        /// Handles the event of the user clicking a menu item.
        /// </summary>
        /// <param name="e">The <see cref="ItemClickEventArgs" /> instance containing the event data.</param>
        public void HandleMenuItemClicked(ItemClickEventArgs e)
        {
            var itemClicked = (MainPageMenuItemViewModel)e.ClickedItem;
            if (itemClicked.NavigateTo != null)
            {
                NavigationService.Navigate(itemClicked.NavigateTo);
            }
        }
    }
}
