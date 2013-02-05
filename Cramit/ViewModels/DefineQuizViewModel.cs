using Caliburn.Micro;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cramit.Data;
using Windows.UI.Popups;
using System.Threading;

namespace Cramit.ViewModels
{
    public class DefineQuizViewModel : ViewModelBase
    {
        private readonly Quiz quiz;

        private StorageFile quizFile;
        private bool isDirty;

        public DefineQuizViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            quiz = new Quiz();
        }

        public string Title
        {
            get
            {
                return quiz.Title;
            }
            set
            {
                quiz.Title = value;
                isDirty = true;
                NotifyOfPropertyChange(() => Title);
            }
        }

        protected override void OnInitialize()
        {
            PickQuizSaveFile();
            base.OnInitialize();
        }

        public override async void GoBack()
        {
            if (isDirty)
            {
                var messageDialog = new MessageDialog("There are unsaved changes to your quiz. Do you wish to save?", "Save Quiz?");
                messageDialog.Commands.Add(new UICommand("Save", _ => { Save(); base.GoBack(); }));
                messageDialog.Commands.Add(new UICommand("Don't Save", _ => base.GoBack()));
                messageDialog.Commands.Add(new UICommand("Cancel"));
                messageDialog.DefaultCommandIndex = 0;
                messageDialog.CancelCommandIndex = 2;
                await messageDialog.ShowAsync();
            }
        }

        private void Save()
        {
            // TODO
        }

        private async Task PickQuizSaveFile()
        {
            var fileSavePicker = new FileSavePicker
            {
                CommitButtonText = "Create Quiz",
                SuggestedFileName = "New Quiz",
                DefaultFileExtension = ".cramit",
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            fileSavePicker.FileTypeChoices.Add("Cramit Quiz File", new[] { ".cramit" }.ToList());
            quizFile = await fileSavePicker.PickSaveFileAsync();
            if (quizFile == null)
            {
                GoBack();
            }
            else
            {
                Title = quizFile.DisplayName;
            }
        }
    }
}
