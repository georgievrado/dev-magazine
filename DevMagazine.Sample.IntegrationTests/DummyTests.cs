using MbUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMagazine.Sample.IntegrationTests
{
    [TestFixture]
    [Description("Dummy integration tests"]
    public class DummyTests
    {
        [Test]
        [Category("Dummy Tests")]
        [Author("Radoslav Georgiev")]
        [Description("A simple test that will pass.")]
        public void PassingTest()
        {
            int expectedValue = 2;

            int actualValue = 1 + 1;

            Assert.AreEqual<int>(expectedValue, actualValue);
        }

        [Test]
        [Category("Dummy Tests")]
        [Author("Radoslav Georgiev")]
        [Description("A simple test that will fail.")]
        public void FailingTest()
        {
            int expectedValue = 2;

            int actualValue = 1 + 1 + 1;

            Assert.AreEqual<int>(expectedValue, actualValue);
        }

        [Test]
        [Category("Dummy Tests")]
        [Author("Radoslav Georgiev")]
        [Description("A simple test that will be ignored. You can run it manually in the Test runner.")]
        public void IgnoredTest()
        {
            int expectedValue = 2;

            int actualValue = 1 + 1;

            Assert.AreEqual<int>(expectedValue, actualValue);
        }
    }
}
