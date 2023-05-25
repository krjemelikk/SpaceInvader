using Source.AssetManagement;
using Source.Infrastructure.Services;
using Source.Infrastructure.Services.Input;
using Source.Infrastructure.Services.Random;
using Source.Infrastructure.Services.StaticData;
using Zenject;

namespace Source.Infrastructure.Installers.Global
{
    public class GlobalServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RandomService();

            AssetProvider();

            StaticData();

            InputService();

            SceneLoader();
        }

        private void RandomService() =>
            Container.BindInterfacesTo<RandomService>().AsSingle();

        private void AssetProvider() =>
            Container.BindInterfacesTo<AssetProvider>().AsSingle();

        private void StaticData() =>
            Container.BindInterfacesTo<StaticDataService>().AsSingle();

        private void InputService() =>
            Container.BindInterfacesTo<InputService>().AsSingle();

        private void SceneLoader() =>
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
    }
}