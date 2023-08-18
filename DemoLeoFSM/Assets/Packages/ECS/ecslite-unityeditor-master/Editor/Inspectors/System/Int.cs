// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using Leopotam.EcsLite.UnityEditor.Packages.ECS.Runtime;
using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Packages.ECS.Editor.Inspectors.System {
    sealed class IntInspector : EcsComponentInspectorTyped<int> {
        public override bool OnGuiTyped (string label, ref int value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.IntField (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}