using Cramit.Common;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;

namespace Cramit.Data
{
    public class LocalQuizCollection : BindableBase
    {
        private ObservableCollection<Quiz> items = new ObservableCollection<Quiz>();

        public LocalQuizCollection()
        {
            PopulateItems();
        }

        public ObservableCollection<Quiz> Items
        {
            get { return items; }
        }

        private async void PopulateItems()
        {
            var folder = await KnownFolders.DocumentsLibrary.GetFolderAsync(@"Cramit");
            var files = await folder.GetFilesAsync();
            
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
