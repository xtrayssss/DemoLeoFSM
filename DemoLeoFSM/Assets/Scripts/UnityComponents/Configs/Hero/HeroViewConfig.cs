using UnityComponents.Configs.Weapons.Swords;
using UnityEngine;

namespace UnityComponents.Configs.Hero
{
    [CreateAssetMenu(fileName = "HeroViewData", menuName = "Data/Hero/View")]
    public class HeroViewConfig : ConfigView
    {
        [Header("Effects")] [SerializeField] private GameObject dustEffect;

        [Header("Animations")] [SerializeField]
        private AnimationData idleAnimation;

        [SerializeField] private AnimationData moveAnimation;
        [SerializeField] private AnimationData jumpPreparationAnimation;
        [SerializeField] private AnimationData jumpAnimation;
        [SerializeField] private AnimationData landingAnimation;
        [SerializeField] private AnimationData fallingAnimation;

        #region Properties

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