using UnityEngine;

namespace Helpers.Drawers
{
    public class DrawerCirclePoint : MonoBehaviour
    {
        [field: SerializeField] public bool IsActive { get; private set; }
        [field: SerializeField] public float Radius { get; private set;}
        [field: SerializeField] public Color Color { get;  private set;}
    }
}