using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Injection
{
    public abstract class GlobalMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            LeoEcsLiteInjector.AddInjection(this);
            Globals.Globals.Add(this);
        }

        protected virtual void OnDestroy()
        {
            LeoEcsLiteInjector.RemoveInjection(this);
            Globals.Globals.Remove(this);
        }
    }
}