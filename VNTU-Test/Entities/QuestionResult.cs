using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNTU_Test.Entities
{
    public class QuestionResult
    {
        public int QuestionId { get; set; }
        public List<int> AnswersId { get; set; }

        public QuestionResult()
        {
            AnswersId = new List<int>();
        }
    }
}
