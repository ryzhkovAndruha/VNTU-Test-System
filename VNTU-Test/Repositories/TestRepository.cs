using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNTU_Test.Context;
using VNTU_Test.Entities;

namespace VNTU_Test.Repositories
{
    public class TestRepository
    {
        TestContext testContext;

        public TestRepository()
        {
            testContext = new TestContext();
            testContext.Database.CreateIfNotExists();
        }
       
        public List<Test> GetList() => testContext.Tests.ToList();
        public Test GetById(int id) => testContext.Tests.Find(id);
        public void Update(Test item)
        {
            var test = testContext.Tests.Find(item.Id);
            if(test == null)
            {
                return;
            }

            test.Name = item.Name;
            test.Questions = item.Questions;
            test.Result = item.Result;
            test.CountOfCorrectAnswers = item.CountOfCorrectAnswers;
            testContext.SaveChanges();
        }
        public void Create(Test item)
        {
            testContext.Tests.Add(item);
            testContext.SaveChanges();
        }
        public void Delete(int id)
        {
            testContext.Tests.Remove(testContext.Tests.Find(id));
            testContext.SaveChanges();
        }

        public void AddTestDataToDb()
        {
            TestData.CreateTestData();
            testContext.Tests.Add(TestData.Tests[0]);
            int s = testContext.SaveChanges();
        }
    }
}
