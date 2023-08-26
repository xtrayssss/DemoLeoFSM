using GameLogic.Components;
using GameLogic.Components.Requests.Self;
using Leopotam.EcsLite;

namespace GameLogic.Systems
{
    internal class ColorSpriteInHurt : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<RendererHit> _renderersHit;
        private EcsPool<TakingDamageAnalysisSelfRequest> _analyzeRequests;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _filter = _defaultWorld.Filter<TakingDamageAnalysisSelfRequest>().Inc<RendererHit>().End();
            _renderersHit = _defaultWorld.GetPool<RendererHit>();
            _analyzeRequests = _defaultWorld.GetPool<TakingDamageAnalysisSelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                //_renderersHit.Get(entity).value.Value.RenderHit();
       
                _analyzeRequests.Del(entity);
            }
        }
    }
}