using Leopotam.EcsLite;

namespace UnityComponents.Views
{
    public class EnemyEntityView : EntityView
    {
        public override int Entity { get; protected set; }
        public override EcsWorld World { get; protected set; }
    }
}