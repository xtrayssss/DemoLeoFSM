using Cysharp.Threading.Tasks;
using GameLogic.Services.Drawers;
using GameLogic.Skeletons.SkeletonMVP.View;
using GameLogic.UnityComponents.Presenters;
using Infrastructure.Services.CancellationToken;
using Infrastructure.Services.Timer;
using UnityEngine;
using Zenject;

namespace GameLogic.UnityComponents.Views
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