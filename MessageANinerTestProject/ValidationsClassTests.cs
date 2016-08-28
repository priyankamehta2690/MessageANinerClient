using MessageANiner.Entities;
using NUnit.Framework;
using System;

namespace MessageANinerTestProject
{
    /// <summary>
    /// Summary description for ValidationsClassTests
    /// </summary>
    [TestFixture]
    public class ValidationsClassTests
    {

        [TestCase("Shrujan", null)]
        [TestCase("", "User name is Mandatory")]
        public void ShouldValidateUserName(string input, string expectedValue)
        {
            var result = Validations.isUserNameValid(input);
            Assert.That(result, Is.EqualTo(expectedValue));
        }


        [TestCase("", "New Password required!")]
        [TestCase("##", "Password invalid!")]
        [TestCase("AAaa123", null)]
        public void ShouldValidatePassword(string input, string expectedValue)
        {
            var result = Validations.isPasswordValid(input);
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase("", "e-mail address is required.")]
        [TestCase("##", "e-mail address must be valid e-mail address format.\n" +
                                    "For example 'someone@uncc.edu' ")]
        [TestCase("skotturi@uncc.edu", null)]
        public void ShouldValidateEmailID(string input, string expectedValue)
        {
            var result = Validations.isEmailIDValid(input);
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        #region 'Setup and TearDown Test Level'

        [SetUp]
        public void BeforeEachTest()
        {
            Console.WriteLine(" Before : {0}", TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterEachTest()
        {
            Console.WriteLine(" After : {0}", TestContext.CurrentContext.Test.Name);
        }

        [OneTimeSetUp]
        public void BeforeEachTestFixture()
        {
            Console.WriteLine(" Before : {0}", TestContext.CurrentContext.Test.Name);
        }

        [OneTimeTearDown]
        public void AfterEachTestFixture()
        {
            Console.WriteLine(" After : {0}", TestContext.CurrentContext.Test.Name);
        }

        #endregion
    }
}
