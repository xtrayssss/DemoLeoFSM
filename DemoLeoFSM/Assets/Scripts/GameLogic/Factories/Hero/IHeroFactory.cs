using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Hero
{
    public interface IHeroFactory
    {
        public GameObject CreateHero(IEcsSystems system);
    }
}