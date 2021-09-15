using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNTU_Test.Entities
{
    public class TestResult
    {
        public int Id { get; set; }
        public List<QuestionResult> QuestionResults { get; set; }

        public TestResult()
        {
            QuestionResults = new List<QuestionResult>();
        }
    }
}
