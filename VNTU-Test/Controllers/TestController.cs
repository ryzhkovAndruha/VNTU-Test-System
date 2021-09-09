using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using VNTU_Test.Entities;

namespace VNTU_Test.Controllers
{
    public class TestController : Controller
    {
        const string CURRENT_TEST = "CurrentTest";


        ISession _session;
        public TestController(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            //SessionInit();
        }

        public IActionResult Index()
        {
            Test sessionTest = JsonConvert.DeserializeObject<Test>(_session.GetString(CURRENT_TEST));
            Question question = sessionTest.Questions[sessionTest.CurrentQuestion];

            foreach (var answer in question.Answers)
            {
                answer.IsCorrect = false;
            }
            
            return View(question);
        }

        [HttpPost]
        public IActionResult Index(string[] answer)
        {
            Test sessionTest = JsonConvert.DeserializeObject<Test>(_session.GetString(CURRENT_TEST));
            Question sessionQuestion = sessionTest.Questions[sessionTest.CurrentQuestion];
            sessionTest.CurrentQuestion++;

            var rightAnswers = sessionQuestion.Answers.Where(a => a.IsCorrect).Select(a => a.Id).ToArray();

            if(Enumerable.SequenceEqual(answer, rightAnswers))
            {
                sessionTest.CountOfCorrectAnswers++;
            }

            _session.SetString(CURRENT_TEST, JsonConvert.SerializeObject(sessionTest));

            if (sessionTest.CurrentQuestion < sessionTest.Questions.Count)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Results");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Test test = new Test()
            {
                Questions = new List<Question>()
            };
            return View(test);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Test> tests = TestData.Tests;

            return View(tests);
        }

        [HttpPost]
        public IActionResult Create(Test model)
        {
            TestData.Tests.Add(JsonConvert.DeserializeObject<Test>(_session.GetString(CURRENT_TEST)));

            return RedirectToAction("Get");
        }

        public IActionResult Results()
        {
            Test sessionTest = JsonConvert.DeserializeObject<Test>(_session.GetString(CURRENT_TEST));
            return View(sessionTest);
        }

        public IActionResult AddAnswers(Test test)
        {
            for(int i =0; i < test.Questions[test.NumberOfQuestions].NumberOfAnswers; i++)
            {
                test.Questions[test.NumberOfQuestions].Answers.Add(new Answer());
            }
            
            return View("Create",test);
        }

        public IActionResult CreateQuestions(Test test)
        {
            test.Questions.Add(new Question());

            return View("Create",test);
        }

        public IActionResult AddQuestion(Test test)
        {
            if(_session.GetString(CURRENT_TEST) == null)
            {
                _session.SetString(CURRENT_TEST, JsonConvert.SerializeObject(test));
            }
            else
            {
                Test newTest = JsonConvert.DeserializeObject<Test>(_session.GetString(CURRENT_TEST));
                newTest.Questions.Add(test.Questions[0]);
                _session.SetString(CURRENT_TEST, JsonConvert.SerializeObject(newTest));
            }
            test.NumberOfQuestions++;
            return View("Create", test);
        }

        private void SessionInit()
        {
            if (!_session.Keys.Contains(CURRENT_TEST))
            {
                _session.SetString(CURRENT_TEST, JsonConvert.SerializeObject(TestData.Tests[0]));
            }
            
        }

    }
}
