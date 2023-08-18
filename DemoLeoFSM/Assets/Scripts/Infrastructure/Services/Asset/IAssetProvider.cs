using UnityEngine;

namespace Infrastructure.Services.Asset
{
    internal interface IAssetProvider
    {
        public T Load<T>(string path) where T : Object;
        public T[] LoadAll<T>(string dataLevels) where T : Object;
    }
}