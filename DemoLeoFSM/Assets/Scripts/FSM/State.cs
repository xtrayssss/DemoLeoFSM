using Leopotam.EcsLite;
using UnityComponents.Views;

namespace FSM
{
    public class State
    {
        protected readonly int Entity;
        protected readonly EcsWorld World;

        protected State(EntityView entityView)
        {
            World = entityView.World;
            Entity = entityView.Entity;
        }

        public virtual void Enter() => 
            Setup();

        public virtual void Exit() => 
            Cleanup();

        public virtual void LogicUpdate()
        {
        }

        protected virtual void Cleanup()
        {
        }

        protected virtual void Setup()
        {
        }
    }
}