// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using Leopotam.EcsLite.UnityEditor.Packages.ECS.Runtime;
using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Packages.ECS.Editor.Inspectors.System {
    sealed class StringInspector : EcsComponentInspectorTyped<string> {
        public override bool IsNullAllowed () {
            return true;
        }

        public override bool OnGuiTyped (string label, ref string value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.TextField (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}