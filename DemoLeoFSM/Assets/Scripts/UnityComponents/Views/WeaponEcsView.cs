﻿using Leopotam.EcsLite.Packages.ECS.src;

namespace UnityComponents.Views
{
    public class WeaponEntityView : EntityView
    {
        public override int Entity { get; protected set; }
        
        public override EcsWorld World { get; protected set; }
    }
}