namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Conversion
{
    public enum CollectMode
    {
        OnlyThisGameObject,
        IncludeChildren
    }
    
    public enum ConvertMode
    {
        ConvertAndInject,
        ConvertAndDestroy
    }
    
    public enum ConvertTime
    {
        Start,
        EndOfFrame
    }
}