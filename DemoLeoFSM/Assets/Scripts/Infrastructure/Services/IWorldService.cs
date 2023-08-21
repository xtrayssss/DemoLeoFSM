using Leopotam.EcsLite;

namespace Infrastructure.Services
{
    public interface IWorldService
    {
        public EcsWorld DefaultWorld { get; }
        public EcsWorld EventsWorld { get; }
        public EcsWorld StatesWorld { get; }
    
        public void Init(EcsWorld defaultWorld, EcsWorld eventsWorld, EcsWorld transitionWorld);
    }
}