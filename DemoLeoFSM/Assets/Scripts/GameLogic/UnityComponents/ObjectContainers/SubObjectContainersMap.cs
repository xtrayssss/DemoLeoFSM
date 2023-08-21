using System;
using Helpers.Serializators.SerializableDictionary;
using UnityEngine;

namespace GameLogic.UnityComponents.ObjectContainers
{
    [Serializable]
    public class SubObjectContainersMap : SerializableDictionary<ObjectContainerTypeId, Transform> {}
}