using UnityEngine;

namespace UnityComponents.Configs.Weapons
{
    public class WeaponConfig : ScriptableObject
    {
        [Header("General")] [SerializeField] private GameObject prefabWeapon;
        [SerializeField] private WeaponTypeId weaponTypeId;

        [Header("Description")] [SerializeField]
        private string weaponName;

        [Header("Stats")] 
        [SerializeField, Range(1, 100)] private float damage = 5.0f;
        [SerializeField, Range(0, 20)] private float coolDown = 0.5f;
        [SerializeField, Range(0, 10)] private float rangeAttack = 0.3f;
        [SerializeField, Range(0, 10)] private int maxHitSize = 1;
        [SerializeField] private LayerMask hitLayer;
        
        #region Properties
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