using Leopotam.EcsLite;

namespace Infrastructure.Services
{
    public class WorldService : IWorldService
    {
        public EcsWorld DefaultWorld { get; private set; }
        public EcsWorld EventsWorld { get; private set; }
        public EcsWorld StatesWorld { get; private set; }

        public void Init(EcsWorld defaultWorld, EcsWorld eventsWorld, EcsWorld transitionsWorld)
        {
            DefaultWorld = defaultWorld;
            EventsWorld = eventsWorld;
            StatesWorld = transitionsWorld;
        }
    }
}