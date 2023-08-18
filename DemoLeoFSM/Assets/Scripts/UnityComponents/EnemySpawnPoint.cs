using UnityComponents.Configs.Enemies;
using UnityEngine;

namespace UnityComponents
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [field: SerializeField] public EnemyTypeId EnemyTypeId { get; private set; }
    }
}