using Common;
using GameLogic.Components.Owners;
using GameLogic.Components.Transition;
using Leopotam.EcsLite;

namespace GameLogic.Systems.StateMachine
{
    internal class CheckConditionGroupTransitionsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _statesWorldName;
        private EcsFilter _filter;
        private EcsPool<ConditionTransition> _conditionsTransition;
        private EcsPool<OwnerComponent> _owners;
        private EcsPool<CurrentState> _currentStates;
        private EcsPool<TargetState> _targetStates;
        private EcsPool<SwitchStateSelfRequest> _switchStateSelfRequest;
        private EcsPool<GroupStates> _groupsStates;

        public void Init(IEcsSystems systems)
        {
            _statesWorldName = systems.GetWorld(WorldsNames.StatesWorldName);

            _filter = _statesWorldName.Filter<ConditionTransition>().Inc<OwnerComponent>().Inc<GroupStates>().End();

            _conditionsTransition = _statesWorldName.GetPool<ConditionTransition>();
            _owners = _statesWorldName.GetPool<OwnerComponent>();
            _currentStates = _statesWorldName.GetPool<CurrentState>();
            _switchStateSelfRequest = _statesWorldName.GetPool<SwitchStateSelfRequest>();
            _groupsStates = _statesWorldName.GetPool<GroupStates>();
            _targetStates = _statesWorldName.GetPool<TargetState>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var conditionTransition = ref _conditionsTransition.Get(entity);
                ref var groupStates = ref _groupsStates.Get(entity);
                ref var ownerComponent = ref _owners.Get(entity);
                ref var targetState = ref _targetStates.Get(entity);

                if (TryUnpack(ownerComponent, out int ownerEntity))
                {
                    if (CheckConditionTransition(conditionTransition, groupStates, ownerEntity))
                    {
                        _switchStateSelfRequest.Add(ownerEntity).TargetState = targetState.Value;
                    }
                }
            }
        }

        private bool TryUnpack(OwnerComponent ownerComponent, out int ownerEntity) =>
            ownerComponent.Value.Unpack(out _, out ownerEntity);

        private bool CheckConditionTransition(ConditionTransition conditionTransition, GroupStates groupStates,
            int ownerEntity) =>
            groupStates.Value.Contains(_currentStates.Get(ownerEntity).Value) && conditionTransition.Value();
    }
}