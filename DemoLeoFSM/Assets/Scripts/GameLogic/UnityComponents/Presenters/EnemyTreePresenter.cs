using System.Collections.Generic;
using GameLogic.Components;
using GameLogic.Configs.Enemies;
using GameLogic.EntityViews;
using GameLogic.Factories.Requests.Velocity;
using GameLogic.Factories.Transition;
using GameLogic.Models;
using GameLogic.Services.Data;
using GameLogic.Skeletons.SkeletonFSM;
using GameLogic.Skeletons.SkeletonMVP.Presenter;
using GameLogic.States.Enemies.Tree;
using GameLogic.UnityComponents.Views;
using Infrastructure.Services;
using Infrastructure.Services.Timer;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace GameLogic.UnityComponents.Presenters
{
    public class EnemyTreePresenter : AbstractMonobehaviourPresenter<EnemyTreeView, EnemyTreeModel>
    {
        [SerializeField] private EnemyEntityView enemyEntityView;
        [SerializeField] private Collider2D aggroZone;
        [SerializeField] private Collider2D introductionZone;
        [SerializeField] private Collider2D attackZone;

        private IObservableTimerService _observableTimerService;
        private IStaticDataService _staticDataService;
        private IVelocityRequestsFactory _velocityRequestsFactory;
        private ITransitionFactory _transitionFactory;
        private IWorldService _worldService;
        private IStateMachineFactory _stateMachineFactory;

        private bool _isFollow;
        private bool _isIntroduction;
        private bool _isAttack;
        public EnemyTreeConfig enemyTreeConfig;

        [Inject]
        private void Construct(IStaticDataService staticDataService,
            IVelocityRequestsFactory velocityRequestsFactory,
            ITransitionFactory transitionFactory, IWorldService worldService, IStateMachineFactory stateMachineFactory,
            IObservableTimerService observableTimerService)
        {
            _stateMachineFactory = stateMachineFactory;
            _worldService = worldService;
            _transitionFactory = transitionFactory;
            _velocityRequestsFactory = velocityRequestsFactory;
            _staticDataService = staticDataService;
            _observableTimerService = observableTimerService;
        }

        private void Start()
        {
            enemyTreeConfig = _staticDataService.GetEnemyData<EnemyTreeConfig>(EnemyTypeId.Tree);

            TreeCamouflageState treeCamouflageState = new TreeCamouflageState(enemyEntityView,
                enemyTreeConfig.EnemyTreeViewConfig.CamouflageAnimationData, view);

            TreeIntroductionState treeIntroductionState = new TreeIntroductionState(enemyEntityView,
                enemyTreeConfig.EnemyTreeViewConfig.IntroductionAnimationData, view, _observableTimerService);

            TreeIdleState treeIdleState = new TreeIdleState(enemyEntityView,
                enemyTreeConfig.EnemyTreeViewConfig.IdleAnimationData, view);

            TreeMoveState treeMoveState = new TreeMoveState(enemyEntityView,
                enemyTreeConfig.EnemyTreeViewConfig.MoveAnimationData, view, _worldService, _velocityRequestsFactory);

            TreeAttackState treeAttackState = new TreeAttackState(enemyEntityView,
                enemyTreeConfig.EnemyTreeViewConfig.AttackAnimationData, view, _observableTimerService);

            TreeDeathState treeDeathState = new TreeDeathState(enemyEntityView,
                enemyTreeConfig.EnemyTreeViewConfig.AttackAnimationData, view);

            int stateMachineEntity =
                _stateMachineFactory.CreateStateMachine(_worldService.StatesWorld, treeCamouflageState);

            ref var packTransitions = ref _worldService.StatesWorld.GetPool<PackTransitions>().Get(stateMachineEntity);

            aggroZone.OnTriggerEnter2DAsObservable().Subscribe(other => _isFollow = true);
            aggroZone.OnTriggerExit2DAsObservable().Subscribe(other => _isFollow = false);

            introductionZone.OnTriggerEnter2DAsObservable().Subscribe(other => _isIntroduction = true);
            introductionZone.OnTriggerExit2DAsObservable().Subscribe(other => _isIntroduction = false);

            attackZone.OnTriggerEnter2DAsObservable().Subscribe(other => _isAttack = true);
            attackZone.OnTriggerExit2DAsObservable().Subscribe(other => _isAttack = false);
            
            _transitionFactory.CreateGroupTransition(_worldService.StatesWorld, treeDeathState,
                () => IsDeath() && view.IsPaintedDamage, new HashSet<State>
                {
                    treeCamouflageState,
                    treeIntroductionState,
                    treeMoveState,
                    treeIdleState,
                    treeAttackState,
                }, stateMachineEntity);

            packTransitions.Value.Add(treeCamouflageState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeCamouflageState,
                    treeIntroductionState, () => _isIntroduction, stateMachineEntity)
            });

            packTransitions.Value.Add(treeIntroductionState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeIntroductionState,
                    treeIdleState, () => !_isFollow && !_isAttack && treeIntroductionState.IsAnimationComplete,
                    stateMachineEntity),

                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeIntroductionState,
                    treeMoveState, () => _isFollow && !_isAttack && treeIntroductionState.IsAnimationComplete,
                    stateMachineEntity),

                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeIntroductionState,
                    treeAttackState, () => _isAttack && treeIntroductionState.IsAnimationComplete,
                    stateMachineEntity),
            });

            packTransitions.Value.Add(treeMoveState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeMoveState,
                    treeIdleState, () => !_isFollow && !_isAttack, stateMachineEntity),

                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeMoveState,
                    treeAttackState, () => _isAttack, stateMachineEntity)
            });

            packTransitions.Value.Add(treeIdleState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeIdleState,
                    treeMoveState, () => _isFollow && !_isAttack, stateMachineEntity),

                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeIdleState,
                    treeAttackState, () => _isAttack, stateMachineEntity)
            });

            packTransitions.Value.Add(treeAttackState, new[]
            {
                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeAttackState,
                    treeMoveState, () => _isFollow && !_isAttack && treeAttackState.IsAnimationComplete,
                    stateMachineEntity),

                _transitionFactory.CreateTransition(_worldService.StatesWorld, treeAttackState,
                    treeIdleState, () => !_isFollow && !_isAttack && treeAttackState.IsAnimationComplete,
                    stateMachineEntity)
            });
        }

        private bool IsDeath() => 
            _worldService.DefaultWorld.GetPool<DeathMarker>().Has(enemyEntityView.Entity);
    }
}