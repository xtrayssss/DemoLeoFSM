using Leopotam.EcsLite;

namespace UnityComponents.Views
{
    public class HeroEntityView : EntityView
    {
        public override int Entity { get; protected set; }
        
        public override EcsWorld World { get; protected set; }
    }
}