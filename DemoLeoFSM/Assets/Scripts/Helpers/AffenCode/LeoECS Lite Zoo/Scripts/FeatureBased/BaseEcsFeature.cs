using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    public abstract class BaseEcsFeature
    {
        public virtual void AddUpdateSystems(IEcsSystems systems)
        {
        }

        public virtual void AddInitSystems(IEcsSystems systems)
        {
        }

        public virtual void AddLateUpdateSystems(IEcsSystems systems)
        {
        }

        public virtual void AddFixedUpdateSystems(IEcsSystems systems)
        {
        }

        public virtual void AddFixedUpdateOneFrames(IEcsSystems systems)
        {
        }

        public virtual void AddUpdateOneFrames(IEcsSystems systems)
        {
        }

        public virtual void AddLateUpdateOneFrames(IEcsSystems systems)
        {
        }
    }
}