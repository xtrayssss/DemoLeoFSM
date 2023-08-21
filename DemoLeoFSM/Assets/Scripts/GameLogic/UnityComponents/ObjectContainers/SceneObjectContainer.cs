using UnityEngine;

namespace GameLogic.UnityComponents.ObjectContainers
{
    public class SceneObjectContainer : MonoBehaviour
    {
        [SerializeField] private SubObjectContainersMap subObjectContainersMap;
        public SubObjectContainersMap SubObjectContainersMap => subObjectContainersMap;
    }
}