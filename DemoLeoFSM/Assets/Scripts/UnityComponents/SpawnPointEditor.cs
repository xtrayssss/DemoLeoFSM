#if UNITY_EDITOR
using Common;
using UnityEngine;

namespace UnityComponents
{
    [ExecuteInEditMode]
    public class SpawnPointEditor<TConfig> : MonoBehaviour where TConfig : Object, IStorageSpawnPosition
    {
        private Transform[] _childTransforms;

        private void Start() =>
            _childTransforms = GetComponentsInChildren<Transform>(true);

        private void Update()
        {
            foreach (Transform childTransform in _childTransforms)
            {
                GameObject childObject = childTransform.gameObject;

                if (!childObject.CompareTag(Tags.SpawnPositionTag)) continue;
                
                TConfig[] configs = Resources.LoadAll<TConfig>(AssetPaths.DataPath);

                foreach (TConfig config in configs)
                {
                    config.SpawnPosition = childObject.transform.position;
                    UnityEditor.EditorUtility.SetDirty(config);
                }
            }
        }
    }
}

#endif