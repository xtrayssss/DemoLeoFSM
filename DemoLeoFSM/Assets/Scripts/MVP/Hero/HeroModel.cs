using MVP.Base.Model;
using UnityComponents.Configs.Hero;

namespace MVP.Hero
{
    public class HeroModel : AbstractModel<HeroView>
    {
        private readonly HeroConfig _heroConfig;
        
        public HeroModel(HeroView view, HeroConfig heroConfig) : base(view) => 
            _heroConfig = heroConfig;
    }
}