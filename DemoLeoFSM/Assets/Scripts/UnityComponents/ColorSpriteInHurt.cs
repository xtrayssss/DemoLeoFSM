using Components.Requests.Self;
using Leopotam.EcsLite;

namespace UnityComponents
{
    internal class ColorSpriteInHurt : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<RendererHit> _renderersHit;
        private EcsPool<AnalyzeTakeDamageSelfRequest> _analyzeRequests;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _filter = _defaultWorld.Filter<AnalyzeTakeDamageSelfRequest>().Inc<RendererHit>().End();
            _renderersHit = _defaultWorld.GetPool<RendererHit>();
            _analyzeRequests = _defaultWorld.GetPool<AnalyzeTakeDamageSelfRequest>();
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