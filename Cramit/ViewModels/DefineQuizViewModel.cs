using System;
using System.Linq;
using Caliburn.Micro;
using Cramit.Data;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace Cramit.ViewModels
{
    /// <summary>
    /// View model for defining a new quiz.
    /// </summary>
    public class DefineQuizViewModel : ViewModelBase
    {
        private readonly EditQuizViewModel quizViewModel;

        private StorageFile quizFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefineQuizViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public DefineQuizViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            quizViewModel = new EditQuizViewModel();
        }

        /// <summary>
        /// Gets the quiz.
        /// </summary>
        public EditQuizViewModel Quiz
        {
            get { return quizViewModel; }
        }

        /// <summary>
        /// Navigates back.
        /// </summary>
        public override void GoBack()
        {
            if (quizViewModel.IsDirty)
            {
                GuardGoBack();
            }
            else
            {
                base.GoBack();
            }
        }

        /// <summary>
        /// Saves the quiz.
        /// </summary>
        public async void Save()
        {
            string serialized = quizViewModel.Quiz.Serialize();
            await quizFile.WriteAllTextAsync(serialized);
        }

        /// <summary>
        /// Called when initializing.
        /// </summary>
        protected override void OnInitialize()
        {
            PickQuizSaveFile();

            base.OnInitialize();
        }

        /// <summary>
        /// Asks the user of she really wants to go back when there are unsaved changes.
        /// </summary>
        private async void GuardGoBack()
        {
            var messageDialog = new MessageDialog(
                title: "Save Quiz?",
                content: "There are unsaved changes to your quiz. Do you wish to save?");

            messageDialog.Commands.Add(new UICommand("Save", _ => { Save(); base.GoBack(); }));
            messageDialog.Commands.Add(new UICommand("Don't Save", _ => base.GoBack()));
            messageDialog.Commands.Add(new UICommand("Cancel"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 2;

            await messageDialog.ShowAsync();
        }

        /// <summary>
        /// Picks the file to save the quiz to.
        /// </summary>
        private async void PickQuizSaveFile()
        {
            var fileSavePicker = new FileSavePicker
            {
                CommitButtonText = "Create Quiz",
                SuggestedFileName = "New Quiz",
                DefaultFileExtension = ".cramit",
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            fileSavePicker.FileTypeChoices.Add("Cramit Quiz", new[] { ".cramit" }.ToList());
            quizFile = await fileSavePicker.PickSaveFileAsync();
            if (quizFile == null)
            {
                GoBack();
            }
            else
            {
                quizViewModel.Title = quizFile.DisplayName;
            }
        }
    }
}
