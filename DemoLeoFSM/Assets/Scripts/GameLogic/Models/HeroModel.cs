using GameLogic.Configs.Hero;
using GameLogic.Skeletons.SkeletonMVP.Model;
using GameLogic.UnityComponents.Views;

namespace GameLogic.Models
{
    public class HeroModel : AbstractModel<HeroView>
    {
        private readonly HeroConfig _heroConfig;
        
        public HeroModel(HeroView view, HeroConfig heroConfig) : base(view) => 
            _heroConfig = heroConfig;
    }
}