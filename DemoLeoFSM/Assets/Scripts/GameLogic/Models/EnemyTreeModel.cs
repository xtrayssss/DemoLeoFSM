using GameLogic.Skeletons.SkeletonMVP.Model;
using GameLogic.UnityComponents.Views;

namespace GameLogic.Models
{
    public class EnemyTreeModel : AbstractModel<EnemyTreeView>
    {
        public EnemyTreeModel(EnemyTreeView view) : base(view)
        {
        }
    }
}