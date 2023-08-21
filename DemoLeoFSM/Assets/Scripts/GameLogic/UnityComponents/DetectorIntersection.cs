using GameLogic.Components.Performs;
using GameLogic.EntityViews;
using UnityEngine;

namespace GameLogic.UnityComponents
{
    internal class DetectorIntersection : MonoBehaviour
    {
        [SerializeField] private EntityView entityView;
        
        public void DetectIntersection() => 
            entityView.World.GetPool<PerformDetection>().Add(entityView.Entity);
    }
}