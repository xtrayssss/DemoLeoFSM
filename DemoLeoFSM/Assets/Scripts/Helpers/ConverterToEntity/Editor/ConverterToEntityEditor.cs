using UnityEditor;
using UnityEngine;

namespace Helpers.ConverterToEntity.Editor
{
    [CustomEditor(typeof(ConverterToEntity))]
    public class ConverterToEntityEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("GetComponents"))
            {
                ConverterToEntity converterToEntity = (ConverterToEntity) target;
                
                converterToEntity.converters = converterToEntity.GetComponents<BaseConverterComponent>();
                
                EditorUtility.SetDirty(target);
            }
        }
    }
}