﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace Drawers
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool previousGUIState = GUI.enabled;

            GUI.enabled = false;

            EditorGUI.PropertyField(position, property, label);

            GUI.enabled = previousGUIState;
        }
    }
}

#endif