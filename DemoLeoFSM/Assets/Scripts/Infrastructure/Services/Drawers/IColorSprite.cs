using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Drawers
{
    internal interface IColorSprite
    {
        public UniTask DrawSprite(SpriteRenderer sprite, float time, IControllableTimer controllableTimer,
            Action onCompleted, System.Threading.CancellationToken cancellationToken);
    }
}