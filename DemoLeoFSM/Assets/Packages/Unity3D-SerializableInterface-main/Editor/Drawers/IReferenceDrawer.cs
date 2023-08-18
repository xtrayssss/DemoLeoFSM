using UnityEngine;

namespace TNRD.Packages.Editor.Drawers
{
    internal interface IReferenceDrawer
    {
        float GetHeight();
        void OnGUI(Rect position);
    }
}
