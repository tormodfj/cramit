using System.Collections.ObjectModel;

namespace Cramit.Data
{
    public class Quiz
    {
        public Quiz()
        {
            Items = new ObservableCollection<QuizEntity>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public ObservableCollection<QuizEntity> Items { get; private set; }
    }
}
