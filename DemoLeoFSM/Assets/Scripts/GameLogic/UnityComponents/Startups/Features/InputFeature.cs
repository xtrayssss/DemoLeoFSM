using GameLogic.Services.Input;
using GameLogic.Systems.Input;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class InputFeature : BaseEcsFeature
    {
        private readonly IInputService _inputService;

        public InputFeature(IInputService inputService) =>
            _inputService = inputService;

        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems.Add(new HeroInputSystem(_inputService));
    }
}