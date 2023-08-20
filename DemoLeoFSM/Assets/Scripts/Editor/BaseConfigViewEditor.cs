using System;
using System.Reflection;
using UnityComponents.Configs;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public abstract class BaseConfigViewEditor<T> : UnityEditor.Editor where T : class
    {
        private const string FloatTipText =
            "Click on the \"Generate Animations Data\" button if you have changed something in any animation";

        private const string TipText = "Tip";

        private GUIStyle _headerStyle;
        private int _animationIndex;

        private void Awake() =>
            _headerStyle = new GUIStyle(EditorStyles.boldLabel) {alignment = TextAnchor.MiddleCenter, fontSize = 12};

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField(
                new GUIContent(TipText, FloatTipText), _headerStyle);

            GUILayout.Space(5);

            base.OnInspectorGUI();

            if (GUILayout.Button("GenerateAnimationsData"))
            {
                T viewConfig = target as T;

                Type viewConfigType = typeof(T);

                FieldInfo[] fields =
                    viewConfigType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo fieldInfo in fields)
                {
                    if (!(fieldInfo.GetValue(viewConfig) is AnimationData animationData)) continue;

                    animationData.UpdateAnimationData(animationData.AnimationClip.name,
                        StringToHash(animationData.AnimationClip.name), animationData.AnimationClip.length);
                }
            }

            SetSpace(5);

            EditorUtility.SetDirty(target);
        }

        private int StringToHash(string animationName) =>
            Animator.StringToHash(animationName);

        private void SetSpace(int pixels) =>
            GUILayout.Space(pixels);
    }
}