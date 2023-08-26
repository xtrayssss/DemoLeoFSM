using GameLogic.Systems.StateMachine;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class StateMachineFeature : BaseEcsFeature
    {
        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new CheckConditionGroupTransitionsSystem())
                .Add(new CheckConditionTransitionsSystem())
                .Add(new ChangeCurrentStateSystem())
                .Add(new CleanupTransitionsActivitySystem())
                .Add(new SetupTransitionsActivitySystem())
                .Add(new UpdateCurrentStateSystem());
    }
}