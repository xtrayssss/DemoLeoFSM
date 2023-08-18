using Cinemachine;
using UnityComponents.Configs.Detection;
using UnityEngine;

namespace UnityComponents.Configs.Hero
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Data/Hero/Hero")]
    public class HeroConfig : ScriptableObject
    {
        [Header("General")] [SerializeField] private GameObject heroPrefab;

        [Header("Stats")] [SerializeField, Range(1, 300)]
        private float movementSpeed = 50;

        [SerializeField, Range(1, 100)] private float health = 50;
        [SerializeField, Range(0, 1000)] private float jumpVelocity = 400;
        [SerializeField, Range(-2000, 0)] private float jumpGravity = -400;

        [Header("View")] [SerializeField] private HeroViewConfig heroViewConfig;

        [Header("CoyoteTime")] [SerializeField]
        private float moveToIdleCoyoteTime;

        [Header("FollowCamera")] [SerializeField]
        private CinemachineVirtualCamera camera;

        [Header("Detection")] [SerializeField]
        private DetectionConfig groundDetectionConfig;

        #region Properties

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