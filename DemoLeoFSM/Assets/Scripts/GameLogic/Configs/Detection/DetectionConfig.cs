using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Detection
{
    [CreateAssetMenu(fileName = "OverlapCircleData", menuName = "Data/OverlapCircle")]
    public class DetectionConfig : ScriptableObject, IStorageSpawnPosition
    {
        [BoxGroup("General")] [SerializeField] private GameObject startPointPrefab;
        [field: SerializeField] public Vector2 SpawnPosition { get; set; }

        [BoxGroup("Stats")] [SerializeField] [Range(0, 5)]
        private float radius = 0.08f;

        [BoxGroup("Stats")] [SerializeField] [Range(0, 5)]
        private float coolDownDetection = 0.2f;

        [BoxGroup("Stats")] [SerializeField] [Range(0, 10)]
        private int hitSize = 1;

        [BoxGroup("Stats")] [SerializeField] private LayerMask mask;

        #region Other

        public GameObject StartPointPrefab => startPointPrefab;
        public int HitSize => hitSize;
        public float CoolDownDetection => coolDownDetection;
        public LayerMask Mask => mask;
        public float Radius => radius;

        #endregion
    }
}