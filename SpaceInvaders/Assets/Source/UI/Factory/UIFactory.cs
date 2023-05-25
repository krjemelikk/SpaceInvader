using Source.AssetManagement;
using UnityEngine;
using Zenject;

namespace Source.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        private Transform _uiRoot;

        public UIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public void CreateUIRoot()
        {
            var prefab = _assetProvider.Load<GameObject>(AssetPath.UIRoot);
            var instance = _instantiator.InstantiatePrefab(prefab);
            _uiRoot = instance.transform;
        }

        public void CreateHUD()
        {
            var prefab = _assetProvider.Load<GameObject>(AssetPath.HUD);
            var instance = _instantiator.InstantiatePrefab(prefab, _uiRoot);
        }
    }
}