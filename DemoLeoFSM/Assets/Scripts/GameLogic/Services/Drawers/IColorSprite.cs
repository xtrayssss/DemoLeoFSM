using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.Timer;
using UnityEngine;

namespace GameLogic.Services.Drawers
{
    internal interface IColorSprite
    {
        public UniTask DrawSprite(SpriteRenderer sprite, float time, IControllableTimer controllableTimer,
            Action onCompleted, System.Threading.CancellationToken cancellationToken);
    }
}