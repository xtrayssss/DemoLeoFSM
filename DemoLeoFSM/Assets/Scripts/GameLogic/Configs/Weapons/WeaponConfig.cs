using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Weapons
{
    public class WeaponConfig : ScriptableObject
    {
        [BoxGroup("General")] [SerializeField] [Required]
        private GameObject prefabWeapon;

        [BoxGroup("General")] [SerializeField] private WeaponTypeId weaponTypeId;

        [BoxGroup("Description")] [SerializeField] [ResizableTextArea]
        private string weaponName;

        [BoxGroup("Stats")] [SerializeField] [Range(1, 100)]
        private float damage = 5.0f;

        [BoxGroup("Stats")] [SerializeField] [Range(0, 20)]
        private float coolDown = 0.5f;

        [BoxGroup("Stats")] [SerializeField] [Range(0, 10)]
        private float rangeAttack = 0.3f;

        [BoxGroup("Stats")] [SerializeField] [Range(0, 10)]
        private int maxHitSize = 1;

        [BoxGroup("Stats")] [SerializeField] private LayerMask hitLayer;

        #region Other

        public float RangeAttack => rangeAttack;

        public int MAXHitSize => maxHitSize;

        public LayerMask HitLayer => hitLayer;

        public float CoolDown => coolDown;
        public GameObject PrefabWeapon => prefabWeapon;
        public WeaponTypeId WeaponTypeId => weaponTypeId;
        public string WeaponName => weaponName;
        public float Damage => damage;

        #endregion
    }
}