// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using Leopotam.EcsLite.UnityEditor.Packages.ECS.Runtime;
using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Packages.ECS.Editor.Inspectors.System {
    sealed class DoubleInspector : EcsComponentInspectorTyped<double> {
        public override bool OnGuiTyped (string label, ref double value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.DoubleField (label, value);
            if (global::System.Math.Abs (newValue - value) < double.Epsilon) { return false; }
            value = newValue;
            return true;
        }
    }
}