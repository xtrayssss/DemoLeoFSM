using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Enemies
{
    [CreateAssetMenu(fileName = "newTreeViewConfig", menuName = "Data/Enemies/Tree/View")]
    public class EnemyTreeViewConfig : ScriptableObject
    {
        [BoxGroup("CoolDowns")] [SerializeField] [MinValue(0.1f), MaxValue(3.0f)]
        private float coolDownColoringHit = 0.1f;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData idleAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData moveAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData attackAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData preparationJumpAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData jumpAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData fallAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData introductionAnimationData;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData camouflageAnimationData;

        #region Other

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