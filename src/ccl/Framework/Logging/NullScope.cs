using System.Runtime.CompilerServices;

namespace ccl.Framework.Logging
{
    public class NullScope : LoggingScope
    {
        public NullScope(string name) : base(name)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void StartScope()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override void EndScope()
        {
        }
    }
}