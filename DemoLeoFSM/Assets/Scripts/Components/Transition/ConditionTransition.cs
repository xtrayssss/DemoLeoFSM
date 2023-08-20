using System;

namespace Components.Transition
{
    internal struct ConditionTransition
    {
        public Func<bool> Value;
    }
}