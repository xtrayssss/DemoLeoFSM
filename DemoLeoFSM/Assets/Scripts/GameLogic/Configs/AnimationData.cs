﻿using System;
using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs
{
    [Serializable]
    public class AnimationData
    {
        [SerializeField] [Required] private AnimationClip animationClip;
        [SerializeField, ReadOnly] private string nameAnimation;
        [SerializeField, ReadOnly] private int hashAnimation;
        [SerializeField, ReadOnly] private float durationAnimation;
        public AnimationClip AnimationClip => animationClip;
        public string NameAnimation => nameAnimation;
        public int HashAnimation => hashAnimation;
        public float DurationAnimation => durationAnimation;

        public void UpdateAnimationData(string name, int hash, float duration)
        {
            nameAnimation = name;
            hashAnimation = hash;
            durationAnimation = duration;
        }
    }
}