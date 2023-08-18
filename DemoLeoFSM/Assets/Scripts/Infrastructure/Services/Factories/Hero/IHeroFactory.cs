using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;

namespace Infrastructure.Services.Factories.Hero
{
    internal interface IHeroFactory
    {
        public GameObject CreateHero(IEcsSystems system);
    }
}