using System.IO;
using TNRD.Packages.Editor.Utilities;
using TNRD.Packages.Runtime;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace TNRD.Packages.Editor.Items
{
    internal sealed class AssetDropdownItem : AdvancedDropdownItem, IDropdownItem
    {
        private readonly string path;

        /// <inheritdoc />
        public AssetDropdownItem(string path)
            : base(Path.GetFileNameWithoutExtension(path))
        {
            this.path = path;
            icon = IconUtility.GetIconForObject(path);
        }

        /// <inheritdoc />
        ReferenceMode IDropdownItem.Mode => ReferenceMode.Unity;

        /// <inheritdoc />
        object IDropdownItem.GetValue()
        {
            return AssetDatabase.LoadAssetAtPath<Object>(path);
        }
    }
}
