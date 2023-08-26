using System;
using UniRx;

namespace GameLogic.Components.Hit
{
    [Serializable]
    public struct ReactiveIsHit
    {
        public ReactiveProperty<bool> value;
    }
}