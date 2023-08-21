using GameLogic.Components;
using GameLogic.Configs.Weapons;
using GameLogic.Configs.Weapons.Swords;
using GameLogic.EntityViews;
using GameLogic.Factories.Transition;
using GameLogic.Models;
using GameLogic.Services.Data;
using GameLogic.Services.Input;
using GameLogic.Skeletons.SkeletonMVP.Presenter;
using GameLogic.States.Sword;
using GameLogic.UnityComponents.Views;
using Infrastructure.Services;
using Infrastructure.Services.Timer;
using UnityEngine;
using Zenject;

namespace GameLogic.UnityComponents.Presenters
{
    internal class SwordPresenter : AbstractMonobehaviourPresenter<SwordView, SwordModel>
    {
        [SerializeField] private WeaponEntityView weaponEntityView;
        [SerializeField] private WeaponTypeId weaponTypeId;

        private IInputService _inputService;
        private IObservableTimerService _observableTimerService;
        private IStaticDataService _staticDataService;
        private ITransitionFactory _transitionFactory;
        private IWorldService _worldService;
        private IStateMachineFactory _stateMachineFactory;

        [Inject]
        private void Construct(IStaticDataService staticDataService, IInputService inputService,
            ITransitionFactory transitionFactory, IWorldService worldService, IStateMachineFactory stateMachineFactory,
            IObservableTimerService observableTimerService)
        {
            _stateMachineFactory = stateMachineFactory;
            _worldService = worldService;
            _transitionFactory = transitionFactory;
            _staticDataService = staticDataService;
            _inputService = inputService;
            _observableTimerService = observableTimerService;
        }

        private void Start()
        {
            SwordConfig swordConfig = _staticDataService.GetWeaponData<SwordConfig>(weaponTypeId);

            SwordEmptyState swordEmptyState =
                new SwordEmptyState(weaponEntityView, swordConfig.SwordViewConfig.EmptyAnimation, view);
            
            SwordAttackState swordAttackState = new SwordAttackState(weaponEntityView,
                swordConfig.SwordViewConfig.AttackAnimation, view, _observableTimerService);

            int stateMachineEntity =
                _stateMachineFactory.CreateStateMachine(_worldService.StatesWorld, swordEmptyState);

            ref var packTransitions = ref _worldService.StatesWorld.GetPool<PackTransitions>().Get(stateMachineEntity);

            packTransitions.Value.Add(swordEmptyState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, swordEmptyState, swordAttackState,
                    IsAttack, stateMachineEntity),
            });

            packTransitions.Value.Add(swordAttackState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, swordAttackState, swordEmptyState,
                    () => swordAttackState.IsAnimationComplete, stateMachineEntity),
            });
        }

        private bool IsAttack() =>
            _inputService.IsMeleeAttack;
    }
}