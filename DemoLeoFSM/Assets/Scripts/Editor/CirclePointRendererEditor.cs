using UnityComponents;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CirclePoint))]
    public class CirclePointRendererEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawSpawnPoint(CirclePoint point, GizmoType gizmo)
        {
            if (!point.IsActive) return;
            
            Gizmos.color = point.Color;

            Gizmos.DrawSphere(point.transform.position, point.Radius);
        }
    }
}