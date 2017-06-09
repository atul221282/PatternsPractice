using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository
{
    public class TestRepository : ITestRepository
    {
        public string GetTestRepo()
        {
            return "TEST REPO FROM TEST REPOSITORY";
        }
    }
    public interface ITestRepository
    {
        string GetTestRepo();
    }
}
