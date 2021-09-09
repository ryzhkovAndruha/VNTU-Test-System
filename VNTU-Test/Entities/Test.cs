using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNTU_Test.Entities
{
    public class Test
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public int CurrentQuestion { get; set; }
        public int CountOfCorrectAnswers { get; set; }
        public int NumberOfQuestions { get; set; }
        //public int Result { get; set; }

        public Test()
        {
            NumberOfQuestions = 0;
            //Questions = new List<Question>();
        }
    }
}
