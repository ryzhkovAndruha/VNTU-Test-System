using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNTU_Test.Entities;
using VNTU_Test.Repositories;

namespace VNTU_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        TestRepository testRepository;
        public TestApiController()
        {
            TestData.CreateTestData();
            testRepository = new TestRepository();
        }

        [HttpGet]
        public ActionResult<List<Test>> Get()
        {
            return testRepository.GetList();
        }

        [HttpGet("{id}")]
        public ActionResult<Test> Get(int id)
        {
            Test test = testRepository.GetById(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        [HttpPut]
        public ActionResult<Test> Put(Test test)
        {
            if (test == null)
            {
                return BadRequest();
            }
            if (!testRepository.GetList().Any(t => t.Id == test.Id))
            {
                NotFound();
            }

            Test testFromDb = testRepository.GetList().FirstOrDefault(t => t.Id == test.Id);

            testFromDb.Name = test.Name;
            testFromDb.Questions = test.Questions;

            return Ok(testFromDb);
        }

        [HttpPost]
        public ActionResult<Test> Post(Test test)
        {
            if (test == null)
            {
                return BadRequest();
            }

            testRepository.Update(test);
            return Ok(test);
        }

        [HttpDelete("{id}")]
        public ActionResult<Test> Delete(int id)
        {
            Test test = testRepository.GetList().FirstOrDefault(t => t.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            testRepository.Delete(id);
            return Ok(test);
        }

        public ActionResult<int> FinishTest(TestResult testResult)
        {
            if(testResult == null)
            {
                return BadRequest();
            }

            Test test = testRepository.GetList().FirstOrDefault(t => t.Id == testResult.Id);
            int countOfRightAnswers = 0;

            foreach (var result in testResult.QuestionResults)
            {
                var rightAnswers = test.Questions[result.QuestionId].Answers.Where(a => a.IsCorrect==true).Select(a => a.Id).ToArray();
                var answers = result.AnswersId.ToArray();

                if (Enumerable.SequenceEqual(answers, rightAnswers))
                {
                    countOfRightAnswers++;
                }
            }

            return Ok(countOfRightAnswers);
        }
    }
}
