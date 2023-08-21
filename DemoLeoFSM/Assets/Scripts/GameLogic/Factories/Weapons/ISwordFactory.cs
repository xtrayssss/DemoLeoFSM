using GameLogic.Configs.Weapons;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Weapons
{
    internal interface ISwordFactory
    {
        public void CreateSword(IEcsSystems system, WeaponTypeId weaponTypeId,
            Vector2 position, Transform parent);
    }
}