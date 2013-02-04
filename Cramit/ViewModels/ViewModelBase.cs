using Caliburn.Micro;

namespace Cramit.ViewModels
{
    public class ViewModelBase : Screen
    {
        protected INavigationService NavigationService;

        protected ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        public void GoBack()
        {
            NavigationService.GoBack();
        }

        public bool CanGoBack
        {
            get { return NavigationService.CanGoBack; }
        }
    }
}
