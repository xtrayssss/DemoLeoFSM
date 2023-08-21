using Cysharp.Threading.Tasks;

namespace GameLogic
{
    public interface IHitRenderer
    {
        public UniTask RenderHit();
    }
}