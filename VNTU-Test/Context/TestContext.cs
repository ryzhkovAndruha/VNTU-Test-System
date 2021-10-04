using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VNTU_Test.Entities;

namespace VNTU_Test.Context
{
    public class TestContext : DbContext
    {
        public TestContext(): base("TestDB")
        { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
