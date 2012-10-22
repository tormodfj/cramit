using Cramit.Common;

namespace Cramit.Data
{
    public class QuizEntity : BindableBase
    {
        private string question = string.Empty;
        private string answer = string.Empty;

        public string Question
        {
            get { return question; }
            set { SetProperty(ref question, value); }
        }

        public string Answer
        {
            get { return answer; }
            set { SetProperty(ref answer, value); }
        }
    }
}
