using UnityEngine;

namespace Packages.ECS.src
{
    [DisallowMultipleComponent]
    public class ComponentsContainer : MonoBehaviour
    {
        [SerializeField] private BaseConverter[] _converters;
        [SerializeField] private bool _destroyAfterConversion;
        public BaseConverter[] Converters => _converters;
        public bool DestroyAfterConversion => _destroyAfterConversion;

        internal void GetConverters()
        {
            _converters = GetComponents<BaseConverter>();
        }
    }
}