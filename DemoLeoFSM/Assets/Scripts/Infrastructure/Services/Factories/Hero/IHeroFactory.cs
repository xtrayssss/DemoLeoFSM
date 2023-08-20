using Leopotam.EcsLite;
using UnityEngine;

namespace Infrastructure.Services.Factories.Hero
{
    internal interface IHeroFactory
    {
        public GameObject CreateHero(IEcsSystems system);
    }
}