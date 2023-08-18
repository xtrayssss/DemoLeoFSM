using System;
using Packages.Assets.SerializableDictionary;
using UnityEngine;

namespace UnityComponents.ObjectContainers
{
    [Serializable]
    public class SubObjectContainersMap : SerializableDictionary<ObjectContainerTypeId, Transform> {}
}