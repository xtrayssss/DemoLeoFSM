using UnityEngine;

namespace UnityComponents.Configs.Enemies
{
    [CreateAssetMenu(fileName = "newTreeViewConfig", menuName = "Data/Enemies/Tree/View")]
    public class EnemyTreeViewConfig : ScriptableObject
    {
        [SerializeField] private float coolDownColoringHit;

        [Header("Animations")]
        [SerializeField] private AnimationData idleAnimationData;
        [SerializeField] private AnimationData moveAnimationData;
        [SerializeField] private AnimationData attackAnimationData;
        [SerializeField] private AnimationData preparationJumpAnimationData;
        [SerializeField] private AnimationData jumpAnimationData;
        [SerializeField] private AnimationData fallAnimationData;
        [SerializeField] private AnimationData introductionAnimationData;
        [SerializeField] private AnimationData camouflageAnimationData;

        #region Properties

        public float CoolDownColoringHit => coolDownColoringHit;
        public AnimationData IntroductionAnimationData => introductionAnimationData;
        public AnimationData IdleAnimationData => idleAnimationData;

        public AnimationData MoveAnimationData => moveAnimationData;
        public AnimationData AttackAnimationData => attackAnimationData;

        public AnimationData PreparationJumpAnimationData => preparationJumpAnimationData;

        public AnimationData JumpAnimationData => jumpAnimationData;

        public AnimationData FallAnimationData => fallAnimationData;
        public AnimationData CamouflageAnimationData => camouflageAnimationData;

        #endregion
    }
}