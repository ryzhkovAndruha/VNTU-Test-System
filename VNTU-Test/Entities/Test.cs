using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNTU_Test.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public int CurrentQuestion { get; set; }
        public int CountOfCorrectAnswers { get; set; }
        public int Result { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
