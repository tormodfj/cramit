using Caliburn.Micro;
using Cramit.Data;

namespace Cramit.ViewModels
{
    /// <summary>
    /// View model for editing a <see cref="Quiz"/>.
    /// </summary>
    public class EditQuizViewModel : PropertyChangedBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditQuizViewModel" /> class.
        /// </summary>
        public EditQuizViewModel()
            : this(new Quiz())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditQuizViewModel" /> class.
        /// </summary>
        /// <param name="quiz">The quiz to wrap.</param>
        public EditQuizViewModel(Quiz quiz)
        {
            Quiz = quiz;
        }

        /// <summary>
        /// Gets the quiz.
        /// </summary>
        public Quiz Quiz { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is dirty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dirty; otherwise, <c>false</c>.
        /// </value>
        public bool IsDirty { get; private set; }

        /// <summary>
        /// Gets or sets the quiz title.
        /// </summary>
        public string Title
        {
            get
            {
                return Quiz.Title;
            }
            set
            {
                Quiz.Title = value;
                IsDirty = true;
                NotifyOfPropertyChange(() => Title);
            }
        }

        /// <summary>
        /// Gets or sets the quiz description.
        /// </summary>
        public string Description
        {
            get
            {
                return Quiz.Description;
            }
            set
            {
                Quiz.Description = value;
                IsDirty = true;
                NotifyOfPropertyChange(() => Description);
            }
        }
    }
}
