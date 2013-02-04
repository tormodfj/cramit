using Caliburn.Micro;
using Cramit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Cramit.ViewModels
{
    public class QuizDefinitionsViewModel : ViewModelBase
    {
        private LocalQuizCollection quizCollection = new LocalQuizCollection();

        public QuizDefinitionsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        public BindableCollection<Quiz> Quizzes
        {
            get { return quizCollection.Items; }
        }

        private Quiz selectedQuiz;
        public Quiz SelectedQuiz
        {
            get { return selectedQuiz; }
            set 
            {
                selectedQuiz = value;
                NotifyOfPropertyChange(() => SelectedQuiz);
                DetailsViewVisibility = value == null ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private Visibility detailsViewVisibility;
        public Visibility DetailsViewVisibility
        {
            get { return detailsViewVisibility; }
            set 
            {
                detailsViewVisibility = value;
                NotifyOfPropertyChange(() => DetailsViewVisibility);
            }
        }

        private void HandleAddQuizClick(object sender, RoutedEventArgs e)
        {
            var newQuiz = CreateNewQuiz();
            quizCollection.Items.Add(newQuiz);
            SelectedQuiz = newQuiz;
        }

        private Quiz CreateNewQuiz()
        {
            return new Quiz { Title = @"(no name)", Description = @"(empty description)" };
        }
    }
}
