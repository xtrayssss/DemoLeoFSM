using UnityEngine;

namespace GameLogic.Configs.Weapons.Swords
{
    [CreateAssetMenu(fileName = "newSwordViewData", menuName = "Data/Weapon/Sword/View")]
    public class SwordViewConfig : ConfigView
    {
        [SerializeField] private AnimationData emptyAnimation;

        [SerializeField] private AnimationData attackAnimation;

        #region Properties

        public AnimationData EmptyAnimation => emptyAnimation;

        public AnimationData AttackAnimation => attackAnimation;

        #endregion
    }
}