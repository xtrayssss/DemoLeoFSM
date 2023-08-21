using System;

namespace GameLogic.Components.Transition
{
    internal struct ConditionTransition
    {
        public Func<bool> Value;
    }
}