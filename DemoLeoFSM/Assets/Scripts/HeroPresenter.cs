using System;
using System.Collections.Generic;
using Components;
using Components.EngineComponents;
using Components.Grounds;
using FSM;
using Infrastructure.Services.Data;
using Infrastructure.Services.Factories.Requests.Velocity;
using Infrastructure.Services.Factories.Transition;
using Infrastructure.Services.Input;
using Infrastructure.Services.Timer;
using Leopotam.EcsLite;
using MVP.Base.Presenter;
using MVP.Hero;
using UnityComponents.Configs.Hero;
using UnityComponents.States.Hero;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

public class HeroPresenter : AbstractMonobehaviourPresenter<HeroView, HeroModel>
{
    [SerializeField] private HeroEntityView heroEntityView;

    private IInputService _inputService;
    private IObservableTimerService _observableTimerService;
    private IStaticDataService _staticDataService;
    private HeroConfig _heroConfig;
    private IVelocityRequestsFactory _velocityRequestsFactory;
    private ITransitionFactory _transitionFactory;
    private IWorldService _worldService;
    private IStateMachineFactory _stateMachineFactory;

    [Inject]
    private void Construct(IStaticDataService staticDataService,
        IVelocityRequestsFactory velocityRequestsFactory, IInputService inputService,
        ITransitionFactory transitionFactory, IWorldService worldService, IStateMachineFactory stateMachineFactory,
        IObservableTimerService observableTimerService)
    {
        _stateMachineFactory = stateMachineFactory;
        _worldService = worldService;
        _transitionFactory = transitionFactory;
        _velocityRequestsFactory = velocityRequestsFactory;
        _staticDataService = staticDataService;
        _inputService = inputService;
        _observableTimerService = observableTimerService;
    }

    private void Start()
    {
        _heroConfig = _staticDataService.GetHeroData();
        Model = new HeroModel(view, _heroConfig);

        HeroIdleState heroIdleState = new HeroIdleState(heroEntityView,
            _heroConfig.HeroViewConfig.IdleAnimation, view);

        HeroMoveState heroMoveState = new HeroMoveState(heroEntityView,
            _heroConfig.HeroViewConfig.MoveAnimation, view,
            _inputService, _velocityRequestsFactory,
            _heroConfig.MoveToIdleCoyoteTime, _worldService);

        HeroJumpState heroJumpState = new HeroJumpState(heroEntityView,
            _heroConfig.HeroViewConfig.JumpAnimation, view,
            _velocityRequestsFactory, _worldService);

        HeroJumpPreparationState heroJumpPreparationState = new HeroJumpPreparationState(heroEntityView,
            _heroConfig.HeroViewConfig.JumpPreparationAnimation, view,
            _observableTimerService);

        HeroFallState heroFallState = new HeroFallState(heroEntityView,
            _heroConfig.HeroViewConfig.FallingAnimation, view, _velocityRequestsFactory, _worldService);

        HeroLandState heroLandState = new HeroLandState(heroEntityView,
            _heroConfig.HeroViewConfig.LandingAnimation, view,
            _observableTimerService);

        int stateMachineEntity = _stateMachineFactory.CreateStateMachine(_worldService.StatesWorld, heroIdleState);

        ref var packTransitions = ref _worldService.StatesWorld.GetPool<PackTransitions>().Get(stateMachineEntity);

        _transitionFactory.CreateGroupTransition(_worldService.StatesWorld, heroFallState,
            () => !IsGrounded() && IsFall(), new HashSet<State>
            {
                heroIdleState, heroMoveState, heroJumpPreparationState, heroJumpState
            }, stateMachineEntity);

        packTransitions.Value.Add(heroIdleState, new[]
        {
            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroIdleState, heroMoveState,
                IsMove, stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroIdleState,
                heroJumpPreparationState,
                () => IsJump() && IsGrounded(), stateMachineEntity)
        });

        packTransitions.Value.Add(heroMoveState, new[]
        {
            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroMoveState, heroIdleState,
                () => heroMoveState.CoyoteTimer.IsDone, stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroMoveState, heroJumpState,
                () => IsJump() && IsGrounded(), stateMachineEntity)
        });

        packTransitions.Value.Add(heroJumpPreparationState, new[]
        {
            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroJumpPreparationState, heroJumpState,
                () => IsMove() || heroJumpPreparationState.IsAnimationComplete, stateMachineEntity)
        });

        packTransitions.Value.Add(heroJumpState, new[]
        {
            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroJumpState, heroMoveState,
                () => IsGrounded() && IsFall() && IsMove(), stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroJumpState, heroLandState,
                () => IsGrounded() && IsFall() && !IsMove(), stateMachineEntity)
        });

        packTransitions.Value.Add(heroFallState, new[]
        {
            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroFallState, heroLandState,
                () => IsGrounded() && !IsMove(), stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroFallState, heroMoveState,
                () => IsGrounded() && IsMove(), stateMachineEntity)
        });

        packTransitions.Value.Add(heroLandState, new[]
        {
            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroLandState, heroIdleState,
                () => !IsMove() && !IsJump() && heroLandState.IsAnimationComplete, stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroLandState, heroMoveState,
                () => IsMove() && !IsJump(), stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroLandState, heroJumpPreparationState,
                () => !IsMove() && IsJump() && heroLandState.IsAnimationComplete, stateMachineEntity),

            _transitionFactory.CreateTransition(_worldService.StatesWorld, heroLandState, heroJumpState,
                () => IsMove() && IsJump(), stateMachineEntity)
        });
    }

    private bool IsFall() =>
        _worldService.DefaultWorld.GetPool<RigidbodyComponent>().Get(heroEntityView.Entity).value.velocity.y <
        0.0f;

    private bool IsJump() =>
        _inputService.IsJump;

    private bool IsGrounded() =>
        _worldService.DefaultWorld.GetPool<Grounded>().Get(heroEntityView.Entity).value;

    private void OnDestroy() =>
        ((IDisposable) _observableTimerService).Dispose();

    private bool IsMove()
    {
        return _inputService.MovementDirection.x != 0.0f;
    }
}

public interface IWorldService
{
    public EcsWorld DefaultWorld { get; }
    public EcsWorld EventsWorld { get; }
    public EcsWorld StatesWorld { get; }
    
    public void Init(EcsWorld defaultWorld, EcsWorld eventsWorld, EcsWorld transitionWorld);
}

internal class WorldService : IWorldService
{
    public EcsWorld DefaultWorld { get; private set; }
    public EcsWorld EventsWorld { get; private set; }
    public EcsWorld StatesWorld { get; private set; }

    public void Init(EcsWorld defaultWorld, EcsWorld eventsWorld, EcsWorld transitionsWorld)
    {
        DefaultWorld = defaultWorld;
        EventsWorld = eventsWorld;
        StatesWorld = transitionsWorld;
    }
}