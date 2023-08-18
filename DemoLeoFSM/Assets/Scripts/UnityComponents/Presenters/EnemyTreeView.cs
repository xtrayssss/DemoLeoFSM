using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.CancellationToken;
using Infrastructure.Services.Drawers;
using MVP.Base.View;
using UnityEngine;
using Zenject;

namespace UnityComponents.Presenters
{
    public class EnemyTreeView : AbstractAnimationViewWithMonobehPresenter<EnemyTreePresenter>, IHitRenderer
    {
        public bool IsPaintedDamage { get; private set; }

        private IColorSprite _colorSprite;

        private readonly IControllableTimer _controllableTimer = new ControllableTimer();

        private Coroutine _hitCoroutine;
        private ICancellationTokenService _cancellationTokenService;
        private UniTask _drawSpriteTask;

        [Inject]
        private void Construct(IColorSprite colorSprite, ICancellationTokenService cancellationTokenService)
        {
            _cancellationTokenService = cancellationTokenService;
            _colorSprite = colorSprite;
        }

        public async UniTask RenderHit()
        {
            await _colorSprite.DrawSprite(sprite,
                presenter.enemyTreeConfig.EnemyTreeViewConfig.CoolDownColoringHit,
                _controllableTimer, () => IsPaintedDamage = true, _cancellationTokenService.GetCancellationToken());
        }
    }
}