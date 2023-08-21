using GameLogic.Configs.Weapons.Swords;
using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Hero
{
    [CreateAssetMenu(fileName = "HeroViewData", menuName = "Data/Hero/View")]
    public class HeroViewConfig : ConfigView
    {
        [BoxGroup("Effects")] [SerializeField] private GameObject dustEffect;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData idleAnimation;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData moveAnimation;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData jumpPreparationAnimation;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData jumpAnimation;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData landingAnimation;

        [BoxGroup("Animations")] [SerializeField] [AllowNesting]
        private AnimationData fallingAnimation;

        #region Other

        public AnimationData IdleAnimation => idleAnimation;
        public AnimationData MoveAnimation => moveAnimation;
        public AnimationData JumpPreparationAnimation => jumpPreparationAnimation;
        public AnimationData JumpAnimation => jumpAnimation;
        public AnimationData LandingAnimation => landingAnimation;
        public AnimationData FallingAnimation => fallingAnimation;
        public GameObject DustEffect => dustEffect;

        #endregion
    }
}