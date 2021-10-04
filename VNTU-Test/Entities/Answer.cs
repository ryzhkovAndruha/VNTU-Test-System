using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNTU_Test.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
