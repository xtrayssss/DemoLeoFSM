using GameLogic.Configs.Enemies;
using UnityEngine;

namespace GameLogic.UnityComponents
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [field: SerializeField] public EnemyTypeId EnemyTypeId { get; private set; }
    }
}