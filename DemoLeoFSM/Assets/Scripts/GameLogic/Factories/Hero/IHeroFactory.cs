using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Hero
{
    internal interface IHeroFactory
    {
        public GameObject CreateHero(IEcsSystems system);
    }
}