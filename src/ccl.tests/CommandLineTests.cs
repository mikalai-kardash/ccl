using NUnit.Framework;
using ccl.Framework.Exceptions;
using ccl.tests.Commands;

namespace ccl.tests
{
    [TestFixture]
    public class CommandLineTests
    {
        [Test]
        public void Run_registered_command()
        {
            CommandLine.Run("install", "db");
            Assert.That(InstallDatabase.IsExecuted, Is.True);
        }

        [Test]
        public void Handle_commands_that_throw_exceptions()
        {
            Assert.Throws<CommandNotRunException>(() => CommandLine.Run("throw", "exception"));
        }

        [Test]
        public void Handle_unregistered_commands()
        {
            Assert.Throws<CommandNotFoundException>(() => CommandLine.Run("unregistered", "command"));
        }

        [Test]
        public void Handle_commands_that_cannot_be_created()
        {
            Assert.Throws<CommandNotCreatedException>(() => CommandLine.Run("cannot", "create"));
        }

        [Test]
        public void Run_command_and_set_parameters()
        {
            CommandLine.Run("with", "params", "param1=value1", "-param2=33", "/param3");

            Assert.That(CommandWithParameters.Param1Value, Is.EqualTo("value1"));
            Assert.That(CommandWithParameters.Param2Value, Is.EqualTo(33));
            Assert.That(CommandWithParameters.Param3Value, Is.True);
        }
    }
}