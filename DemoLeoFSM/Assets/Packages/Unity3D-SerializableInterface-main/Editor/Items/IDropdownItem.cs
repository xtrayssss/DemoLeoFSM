using TNRD.Packages.Runtime;

namespace TNRD.Packages.Editor.Items
{
    internal interface IDropdownItem
    {
        internal ReferenceMode Mode { get; }
        object GetValue();
    }
}
