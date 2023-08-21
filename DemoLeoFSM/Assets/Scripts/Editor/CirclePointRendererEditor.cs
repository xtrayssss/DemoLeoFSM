using Helpers.Drawers;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(DrawerCirclePoint))]
    public class CirclePointRendererEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawSpawnPoint(DrawerCirclePoint point, GizmoType gizmo)
        {
            if (!point.IsActive) return;
            
            Gizmos.color = point.Color;

            Gizmos.DrawSphere(point.transform.position, point.Radius);
        }
    }
}