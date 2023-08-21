using Leopotam.EcsLite;

namespace GameLogic.EntityViews
{
    public class HeroEntityView : EntityView
    {
        public override int Entity { get; protected set; }
        
        public override EcsWorld World { get; protected set; }
    }
}