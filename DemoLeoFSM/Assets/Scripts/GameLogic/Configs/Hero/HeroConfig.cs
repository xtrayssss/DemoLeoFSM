using Cinemachine;
using GameLogic.Configs.Detection;
using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Hero
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Data/Hero/Hero")]
    public class HeroConfig : ScriptableObject
    {
        [BoxGroup("General")] [SerializeField] [Required]
        private GameObject heroPrefab;

        [BoxGroup("General")] [SerializeField] public Vector2 spawnPosition;

        [BoxGroup("Stats")] [SerializeField, Range(1, 300)]
        private float movementSpeed = 50;

        [BoxGroup("Stats")] [SerializeField] [Range(1, 100)] [OnValueChanged(nameof(UpdateValueHealthBar))]
        private float health = 50;

        [BoxGroup("Stats")] [SerializeField] [ProgressBar("Health", 100, EColor.Green)]
        private float healthBar;

        [BoxGroup("Stats")] [SerializeField] [Range(0, 1000)]
        private float jumpVelocity = 400;

        [BoxGroup("Stats")] [SerializeField] [Range(-2000, 0)]
        private float jumpGravity = -400;

        [BoxGroup("View")] [SerializeField] [Expandable] [Required]
        private HeroViewConfig heroViewConfig;

        [BoxGroup("CoyoteTimes")] [SerializeField] [MinValue(0.0f), MaxValue(1.0f)]
        private float moveToIdleCoyoteTime;

        [BoxGroup("FollowCamera")] [SerializeField] [Required]
        private CinemachineVirtualCamera camera;

        [BoxGroup("Detections")] [SerializeField] [Expandable] [Required]
        private DetectionConfig groundDetectionConfig;

        #region Other

        public void UpdateValueHealthBar() =>
            healthBar = health;

        public DetectionConfig GroundDetectionConfig => groundDetectionConfig;
        public float MovementSpeed => movementSpeed;

        public GameObject HeroPrefab => heroPrefab;
        public float Health => health;
        public float JumpVelocity => jumpVelocity;
        public float JumpGravity => jumpGravity;

        public CinemachineVirtualCamera Camera => camera;
        public HeroViewConfig HeroViewConfig => heroViewConfig;
        public float MoveToIdleCoyoteTime => moveToIdleCoyoteTime;

        #endregion
    }
}