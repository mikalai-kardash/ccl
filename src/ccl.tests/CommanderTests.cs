using NUnit.Framework;
using ccl.tests.Commanders;

namespace ccl.tests
{
    [TestFixture]
    public class CommanderTests
    {
        [Test]
        public void Commander_should_be_able_to_invoke_commands()
        {
            CommandLine.Run("iis", "start");
            Assert.That(IisTestCommander.IsStarted, Is.True);
        }

        [Test]
        public void Commander_supports_aliases_for_arguments()
        {
            CommandLine.Run("iis", "restart", "-harsh");
            Assert.That(IisTestCommander.IsRestarted, Is.True);
        }
    }
}