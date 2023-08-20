using System;
using TNRD.Packages.Runtime;
using UnityComponents.Presenters;

namespace UnityComponents
{
    [Serializable]
    public struct RendererHit
    {
        public SerializableInterface<IHitRenderer> value;
    }
}