using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Weapons.Swords
{
    [CreateAssetMenu(fileName = "newSwordData", menuName = "Data/Weapon/Sword/Sword")]
    public class SwordConfig : WeaponConfig
    {
        [BoxGroup("View")] [SerializeField] [Expandable] [Required]
        private SwordViewConfig swordViewConfig;

        #region Other

        public SwordViewConfig SwordViewConfig => swordViewConfig;

        #endregion
    }
}