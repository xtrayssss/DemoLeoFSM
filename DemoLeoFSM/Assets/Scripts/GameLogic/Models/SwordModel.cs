using GameLogic.Skeletons.SkeletonMVP.Model;
using GameLogic.UnityComponents.Views;

namespace GameLogic.Models
{
    class SwordModel : AbstractModel<SwordView>
    {
        public SwordModel(SwordView view) : base(view)
        {
        }
    }
}