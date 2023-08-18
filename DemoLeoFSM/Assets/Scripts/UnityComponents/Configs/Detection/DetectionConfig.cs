using UnityEngine;

namespace UnityComponents.Configs.Detection
{
    [CreateAssetMenu(fileName = "OverlapCircleData", menuName = "Data/OverlapCircle")]
    public class DetectionConfig : ScriptableObject, IStorageSpawnPosition
    {
        [Header("General")] [SerializeField] private GameObject startPointPrefab;
        [field: SerializeField] public Vector2 SpawnPosition { get; set; }

        [Header("Stats")] [SerializeField, Range(0, 5)]
        private float radius = 0.08f;

        [SerializeField, Range(0, 5)] private float coolDownDetection = 0.2f;
        [SerializeField, Range(0, 10)] private int hitSize = 1;
        [SerializeField] private LayerMask mask;

        #region Prpoperties

        public GameObject StartPointPrefab => startPointPrefab;
        public int HitSize => hitSize;
        public float CoolDownDetection => coolDownDetection;
        public LayerMask Mask => mask;
        public float Radius => radius;

        #endregion
    }
}