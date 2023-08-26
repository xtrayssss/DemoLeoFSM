using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Injection
{
    public sealed class Inject : MonoBehaviour
    {
        [SerializeField] private Component Component;
            
        private void Awake()
        {
            LeoEcsLiteInjector.AddInjection(Component);
        }

        private void OnDestroy()
        {
            LeoEcsLiteInjector.RemoveInjection(Component);
        }
        
        private void Reset()
        {
            Component = gameObject.GetComponent<MonoBehaviour>();
        }
    }
}