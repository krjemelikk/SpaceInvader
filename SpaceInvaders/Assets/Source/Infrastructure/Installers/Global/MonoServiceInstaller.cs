using Source.AssetManagement;
using Source.Infrastructure.Services;
using Zenject;

namespace Source.Infrastructure.Installers.Global
{
    public class MonoServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            CoroutineRunner();

            LoadingScreen();
        }

        private void CoroutineRunner()
        {
            Container
                .BindInterfacesTo<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunner)
                .AsSingle();
        }

        private void LoadingScreen()
        {
            Container
                .BindInterfacesTo<LoadingScreen>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.LoadingScreen)
                .AsSingle();
        }
    }
}