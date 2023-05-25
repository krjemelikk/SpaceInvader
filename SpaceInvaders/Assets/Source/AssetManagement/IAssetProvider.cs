using UnityEngine;

namespace Source.AssetManagement
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : Object;
    }
}