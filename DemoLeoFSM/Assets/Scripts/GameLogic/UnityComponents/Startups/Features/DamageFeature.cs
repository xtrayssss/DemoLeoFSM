using GameLogic.Systems;
using GameLogic.Systems.Damage;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class DamageFeature : BaseEcsFeature
    {
        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new MakeDamageSystem())
                .Add(new ColorSpriteInHurt());
    }
}