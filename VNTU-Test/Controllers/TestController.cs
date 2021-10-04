using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            SessionInit();
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
        public IActionResult Index(int[] answer)
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
            //TODO: if current question == questions count = new View();
        }

        public IActionResult Results()
        {
            Test sessionTest = JsonConvert.DeserializeObject<Test>(_session.GetString(CURRENT_TEST));
            return View(sessionTest);
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
