﻿using UnityEngine;

namespace GameLogic.EntityViews
{
    public abstract class EntityEcsView : MonoBehaviour
    {
        public abstract int Entity { get; protected set; }
        public void Init(int entity) => 
            Entity = entity;
    }
}