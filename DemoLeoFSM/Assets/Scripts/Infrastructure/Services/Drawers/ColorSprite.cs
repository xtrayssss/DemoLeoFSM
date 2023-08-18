using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Drawers
{
    internal class ColorSprite : IColorSprite
    {
        public async UniTask DrawSprite(SpriteRenderer sprite, float time, IControllableTimer controllableTimer,
            Action onCompleted, System.Threading.CancellationToken cancellationToken)
        {
            controllableTimer.SetTime(time);

            while (sprite.color != Color.red)
            {
                Debug.Log("thread");
                await UniTask.DelayFrame(1, PlayerLoopTiming.Update, cancellationToken);
                
                controllableTimer.Tick();
               
                sprite.color = Color.Lerp(Color.white, Color.red, controllableTimer.CurrentTime / time);
            }

            onCompleted?.Invoke();

            sprite.color = Color.white;
        }
    }
}