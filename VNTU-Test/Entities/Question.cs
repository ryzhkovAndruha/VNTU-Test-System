using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNTU_Test.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
