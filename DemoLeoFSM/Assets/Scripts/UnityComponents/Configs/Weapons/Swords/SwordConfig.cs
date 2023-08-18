using UnityEngine;

namespace UnityComponents.Configs.Weapons.Swords
{
    [CreateAssetMenu(fileName = "newSwordData", menuName = "Data/Weapon/Sword/Sword")]
    public class SwordConfig : WeaponConfig
    {
        [SerializeField] private SwordViewConfig swordViewConfig;

        #region Properties

        public SwordViewConfig SwordViewConfig => swordViewConfig;

        #endregion
    }
}