using System.Collections.Generic;

namespace Cramit.Data
{
    public class Quiz
    {
        public Quiz()
        {
            Entities = new List<QuizEntity>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<QuizEntity> Entities { get; private set; }
    }
}
