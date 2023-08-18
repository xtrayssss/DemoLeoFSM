// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using Leopotam.EcsLite.UnityEditor.Packages.ECS.Runtime;
using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Packages.ECS.Editor.Inspectors.Unity {
    sealed class ColorInspector : EcsComponentInspectorTyped<Color> {
        public override bool OnGuiTyped (string label, ref Color value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.ColorField (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}