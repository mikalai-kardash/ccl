using System;
using ccl.Framework.Commands;

namespace ccl
{
    public interface ICommandLine
    {
        void Register<T>(string[] path) where T : ICommand;
        void Register(Type type, params string[] path);
        void Run(string[] args);
    }
}