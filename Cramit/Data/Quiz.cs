using Cramit.Common;
using System.Collections.ObjectModel;

namespace Cramit.Data
{
    public class Quiz : BindableBase
    {
        private string title = string.Empty;
        private string description = string.Empty;
        private ObservableCollection<QuizEntity> items = new ObservableCollection<QuizEntity>();

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public ObservableCollection<QuizEntity> Items
        {
            get { return items; }
        }
    }
}
