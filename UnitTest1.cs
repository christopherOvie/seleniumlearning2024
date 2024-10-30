using NUnit.Framework;

namespace SeleniumLearning2024
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("set up method"); 
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("this is test 1");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("this is test 2");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("tear down method");
        }
    }
}