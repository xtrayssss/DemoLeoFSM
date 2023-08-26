using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Injection
{
    public abstract class InjectableMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            LeoEcsLiteInjector.AddInjection(this);
        }

        protected virtual  void OnDestroy()
        {
            LeoEcsLiteInjector.RemoveInjection(this);
        }
    }
}