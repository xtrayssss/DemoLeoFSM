using UnityEngine;

namespace UnityComponents.ObjectContainers
{
    public class SceneObjectContainer : MonoBehaviour
    {
        [SerializeField] private SubObjectContainersMap subObjectContainersMap;
        public SubObjectContainersMap SubObjectContainersMap => subObjectContainersMap;
    }
}