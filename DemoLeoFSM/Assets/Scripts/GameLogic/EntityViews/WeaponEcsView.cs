using Leopotam.EcsLite;

namespace GameLogic.EntityViews
{
    public class WeaponEntityView : EntityView
    {
        public override int Entity { get; protected set; }
        
        public override EcsWorld World { get; protected set; }
    }
}