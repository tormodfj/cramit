using Cramit.Common;
using Cramit.Data;
using System;
using Windows.UI.Xaml.Controls;

namespace Cramit
{
    /// <summary>
    /// The main page of the application, handling navigation to the other pages.
    /// </summary>
    public sealed partial class MainPage : LayoutAwarePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Invoked when an item in the main menu is clicked.
        /// </summary>
        /// <param name="sender">The ListView displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        private void HandleItemClick(object sender, ItemClickEventArgs e)
        {
            string destination = ((MainPageButtonModel)e.ClickedItem).NavigateTo;
            if (destination != null)
            {
                Frame.Navigate(Type.GetType(destination));
            }
        }
    }
}
