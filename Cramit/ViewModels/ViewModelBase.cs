using Caliburn.Micro;

namespace Cramit.ViewModels
{
    /// <summary>
    /// Base class for all view model, providing a unified navigation mechanism.
    /// </summary>
    public class ViewModelBase : Screen
    {
        protected INavigationService NavigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        protected ViewModelBase(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        /// <summary>
        /// Navigates back.
        /// </summary>
        public virtual void GoBack()
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Gets a value indicating whether the navigator can navigate back.
        /// </summary>
        /// <value>
        /// <c>true</c> if the navigator can navigate back; otherwise, <c>false</c>.
        /// </value>
        public virtual bool CanGoBack
        {
            get { return NavigationService.CanGoBack; }
        }
    }
}
