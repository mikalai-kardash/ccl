using System;
using System.Runtime.CompilerServices;

namespace ccl.Framework.Logging
{
    public class NullLogger : ILogger
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Info(string message)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Info(string messageFormat, params object[] args)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Info(Exception exception)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(string message)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(string messageFormat, params object[] args)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Warning(Exception exception)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(string message)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(string messageFormat, params object[] args)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Error(Exception exception)
        {
        }
    }
}