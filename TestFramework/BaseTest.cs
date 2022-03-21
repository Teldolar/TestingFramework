using NUnit.Framework;
using TestFramework.Utils;

namespace TestFramework
{
    public abstract class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            DriverUtil.MaxWindow();
        }

        [TearDown]
        public void TearDown()
        {
            DriverUtil.QuitDriver();
        }
    }
}