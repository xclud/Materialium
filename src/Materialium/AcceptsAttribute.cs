using System;

namespace Materialium
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AcceptsAttribute : Attribute
    {
        public Type[] Types { get; }

        public AcceptsAttribute(params Type[] types)
        {
            this.Types = types;
        }
    }
}