using TNRD.Packages.Runtime;
using UnityEditor.IMGUI.Controls;

namespace TNRD.Packages.Editor.Items
{
    public class NoneDropdownItem : AdvancedDropdownItem, IDropdownItem
    {
        public NoneDropdownItem()
            : base("None")
        {
        }

        ReferenceMode IDropdownItem.Mode => ReferenceMode.Raw;

        public object GetValue()
        {
            return null;
        }
    }
}
