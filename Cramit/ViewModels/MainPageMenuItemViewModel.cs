using System;
using Windows.UI.Xaml.Media;

namespace Cramit.Data
{
    public class MainPageMenuItemViewModel
    {
        public ImageSource Image { get; set; }

        public string Text { get; set; }

        public Type NavigateTo { get; set; }
    }
}
