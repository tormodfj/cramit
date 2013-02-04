using Caliburn.Micro;
using Cramit.Common;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace Cramit.Data
{
    public class LocalQuizCollection : BindableBase
    {
        private BindableCollection<Quiz> items = new BindableCollection<Quiz>();

        public LocalQuizCollection()
        {
            PopulateItems();
        }

        public BindableCollection<Quiz> Items
        {
            get { return items; }
        }

        private async void PopulateItems()
        {
            var quizFolder = await ApplicationData.Current.LocalFolder
                .CreateFolderAsync("Indexed", CreationCollisionOption.OpenIfExists);

            var files = await quizFolder.GetFilesAsync();

            Items.Clear();
            foreach (var file in files)
            {
                var quiz = await ReadQuiz(file);
                Items.Add(quiz);
            }
        }

        private async Task<Quiz> ReadQuiz(StorageFile file)
        {
            var content = await FileIO.ReadTextAsync(file);
            // TODO: parse file contents
            return new Quiz();
        }
    }
}
