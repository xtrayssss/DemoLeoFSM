using Common;
using Components;
using Components.Owners;
using Components.Transition;
using Leopotam.EcsLite;

namespace Systems.StateMachine
{
    internal class CheckConditionTransitionsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _statesWorld;
        private EcsFilter _filter;
        private EcsPool<ConditionTransition> _conditionsTransition;
        private EcsPool<OwnerComponent> _owners;
        private EcsPool<TargetState> _targetStates;
        private EcsPool<SwitchStateSelfRequest> _switchStateSelfRequest;

        public void Init(IEcsSystems systems)
        {
            _statesWorld = systems.GetWorld(WorldsNames.StatesWorldName);

            _filter = _statesWorld.Filter<ConditionTransition>().Inc<OwnerComponent>().Inc<FromState>().Inc<ActiveMarker>().End();

            _conditionsTransition = _statesWorld.GetPool<ConditionTransition>();
            _owners = _statesWorld.GetPool<OwnerComponent>();
            _targetStates = _statesWorld.GetPool<TargetState>();
            _switchStateSelfRequest = _statesWorld.GetPool<SwitchStateSelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var conditionTransition = ref _conditionsTransition.Get(entity);
                ref var targetState = ref _targetStates.Get(entity);
                ref var ownerComponent = ref _owners.Get(entity);

                if (!CheckConditionTransition(conditionTransition) || !TryUnpack(ownerComponent, out int ownerEntity))
                    continue;

                _switchStateSelfRequest.Add(ownerEntity).TargetState = targetState.Value;
            }
        }

        private bool TryUnpack(OwnerComponent ownerComponent, out int ownerEntity) =>
            ownerComponent.Value.Unpack(out _, out ownerEntity);

        private bool CheckConditionTransition(ConditionTransition conditionTransition) =>
            conditionTransition.Value();
    }
}