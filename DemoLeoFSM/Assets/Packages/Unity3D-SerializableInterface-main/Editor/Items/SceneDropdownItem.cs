using TNRD.Packages.Editor.Utilities;
using TNRD.Packages.Runtime;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace TNRD.Packages.Editor.Items
{
    internal sealed class SceneDropdownItem : AdvancedDropdownItem, IDropdownItem
    {
        private readonly Object component;

        /// <inheritdoc />
        public SceneDropdownItem(Component component)
            : base(component.GetType().Name)
        {
            this.component = component;
            icon = IconUtility.GetIconForObject(component) ?? IconUtility.ScriptIcon;
        }

        /// <inheritdoc />
        ReferenceMode IDropdownItem.Mode => ReferenceMode.Unity;

        /// <inheritdoc />
        object IDropdownItem.GetValue()
        {
            return component;
        }
    }
}
