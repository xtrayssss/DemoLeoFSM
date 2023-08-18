using Components.Performs;
using UnityComponents.Views;
using UnityEngine;

namespace UnityComponents
{
    internal class DetectorIntersection : MonoBehaviour
    {
        [SerializeField] private EntityView entityView;
        
        public void DetectIntersection() => 
            entityView.World.GetPool<PerformDetection>().Add(entityView.Entity);
    }
}