using UnityEngine;

namespace UnityComponents
{
    public class CirclePoint : MonoBehaviour
    {
        [field: SerializeField] public bool IsActive { get; private set; }
        [field: SerializeField] public float Radius { get; private set;}
        [field: SerializeField] public Color Color { get;  private set;}
    }
}